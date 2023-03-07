using Server_ChatMMIS;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks.Dataflow;

//Настройки соединения с сервером
string ip = "__СЮДА_ВСТАВЬТЕ_ВАШ_ЛОКАЛЬНЫЙ_IP_";
string port = "2800";

//Создание объекта сервера
HttpListener server = new HttpListener();

//Создание объекта контроллеров
Controllers controllers = new Controllers();

// Установка API адресов
server.Prefixes.Add("http://" + ip + ":" + port + "/authorization/");
server.Prefixes.Add("http://" + ip + ":" + port + "/send/");
server.Prefixes.Add("http://" + ip + ":" + port + "/registration/");
server.Prefixes.Add("http://" + ip + ":" + port + "/read/");
server.Start();

while (true)
{
    try
    {
        // Получаем контекст и данные запроса
        var context = await server.GetContextAsync();
        var request = context.Request;
        string url = request.RawUrl.Trim('/');

        //Получаем объект для установки ответа
        var response = context.Response;
        response.AddHeader("Access-Control-Allow-Origin", "*");
        response.AddHeader("Access-Control-Allow-Headers", "*");
        response.AddHeader("Access-Control-Expose-Headers", "*");

        //Получаем заголовки запроса
        //Console.Clear();
        List<string> headers = new List<String>();
        foreach (string item in request.Headers.Keys)
        {
            //Console.WriteLine($"{item}:{request.Headers[item]}");
            headers.Add(item);
        }

        //Проверка на пустой запрос от xml или fetch (Политика безопасности)
        if (request.Headers["sec-fetch-mode"] != null)
            response.StatusCode = 200;
        else
            //Адресация на контроллеры
            switch (url)
            {
                case "authorization":
                    response = controllers.authorization(request, response, headers);
                    break;

                case "send":
                    response = controllers.send(request, response, headers);
                    break;

                case "registration":
                    response = controllers.registration(request, response, headers);
                    break;

                case "read":
                    response = controllers.read(request, response, headers);
                    break;
            };

        //Получаем поток для ответа
        using Stream output = response.OutputStream;

        //Отправляем данные
        await output.FlushAsync();
        Console.WriteLine($"STATUS-CODE:{response.StatusCode} Message:'{response.Headers["message"]}' API:{request.RawUrl}");
    } catch (InvalidCastException e)
    {
        Console.WriteLine("Ошибка запроса ", e);
    }
}