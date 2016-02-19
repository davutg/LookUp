using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services
{
    public class MockMailService : IMailService
    {
        public bool SendMail(string name, string surName, string email, string message)
        {
            Debug.WriteLine(String.Format("{0},{1},{2},{3}",name??"",surName??"",email??"",message??""));
            Debug.WriteLine($"{name??""},{surName ?? ""},{email ?? ""},{message ?? ""}");
            return true;
        }
    }
}
