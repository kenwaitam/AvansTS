using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public class Report : ReportBase
	{

		public override string Header { get; }

		public override string Content { get; }

		public override string Footer { get; }

		public Report(string content)
		{
			Content = content;
		}
	}
}
