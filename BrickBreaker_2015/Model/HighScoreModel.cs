using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BrickBreaker_2015.Model;

namespace BrickBreaker_2015.Model
{
    class HighScoreModel
    {
        string playerName;
        string playerScore;

        public string PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                playerName = value;
            }
        }

        public string PlayerScore
        {
            get
            {
                return playerScore;
            }

            set
            {
                playerScore = value;
            }
        }

        public HighScoreModel(string playerName, string playerScore)
        {
            this.playerName = playerName;
            this.playerScore = playerScore;
        }
    }
}
