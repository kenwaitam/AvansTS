using AvansTS.Core.SCM.Commands;
using AvansTS.Core.SCM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.SCM.Providers.VC
{
    public class GitProvider : IVCProvider
    {
        public Git.Git Git { get; set; }

        public GitProvider()
        {
            Git = new Git.Git();
        }

        public void Request(List<Commit> commits)
        {
            foreach (var commit in commits)
            {
                Git.Commit(commit);
            }
        }
    }
}
