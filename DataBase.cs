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
        const string nameSqlServer = "_ИМЯ_ВАШЕГО_СЕРВЕРА_ПРИ_ВХОДЕ_В_Microsoft_SQL_Server_Management_Studio_18_";
        const string nameDataBase = "_ИМЯ_ВАШЕЙ_БАЗЫ_ДАННЫХ_КОТОРОЕ_ВЫ_УКАЗЫВАЛИ_ПРИ_СОЗДАНИИ_";

        //Объект соединения с базой данных
        SqlConnection sqlConnection = new SqlConnection($@"Data Source={nameSqlServer};Initial Catalog={nameDataBase};Integrated Security=True;");


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
