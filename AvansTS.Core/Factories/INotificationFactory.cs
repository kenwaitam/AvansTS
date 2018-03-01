using AvansTS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Factories
{
    public interface INotificationFactory
    {
        INotificationService CreateNotificationService();
    }
}
