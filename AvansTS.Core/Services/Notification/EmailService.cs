using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using AvansTS.Core.Models;

namespace AvansTS.Core.Services.Notification
{
    public class EmailService : INotificationService
    {
		public void Send(Developer user)
        {
            Debug.WriteLine("Email notification sended to " + user.Email);

			// Fake via log
			FileLogger FileLog = new FileLogger();
			using (StreamWriter w = File.AppendText(@".\Logs\EmailLog.txt"))
			{
				FileLog.Log("Email notification sended to " + user.Email, w);
			}
		}
    }
}
