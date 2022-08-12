using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public abstract class ConnectionSQL
    {
        private readonly string connectionString;
        //readonly - constante de tempo de execução (runtime) - Não precisa ser inicializada na sua declaração
        //const - constante de tempo de compilação(compile-time)  
        public ConnectionSQL()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\paulo\Desktop\Studys\Sistema Desktop para Famarcia ZyX\DB\FarmaciaZyX1DB.mdf;Integrated Security=True;Connect Timeout=3";
            //connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\entra21\Desktop\Sistema Desktop para Famarcia ZyX\FarmaciaZyX1DB.mdf;Integrated Security=True;Connect Timeout=3";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
