using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_ChatMMIS
{
    internal class DataBase
    {

        //Объект соединения с базой данных
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-9OM3ILD;Initial Catalog=Data;Integrated Security=True;");


        ////Открывает соединение с базой данных ( ЗАВЕРШЕНО ✓ )
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            };

        }

        ////Закрывает соединение с базой данных ( ЗАВЕРШЕНО ✓ )
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            };
        }

        //Возвращает объект соединения с базой данных ( ЗАВЕРШЕНО ✓ )
        public SqlConnection getConncection()
        {
            return sqlConnection;
        }

    }
}
