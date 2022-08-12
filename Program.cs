using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    namespace BreakFastAssignment
    {
        internal class Bacon { }
        internal class Coffee { }
        internal class Egg { }
        internal class Juice { }
        internal class Toast { }
        internal class BreakFastDemo
        {
            private static Juice PourOJ()
            {
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId}  Pouring orange juice");
                return new Juice();
            }

            private static void ApplyJam(Toast toast) =>
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId} Putting jam on the toast");

            private static void ApplyButter(Toast toast) =>
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId}  Putting butter on the toast");

            private static Toast ToastBread(int slices)
            {
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} Putting a slice of bread in the toaster :");
                }
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId}  Start toasting...");
                Task.Delay(3000).Wait();
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId} Remove toast from toaster");

                return new Toast();
            }
            private static Task<Toast> ToastBreadAsync(int slices)
            {
                return Task.Run<Toast>(() => { return ToastBread(slices); });

            }

            private static Bacon FryBacon(int slices)
            {
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} putting {slices} slices of bacon in the pan");
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId}  cooking first side of bacon...");
                Task.Delay(3000).Wait();
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId}  flipping a slice of bacon");
                }
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId} cooking the second side of bacon...");
                Task.Delay(3000).Wait();
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId} Put bacon on plate");

                return new Bacon();
            }
            private static Task<Bacon> FryBaconAsync(int slices)
            {

                return Task.Run<Bacon>(() => { return FryBacon(slices); });
            }

            private static Egg FryEggs(int howMany)
            {
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId} Warming the egg pan...");
                Task.Delay(3000).Wait();
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}  cracking {howMany} eggs");
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} cooking the eggs ...");
                Task.Delay(3000).Wait();
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId}  Put eggs on plate");

                return new Egg();
            }
            private static Task<Egg> FryEggsAsync(int howMany)
            {
                return Task.Run<Egg>(() => {
                    return FryEggs(howMany);
                });
            }

            private static Coffee PourCoffee()
            {
                Console.WriteLine($" Thread : {Thread.CurrentThread.ManagedThreadId} Pouring coffee");
                return new Coffee();
            }

            public static async void PrepareBreakfast()
            {
                Coffee cup = PourCoffee();
                Console.WriteLine("coffee is ready");

                await Task.WhenAll(FryEggsAsync(2), FryBaconAsync(3));
                Console.WriteLine("eggs are ready");
                Console.WriteLine("bacon is ready");

                var toast = await ToastBreadAsync(2);
                ApplyButter(toast);
                ApplyJam(toast);
                Console.WriteLine("toast is ready");


                Juice oj = PourOJ();
                Console.WriteLine("oj is ready");
                Console.WriteLine("Breakfast is ready!");
            }
        }
        class ProgramBegin
        {

            static void Main()
            {
                System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
                _watch.Start();
              
                BreakFastDemo.PrepareBreakfast();
                _watch.Stop();
                Console.WriteLine($"Time taken to prepare breakfast {_watch.Elapsed.TotalSeconds}");
                Console.Read();
            }

        }
    }
    
}
