using AvansTS.Core.SCM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.SCM.Providers.VC.Subversion
{
    public class Subversion
    {
        public void Transfer(Commit commit)
        {
            Debug.WriteLine("Subversion: commit transfered to remote " + commit.Branch.Name);
        }
    }
}
