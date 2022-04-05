using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha16
{
	internal class Program
	{
		static async Task Main(string[] args)
		//static void Main(string[] args)
		{

			//var testSync = new TestSync();
			//testSync.Run();

			var testAsync = new TestAsync();
			await testAsync.RunAsync();
		}
	}
}
