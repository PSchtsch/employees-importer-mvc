using System.ComponentModel;
using System.Data;

namespace EmployeeDataAccess.DbAccess;

public static class IEnumerableExtensions
{
    public static DataTable ToDataTable<T>(this IEnumerable<T> collection) where T : class
    {
        DataTable dataTable = new();
        if (!collection.Any())
        {
            return dataTable;
        }

        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

        //add colums
        foreach (PropertyDescriptor property in properties)
        {
            dataTable.Columns.Add(
                property.Name,
                Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
        }

        //add rows
        foreach (var item in collection)
        {
            DataRow row = dataTable.NewRow();

            foreach (PropertyDescriptor property in properties)
            {
                row[property.Name] = property.GetValue(item) ?? DBNull.Value;
            }

            dataTable.Rows.Add(row);
        }

        return dataTable;
    }
}
