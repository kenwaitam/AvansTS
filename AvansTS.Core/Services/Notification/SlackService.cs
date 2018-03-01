using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using AvansTS.Core.Models;

namespace AvansTS.Core.Services.Notification
{
    public class SlackService : INotificationService
    {
		public void Send(Developer user)
        {
            Debug.WriteLine("Slack notification sended to " + user.Name);

			//Fake via log
			FileLogger FileLog = new FileLogger();
			using (StreamWriter w = File.AppendText(@".\Logs\SlackLog.txt"))
			{
				FileLog.Log("Slack notification sended to " + user.Name, w);
			}

		}
    }
}
