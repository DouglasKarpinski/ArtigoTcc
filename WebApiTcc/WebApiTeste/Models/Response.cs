using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace WebApiTeste.Models
{
    public class Response
    {
        #region ☼ Construtores ☼

        public Response()
        {

        }

        public Response(IEnumerable<Notification> notifications)
        {
            Notifications = notifications;
        }

        public Response(HttpStatusCode status)
        {
            StatusCode = status;
        }

        public Response(HttpStatusCode status, string message)
        {
            StatusCode = status;
            Notifications = new List<Notification>
            {
                new Notification("Problema na Api",message)
            };
        }

        #endregion

        public HttpStatusCode StatusCode { get; set; }

        public IEnumerable<Notification> Notifications { get; set; }

        public IEnumerable<string> Messages()
        {
            return Notifications?.Select(x => x.Value) ?? new List<string> { "Ocorreu um erro ao realizar a operação." };
        }

        public bool IsSuccess => StatusCode == HttpStatusCode.OK;

        public bool PossuiNotificacoesDoTipo(string tipo)
        {
            if (Notifications == null) return false;
            return Notifications.Any(x => x.Key == tipo);
        }

        public IEnumerable<string> MensagensDoTipo(string tipo)
        {
            return Notifications.Where(x => x.Key == tipo).Select(x => x.Value);
        }

    }

    public class Response<T> : Response
    {
        #region ☼ Contrutores ☼

        public Response(T content) : base(Enumerable.Empty<Notification>())
        {
            Content = content;
        }

        [JsonConstructor]
        public Response(T content, IEnumerable<Notification> notifications) : base(notifications)
        {
            Content = content;
        }

        public Response(T content, HttpStatusCode status)
            : base(status)
        {
            Content = content;
        }

        public Response(HttpStatusCode status, string message)
            : base(status, message)
        {

        }
        #endregion

        public T Content;

        public bool HasNotification()
        {
            return Notifications.Any();
        }
    }
}
