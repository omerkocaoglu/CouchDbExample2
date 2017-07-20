using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchDbApplication.DTO
{
    public class groupingCarDTO
    {
        public string Id { get; set; }
        public List<string> Key { get; set; }
        public string Value { get; set; }
    }
}
