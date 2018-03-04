using AvansTS.Core.SCM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.SCM.Providers
{
    public interface IVCProvider
    {
        void Request(List<Commit> commits);
    }
}
