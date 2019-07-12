using Sample.RestHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.UWPClient.Models
{
    public class Concert
    {
        public string Name { get; set; }
        public ICollection<RestMeta> RestMetas { get; set; } = new List<RestMeta>();
    }
}
