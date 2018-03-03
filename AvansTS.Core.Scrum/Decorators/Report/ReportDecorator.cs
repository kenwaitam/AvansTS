using AvansTS.Core.Scrum.Decorator;
using System;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public class ReportDecorator : ReportDecoratorBase
	{
		public ReportDecorator(IReport report, string content) : base(report)
		{
			base.Content = content;
		}
	}
}
