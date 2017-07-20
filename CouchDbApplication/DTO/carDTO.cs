using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchDbApplication.DTO
{
   public class carDTO
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public List<string> Value { get; set; }
    }
}
