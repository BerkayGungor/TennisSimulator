using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using TennisSimulator.Scripts.Models;

namespace TennisSimulator.Scripts.Mechanics
{
    class SimulationManager
    {
        private readonly string EMPTY_JSON_ERROR = "Json file cannot be empty and must be of valid format declared in the case file";
        private readonly string EMPTY_VALUES_ERROR = "Json player and/or tournament values cannot be empty.";
        private readonly string ODD_PLAYER_ERROR = "The number of player cannot be odd. Number of players must be 2 or multiples of 2.";

        public SimulationManager(string jsonFileName)
        {
            try
            {
                ParseJson(jsonFileName);
            }
            catch (System.ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ParseJson(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string json = streamReader.ReadToEnd();
                if (json != null && json != "")
                {
                    try
                    {
                        JsonInput input = JsonConvert.DeserializeObject<JsonInput>(json);
                        if (input != null)
                        {
                            if (input.Players.Count > 0 && input.Tournaments.Count > 0)
                            {
                                if (input.Players.Count % 2 == 0)
                                {
                                    TournamentManager tournamentManager = new TournamentManager(input.Tournaments, input.Players);
                                }
                                else
                                {
                                    throw new System.ArgumentException(ODD_PLAYER_ERROR, "json");
                                }
                            }
                            else
                            {
                                throw new System.ArgumentException(EMPTY_VALUES_ERROR, "json");
                            }
                        }
                        else
                        {
                            throw new System.ArgumentException(EMPTY_JSON_ERROR, "json");
                        }
                    }
                    catch (System.ArgumentException exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                else
                {
                    throw new System.ArgumentException(EMPTY_JSON_ERROR, "json");
                }
            }
        }
    }
}
