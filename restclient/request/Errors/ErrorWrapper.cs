using RestClientBCF.restclient.constants;
using System;
using System.Linq;

namespace JPA_Porra_Burgos.restclient.request.Errors
{
    public class ErrorWrapper
    {
        public string date { get; set; }
        public string message { get; set; }

        public string MessageFormatted()
        {
            var messages = message.Split(RestConstants.ERROR_REST_DELIMITER);
            var messagesFiltered = messages.ToArray().ToHashSet();
            message = String.Join("\n\n", messagesFiltered);
            return date + "\n\n\n" + message;
        }

    }
}
