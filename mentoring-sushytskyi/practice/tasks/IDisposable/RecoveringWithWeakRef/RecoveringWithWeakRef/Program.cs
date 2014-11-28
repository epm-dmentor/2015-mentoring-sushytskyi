using System;

namespace RecoveringWithWeakRef
{
    public class RecoveredClass
    {
        ~RecoveredClass()
        {
            Console.WriteLine("RecoveredClass finalized");
            // make strong ref by passing instatnce back to Finalize queue
            GC.ReRegisterForFinalize(this);
        }
    }

    class Program
    {
        private static void CollectInstance(WeakReference weakRef)
        {
                Console.WriteLine("GC Collection run!");
                //Run collection to collect RecoveredClassInstanece 
                GC.Collect();
                //wait until finaliation completes (in another case null reference exception may occur) 
                GC.WaitForPendingFinalizers();

                if (weakRef.IsAlive)
                {
                    var instanceStatus = (weakRef.Target as RecoveredClass);
                    if (instanceStatus != null)
                        Console.WriteLine("RecoveredClassInstance Alive : {0}", instanceStatus);
                    instanceStatus = null;
                }

                GC.Collect();
                //wait until finaliation completes (in another case null reference exception may occur) 
                GC.WaitForPendingFinalizers();
  
        }

        static void Main(string[] args)
        {

            WeakReference weakRef = new WeakReference(new RecoveredClass(),true);

            if (weakRef.IsAlive)
            {
                var instance = (weakRef.Target as RecoveredClass);
                if (instance != null)
                    Console.WriteLine("RecoveredClassInstance Alive : {0}", instance);
                instance = null;
            }


            Console.WriteLine("GC Collection run!");
            //Run collection to collect RecoveredClassInstanece 
            GC.Collect();
            //wait until finaliation completes (in another case null reference exception may occur) 
            GC.WaitForPendingFinalizers();


            CollectInstance(weakRef);

  
            Console.ReadLine();
        }
    }
}
