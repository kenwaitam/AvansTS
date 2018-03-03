using AvansTS.Core.Scrum.Decorator;
using System;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public class ReportDecorator : ReportBase
	{
		public ReportBase Report { get; set; }

		public ReportDecorator(ReportBase report)
		{
			Report = report;
		}

		public override string Header { get{ return Report.Header; }}
		public override string Footer { get { return Report.Footer; } }

		public override string Content { get { return Report.Content; } }
	}
}
