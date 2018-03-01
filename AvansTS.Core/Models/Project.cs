using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class Project
    {
		public String Name { get; set; }
		public ProductBacklog ProductBacklog { get; set; }
        public List<User> ProductOwners { get; set; }

        public void AddUser(User user)
        {
            ProductOwners.Add(user);
        }
    }
}
