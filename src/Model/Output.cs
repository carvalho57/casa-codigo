using System.Collections.Generic;
using Flunt.Notifications;

namespace CasaCodigo.Models 
{
    public class Output 
    {
        public Output(bool sucess, string message,  object data)
        {
            Sucess = sucess;
            Data = data;
            Message = message;
        }
        public Output(bool sucess, object data, IReadOnlyCollection<Notification> notifications = null, string message = "")
        {
            Sucess = sucess;
            Data = data;
            Notifications = notifications;
            Message = message;
        }

        public Output(bool sucess, string message, IReadOnlyCollection<Notification> notifications)
        {
            Notifications = notifications;
            Sucess = sucess;
            Message = message;
        }

        public bool Sucess { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
        public IReadOnlyCollection<Notification>  Notifications { get; private set; }
    }
}