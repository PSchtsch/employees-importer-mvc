namespace EmployeeDataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedureName, U parameters, string connectionId = "Default");
    ValueTask<int> SaveDataAsync<T>(string storedProcedureName, T parameters, string connectionId = "Default");
    ValueTask<int> SaveDataSetAsync<T>(string storedProcedureName, IEnumerable<T> dataSet, string udtParameterName, string udtTypeName, string connectionId = "Default") where T : class;
}