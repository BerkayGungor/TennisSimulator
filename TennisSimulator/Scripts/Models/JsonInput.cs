using System.Collections.Generic;
using TennisSimulator.Scripts.Core.PlayerData;
using TennisSimulator.Scripts.Core.TournamentData;

namespace TennisSimulator.Scripts.Models
{
    class JsonInput
    {
        private List<Player> _players;
        private List<Tournament> _tournaments;


        public JsonInput(List<Player> players, List<Tournament> tournaments)
        {
            _players = players;
            _tournaments = tournaments;
        }

        internal List<Player> Players { get => _players; private set { } }
        internal List<Tournament> Tournaments { get => _tournaments; private set { } }
    }
}
