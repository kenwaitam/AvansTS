using AvansTS.Core.SCM.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.SCM.Factories
{
    public interface IVCFactory
    {
        IVCProvider CreateVCProvider();
    }
}
