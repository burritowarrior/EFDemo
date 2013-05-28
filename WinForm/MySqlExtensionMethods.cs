using System;
using System.Collections.Generic;
using System.Data;

namespace WinForm
{
    public static class MySqlExtensionMethods
    {
        private static Dictionary<Type, Func<object, object>> typeConverters;

        static MySqlExtensionMethods()
        {
            LoadTypeDictionary();
        }

        private static void LoadTypeDictionary()
        {
            typeConverters = new Dictionary<Type, Func<object, object>>
                             {
                                 {typeof (int), v => Convert.ToInt32(v)},
                                 {typeof (DateTime), v => Convert.ToDateTime(v)},
                                 {typeof (decimal), v => Convert.ToDecimal(v)},
                                 {typeof (double), v => Convert.ToDouble(v)},
                                 {typeof (bool), v => Convert.ToBoolean(v)},
                             };
        }

        // Added on 11-04-2012
        public static string SafeConvert(this IDataReader dataReader, int ordinal)
        {
            return dataReader.IsDBNull(ordinal) ? string.Empty : dataReader.GetString(ordinal);
        }

        public static T SafeConvertTo<T>(this IDataReader reader, int ordinalColumn)
        {
            if (typeConverters == null)
                LoadTypeDictionary();

            Type targetType = typeof(T);

            if (typeConverters != null)
                return reader.IsDBNull(ordinalColumn)
                           ? default(T)
                           : (T)typeConverters[targetType](reader[ordinalColumn]);

            return default(T);
        }
    }                                          
}
