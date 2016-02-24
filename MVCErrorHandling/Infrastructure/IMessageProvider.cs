using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCErrorHandling.Infrastructure
{
    public interface IMessageProvider
    {
        void SendEmail(EmailDetails details);
    }
}