using AvansTS.Core.DevOps.Factories;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Services
{
	public class DeployService : IDevOpsService
	{
		public void Run()
		{
			Debug.WriteLine("Deployed");
		}
	}
}
