using System;
using System.Collections.Generic;
using System.Text;

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
            Comments.Add(new Comment { Developer = user, Text = comment});
        }
    }
}
