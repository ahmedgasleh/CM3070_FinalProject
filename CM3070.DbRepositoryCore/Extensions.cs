using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbRepositoryCore
{
    public static class ExtensionMethods
    {
        public static SqlParameter SetSqlParameter ( string param, int size, bool isNullAble, object value, SqlDbType sqlDbType = SqlDbType.NVarChar )
        {
            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = param;
            sqlParameter.SqlDbType = sqlDbType;
            sqlParameter.Size = size;
            sqlParameter.IsNullable = isNullAble;
            sqlParameter.Value = value;

            return sqlParameter;
        }
        public static SqlParameter SetSqlParameter ( string param, bool isNullAble, object value, SqlDbType sqlDbType = SqlDbType.NVarChar )
        {
            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = param;
            sqlParameter.SqlDbType = sqlDbType;

            sqlParameter.IsNullable = isNullAble;
            sqlParameter.Value = value;

            return sqlParameter;

        }
        public static SqlParameter SetSqlOuputParameter ( string param, SqlDbType sqlDbType = SqlDbType.NVarChar )
        {
            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = param;
            sqlParameter.SqlDbType = sqlDbType;


            sqlParameter.Direction = ParameterDirection.Output;

            return sqlParameter;

        }
        /// <summary>
        /// ForEach: A for each iteration over a collection with action.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="act"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Each<T> ( this IEnumerable<T> source, Action<T> act )
        {
            foreach (T element in source) act(element);
            return source;
        }

        public static bool IsEmpty<T> ( this ICollection<T> possiblyNullCollection )
        {
            return possiblyNullCollection == null || possiblyNullCollection.Count == 0;
        }

        public static void AddRange<T> ( this ICollection<T> collection, IEnumerable<T> items )
        {
            foreach (var item in items)
                collection.Add(item);
        }

        public static void Add<T> ( this ICollection<T> collection, params T [] items )
        {
            foreach (var item in items)
                collection.Add(item);
        }

        ///<summary>
        ///	ToString: Telemed.Model.<see cref="ExtensionMethods"/>. apply this extension to any generic <c>IEnumerable</c> object.
        ///</summary>
        ///<param name="source"></param>
        ///<param name="separator"></param>
        ///<typeparam name="T"></typeparam>
        ///<returns></returns>
        ///<exception cref="ArgumentException"></exception>
        public static string ToString<T> ( this IEnumerable<T> source, string separator )
        {
            if (source == null)
                throw new ArgumentException("source can not be null.");
            if (string.IsNullOrEmpty(separator))
                throw new ArgumentException("separator can not be null or empty.");
            // A LINQ query to call ToString on each elements and constructs a string array.
            var array = (from s in source where s != null select s.ToString()).ToArray();
            // utilise builtin string.Join to concate elements with customizable separator.
            return string.Join(separator, array);
        }
    }
}
