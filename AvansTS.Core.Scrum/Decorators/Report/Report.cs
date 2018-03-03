using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public class Report : IReport
	{
		public string Header { get; set; }

		public string Content { get; set; }

		public string Footer { get; set; }
	}
}
