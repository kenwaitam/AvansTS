using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AvansTS.Core.Models
{
    public class DiscussionThread
    {
        public ProductBacklogItem Item { get; set; }
        public List<Comment> Comments { get; set; }

        public DiscussionThread(ProductBacklogItem item)
        {
            Item = item;
        }

        public void AddComment(User user, String comment)
        {
            if (Item.WorkItemState != Item.DoneState)
            {
                Comments.Add(new Comment { Developer = user, Text = comment });
                Item.NotifyUsers();
            }
        }

        public void DisplayComments()
        {
            foreach (var comment in Comments)
            {
                Debug.WriteLine(comment.Developer.Name + ": " + comment.Text);
            }
        }
    }
}
