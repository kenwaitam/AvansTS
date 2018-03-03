using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public class HeaderDecorator : ReportDecorator
	{
		private String header;

		public HeaderDecorator(ReportBase report, String headerContent) : base(report)
		{
			header = headerContent;
		}

		public override String Header
		{
			get { return base.Header + header; }
		}
	}
}
