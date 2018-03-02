using AvansTS.Core.Composite;
using AvansTS.Core.States.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.BacklogItem
{
	public class DoneState : WorkItemStateBase
	{
		public WorkItemComponentBase Item { get; set; }

		public override string State { get { return "Done"; } }

		public DoneState(WorkItemComponentBase item)
		{
			Item = item;
		}

		public override void InToDo()
		{
			Item.WorkItemState = Item.ToDoState;
		}
	}
}
