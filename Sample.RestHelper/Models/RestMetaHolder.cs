using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.RestHelper.Models
{
    public abstract class RestMetaHolder
    {
        public List<RestMeta> RestMetas { get; set; } = new List<RestMeta>();
    }
}
