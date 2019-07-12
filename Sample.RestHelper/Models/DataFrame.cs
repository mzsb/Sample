using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.RestHelper.Models
{
    public class DataFrame<T>
    {
        public T DataObject { get; set; }

        public List<RestMeta> RestMetas { get; set; } = new List<RestMeta>();
    }
}
