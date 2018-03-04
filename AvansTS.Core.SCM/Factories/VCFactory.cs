using AvansTS.Core.SCM.Factories.VC;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.SCM.Factories
{
    public class VCFactory
    {
        public static VCFactory Instance { get; set; }
        public static Dictionary<int, IVCFactory> Factories { get; set; }

        protected VCFactory() { }

        static VCFactory()
        {
            Instance = new VCFactory();

            Factories = new Dictionary<int, IVCFactory>
            {
                { 1, new GitFactory() },
                { 2, new SubversionFactory() }
            };
        }

        public static IVCFactory CreateVCFactory(int option)
        {
            return Factories[option];
        }
    }
}
