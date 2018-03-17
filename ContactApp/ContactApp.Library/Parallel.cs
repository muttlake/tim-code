using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactApp.Library
{
    public class Parallel
    {
        public void WorkWithThread()
        {
            var t1 = new Thread(() => {
                RunMethod(100, 'A');  // Run 100 times
            });

            var t2 = new Thread(() => {
                RunMethod(100, 'B');  // Run 10 times
            });

            t1.Start();
            t2.Start(); //Actually have 3 threads after this, t1, t2, and the main thread
                        // t0, t1, and t2 and the t0 is what runs the program

            t1.Join(); // Go back into the main thread
            t2.Join();
        }

        public void WorkWithTask()
        {
            var t1 = new Task(() => {
                RunMethod(10000, 'A');  // Run 100 times
            });

            var t2 = new Task(() => {
                RunMethod(10000, 'B');  // Run 10 times
            });


            t1.Start(); //t0 happens too fast, so by time it is done, t1 and t2 have not started
            t2.Start();

            //Task.WaitAll(t1, t2); // tell t0 to wait for t1 and t2
            Task.WaitAll(new Task[] {t1, t2}, 1000); // tell t0 to wait for t1 and t2 for 1 ms
            //The platform handles your own thread
            //Microsoft wrote Task
        }


        // The work that you are doing is the task
        public async Task WorkWithAsync()
        {
            await Task.Run(() => {
                RunMethod(1000, 'C');
            });
        }

        private void RunMethod(int i, char ch)
        {
            var c = 0;
            while(c < i)
            {
                Console.Write(ch);
                c += 1;
            }
        }
    }
}