using AvansTS.Core.Models;
using System.Diagnostics;
using System.IO;

namespace AvansTS.Core.Services.Notification
{
	public class SlackService : INotificationService
	{
		public void Send(User user)
		{
			Debug.WriteLine("Slack notification sended to " + user.Name);

			//Fake via log
			FileLoggerService FileLog = new FileLoggerService();
			using (StreamWriter w = File.AppendText(@".\Logs\SlackLog.txt"))
			{
				FileLog.Log("Slack notification sended to " + user.Name, w);
			}

		}
	}
}
