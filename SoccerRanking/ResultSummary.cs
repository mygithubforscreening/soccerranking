using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerRanking
{
    public class ResultSummary
    {
        int rank;
        string strTeamName;
        int points;

        public int Rank
        {
            get { return rank; }  
            set { rank = value; }
        }

        public string TeamName
        {
            get { return strTeamName; }
            set { strTeamName = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public override string ToString()
        {
            return Rank + "." + " " + TeamName + ", " + " " + Points + "pts";
        }
    }
}
