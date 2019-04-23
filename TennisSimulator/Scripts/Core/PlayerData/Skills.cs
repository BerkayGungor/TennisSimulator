namespace TennisSimulator.Scripts.Core.PlayerData
{
    class Skills
    {
        #region Constants
        private readonly string INVALID_SKILLS_ERROR = "The skill variables can only receive numbers " +
            "between and equal to 1 and 10.";
        #endregion

        #region Fields
        private int _clay;
        private int _grass;
        private int _hard;
        #endregion

        /// <summary>
        /// Skills of player.
        /// </summary>
        /// <param name="clay">Players experience in clay field</param>
        /// <param name="grass">Players experience in grass field</param>
        /// <param name="hard">Players experience in hard field</param>
        public Skills(int clay, int grass, int hard)
        {
            if (!IsSkillsValid(clay, grass, hard))
            {
                throw new System.ArgumentException(INVALID_SKILLS_ERROR, "skills");
            }
            _clay = clay;
            _grass = grass;
            _hard = hard;
        }

        /// <summary>
        /// Checks if skill values are between 10 and 1.
        /// </summary>
        /// <param name="clay"></param>
        /// <param name="grass"></param>
        /// <param name="hard"></param>
        /// <returns>Returns true if skills are between 10 and 1 else returns false</returns>
        private bool IsSkillsValid(int clay, int grass, int hard)
        {
            // Check if any skill is invalid number.
            if ((1 <= clay && clay <= 10) || (1 <= grass && grass <= 10) || (1 <= hard && hard <= 10))
            {
                return true;
            }
            return false;
        }

        public int GetMatchingSurfaceSkill(string ground)
        {
            if (ground == "clay" || ground == "toprak")
            {
                return _clay;
            }
            else if (ground == "grass" || ground == "çim")
            {
                return _grass;
            }
            else
            {
                return _hard;
            }
        }
    }
}
