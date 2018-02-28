using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class Developer
    {
		public String Name { get; set; }
        public String Email { get; set; }
        public List<int> NotificationOptions { get; set; }

        public void AddOption(int option)
        {
            NotificationOptions.Add(option);
        }

        public void Remove(int option)
        {
            NotificationOptions.Remove(option);
        }
    }
}
