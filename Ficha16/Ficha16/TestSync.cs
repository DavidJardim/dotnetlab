using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha16
{
	internal class TestSync
	{
		internal void Run()
		{
			RunFirst();
			RunSecond();
			RunThird();
		}

		private void RunThird()
		{
			Console.WriteLine("RunThird");
			// wait is blocking
			Task.Delay(2000).Wait();
		}

		private void RunSecond()
		{
			Console.WriteLine("RunSecond");
			Task.Delay(2000).Wait();
		}

		private void RunFirst()
		{
			Console.WriteLine("RunFirst");
			Task.Delay(2000).Wait();
		}
	}
}
