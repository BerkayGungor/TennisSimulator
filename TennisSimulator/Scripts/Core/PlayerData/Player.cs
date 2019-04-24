namespace TennisSimulator.Scripts.Core.PlayerData
{
    class Player
    {
        #region Constants
        private readonly string INVALID_HAND_ERROR = "The hand variable can only receive the case-insensitive " +
            "left-right-sol-sağ values.";
        #endregion

        #region Fields
        #region Required
        private int _id;
        private int _experience;
        private string _hand;
        private Skills _skills;
        #endregion
        private bool isWinner;
        private int _initialExp;
        #endregion        

        /// <summary>
        /// Creates Player object       
        /// </summary>
        /// <param name="id">Id of player</param>
        /// <param name="hand">Dominant hand of player. 
        /// Can only be case insensitive "Left", "Right", "Sol", "Sağ" values.
        /// </param>
        /// <param name="experience">Experience of player</param>
        /// <param name="skills">Skills of player</param>
        public Player(Skills skills, int id, int experience, string hand)
        {
            if (!IsHandValid(hand))
            {
                throw new System.ArgumentException(INVALID_HAND_ERROR, "hand");
            }
            _id = id;
            _experience = experience;
            _hand = hand;
            _skills = skills;

            isWinner = false;
            _initialExp = experience;
        }

        public int Id { get => _id; private set { } }
        public int Exp { get => _experience; private set { } }
        public string Hand { get => _hand; private set { } }
        public Skills SurfaceSkills { get => _skills; private set { } }

        public bool IsWinner { get => isWinner; set => isWinner = value; }
        public int InitialExp { get => _initialExp; private set { } }

        /// <summary>
        /// Checks if hand value is either "left", "right", "sol", "sağ" value.
        /// This function works case insensitive.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>returns true if value is valid else returns false.</returns>
        private bool IsHandValid(string hand)
        {
            string caseInsentiveHand = hand.ToLower();
            if (caseInsentiveHand == "left" || caseInsentiveHand == "right")
            {
                return true;
            }
            else if (caseInsentiveHand == "sol" || caseInsentiveHand == "sağ")
            {
                return true;
            }
            return false;
        }

        public void FinishMatch(int earnedExp)
        {
            _experience = _experience + earnedExp;
        }
    }
}
