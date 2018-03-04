using AvansTS.Core.Scrum.Decorators.Page;
using AvansTS.Core.Scrum.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Models
{
    public class Report
    {
        public String CompanyName { get; set; }
        public String ProjectName { get; set; }
        public String CompanyLogo { get; set; }

        public List<PageBase> Pages { get; set; }

        public Report()
        {
            Pages = new List<PageBase>();
        }

        public void UpdateHeading(String companyName, String projectName, String companyLogo)
        {
            CompanyName = companyName;
            ProjectName = projectName;
            CompanyLogo = companyLogo;
        }

        public void CreateTemplate(Boolean header, Boolean footer, int count = 1)
        {
            for (int i = 1; i <= count; i++)
            {
                PageBase page = new Page();

                if (header == true)
                {
                    page = new HeaderDecorator(page)
                    {
                        LeftText = CompanyName,
                        CenterText = ProjectName,
                        RightText = CompanyLogo
                    };
                }

                page = new SectionDecorator(page)
                {
                    LeftText = "Lorem ipsum dolor sit amet"
                };

                if (footer == true)
                {
                    String day = DateTime.Now.Day.ToString();
                    String month = DateTime.Now.Month.ToString();
                    String year = DateTime.Now.Year.ToString();
                    String date = day + "/" + month + "/" + year;
                    int number = 1 + Pages.Count;

                    page = new FooterDecorator(page)
                    {
                        LeftText = ProjectName,
                        CenterText = date,
                        RightText = number.ToString()
                    };
                }

                Pages.Add(page);
            }
        }

        public void AddPage(PageBase page)
        {
            Pages.Add(page);
        }

        public void RemovePage(PageBase page)
        {
            Pages.Remove(page);
        }

        public void Preview()
        {
            foreach (var page in Pages)
            {
                page.Apply();
            }
        }
    }
}
