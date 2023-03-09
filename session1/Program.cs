using System;
using System.Threading;

class Program
{
    private static int[] arr = new int[300];

    static void Main(string[] args)
    {
        // Initialize the array
        for (int i = 0; i < 300; i++)
        {
            arr[i] = i + 1;
        }

        // Create 3 threads to sum the elements in each range
        SumThread t1 = new SumThread(0, 100);
        SumThread t2 = new SumThread(100, 200);
        SumThread t3 = new SumThread(200, 300);

        // Start the threads
        t1.Start();
        t2.Start();
        t3.Start();

        // Wait for all threads to finish
        t1.Join();
        t2.Join();
        t3.Join();

        // Sum the results from each thread
        int result = t1.Result + t2.Result + t3.Result;

        // Display the final result
        Console.WriteLine("The sum of the elements in the array is: " + result);
    }

    class SumThread
    {
        private int start;
        private int end;
        private int result;
        private Thread thread;

        public SumThread(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public void Start()
        {
            // Create a new thread to execute the sum operation
            thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        public void Join()
        {
            // Wait for the thread to finish
            thread.Join();
        }

        public int Result
        {
            get { return result; }
        }

        private void Run()
        {
            for (int i = start; i < end; i++)
            {
                result += arr[i];
            }
        }
    }
}
