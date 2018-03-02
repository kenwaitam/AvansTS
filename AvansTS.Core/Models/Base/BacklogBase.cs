using System;
using System.Collections.Generic;

namespace AvansTS.Core.Models.Base
{
	public abstract class BacklogBase
	{
		public String Name { get; set; }
		public List<ProductBacklogItem> Items { get; set; }
	}
}
