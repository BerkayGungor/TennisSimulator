using System;
using System.Collections.Generic;
using TennisSimulator.Scripts.Core.PlayerData;

namespace TennisSimulator.Scripts.Core.TournamentData
{
    class Match
    {
        private readonly int ELIMINATION_WIN_EXP = 20;
        private readonly int ELIMINATION_LOSE_EXP = 10;
        private readonly int LEAGUE_WIN_EXP = 10;
        private readonly int LEAGUE_LOSE_EXP = 1;

        private Player _firstPlayer;
        private Player _secondPlayer;
        private List<Player> _opponents;
        private Random random;

        public List<Player> GetOpponents()
        {
            return _opponents;
        }

        public void SetOpponents(List<Player> value)
        {
            _opponents = value;
        }

        /// <summary>
        /// Sets Elimination Match.
        /// Player order is unimportant.
        /// </summary>
        /// <param name="firstPlayer">First Player Of Match.</param>
        /// <param name="secondPlayer">Second Player Of Match.</param>
        public Match(Player firstPlayer, Player secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        /// <summary>
        /// Sets league matches.
        /// Player order is important.
        /// </summary>
        /// <param name="firstPlayer"></param>
        public Match(Player firstPlayer, List<Player> opponents)
        {
            _firstPlayer = firstPlayer;
            _opponents = new List<Player>(opponents);
        }

        public void PlayMatch(string surface, string type)
        {
            // Refresh random variable every match to avoid same random seed.
            random = new Random();
            float firstPlayerPoint = CalculatePlayerPoint(_firstPlayer, _secondPlayer, surface);
            float secondPlayerPoint = CalculatePlayerPoint(_secondPlayer, _firstPlayer, surface);

            float firstPlayerWinningChance = firstPlayerPoint / (firstPlayerPoint + secondPlayerPoint);
            float secondPlayerWinningChance = secondPlayerPoint / (firstPlayerPoint + secondPlayerPoint);

            if (type == "elimination" || type == "eleme")
            {
                // First Player Wins
                if (secondPlayerWinningChance < firstPlayerWinningChance)
                {
                    _firstPlayer.IsWinner = true;
                    _firstPlayer.FinishMatch(ELIMINATION_WIN_EXP);
                    _secondPlayer.IsWinner = false;
                    _secondPlayer.FinishMatch(ELIMINATION_LOSE_EXP);
                }
                // Second Player Wins. Even if both of them have equal chance.
                else
                {
                    _secondPlayer.IsWinner = true;
                    _secondPlayer.FinishMatch(ELIMINATION_WIN_EXP);
                    _firstPlayer.IsWinner = false;
                    _firstPlayer.FinishMatch(ELIMINATION_LOSE_EXP);
                }
            }
            else
            {
                // First Player Wins
                if (secondPlayerWinningChance < firstPlayerWinningChance)
                {
                    _firstPlayer.IsWinner = true;
                    _firstPlayer.FinishMatch(LEAGUE_WIN_EXP);
                    _secondPlayer.IsWinner = false;
                    _secondPlayer.FinishMatch(LEAGUE_LOSE_EXP);
                }
                // Second Player Wins
                else
                {
                    _secondPlayer.IsWinner = true;
                    _secondPlayer.FinishMatch(LEAGUE_WIN_EXP);
                    _firstPlayer.IsWinner = false;
                    _firstPlayer.FinishMatch(LEAGUE_LOSE_EXP);
                }
            }
        }

        private float CalculatePlayerPoint(Player player, Player rival, string surface)
        {
            // Default matching point
            float matching = 1;
            // Calculate hand point
            float hand = player.Hand == "left" ? 2 : 0;
            // Calculate exp point
            float exp = player.Exp > rival.Exp ? 3 : 0;

            // Calculate ground point
            int playerSurfaceSkill = player.SurfaceSkills.GetMatchingSurfaceSkill(surface);
            int rivalSurfaceSkill = rival.SurfaceSkills.GetMatchingSurfaceSkill(surface);
            float ground = playerSurfaceSkill > rivalSurfaceSkill ? 4 : 0;

            return matching + hand + exp + ground;
        }
        /// <summary>
        /// Method to return winning player.
        /// </summary>
        /// <returns>Returns winning player object</returns>
        public Player GetWinner()
        {
            return _firstPlayer.IsWinner ? _firstPlayer : _secondPlayer;
        }

        public bool PlayMatch(Player opponent, string surface, string type)
        {
            _secondPlayer = opponent;
            PlayMatch(surface, type);
            _opponents.Remove(opponent);
            _secondPlayer = null;

            return _opponents.Count <= 0;
        }
    }
}
