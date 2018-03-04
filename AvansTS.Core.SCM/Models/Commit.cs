using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.SCM.Models
{
    public class Commit
    {
        public Branch Branch { get; set; }
        public String Message { get; set; }
    }
}
