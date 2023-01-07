using System;
namespace dotnet.Helpers
{
	public class SleepHelper
	{
		public static void Sleep(int Min, int Max)
		{
            Random Random = new Random();
            int SleepTime = Random.Next(Min * 1000, Max * 1000);
            System.Threading.Thread.Sleep(SleepTime);
        }

        public static void Sleep(int Value)
        {
            System.Threading.Thread.Sleep(Value * 1000);
        }
    }
}

