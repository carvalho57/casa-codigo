using System.Collections.Generic;
using Flunt.Notifications;

namespace CasaCodigo.Models
{
    public class Response
    {
        public Response(string message)
        {
            Message = message;
        }
        public Response(string message, IEnumerable<Notification> errors)
        {
            Message = message;
            Errors = errors;
        }

        public Response(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public Response(string message, object data, IEnumerable<Notification> errors)
        {
            Message = message;
            Data = data;
            Errors = errors;
        }

        public string Message { get; set; }
        public object Data { get; set; }
        public IEnumerable<Notification> Errors { get; set; }
    }
}