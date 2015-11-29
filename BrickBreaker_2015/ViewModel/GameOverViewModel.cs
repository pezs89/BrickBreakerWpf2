using BrickBreaker_2015.DataAccess;
using BrickBreaker_2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for GameOverViewModel.
    /// </summary>
    class GameOverViewModel
    {
        #region Fields

        // The scores xml access.
        private ScoresXmlAccess scoresXmlAccess;

        // The error log viewmodel.
        private ErrorLogViewModel errorLogViewModel;

        // The list of scores.
        private List<HighScoreModel> highscoreList;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public GameOverViewModel()
        {
            try
            {
                errorLogViewModel = new ErrorLogViewModel();
                scoresXmlAccess = new ScoresXmlAccess();
                highscoreList = scoresXmlAccess.LoadScores();
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Checks if the player's scores can be in the highscores.
        /// </summary>
        /// <param name="playerScore">The player's score.</param>
        /// <returns></returns>
        public bool CheckScore(int playerScore)
        {
            try
            {
                highscoreList.Sort((x, y) => int.Parse(y.PlayerScore).CompareTo(int.Parse(x.PlayerScore)));
                bool returnValue = false;

                for (int i = 0; i < highscoreList.Count; i++)
                {
                    if (int.Parse(highscoreList[i].PlayerScore) < playerScore)
                    {
                        if (!returnValue)
                        {
                            returnValue = true;
                        }
                    }
                }

                return returnValue;
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
                return false;
            }
        }

        /// <summary>
        /// Saves the player's score in the highscores.
        /// </summary>
        /// <param name="playerName">The player's name.</param>
        /// <param name="playerScore">The player's score.</param>
        public void SaveScore(string playerName, int playerScore)
        {
            try
            {
                highscoreList.Add(new HighScoreModel(playerName, playerScore.ToString()));
                highscoreList.Sort((x, y) => int.Parse(y.PlayerScore).CompareTo(int.Parse(x.PlayerScore)));
                highscoreList.RemoveAt(10);

                scoresXmlAccess.SaveScore(highscoreList);
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        #endregion Methods
    }
}
