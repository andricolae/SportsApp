using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public static class TournamentWork
    {
        private static List<Team> RandomTeams(List<Team> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
        private static int ComputeRounds(int teamCount)
        {
            int output = 1;
            int val = 2;
            while (val < teamCount)
            {
                output += 1;
                val *= 2;
            }
            return output;
        }
        private static int ComputeDummyRounds(int rounds, int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;
            for(int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }
            output = totalTeams - numberOfTeams;
            return output;
        }
        private static List<Matchup> CreateFirstRound(int dummy, List<Team> teams)
        {
            List<Matchup> output = new List<Matchup>();
            Matchup current = new Matchup();

            foreach(Team team in teams)
            {
                current.Entries.Add(new MatchupEntry {Team = team});
                if (dummy > 0 || current.Entries.Count > 1)
                {
                    current.MatchupRound = 1;
                    output.Add(current);
                    current = new Matchup();

                    if (dummy > 0)
                    {
                        dummy -= 1;
                    }
                }
            }
            return output;
        }
        private static void CreateRounds(Tournament tournament, int rounds)
        {
            int round = 2;
            List<Matchup> prevRound = tournament.Rounds[0];
            Matchup currentMatchup = new Matchup();
            List<Matchup> currentRound = new List<Matchup>();
            while (round <= rounds)
            {
                foreach (Matchup match in prevRound)
                {
                    currentMatchup.Entries.Add(new MatchupEntry { ParentMatchup = match });
                    if (currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.MatchupRound = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new Matchup();
                    }
                }
                tournament.Rounds.Add(currentRound);
                prevRound = currentRound;
                currentRound= new List<Matchup>();
                round += 1;
            }
        }
        public static void CreateRounds(Tournament tournament)
        {
            List<Team> randomized = RandomTeams(tournament.Teams);
            int rounds = ComputeRounds(randomized.Count);
            int dummy = ComputeDummyRounds(rounds, randomized.Count);
            tournament.Rounds.Add(CreateFirstRound(dummy, randomized));
            CreateRounds(tournament, rounds);
        }
        
    }
}
