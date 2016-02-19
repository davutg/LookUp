using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services
{
    public interface IMailService
    {
        bool SendMail(string name, string surName, string email, string message);
    }
}
