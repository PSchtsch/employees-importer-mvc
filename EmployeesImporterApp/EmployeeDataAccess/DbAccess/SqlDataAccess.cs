using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;

    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<T>> LoadDataAsync<T, U>(
        string storedProcedureName,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection =
            new SqlConnection(_configuration.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(
            storedProcedureName,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async ValueTask<int> SaveDataAsync<T>(
        string storedProcedureName,
        T parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection =
            new SqlConnection(_configuration.GetConnectionString(connectionId));

        return await connection.ExecuteAsync(
            storedProcedureName,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async ValueTask<int> SaveDataSetAsync<T>(
        string storedProcedureName,
        IEnumerable<T> dataSet,
        string udtParameterName,
        string udtTypeName,
        string connectionId = "Default") where T : class
    {
        var dataTable = dataSet.ToDataTable();
        var parameters = new DynamicParameters();
        parameters.Add(udtParameterName, dataTable.AsTableValuedParameter(udtTypeName));

        using IDbConnection connection =
            new SqlConnection(_configuration.GetConnectionString(connectionId));

        return await connection.ExecuteAsync(
            storedProcedureName,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
