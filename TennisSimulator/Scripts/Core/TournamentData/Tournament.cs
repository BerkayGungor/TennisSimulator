using System.Collections.Generic;
using TennisSimulator.Scripts.Core.PlayerData;

namespace TennisSimulator.Scripts.Core.TournamentData
{
    class Tournament
    {
        #region Constants
        private readonly string INVALID_SURFACE_ERROR = "The surface variable can only receive the case-insensitive " +
            "clay-grass-hard-toprak-çim-sert values.";
        private readonly string INVALID_TYPE_ERROR = "The type variable can only receive the case-insensitive " +
            "elimination-league-eleme-lig values.";
        #endregion

        #region Fields
        private int _id;
        private string _surface;
        private string _type;
        private List<Match> _matches = new List<Match>();

        public int Id { get => _id; private set { } }
        #endregion

        public Tournament(int id, string surface, string type)
        {
            if (!IsSurfaceValid(surface))
            {
                throw new System.ArgumentException(INVALID_SURFACE_ERROR, "surface");
            }
            if (!IsTypeValid(type))
            {
                throw new System.ArgumentException(INVALID_TYPE_ERROR, "type");
            }
            _id = id;
            _surface = surface;
            _type = type;
        }

        /// <summary>
        /// Checks if surface value is equal to
        /// clay-grass-hard-toprak-çim-sert values.
        /// This function works case insensitive.
        /// </summary>
        /// <param name="surface"></param>
        /// <returns>Returns true if surface is valid else returns false</returns>
        private bool IsSurfaceValid(string surface)
        {
            string caseInsensitiveSurface = surface.ToLower();
            if (caseInsensitiveSurface == "clay" || caseInsensitiveSurface == "grass" || caseInsensitiveSurface == "hard")
            {
                return true;
            }
            else if (caseInsensitiveSurface == "toprak" || caseInsensitiveSurface == "çim" || caseInsensitiveSurface == "sert")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if type value is equal to
        /// elimination-league-eleme-lig values.
        /// This function works case insensitive.
        /// </summary>
        /// <param name="surface"></param>
        /// <returns>Returns true if type value is valid else returns false.</returns>
        private bool IsTypeValid(string type)
        {
            string caseInsensitiveType = type.ToLower();
            if (caseInsensitiveType == "elimination" || caseInsensitiveType == "league")
            {
                return true;
            }
            else if (caseInsensitiveType == "eleme" || caseInsensitiveType == "lig")
            {
                return true;
            }
            return false;
        }

        public void SetMatches(List<Player> players)
        {
            _matches.Clear();

            if (_type == "elimination")
            {
                PairEliminationPlayers(players);
            }
            else
            {
                PairLeaguePlayers(players);
            }
        }

        private void PairEliminationPlayers(List<Player> players)
        {
            for (int i = 0; i < players.Count; i = i + 2)
            {
                _matches.Add(new Match(players[i], players[i + 1]));
            }
        }

        private void PairLeaguePlayers(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                int nextIndex = i + 1;
                _matches.Add(new Match(players[i], players.GetRange(nextIndex, players.Count - nextIndex)));
            }
        }

        public void PlayMatches()
        {
            if (_type == "elimination" || _type == "eleme")
            {
                PlayEliminationMatches(_matches);
            }
            else
            {
                PlayLeagueMatches(_matches);
            }
        }

        private void PlayEliminationMatches(List<Match> matches)
        {
            List<Player> players = new List<Player>();

            foreach (Match match in matches)
            {
                match.PlayMatch(_surface, _type);
                Player winner = match.GetWinner();
                players.Add(winner);
                winner.IsWinner = false;
            }
            matches.Clear();
            PairEliminationPlayers(players);
            PlayEliminationMatches(_matches);
        }

        private void PlayLeagueMatches(List<Match> matches)
        {
            System.Random random = new System.Random();

            int randomMatch = random.Next(0, matches.Count);
            Match currentMatch = matches[randomMatch];

            List<Player> opponents = currentMatch.GetOpponents();
            int randomOpponent = random.Next(0, opponents.Count);
            Player opponent = opponents[randomOpponent];
            opponent;
        }
    }
}
