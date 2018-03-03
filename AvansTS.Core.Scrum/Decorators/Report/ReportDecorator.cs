using AvansTS.Core.Scrum.Decorator;
using System;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public class ReportDecorator : ReportDecoratorBase
	{
		private String HeaderContent;
		private String FooterContent;

		public ReportDecorator(IReport report, String HeaderContent, String Content, String FooterContent) : base(report)
		{
			this.HeaderContent = HeaderContent;
			base.Content = Content;
			this.FooterContent = FooterContent;
		}


		public override String Header
		{
			get { return Header + '\n' + HeaderContent; }
		}

		public override String Footer
		{
			get { return Footer + '\n' + FooterContent; }
		}
	}
}
