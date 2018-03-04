using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AvansTS.Core.Scrum.Models.Base;

namespace AvansTS.Core.Scrum.Decorators.Page
{
    public class SectionDecorator : PageDecoratorBase
    {
        public SectionDecorator(PageBase page) : base(page)
        {
            Prev = page;
        }

        public override void Apply()
        {
            base.Apply();
            if (Prev.GetType() != typeof(HeaderDecorator))
            {
                Debug.Write(Environment.NewLine);
            }
            Debug.WriteLine("{0,5} {1,5} {2,5}", LeftText, CenterText, RightText);
        }
    }
}
