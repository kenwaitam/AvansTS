using AvansTS.Core.SCM.Factories;
using AvansTS.Core.SCM.Providers;
using System;
using System.Collections.Generic;

namespace AvansTS.Core.Models
{
	public class Project
	{
		public String Name { get; set; }
        public IVCProvider Provider { get; set; }
        public ProductBacklog ProductBacklog { get; set; }
		public List<User> ProductOwners { get; set; }

		public void AddUser(User user)
		{
			ProductOwners.Add(user);
		}

        public void ChooseVersionControl(int option = 1)
        {
            Provider = VCFactory.CreateVCFactory(option).CreateVCProvider();
        }
	}
}
