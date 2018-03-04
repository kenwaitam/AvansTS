using System;
using System.Collections.Generic;
using System.Text;
using AvansTS.Core.SCM.Models;

namespace AvansTS.Core.SCM.Providers.VC
{
    public class SubversionProvider : IVCProvider
    {
        public Subversion.Subversion Subversion { get; set; }

        public SubversionProvider()
        {
            Subversion = new Subversion.Subversion();
        }

        public void Request(List<Commit> commits)
        {
            foreach (var commit in commits)
            {
                Subversion.Transfer(commit);
            }
        }
    }
}
