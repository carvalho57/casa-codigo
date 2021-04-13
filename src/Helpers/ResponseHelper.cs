using System.Collections.Generic;
using CasaCodigo.Models;
using Flunt.Notifications;

namespace CasaCodigo.Helpers
{
    public static class ResponseHelper
    {        
        public static Response CreateResponse(string message, IEnumerable<Notification> notifications)
        {
            return new Response(message, notifications);
        }

        public static Response CreateResponse(string message, object data)
        {
            return new Response(message, data);
        }
    }
}