using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public class FooterDecorator : ReportDecoratorBase
	{
		private String footer;

		public FooterDecorator(IReport report, string footerContent) : base(report)
		{
			footer = footerContent;
		}

		public override String Footer
		{
			get { return base.Report.Footer + footer; }
		}
	}
}
