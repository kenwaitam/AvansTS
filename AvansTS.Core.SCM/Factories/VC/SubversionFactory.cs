using System;
using System.Collections.Generic;
using System.Text;
using AvansTS.Core.SCM.Providers;
using AvansTS.Core.SCM.Providers.VC;

namespace AvansTS.Core.SCM.Factories.VC
{
    public class SubversionFactory : IVCFactory
    {
        public IVCProvider CreateVCProvider()
        {
            return new SubversionProvider();
        }
    }
}
