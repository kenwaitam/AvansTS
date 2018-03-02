using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Observers
{
    public interface INotificationObserver
    {
        void Send(User user);
    }
}
