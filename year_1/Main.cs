using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Codejam
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//C:\Users\Jake\Documents\Visual Studio 2010\Projects\2013 CodeJame Prelims\2013 CodeJame Prelims
			//Problem1 problem1 = new Problem1("C:\\Users\\Jake\\Desktop\\codejam\\prelim\\A-large.in", "C:\\Users\\Jake\\Desktop\\codejam\\prelim\\A-large.out");
			//problem1.Execute();
			
			//Problem2 problem2 = new Problem2("C:\\Users\\Jake\\Desktop\\codejam\\prelim\\B-large.in", "C:\\Users\\Jake\\Desktop\\codejam\\prelim\\B-large.out");
			//problem2.Execute();
			
			Problem3 problem3 = new Problem3("/Users/jakewalker/Projects/Codejam/Codejam/C-small-attempt0.in", "/Users/jakewalker/Projects/Codejam/Codejam/C-small-attempt0.out");
			problem3.Execute();            
		
		}
	}
}
