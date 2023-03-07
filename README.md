# MMIS-Server
Server from MMIS-Chat

1. Для запуска проекта нужно установить программы:
1.1 SQL SERVER
https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads

1.2 Microsoft SQL Server Management Studio
https://learn.microsoft.com/ru-Ru/sql/ssms/download-sql-server-management-studio-ssms?view=azure-sqldw-latest


2. В SQL Server Management Studio создать базу данных "Data"
2.1 Создать в ней таблицы members, messages, sessions.
SQL Запрос для этого представлен ниже:

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='members' AND xtype='U') CREATE TABLE members( id int IDENTITY(1,1) NOT NULL, first_name VARCHAR(1000) NOT NULL, last_name VARCHAR(1000) NOT NULL, age INT NOT NULL, member_login VARCHAR(1000) UNIQUE NOT NULL, member_password VARCHAR(1000) NOT NULL ) 

go

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='messages' AND xtype='U') CREATE TABLE messages( id int IDENTITY(1,1) NOT NULL, member_id INT NOT NULL, date_time VARCHAR(1000) NOT NULL, content VARCHAR(1000) NOT NULL )

go

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='sessions' AND xtype='U') CREATE TABLE sessions( id int IDENTITY(1,1) NOT NULL, uuid VARCHAR(1000) NOT NULL, date_deactivation VARCHAR(1000) NOT NULL, member_id INT NOT NULL )

go

3. Скачать код этого проекта, и установить пакеты NuGet:
    3.1 Newtonsoft.Json
    3.2 System.Data.SqlClient

4. В Program.cs заменить переменную ip на свой локальный ip компьютера
5. В DataBase.cs заменить идентификатор подключения к базе данных на свой, который вы получите при создании базы данных "Data"

15:> SqlConnection sqlConnection = new SqlConnection(@"Data Source=ЗДЕСЬ ДОЛЖЕН БЫТЬ ВАШ ИДЕНТИФИКАТОР;Initial Catalog=Data;Integrated Security=True;");

Готово!

Так же можете посмотреть видео на YouTube о том как запустить этот проект по ссылке:

