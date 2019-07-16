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

        public RestMethod SetResponse(Type type)
        {
            ResponseType = type.Name;

            return this;
        }

        public RestMethod SetMethod(MethodType methodType)
        {
            MethodType = methodType;

            return this;
        }

        public RestMethod SetController(string controller)
        {
            Route = Route.Substring(0,27);

            Route += controller + "/";

            return this;
        }

        public RestMethod SetJsonBody(string jsonBody)
        {
            JsonBody = jsonBody;

            return this;
        }

        public RestMethod SetParameter(string parameter)
        {
            Route += parameter;

            HasParameter = true;

            return this;
        }
    }
}
