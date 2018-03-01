using AvansTS.Core.Models;
using AvansTS.Core.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Services
{
    public interface INotificationService
    {
        void Send(Developer user);
    }
}
