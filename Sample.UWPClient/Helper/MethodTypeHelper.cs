using Sample.RestHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Sample.UWPClient.Helper
{
    public static class MethodTypeHelper
    {
        public static HttpMethod ToHttpMethod(this MethodType methodType)
        {
            switch (methodType)
            {
                case MethodType.Get:
                    return HttpMethod.Get;
                case MethodType.Post:
                    return HttpMethod.Post;
                case MethodType.Put:
                    return HttpMethod.Put;
                case MethodType.Delete:
                    return HttpMethod.Delete;
                default:
                    return HttpMethod.Options;
            }
        }
    }
}
