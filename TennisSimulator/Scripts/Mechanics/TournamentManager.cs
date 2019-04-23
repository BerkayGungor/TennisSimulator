using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Scripts.Core.PlayerData;
using TennisSimulator.Scripts.Core.TournamentData;

namespace TennisSimulator.Scripts.Mechanics
{
    class TournamentManager
    {
        public TournamentManager(List<Tournament> tournaments, List<Player> players)
        {
            tournaments = tournaments.OrderBy(tournament => tournament.Id).ToList();
            players = players.OrderBy(player => player.Id).ToList();
            foreach (Tournament tournament in tournaments)
            {
                tournament.SetMatches(players);
                tournament.PlayMatches();
            }
        }
    }
}
