using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models.Base
{
    public abstract class WorkItemBase
    {
        public String Title { get; set; }
        public User Developer { get; set; }
        public SprintBacklog Sprint { get; set; }
        public List<Comment> Comments { get; set; }

        public void AssignDeveloper(User user)
        {
            Developer = user;
        }
    }
}
