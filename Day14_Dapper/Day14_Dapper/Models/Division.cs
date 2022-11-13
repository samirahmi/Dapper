using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Models
{
    public class Division
    {
        public Guid DivisionId { get; set; }
        public Guid CompanyId { get; set; }
        public string DivisionName { get; set; }
    }
}
