using AvansTS.Core.DevOps.Factories;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Services
{
	public class TestService : IDevOpsService
	{
		public void Run()
		{
			Debug.WriteLine("Tested");
		}
	}
}
