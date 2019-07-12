using Sample.RestHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebAPI.Dtos
{
    public class Concert
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }

        public string Name { get; set; }
        public ICollection<RestMeta> RestMetas { get; set; } = new List<RestMeta>();
    }
}
