using System;
using System.IO;
using System.Linq;

namespace AvansTS.Core.Services
{
	public class FileLogger
	{
		public FileLogger()
		{
			Directory.CreateDirectory(@".\Logs\");
		}

		public void Log(string logMessage, TextWriter w)
		{
			w.WriteLine(logMessage);
		}

		public void DumpLog(StreamReader r)
		{
			string line;
			while ((line = r.ReadLine()) != null)
			{
				Console.WriteLine(line);
			}
		}

		public String GetLastMessage(string file)
		{
			return File.ReadLines(file).Last();
		}
	}
}
