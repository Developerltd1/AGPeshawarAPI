using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelLayer.Models
{
    public class ContentResult
    {
        public string Message { get; set; }
        public string DevMessage { get; set; }
        public object Content { get; set; }

        public ContentResult(string Msg, string DevMsg)
        {
            Message = Msg;
            DevMessage = DevMsg;
        }

        public ContentResult(string Msg, string DevMsg, object Cont)
        {
            Message = Msg;
            DevMessage = DevMsg;
            Content = Cont;
        }

        public ContentResult(object Cont)
        {
            Message = "";
            DevMessage = "";
            Content = Cont;
        }

    }

}