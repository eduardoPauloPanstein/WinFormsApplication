using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DbExecuter
    {
        //PASSAR PARA STATIC?
        internal static Response Execute(SqlCommand command)
        {
            DbConnection conn = new DbConnection();
            try
            {             
                conn.AttachCommand(command);
                conn.Open();
                command.ExecuteNonQuery();
                return new Response("Comando executado com sucesso", true);
            }
            finally
            {
                conn.Close();
            }
        }

        internal static int ExecuteScalar(SqlCommand command)
        {
            DbConnection conn = new DbConnection();
            try
            {
                conn.AttachCommand(command);
                conn.Open();
                int ID = Convert.ToInt32(command.ExecuteScalar());
                return ID;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataResponse<T> GetData<T>(SqlCommand command)
        {
            DbConnection conn = new DbConnection();

            try
            {
                conn.AttachCommand(command);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataResponse<T> response = new DataResponse<T>("Comando executado com sucesso", true, dt.ToTable<T>());
                return response;
            }
            finally
            {
                conn.Close();
            }
        }
        internal static SingleResponse<T> GetItem<T>(SqlCommand command)
        {
            DbConnection conn = new DbConnection();

            try
            {
                conn.AttachCommand(command);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse(dt.Rows[0].ToItem<T>());
            }
            finally
            {
                conn.Close();
            }
        }

    }


    internal static class SqlExtensions
    {
        public static List<T> ToTable<T>(this DataTable dt)
        {
            List<T> items = new List<T>();

            PropertyInfo[] propriedades = typeof(T).GetProperties();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow registro = dt.Rows[i];
                T t = Activator.CreateInstance<T>();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    propriedade.SetValue(t, dt.Rows[i][propriedade.Name]);
                }
                items.Add(t);
            }
            return items;
        }
        public static T ToItem<T>(this DataRow item)
        {
            PropertyInfo[] propriedades = typeof(T).GetProperties();
            T t = Activator.CreateInstance<T>();

            foreach (var prop in propriedades)
            {
                prop.SetValue(t, item[prop.Name]);
            }
            return t;
        }
    }

    internal class DbConnection : ConnectionSQL
    {
        private SqlConnection conn;

        public DbConnection()
        {
            conn = GetConnection();
        }

        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                //conn.BeginTransaction()//.Rollback
            }
        }

        public void Close()
        {
            conn.Dispose();
        }

        public void AttachCommand(SqlCommand command)
        {
            command.Connection = this.conn;
        }

    }
}
