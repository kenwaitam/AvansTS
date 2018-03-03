using System;
using System.IO;
using System.Linq;

namespace AvansTS.Core.Services
{
	public class FileLoggerService
	{
		public FileLoggerService()
		{
			Directory.CreateDirectory(@".\Logs\");
		}

		public void Log(string logMessage, TextWriter w)
		{
			w.WriteLine(logMessage);
			w.Close();
		}

		public void DumpLog(StreamReader r)
		{
			string line;
			while ((line = r.ReadLine()) != null)
			{
				Console.WriteLine(line);
			}
		}
	}
}
