using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	class HeaderDecorator : ReportDecoratorBase
	{
		private String header;

		public HeaderDecorator(IReport report, String headerContent) : base(report)
		{
			header = headerContent;
		}

		public override String Header
		{
			get { return base.Report.Header + header; }
		}
	}
}
