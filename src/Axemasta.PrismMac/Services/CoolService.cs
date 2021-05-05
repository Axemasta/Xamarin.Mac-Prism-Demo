using System;
using System.Diagnostics;

namespace Axemasta.PrismMac.Services
{
    public class CoolService : ICoolService
    {
        private const string _cool = "😎👉 Ehhhhhhhhh";

        public void DoSomething()
        {
            Debug.WriteLine(_cool);
        }

        public string GetSomething()
        {
            return _cool;
        }
    }
}
