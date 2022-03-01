using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace SoccerRanking
{
    public class Ranking
    {
        public Ranking()
        {

        }

        public Dictionary<string, int> AddMatch(string strMatches)
        {
            Dictionary<string, int> matchCollection = new Dictionary<string, int>();

            //Read input file line by line
            foreach (string match in strMatches.Split(Environment.NewLine))
            {
                //Spilt result from each row
                string[] strTeams = match.Split(',');

                //Check if either of string is empty or null, if yes - continue to next match
                if (!string.IsNullOrWhiteSpace(strTeams[0]) && !string.IsNullOrWhiteSpace(strTeams[1]))
                {
                    //Get Each Team's Goals scored
                    int teamNumber1 = Regex.Matches(strTeams[0], @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).FirstOrDefault();
                    int teamNumber2 = Regex.Matches(strTeams[1], @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).FirstOrDefault();

                    var teamName1 = Regex.Matches(strTeams[0], @"^[a-zA-Z\s]+").OfType<Match>().Select(x => x.Value).FirstOrDefault().Trim();
                    var teamName2 = Regex.Matches(strTeams[1], @"[a-zA-Z\s]+").OfType<Match>().Select(x => x.Value).FirstOrDefault().Trim();

                    //Check if any teamname or team score is not valid. if invalid - then continue to next match
                    if (string.IsNullOrWhiteSpace(teamName1) || string.IsNullOrWhiteSpace(teamName2) || teamNumber1 <= Int32.MinValue || teamNumber1 >= Int32.MaxValue || teamNumber2 <= Int32.MinValue || teamNumber2 >= Int32.MaxValue)
                    {
                        continue;
                    }

                    //Initialization of Team 1 and Team 2 with score 0
                    //This will make sure that we will always has Team available in the collection.
                    if (!matchCollection.ContainsKey(teamName1))
                    {
                        matchCollection.TryAdd(teamName1, 0);
                    }

                    if (!matchCollection.ContainsKey(teamName2))
                    {
                        matchCollection.TryAdd(teamName2, 0);
                    }

                    //Winning team will get 3 points added to their existing score, draw is worth 1 point.
                    if (teamNumber1 > teamNumber2)
                    {
                        matchCollection[teamName1] = matchCollection[teamName1] + 3;

                    }
                    else if (teamNumber1 < teamNumber2)
                    {
                        matchCollection[teamName2] = matchCollection[teamName2] + 3;
                    }
                    else
                    {
                        matchCollection[teamName1] = matchCollection[teamName1] + 1;
                        matchCollection[teamName2] = matchCollection[teamName2] + 1;
                    }
                }
            }
            return matchCollection;
        }

        public List<ResultSummary> ResultSummary(Dictionary<string, int> result)
        {
            StringBuilder strResult = new StringBuilder();
            List<ResultSummary> objListResultSummary = new List<ResultSummary>();

            int iPreviousPoint = -1;
            int iRank = 0;
            int iSkipRank = 0;

            foreach (KeyValuePair<string, int> team in result.OrderBy(y => y.Key).OrderByDescending(i => i.Value))
            {
                if (team.Value != iPreviousPoint)
                {
                    iRank++;
                    iRank = iRank + iSkipRank;
                    iSkipRank = 0;
                }
                else
                {
                    iSkipRank++;
                }
                ResultSummary objResultSummary = new ResultSummary();
                objResultSummary.Rank = iRank;
                objResultSummary.TeamName = team.Key;
                objResultSummary.Points = team.Value;
                objListResultSummary.Add(objResultSummary);

                iPreviousPoint = team.Value;
                
            }
            return objListResultSummary;
        }
    }
}
