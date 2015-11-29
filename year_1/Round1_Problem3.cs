using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Codejam
{
	public class Round1_Problem3
	{
		StreamReader sr;
		StreamWriter sw;
		public Round1_Problem3(string infile, string outfile)
		{
			sr = new StreamReader(infile);
			sw = new StreamWriter(outfile);
		}
		public void Execute()
		{
			int[] xCountVert = new int[4];
			int[] xCountHor = new int[4];
			int[] xCountDiag = new int[2]; 
			int[] oCountVert = new int[4];
			int[] oCountHor = new int[4];
			int[] oCountDiag = new int[2];
			int totalSpaceCount;
			
			
			int NumCases = int.Parse(sr.ReadLine());
			for (int k = 0; k < NumCases; k++ )
			{
				//clear values
				for (int i = 0; i < 4; i++)
				{
					xCountVert[i] = 0;
					xCountHor[i] = 0;
					oCountVert[i] = 0; 
					oCountHor[i] = 0;
				}
				for (int i = 0; i < 2; i++)
				{
					xCountDiag[i] = 0;
					oCountDiag[i] = 0;
				}
				totalSpaceCount = 0;
				//TODO: implement diagonals
				for(int i = 0; i < 4; i++)
				{
					string line = sr.ReadLine();
					for (int j = 0; j < 4; j++)
					{
						switch (line[j])
						{
						case 'x':
						case 'X':
						{
							xCountVert[i]++;
							xCountHor[j]++;
							if (i == j)
							{
								xCountDiag[0]++;
							}
							if (i == (3 - j))
							{
								xCountDiag[1]++;
							}
							break;
						}
						case 'o':
						case 'O':
						{
							oCountVert[i]++;
							oCountHor[j]++;
							if (i == j)
							{
								oCountDiag[0]++;
							}
							if (i == (3 - j))
							{
								oCountDiag[1]++;
							}
							break;
						}
						case 't':
						case 'T':
						{
							xCountVert[i]++;
							xCountHor[j]++;
							oCountVert[i]++;
							oCountHor[j]++;
							if (i == j)
							{
								xCountDiag[0]++;
								oCountDiag[0]++;
							}
							if (i == (3 - j))
							{
								xCountDiag[1]++;
								oCountDiag[1]++;
							}
							break;
						}
						case '.':
						default:
						{
							totalSpaceCount++;
							break;
						}
						}  
					}
				}
				
				//assumes we never get passed in an ill-formed board (i.e. both x and o have won the game)
				
				string result = "";
				for (int i = 0; i < 4; i++)
				{ 
					if(xCountVert[i] == 4 || xCountHor[i] == 4 || ((i < 2) && xCountDiag[i] == 4))
					{
						result = "X won";
					}
					else if (oCountVert[i] == 4 || oCountHor[i] == 4 || ((i < 2) && oCountDiag[i] == 4))
					{
						result = "O won";
					}
				}
				if (result == "")
				{ 
					//nobody won...draw or incomplete?
					if (totalSpaceCount > 0)
					{
						result = "Game has not completed";
					}
					else
					{
						result = "Draw";
					}
				}
				sw.WriteLine(String.Format("Case #{0}: {1}", k + 1, result));
				//read the blank line to prepare for the next case
				sr.ReadLine();
			}
			
			
			sw.Close();
			sr.Close();
		}
	}
}

