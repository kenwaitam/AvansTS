using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public class FooterDecorator : ReportDecorator
	{
		private String footer;

		public FooterDecorator(ReportBase report, string footerContent) : base(report)
		{
			footer = footerContent;
		}

		public override String Footer
		{
			get { return base.Footer + footer; }
		}
	}
}
