using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class ResponseData
    {
        public bool IsSuccess { get; set; }
        public int ID { get; set; }
        public string ResponseMessage { get; set; }

        public List<Todos> Todos { get; set; }
    }
}
