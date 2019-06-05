﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        //Order our list of teams randomly
        //Check if it is big enough - if not, add in byes
        //Create our first round of matchups
        //Create every round after that

        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

            CreateOtherRounds(model, rounds);
        }

        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRound = model.Rounds[0];
            List<MatchupModel> currentRound = new List<MatchupModel>();
            MatchupModel currentMatchup = new MatchupModel();

            while(round <= rounds)
            {
                foreach(MatchupModel match in previousRound)
                {
                    currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    if(currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.MatchupRound = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new MatchupModel();
                    }
                }

                model.Rounds.Add(currentRound);
                previousRound = currentRound;
                currentRound = new List<MatchupModel>();
                round += 1;
            }
        }

        private static List<MatchupModel> CreateFirstRound(int numberOfByes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel currentModel = new MatchupModel();

            foreach(TeamModel team in teams)
            {
                currentModel.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                if(numberOfByes > 0 || currentModel.Entries.Count > 1)
                {
                    currentModel.MatchupRound = 1;
                    output.Add(currentModel);
                    currentModel = new MatchupModel();

                    if(numberOfByes > 0)
                    {
                        numberOfByes -= 1;
                    }
                }
            }

            return output;
        }

        private static int NumberOfByes(int rounds, int numberOfTeams)
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

        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while(val < teamCount)
            {
                output += 1;
                val *= 2;
            }

            return output;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> model)
        {
            return model.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
