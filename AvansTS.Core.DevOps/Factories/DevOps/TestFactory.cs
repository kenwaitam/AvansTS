using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.DevOps.Factories.DevOps
{
    public class TestFactory : IDevOpsFactory
    {
		public IDevOpsService CreateDevOpsService()
		{
			return new TestService();
		}
	}
}
