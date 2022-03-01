using System;
using System.Collections.Generic;
using System.IO;

namespace SoccerRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> matchCollection = new Dictionary<string, int>();

            //Create an object of Ranking class
            Ranking objRanking = new Ranking();

            //Read Sample Input file
            string strMatches = File.ReadAllText(@"../../../sample-input.txt");

            //Get Result
            var result = objRanking.AddMatch(strMatches);

            //Print Result
            var objListResultSummary = objRanking.ResultSummary(result);
            foreach (var teamResult in objListResultSummary)
            {
                Console.WriteLine(teamResult.ToString());
            }
        }
    }
}
