using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommSite.SolutionsPrime
{
    public class spReporter
    {
        public enum reportLevelType {ALL,RESULTFILE};
        public static string reportLevel = reportLevelType.ALL.ToString();
        public static void WriteLine(string str)
        {
            switch(reportLevel)
            {
                case "ALL":
                    Console.WriteLine(str);
                    break;
                case "RESULTFILE":
                    Console.WriteLine(str);
                    Console.WriteLine("test Result file ");
                    break;
                default:
                    Console.WriteLine(str);
                    break;
            }            
        }
    }
    
}
