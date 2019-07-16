using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.RestHelper.Models
{
    public class RestMethod
    {
        public MethodType MethodType { get; set; }

        public string ResponseType { get; set; }

        public bool HasParameter { get; set; } = false;

        public string JsonBody { get; set; } 

        public string Route { get; set; }
    }
}
