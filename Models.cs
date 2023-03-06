using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace Server_ChatMMIS
{

    internal class Models
    {

        public class Member // ( ЗАВЕРШЕНО-ПРОТЕСТИРОВАТЬ ☓ )
        {
            //Объекты для получения данных
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableMember = new DataTable();
            DataTable tableSession = new DataTable();
            DataBase db = new DataBase();

            //Данные пользователя, id = -1 если пользователя не существует
            public int id = -1;
            public string? firstName;
            public string? lastName;
            public int? age;
            public string? uuid;
            public bool session = false;
            public string? login;
            public string? password;


            //Поиск пользователя по id, возвращает его объект ( ЗАВЕРШЕНО ✓ )
            public Member getId()
            {
                string query = $"SELECT id, first_name, last_name, age FROM members WHERE id={id}";
                SqlCommand command = new SqlCommand(query, db.getConncection());
                adapter.SelectCommand = command;
                tableMember.Clear();
                adapter.Fill(tableMember);
                fillData();
                return this;
            }


            //Поиск пользователя по логину и паролю, возвращает его объект если пара найдена ( ЗАВЕРШЕНО ✓ )
            public Member getAuth()
            {
                tableMember.Clear();
                string query = $"SELECT id, first_name, last_name, age FROM members WHERE member_login = '{login}' AND member_password = '{password}'";
                SqlCommand command = new SqlCommand(query, db.getConncection());
                adapter.SelectCommand = command;
                adapter.Fill(tableMember);
                fillData();
                createSession();
                return this;
            }


            //Создание сессии пользователя
            public Member createSession()
            {
                if (id != -1)
                {
                    db.openConnection();
                    string dateDeactivation = Convert.ToString(DateTime.Now.AddDays(1));
                    uuid = Guid.NewGuid().ToString();
                    string query = $"INSERT INTO sessions(uuid, date_deactivation, member_id) VALUES('{uuid}', '{dateDeactivation}', {id})";
                    SqlCommand command = new SqlCommand(query, db.getConncection());
                    command.ExecuteNonQuery();
                }
                return this;
            }


            //Поиск сессии по uuid, возвращает его объект пользователя если сессия активна ( ЗАВЕРШЕНО ✓ )
            public Member isActiveSession()
            {
                db.openConnection();
                tableSession.Clear();
                string query = $"SELECT member_id, date_deactivation FROM sessions WHERE uuid='{uuid}'";
                SqlCommand command = new SqlCommand(query, db.getConncection());
                adapter.SelectCommand = command;
                adapter.Fill(tableSession);

                if (tableSession.Rows.Count > 0)
                {
                    id = Convert.ToInt32(tableSession.Rows[0][0]);
                    string sessionDateDeactivation = Convert.ToString(tableSession.Rows[0][1]);

                    DateTime presentTime = DateTime.Now;
                    DateTime timeDeactivation = DateTime.Parse(sessionDateDeactivation);

                    if (presentTime < timeDeactivation)
                    {
                        return getId();
                    }
                    return this;
                }
                return this;
            }


            //Конвертация в формат json типа string
            public string convertToJson()
            {
                string json = JsonConvert.SerializeObject(this);
                return json;
            }


            //Заполняет объект данными пользователя из таблицы ( ЗАВЕРШЕНО ✓ )
            void fillData()
            {
                if (tableMember.Rows.Count > 0)
                {
                    this.id = Convert.ToInt32(tableMember.Rows[0][0]);
                    this.firstName = Convert.ToString(tableMember.Rows[0][1]);
                    this.lastName = Convert.ToString(tableMember.Rows[0][2]);
                    this.age = Convert.ToInt32(tableMember.Rows[0][3]);
                }
            }


            public bool createAccount()
            {
                getAuth();
                if (id == -1)
                {
                    db.openConnection();
                    tableMember.Clear();
                    string query = $@"INSERT INTO members(first_name, last_name, age, member_login, member_password) VALUES(
                        '{firstName}', 
                        '{lastName}', 
                        {age}, 
                        '{login}', 
                        '{password}'
                    )";
                    SqlCommand command = new SqlCommand(query, db.getConncection());
                    //Запрос в бд и проверка успешен ли он
                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }

        }


        //( ЗАВЕРШЕНО-ПРОТЕСТИРОВАТЬ ☓ )
        public class Message
        {
            DataBase db = new DataBase();

            public Member member;
            public string dateTime;
            public string content;

            public bool createMessage()
            {
                if (member.id != -1)
                {
                    db.openConnection();
                    //Создание запроса
                    string query = $"INSERT INTO messages(member_id, date_time, content) values({member.id}, '{dateTime}', '{content}')";
                    SqlCommand command = new SqlCommand(query, db.getConncection());
                    //Запрос в бд и проверка успешен ли он
                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
                return false;
            }

        }


        //( ЗАВЕРШЕНО-ПРОТЕСТИРОВАТЬ ☓ )
        public class Messages
        {
            public Dictionary<int, Message> messages = new Dictionary<int, Message>();

            //Объекты для получения данных
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataBase db = new DataBase();


            //Добавляет сообщение в словарь этого класса
            public void addMessageToList(int id, Message message)
            {
                messages.Add(id, message);
            }


            //Конвертация списка сообщений в формат json типа string
            public string convertToJson()
            {
                string json = JsonConvert.SerializeObject(this);
                return json;
            }


            //Получение последних 15 сообщений из БД
            public Messages getLastMessages()
            {
                table.Clear();
                string query = $"SELECT TOP 15 * FROM messages ORDER BY id DESC";
                SqlCommand command = new SqlCommand(query, db.getConncection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                fillMessagesList(table);
                return this;
            }


            //Получение следующих 15 сообщений начиная id 
            public Messages getMessages(int id)
            {
                table.Clear();
                string query = $"SELECT TOP 15 * FROM messages WHERE id  > {id}";
                SqlCommand command = new SqlCommand(query, db.getConncection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                fillMessagesList(table);
                return this;
            }


            //Заполнение сообщений в лист сообщений объекта
            void fillMessagesList(System.Data.DataTable table)
            {
                foreach (DataRow row in table.Rows)
                {
                    Message message = new Message();
                    int messageId = Convert.ToInt32(row[0]);
                    message.member = new Member(); //Записываем данные каждого пользователя в каждое сообщение
                    message.member.id = Convert.ToInt32(row[1]);
                    message.member.getId();
                    message.dateTime = Convert.ToString(row[2]);
                    message.content = Convert.ToString(row[3]);
                    addMessageToList(messageId, message);
                }
            }

        }

    }
}
