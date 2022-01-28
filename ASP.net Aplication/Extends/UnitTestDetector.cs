using System;
using System.Linq;

namespace ASP.net_Aplication.Extends {
    static class UnitTestDetector {
        static UnitTestDetector() {
            
            if (AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName.ToLower().Contains("xunit"))) {
                IsRunningFromTest = true;
            }
        }

        public static Boolean IsRunningFromTest { get; private set; } = false;
    }
}
