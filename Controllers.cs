using System.Diagnostics;
using System.Net;
using System.Threading.Tasks.Dataflow;

namespace Server_ChatMMIS
{
    internal class Controllers
    {

        public HttpListenerResponse authorization(HttpListenerRequest request, HttpListenerResponse response, List<string> headers)
        {
            Models.Member member = new Models.Member();
            member.login = request.Headers["login"];
            member.password = request.Headers["password"];
            member.getAuth();

            if (member.id != -1)
            {
                member.createSession();
                response.AddHeader("uuid", member.uuid);
                response.AddHeader("member_id", System.Convert.ToString(member.id));
                response.StatusCode = 200;
                response.AddHeader("message", "Authorization is successful");
            }
            else
            {
                response.AddHeader("message", "Incorrect login-password pair or request data");
                response.StatusCode = 401;
            }
            return response;
        }

        public HttpListenerResponse send(HttpListenerRequest request, HttpListenerResponse response, List<string> headers)
        {
            Models.Message message = new Models.Message();

            message.member = new Models.Member();
            message.member.uuid = request.Headers["uuid"];
            message.member.isActiveSession();

            message.dateTime = Convert.ToString(DateTime.Now);
            message.content = request.Headers["content"] + "";

            switch (message.createMessage())
            {
                case true:
                    response.StatusCode = 200;
                    response.AddHeader("message", "The message has been sent");
                    break;
                case false:
                    response.StatusCode = 401;
                    response.AddHeader("message", "The session time has expired or the request data is incorrect");
                    break;
            }
            return response;
        }

        public HttpListenerResponse registration(HttpListenerRequest request, HttpListenerResponse response, List<string> headers)
        {
            if (request.Headers["firstName"] != null && 
                request.Headers["lastName"] != null &&
                request.Headers["age"] != null &&
                request.Headers["login"] != null &&
                request.Headers["password"] != null
                )
            {
                Models.Member member = new Models.Member();
                member.firstName = request.Headers["firstName"];
                member.lastName = request.Headers["lastName"];
                member.age = Convert.ToInt32(request.Headers["age"]);
                member.login = request.Headers["login"];
                member.password = request.Headers["password"];
                switch (member.createAccount())
                {
                    case true:
                        response.StatusCode = 200;
                        response.AddHeader("message", "Account create");
                        break;

                    case false:
                        response.StatusCode = 401;
                        response.AddHeader("message", "Such a user already exists");
                        break;
                }
            } else
            {
                response.StatusCode = 401;

                response.AddHeader("message", "Incorrect request");
            }
            return response;
        }

        public HttpListenerResponse read(HttpListenerRequest request, HttpListenerResponse response, List<string> headers)
        {
            Models.Member member = new Models.Member();
            member.uuid = request.Headers["uuid"];
            member.isActiveSession();
            switch (member.id)
            {
                case -1:
                    response.StatusCode = 401;
                    response.AddHeader("message", "The session time has expired or the request data is incorrect");
                    break;
                default:
                    Models.Messages messages = new Models.Messages();
                    switch (request.Headers["cursor"])
                    {
                        case "cursor":
                                                        messages.getMessages(Convert.ToInt32(request.Headers["cursor"]));
                            response.StatusCode = 200;
                            response.AddHeader("messages", messages.convertToJson());
                            response.AddHeader("message", "Last messages return");
                            break;

                        default:
                            messages.getLastMessages();
                            response.StatusCode = 200;
                            response.AddHeader("messages", messages.convertToJson());
                            response.AddHeader("message", "Last messages return");
                            break;
                    }
                    break;
            }
            return response;
        }

    }

}