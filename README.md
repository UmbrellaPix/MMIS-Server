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

## В выпавшем меню выбрать пункт "New Database..."

## Cоздать базу данных

'''
При создании базы запомните название которое вы вписали!
Оно потребуется позже.
'''

## Сверху нажать на кнопку NewQuery

## В открывшееся поле вставить SQL запрос из файла SQLQueryДляСозданияТаблицВБазеДанных.sql

## Нажать Execute в том же месте где и была кнопка NewQuery

## Открыть Microsoft Visual Studio !ОТ ИМЕНИ АДМИНИСТРАТОРА!

'''
Иначе при запуске сервера он выдаст ошибку, не знаю почему...
'''

## В Microsoft Visual Studio создать пустой проект "Консольное приложение (Microsoft)"

## Файлы из репозитория вставить в созданный проект, файл Program.cs заменить на файл из репозитория

## Нажать сверху "Проект" и выбрать пункт "Управление пакетами NuGet..."

## Нажать "Обзор"

## Установить 2 пакета:

'''
Newtonsoft.Json
'''

'''
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

## Видео инструкция установки сервера:
https://www.youtube.com/watch?v=wSg-n_H95cM&t=198s&ab_channel=%D0%90%D0%BB%D0%B5%D0%BA%D1%81%D0%B5%D0%B9%D0%97%D0%BE%D0%BD%D1%82%D0%BE%D0%B2

