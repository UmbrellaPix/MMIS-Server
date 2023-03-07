# MMIS-Server
Server from MMIS-Chat

## Установить Microsoft Visual Studio
'''
https://visualstudio.microsoft.com/ru/
'''

## Установить SQL SERVER

'''
https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads
'''

## Установить Microsoft SQL Server Management Studio

'''
https://learn.microsoft.com/ru-Ru/sql/ssms/download-sql-server-management-studio-ssms?view=azure-sqldw-latest
'''

## Подключиться к SQL Server Management Studio

## Кликнуть правой кнопкой мыши по названию папки "Databases"

<<<<<<< HEAD
## В выпавшем меню выбрать пункт "New Database..."

## Cоздать базу данных

'''
При создании базы запомните название которое вы вписали!
Оно потребуется позже.
'''
=======
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='members' AND xtype='U') CREATE TABLE members( id int IDENTITY(1,1) NOT NULL, first_name VARCHAR(1000) NOT NULL, last_name VARCHAR(1000) NOT NULL, age INT NOT NULL, member_login VARCHAR(1000) UNIQUE NOT NULL, member_password VARCHAR(1000) NOT NULL ) 

go

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='messages' AND xtype='U') CREATE TABLE messages( id int IDENTITY(1,1) NOT NULL, member_id INT NOT NULL, date_time VARCHAR(1000) NOT NULL, content VARCHAR(1000) NOT NULL )

go

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='sessions' AND xtype='U') CREATE TABLE sessions( id int IDENTITY(1,1) NOT NULL, uuid VARCHAR(1000) NOT NULL, date_deactivation VARCHAR(1000) NOT NULL, member_id INT NOT NULL )

go
>>>>>>> 86bff0fc241a66d2a0fe5e27a1036a63edd7aeec

## Сверху нажать на кнопку NewQuery

## В открывшееся поле вставить SQL запрос из файла SQLQueryДляСозданияТаблицВБазеДанных.sql

## Нажать Execute в том же месте где и была кнопка NewQuery

## В Microsoft Visual Studio создать пустой проект "Консольное приложение (Microsoft)"

## Файлы из репозитория вставить в созданный проект, файл Program.cs заменить на файл из репозитория

## Нажать сверху "Проект" и выбрать пункт "Управление пакетами NuGet..."

## Нажать "Обзор"

## Установить 2 пакета:

'''
Newtonsoft.Json
System.Data.SqlClient
'''

## Открыть cmd (Командная строка)

## В командной строке выполнить команду

"""
ipconfig
"""

## Скопировать ip из пункта IPv4-адрес 

## В файле Program.cs заменить значение переменной ip на скопированный адрес из прошлого пункта

## Открыть Sql Server Management Studio не подключаясь к серверу

## Скопировать текст из поля Server-name:

## В DataBase.cs заменить значение переменной "nameSqlServer" на скопированные данные из поля Server-name:

## В DataBase.cs заменить значение переменной "nameDataBase" на название базы данных которое вы указали при ее создании

'''
Название базы данных так же высвечивается при подключении к sql серверу в папке Databases с соответствующей иконкой
'''

## Готово!

## Позже будет залит ролик на YouTube как запустить этот проект. Спасибо за внимание!

