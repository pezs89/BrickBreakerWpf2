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

        // The limit of the saved highscores.
        private int highscoreLimit = 10;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GameOverViewModel"/> class.
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
                // Sort the scores in descending order.
                highscoreList.Sort((x, y) => int.Parse(y.PlayerScore).CompareTo(int.Parse(x.PlayerScore)));
                bool returnValue = false;

                // Check each highscore.
                for (int i = 0; i < highscoreList.Count; i++)
                {
                    // The player's score is bigger then any of the highscores.
                    if (int.Parse(highscoreList[i].PlayerScore) < playerScore)
                    {
                        // No mach found previously. 
                        if (!returnValue)
                        {
                            returnValue = true;
                            break;
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
                // Add the player's score and sort the scores in descending order.
                highscoreList.Add(new HighScoreModel(playerName, playerScore.ToString()));
                highscoreList.Sort((x, y) => int.Parse(y.PlayerScore).CompareTo(int.Parse(x.PlayerScore)));

                // Remove the extra ones.
                if (highscoreList.Count >= highscoreLimit)
                {
                    int i = highscoreList.Count - 1;

                    while (i >= highscoreLimit)
                    {
                        highscoreList.RemoveAt(i);
                        i--;
                    }
                }

                // Save the scores.
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
