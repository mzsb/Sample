using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.RestHelper.Models
{
    public abstract class RestMethodHolder
    {
        private const string routeBase = "https://localhost:5001/api/";

        public List<RestMethod> RestMethods { get; set; } = new List<RestMethod>();

        public RestMethod AddMethod<T>(MethodType methodType, string parameter = "") where T : RestMethodHolder
        {
            bool hasParameter = !string.IsNullOrEmpty(parameter);

            RestMethod restMethod = new RestMethod
            {
                MethodType = methodType,
                ResponseType = typeof(T).Name,
                HasParameter = hasParameter,
                Route = routeBase
                + typeof(T).Name
                + (hasParameter ? "/" + parameter : string.Empty)
            };

            RestMethods.Add(restMethod);

            return restMethod;
        }

        public RestMethod AddMethod()
        {
            RestMethod restMethod = new RestMethod()
            {
                Route = routeBase
            };

            RestMethods.Add(restMethod);

            return restMethod;
        }


        public RestMethod GetMethod<T>(MethodType methodType, bool hasParameter = false) where T : RestMethodHolder
        {
            foreach (var restMethod in RestMethods.Where(rm => rm.HasParameter.Equals(hasParameter)))
            {
                if(restMethod.MethodType.Equals(methodType) && restMethod.ResponseType.Equals(typeof(T).Name))
                {
                    return restMethod;
                }
            }

            return null;
        }
    }
}
