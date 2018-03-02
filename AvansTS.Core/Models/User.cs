using System;
using System.Collections.Generic;

namespace AvansTS.Core.Models
{
	public class User
	{
		public String Name { get; set; }
		public String Email { get; set; }
		public List<int> NotificationOptions { get; set; }

		public void AddOption(int option)
		{
			NotificationOptions.Add(option);
		}

		public void RemoveOption(int option)
		{
			NotificationOptions.Remove(option);
		}
	}
}
