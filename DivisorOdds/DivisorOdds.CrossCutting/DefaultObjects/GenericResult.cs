using System;
using System.Collections.Generic;
using System.Text;

namespace DivisorOdds.CrossCutting.DefaultResponses
{
    public class GenericResult
    {
        public GenericResult() { }

        public GenericResult(bool success, string message, object data)
        {
            this.success = success;
            this.message = message;
            this.data = data;
        }

        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
