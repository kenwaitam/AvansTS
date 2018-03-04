using AvansTS.Core.Observers;
using AvansTS.Core.SCM.Commands;
using AvansTS.Core.SCM.Commands.VC;
using AvansTS.Core.SCM.Models;
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

        public void Commit(Commit commit)
        {
            IVCCommand commitCommand = new CommitCommand { Commit = commit };

            commitCommand.Execute();
        }

        public void Push(Branch branch)
        {
            IVCCommand pushCommand = new PushCommand { Branch = branch };

            pushCommand.Execute();
        }
    }
}
