using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Scripts.Core.PlayerData;
using TennisSimulator.Scripts.Core.TournamentData;
using TennisSimulator.Scripts.Models;

namespace TennisSimulator.Scripts.Mechanics
{
    class TournamentManager
    {
        public JsonOutput ManageAndPlayTournaments(List<Tournament> tournaments, List<Player> players)
        {
            tournaments = tournaments.OrderBy(tournament => tournament.Id).ToList();
            players = players.OrderBy(player => player.Id).ToList();
            foreach (Tournament tournament in tournaments)
            {
                tournament.SetMatches(players);
                tournament.PlayMatches();
            }
            // Sort players by exp.
            players.Sort(ComparePlayers);
            return new JsonOutput {
                results = PrepareResults(players)
            };
        }

        private int ComparePlayers(Player firstPlayer, Player secondPlayer)
        {
            if (firstPlayer.Exp > secondPlayer.Exp)
            {
                return -1;
            }
            else if (firstPlayer.Exp < secondPlayer.Exp)
            {
                return 1;
            }
            // They are equal
            else
            {
                if (firstPlayer.InitialExp > secondPlayer.InitialExp)
                {
                    return -1;
                }
                else if (firstPlayer.InitialExp < secondPlayer.InitialExp)
                {
                    return 1;
                }
                // Initial exps are equal. 
                // At this point, pdf does not give any info about what to do. 
                // So, just sort them with normal comparison.
                else
                {
                    return firstPlayer.InitialExp.CompareTo(secondPlayer.InitialExp);
                }
            }
        }

        private List<Result> PrepareResults(List<Player> players)
        {
            List<Result> results = new List<Result>();

            for (int i = 0; i < players.Count; i++)
            {
                Result result = new Result
                {
                    order = i + 1,
                    player_id = players[i].Id,
                    gained_experience = players[i].Exp - players[i].InitialExp,
                    total_experience = players[i].Exp
                };
                results.Add(result);
            }

            return results;
        }
    }
}
