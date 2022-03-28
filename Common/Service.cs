using System;

namespace Common
{
    public abstract class Service
    {
        public void ThrowExceptionIfAny(Notification notification)
        {
            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }
        }
    }
}
