using AvansTS.Core.SCM.Commands;
using AvansTS.Core.SCM.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.SCM.Models
{
    public class Branch
    {
        public String Name { get; set; }
        public IVCProvider Provider { get; set; }
        public List<Commit> Commits { get; set; }

        public void Commit(Commit commit)
        {
            Commits.Add(commit);
        }

        public void Push()
        {
            Provider.Request(Commits);
        }
    }
}
