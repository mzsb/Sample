using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.UWPClient.Models
{
    public class NavigationObject
    {
        public Dictionary<Guid, object> Objects { get; set; } = new Dictionary<Guid, object>();

        public NavigationObject() { }

        public NavigationObject(object o)
        {
            if(o is NavigationObject)
            {
                Objects = ((NavigationObject)o).Objects;
            }
        }

        public NavigationObject Add(params object[] objects)
        {
            foreach (var o in objects)
            {
                Objects.Add(o.GetType().GUID, o);
            }

            return this;
        }

        public T Get<T>() where T : new()
        {
            if (Objects.Any())
            {
                return (T)Objects[typeof(T).GUID];
            }

            return new T();
        }
    }
}
