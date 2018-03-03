using AvansTS.Core.Models;
using System.Diagnostics;
using System.IO;

namespace AvansTS.Core.Services.Notification
{
	public class EmailService : INotificationService
	{
		public void Send(User user)
		{
			Debug.WriteLine("Email notification sended to " + user.Email);

			// Fake via log
			FileLoggerService FileLog = new FileLoggerService();
			using (StreamWriter w = File.AppendText(@".\Logs\EmailLog.txt"))
			{
				FileLog.Log("Email notification sended to " + user.Email, w);
			}
		}
	}
}
