using AvansTS.Core.Scrum.Services;
using AvansTS.Core.Scrum.Services.Format;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Factories.Format
{
    public class PDFFactory : IFormatFactory
    {
        public IFormatService CreateFormatService()
        {
            return new PDFService();
        }
    }
}
