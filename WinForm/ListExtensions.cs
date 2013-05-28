using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace WinForm
{
    public static class ListExtensions
    {
        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            var properties = list.GetPropertiesOfObjectInList();
            var resultTable = CreateTable(properties);

            foreach (var row in list.Select(item => CreateRowFromItem(resultTable, item)))
            {
                resultTable.Rows.Add(row);
            }

            return resultTable;
        }

        private static DataTable CreateTable(IEnumerable<PropertyInfo> properties)
        {
            var resultTable = new DataTable();
            foreach (var property in properties)
            {
                resultTable.Columns.Add(property.Name, property.PropertyType);
            }
            return resultTable;
        }

        public static IList<PropertyInfo> GetPropertiesOfObjectInList<T>(this IList<T> list)
        {
            return typeof(T).GetProperties().ToList();
        }

        private static DataRow CreateRowFromItem<T>(DataTable resultTable, T item)
        {
            var row = resultTable.NewRow();
            var properties = item.GetType().GetProperties().ToList();
            foreach (var property in properties)
            {
                row[property.Name] = property.GetValue(item, null);
            }
            return row;
        }
    }
}
