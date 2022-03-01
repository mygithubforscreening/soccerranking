using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerRanking;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        public void TestValidGames()
        {
            Ranking objSoccerRanking = new Ranking();

            string strMatches = "Lions 2, Snakes 3\r\nTarantulas 1, FC Awesome 0\r\nLions 3, FC Awesome 1\r\nTarantulas 3, Snakes 1\r\nLions 0, Grouches 1";

            var result = objSoccerRanking.AddMatch(strMatches);

            //Print Result
            var objListResultSummary = objSoccerRanking.ResultSummary(result);

            Assert.AreEqual(objListResultSummary[0].TeamName, "Tarantulas", "The winner is Tarantulas");
            Console.WriteLine("Test Case Name - TestValidGames. Result Pass - The winner is Tarantulas");
        }
        [TestMethod]
        public void TestMultipleWinners()
        {
            Ranking objSoccerRanking = new Ranking();

            string strMatches = "Lions 4, Snakes 3\r\nTarantulas 1, FC Awesome 0\r\nLions 3, FC Awesome 1\r\nTarantulas 3, Snakes 1\r\nLions 0, Grouches 1";

            var result = objSoccerRanking.AddMatch(strMatches);

            //Print Result
            var objListResultSummary = objSoccerRanking.ResultSummary(result);

            Assert.IsTrue(objListResultSummary[0].Rank == 1 && objListResultSummary[1].Rank == 1, "We have multiple winners");
            Console.WriteLine("Test Case Name - TestMultipleWinners. Result Pass - We have multiple winners");
        }

        [TestMethod]
        public void TestSameRank()
        {
            Ranking objSoccerRanking = new Ranking();

            string strMatches = "Lions 3, Snakes 3\r\nTarantulas 1, FC Awesome 0\r\nLions 1, FC Awesome 1\r\nTarantulas 3, Snakes 1\r\nLions 4, Grouches 1";

            var result = objSoccerRanking.AddMatch(strMatches);

            //Print Result
            var objListResultSummary = objSoccerRanking.ResultSummary(result);

            Assert.IsTrue(objListResultSummary[2].Rank == 3 && objListResultSummary[2].Rank == 3, "Two teams with same points has the same ranks");
            Console.WriteLine("Test Case Name - TestSameRank. Result Pass - Two teams with same points has the same ranks");
        }

        [TestMethod]
        public void TestRankChangedAfterAValidMatch()
        {
            Ranking objSoccerRanking = new Ranking();

            string strMatches = "Lions 2, Snakes 3\r\nTarantulas 1, FC Awesome 0\r\nLions 3, FC Awesome 1\r\nTarantulas 3, Snakes 1\r\nLions 0, Grouches 1";

            var result = objSoccerRanking.AddMatch(strMatches);

            //Print Result
            var objListResultSummary = objSoccerRanking.ResultSummary(result);

            Assert.AreEqual(objListResultSummary[0].TeamName, "Tarantulas", "The winner is Tarantulas");

            //Add another match
            strMatches = "Lions 2, Snakes 3\r\nTarantulas 1, FC Awesome 0\r\nLions 3, FC Awesome 1\r\nTarantulas 3, Snakes 1\r\nLions 0, Grouches 1\r\nLions 3, Snakes 1\r\nLions 2, Tarantulas 0";

            //Check result
            result = objSoccerRanking.AddMatch(strMatches);

            //Compile result
            objListResultSummary = objSoccerRanking.ResultSummary(result);

            //Validate that new winner is Lions
            Assert.AreEqual(objListResultSummary[0].TeamName, "Lions", "The winner is Lions");
            Console.WriteLine("Test Case Name - TestRankChangedAfterAValidMatch. Result Pass - The winner is Lions");
        }

        [TestMethod]
        public void TestNoMatchPlayed()
        {
            Ranking objSoccerRanking = new Ranking();

            string strMatches = "";

            var result = objSoccerRanking.AddMatch(strMatches);

            //Print Result
            var objListResultSummary = objSoccerRanking.ResultSummary(result);

            Assert.IsTrue(objListResultSummary.Count == 0, "There are no matches played");
            Console.WriteLine("Test Case Name - TestNoMatchPlayed. Result: Pass - There are no matches played");
        }
    }
}
