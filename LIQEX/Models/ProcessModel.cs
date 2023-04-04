using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIQEX.Models
{
    public class ProcessModel
    {
        public int Id { get; set; }
        public bool IsProcessSuccess { get; set; }
        public string Message { get; set; }
    }
}