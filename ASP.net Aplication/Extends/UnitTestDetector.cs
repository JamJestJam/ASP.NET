using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Extends {
    static class UnitTestDetector {
        static UnitTestDetector() {
            if (AppDomain.CurrentDomain.GetAssemblies().Select(a => a.FullName.ToLower()).Contains("nunit.framework")) {
                IsRunningFromNUnit = true;
            }
        }

        public static Boolean IsRunningFromNUnit { get; private set; } = false;
    }
}
