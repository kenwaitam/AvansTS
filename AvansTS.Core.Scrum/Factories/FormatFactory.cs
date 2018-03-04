using AvansTS.Core.Factories.Notification;
using AvansTS.Core.Scrum.Factories;
using AvansTS.Core.Scrum.Factories.Format;
using System.Collections.Generic;

namespace AvansTS.Core.Factories
{
	public class FormatFactory
	{
		public static FormatFactory Instance { get; set; }
		public static Dictionary<int, IFormatFactory> Factories { get; set; }

		protected FormatFactory() { }

		static FormatFactory()
		{
			Instance = new FormatFactory();

			Factories = new Dictionary<int, IFormatFactory>
			{
				{ 1, new PDFFactory() },
				{ 2, new DOCFactory() }
			};
		}

		public static IFormatFactory CreateFormatFactory(int option)
		{
			return Factories[option];
		}
	}
}
