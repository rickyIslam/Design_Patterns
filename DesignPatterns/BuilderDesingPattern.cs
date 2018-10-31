using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class BuilderDesingPattern
    {
        class Program
        {
            interface IRoutine
            {
                void WakeUp();
                void GoToSchool();
                void ListenToMusic();
                void Sleep();
            }
            class Ricky : IRoutine
            {
                public void GoToSchool()
                {
                    Console.WriteLine("going to school");
                }

                public void ListenToMusic()
                {
                    Console.WriteLine("litening to music");
                }

                public void Sleep()
                {
                    Console.WriteLine("tring to sleep");
                }

                public void WakeUp()
                {
                    Console.WriteLine("good morning !!!");
                }
            }
            class Elvis : IRoutine
            {
                public void GoToSchool()
                {
                    Console.WriteLine("going to school");
                }

                public void ListenToMusic()
                {
                    Console.WriteLine("litening to music");
                }

                public void Sleep()
                {
                    Console.WriteLine("tring to sleep");
                }

                public void WakeUp()
                {
                    Console.WriteLine("good morning !!!");
                }
            }
            class Builder
            {
                public void Construct(IRoutine routine)
                {
                    routine.WakeUp();
                    routine.GoToSchool();
                    routine.ListenToMusic();
                    routine.Sleep();
                }
            }
            class Client
            {
                static void Main()
                {
                    Builder builder = new Builder();
                    IRoutine r1 = new Ricky();
                    IRoutine r2 = new Elvis();

                    builder.Construct(r1);
                    builder.Construct(r2);

                    Console.Read();
                }
            }
        }
    }
}
