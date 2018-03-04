using AvansTS.Core.SCM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.SCM.Commands
{
    public class CommitCommand : IVCCommand
    {
        public Commit Commit { get; set; }

        public void Execute()
        {
            Commit.Branch.Commit(Commit);
        }
    }
}
