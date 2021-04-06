using System;

namespace ClassDemoOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatorWorker worker = new OperatorWorker();
            worker.Start();

            Console.WriteLine("Finish");
        }
    }
}
