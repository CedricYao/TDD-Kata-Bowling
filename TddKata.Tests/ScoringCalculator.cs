using System;

namespace TddKata.Tests
{
    public class ScoringCalculator
    {
        public const char MISS = '-';
        public const char SPARE = '/';
        public int Score(string game)
        {
            if (game == String.Empty)
            {
                return 0;
            }

            var frames = game.Split(" ");
            var score = 0;
            bool previousRollWasSpare = false; 
            foreach (var frame in frames)
            {
                var roll1 = frame[0];
                var roll2 = frame[1];
                if (roll2 == SPARE)
                {
                    if (previousRollWasSpare && roll1 != MISS)
                    {
                        score += int.Parse(roll1.ToString());
                    }
                    score += 10;
                    previousRollWasSpare = true;
                }
                else
                {
                    if (roll1 != MISS)
                    {
                        score += int.Parse(roll1.ToString());
                        if (previousRollWasSpare)
                        {
                            score += int.Parse(roll1.ToString());
                        }
                    }
                    previousRollWasSpare = false;
                    if (roll2 != MISS)
                    {
                        score += int.Parse(roll2.ToString());
                    }
                }

            }


            return score;
        }
    }
}