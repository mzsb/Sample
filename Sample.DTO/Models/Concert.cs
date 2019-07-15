using Sample.RestHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.DTO.Models
{
    public class Concert : RestMethodHolder
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }

        public string Name { get; set; }
    }
}
