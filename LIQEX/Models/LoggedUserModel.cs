using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIQEX.Models
{
    public class LoggedUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Rights { get; set; }
        public byte[] Photo { get; set; }
    }
}