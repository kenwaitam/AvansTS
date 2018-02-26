using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class ProductBacklog
    {
		public List<ProductBacklogItem> Items { get; set; }

		public void AddItem(ProductBacklogItem item)
		{
			Items.Add(item);
		}
    }
}
