using AvansTS.Core.SCM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.SCM.Commands.VC
{
    public class PushCommand : IVCCommand
    {
        public Branch Branch { get; set; }

        public void Execute()
        {
            Branch.Push();
        }
    }
}
