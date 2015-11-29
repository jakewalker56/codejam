using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _2013_CodeJame_Prelims
{
    class Problem2
    {
        StreamReader sr;
        StreamWriter sw;
        public Problem2(string infile, string outfile)
        {
            sr = new StreamReader(infile);
            sw = new StreamWriter(outfile);
        }
        public void Execute()
        {
            //Algorithm: a square is cuttable if it is greater than or equal to the tallest square in its row OR its collumn.  
            //  i.e., you have to either cut row j or column i to cut square i,j, so if s(i,j) needs to be shorter than someone in row j or column i, you're hosed
            //  not sure if this is sufficient, or simply neccessary.  Hopefully sufficient, because otherwise I don't know the right algorithm :p

            //Also: yay for the garbage collector!

            int NumCases = int.Parse(sr.ReadLine());
            for (int k = 0; k < NumCases; k++)
            {
                string sizeLine = sr.ReadLine();
                //Console.WriteLine(String.Format("read line as size values: {0}", sizeLine));
                int numRows = int.Parse(sizeLine.Split(' ')[0]);
                int numColumns = int.Parse(sizeLine.Split(' ')[1]);

                int[] maxHeightPerRow = new int[numRows];
                int[] maxHeightPerColumn = new int[numColumns];
                int[][] lawnHeight = new int[numRows][];
                for (int i = 0; i < numRows; i++)
                {
                    lawnHeight[i] = new int[numColumns];
                }

                //fill out lawn array
                //calculate max height per row, max height per column    
                for (int i = 0; i < numRows; i++)
                {
                    string heightLine = sr.ReadLine();
                    //Console.WriteLine(String.Format("read line as height values: {0}", heightLine));

                    string[] heightValues = heightLine.Split(' ');
                    for (int j = 0; j < numColumns; j++)
                    {
                        //Console.WriteLine(heightValues[j]);
                        lawnHeight[i][j] = int.Parse(heightValues[j]);
                        if (lawnHeight[i][j] > maxHeightPerColumn[j])
                        {
                            maxHeightPerColumn[j] = lawnHeight[i][j];
                        }
                        if (lawnHeight[i][j] > maxHeightPerRow[i])
                        {
                            maxHeightPerRow[i] = lawnHeight[i][j];
                        }
                    }
                }


                //for each square, test if we can cut it.  If not, we fail
                bool keepTrying = true;
                for (int i = 0; (i < numRows) && (keepTrying); i++)
                {
                    for (int j = 0; j < numColumns; j++)
                    {
                        if (lawnHeight[i][j] < maxHeightPerColumn[j] && lawnHeight[i][j] < maxHeightPerRow[i])
                        {
                            //Console.WriteLine(String.Format("failing attempt because lawnHeight is {0}, which is smaller than columnHeight {1} and rowHeight {2}", lawnHeight[i][j], maxHeightPerColumn[j], maxHeightPerRow[i]));
                            keepTrying = false;
                            break;
                        }
                    }
                }

                //assumes we never get passed in an ill-formed lawn (i.e. we're not doing any error handling)

                string result = "";
                if (keepTrying)
                {
                    result = "YES";
                }
                else
                {
                    result = "NO";
                }

                sw.WriteLine(String.Format("Case #{0}: {1}", k + 1, result));
            }


            sw.Close();
            sr.Close();
        }
    }
}
