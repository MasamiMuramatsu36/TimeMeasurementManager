using Dll;

namespace UseCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rootStopWatch = new StopWatchNode("test");
            StopWatchManager.SetRootStopWatch(rootStopWatch);
            StopWatchManager.AddChildStopWatch(new StopWatchNode("sub1"));
            StopWatchManager.AddChildStopWatch(new StopWatchNode("sub2"));
            StopWatchManager.AddChildStopWatch(new StopWatchNode("sub3"));

            Method1();

            var result = StopWatchManager.GetAllStopWatchInfo();
            Console.WriteLine(result);
        }

        private static void Method1()
        {
            Task.Delay(1000).Wait();
            Task.Delay(1000).Wait();
            Task.Delay(1000).Wait();
        }
    }
}
