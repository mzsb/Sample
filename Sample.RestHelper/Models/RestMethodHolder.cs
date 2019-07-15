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

        public void AddMethod<T>(MethodType methodType, string parameter = "") where T : RestMethodHolder
        {
            bool hasParameter = !string.IsNullOrEmpty(parameter);
            string controller = typeof(T).Name;

            RestMethods.Add(new RestMethod()
            {
                MethodType = methodType,
                Controller = controller,
                HasParameter = hasParameter,
                Route = routeBase
                + controller
                + (hasParameter ? "/" + parameter : string.Empty)
            });
        }

        public RestMethod GetMethod<T>(MethodType methodType, bool hasParameter = false) where T : RestMethodHolder
        {
            foreach (var restMethod in RestMethods.Where(rm => rm.HasParameter.Equals(hasParameter)))
            {
                if(restMethod.MethodType.Equals(methodType) && restMethod.Controller.Equals(typeof(T).Name))
                {
                    return restMethod;
                }
            }

            return null;
        }
    }
}
