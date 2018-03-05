using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AvansTS.Core.Scrum.Models;

namespace AvansTS.Core.Scrum.Services.Format
{
    public class DOCService : IFormatService
    {
        public Report Report { get; set; }

        public String Convert(Report report)
        {
            Report = report;
            Debug.WriteLine("DOC Service not implemented.");
            return "This is a doc";
        }
    }
}
