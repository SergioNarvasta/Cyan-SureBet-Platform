using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyan.Domain.Common
{
    public class Audit
    {
        public DateTime CreateDate { get; set; }
        public string UserCreate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserUpdate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
