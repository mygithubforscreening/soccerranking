using System;
using System.Collections.Generic;
using System.IO;

namespace SoccerRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            string strGames = string.Empty;
            string strInputFile = string.Empty;
            Dictionary<string, int> matchCollection = new Dictionary<string, int>();

            if (args != null && args.Length > 0)
            {
                try
                {
                    if (File.Exists(args[0]))
                    {
                        strInputFile = args[0];

                        //Create an object of Ranking class
                        Ranking objRanking = new Ranking();

                        //Read From Input file
                        strGames = File.ReadAllText(strInputFile);

                        //Get Result
                        var result = objRanking.AddMatch(strGames);

                        //Print Result
                        var objListResultSummary = objRanking.ResultSummary(result);
                        foreach (var teamResult in objListResultSummary)
                        {
                            Console.WriteLine(teamResult.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input File Not Exist or Invalid Parameter");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input File may be invalid or someother error!");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Input File not passed");
            }
        }       
    }
}