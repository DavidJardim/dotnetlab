using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha16
{
	internal class TestAsync
	{


		internal async Task RunAsync()
		{
			Task<string> firstTask = FirstTaskAsync(5000);
			Task<string> secondTask = SecondTaskAsync(3000);
			Task<string> thirdTask = ThirdTaskAsync(2000);

			string first = await thirdTask;
			string second = await firstTask;
			string third = await secondTask;

			Console.WriteLine(first);
			Console.WriteLine(second);
			Console.WriteLine(third);

		}

		private async Task<string> FirstTaskAsync(int time)
		{
			Console.WriteLine("Start first");
			await Task.Delay(time);
			Console.WriteLine("End first");
			return "FirstTask"; 		
		}

		private async Task<string> SecondTaskAsync(int time)
		{
			Console.WriteLine("Start second");
			await Task.Delay(time);
			Console.WriteLine("End second");
			return "SecondTask";
		}

		private async Task<string> ThirdTaskAsync(int time)
		{
			Console.WriteLine("Start third");
			await Task.Delay(time);
			Console.WriteLine("End third");
			return "ThirdTask";
		}


	}
}
