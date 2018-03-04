using System;
using System.Collections.Generic;
using System.Text;
using AvansTS.Core.Scrum.Services;
using AvansTS.Core.Scrum.Services.Format;

namespace AvansTS.Core.Scrum.Factories.Format
{
    public class DOCFactory : IFormatFactory
    {
        public IFormatService CreateFormatService()
        {
            return new DOCService();
        }
    }
}
