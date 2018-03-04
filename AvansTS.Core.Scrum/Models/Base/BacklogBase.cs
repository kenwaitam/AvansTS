using AvansTS.Core.Subjects;
using System;
using System.Collections.Generic;

namespace AvansTS.Core.Models.Base
{
    public abstract class BacklogBase : BacklogSubjectBase
    {
        public String Name { get; set; }
        public List<ProductBacklogItem> Items { get; set; }

        public virtual void AddItem(ProductBacklogItem item)
        {
            Items.Add(item);
        }
    }
}
