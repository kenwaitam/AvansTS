using AvansTS.Core.SCM.Commands;
using AvansTS.Core.SCM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.SCM.Providers.VC.Git
{
    public class Git
    {
        public void Commit(Commit commit)
        {
            Debug.WriteLine("GIT: Committed to remote " + commit.Branch.Name);
        }
    }
}
