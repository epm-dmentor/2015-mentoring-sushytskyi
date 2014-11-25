using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverObject
{
    public class LiveCLass
    {
        public static string HoldingField;  
    }

    public class RecoveredClass
    {
        private string name = "asdf";
    
        //this is how instance can recovered using static field 
        public static RecoveredClass Instance;

        ~RecoveredClass()
        {
            Console.WriteLine("RecoveredClass finalized");
            LiveCLass.HoldingField = name;

            //instance of class RecoveredClass now reverenced by static field
            Instance = this;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var recoveredClassInstance = new RecoveredClass();
            Console.WriteLine("RecoveredClassInstance Alive {0}", recoveredClassInstance.GetType());
            
           //remove roots to make class collection eligable 
            recoveredClassInstance = null;

            //Run collection to collect RecoveredClassInstanece 
            GC.Collect();

            //wait until finaliation completes (in another case null reference exception may occur) 
            GC.WaitForPendingFinalizers();

            //Making sure that Recovered instance now not eligable for collection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("RecoveredClassInstance still alive {0}", RecoveredClass.Instance.GetType());     
            Console.ReadLine();
        }
    }
}
