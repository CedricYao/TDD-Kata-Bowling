using System;
using System.Linq;

/// <summary>
/// A class to calculate the score of a bowling game.
/// </summary>
public class ScoringCalculator2
{
    /// <summary>
    /// The character representing a miss.
    /// </summary>
    public const char MISS = '-';

    /// <summary>
    /// The character representing a spare.
    /// </summary>
    public const char SPARE = '/';

    /// <summary>
    /// The character representing a strike.
    /// </summary>
    public const char STRIKE = 'X';

    /// <summary>
    /// Calculates the score of a bowling game.
    /// </summary>
    /// <param name="game">The string representing the game.</param>
    /// <returns>The score of the game.</returns>
    public int Score(string game)
    {
        if (game == String.Empty)
        {
            return 0;
        }
    
        var frames = game.Split(" ");
        var score = 0;
        bool previousRollWasSpare = false; // Whether the previous roll was a spare.
        bool previousRollWasStrike = false; // Whether the previous roll was a strike.
    
        foreach (var frame in frames)
        {
            var roll1 = frame[0]; // The first roll of the frame.
            if (roll1 == STRIKE)
            {
                // If the first roll is a strike, add 10 points.
                score += 10;
                // If the previous roll was also a strike, add the first roll of the current frame.
                if (previousRollWasStrike)
                {
                    score += int.Parse(roll1.ToString());
                }
                // Set the previous roll was strike flag to true.
                previousRollWasStrike = true;
                break;
            }
            else
            {
                // If the first roll is not a strike, set the previous roll was strike flag to false.
                previousRollWasStrike = false;
            }
    
            var roll2 = frame[1]; // The second roll of the frame.
            if (roll2 == SPARE)
            {
                // If the second roll is a spare, add 10 points.
                score += 10;
                // If the previous roll was also a spare, add the first roll of the current frame.
                if (previousRollWasSpare && roll1 != MISS)
                {
                    score += int.Parse(roll1.ToString());
                }
                // Set the previous roll was spare flag to true.
                previousRollWasSpare = true;
            }
            else
            {
                // If the second roll is not a spare, add the first roll.
                if (roll1 != MISS)
                {
                    score += int.Parse(roll1.ToString());
                    // If the previous roll was a spare, add the first roll of the current frame.
                    if (previousRollWasSpare || previousRollWasStrike)
                    {
                        score += int.Parse(roll1.ToString());
                    }
                }
                // Set the previous roll was spare flag to false.
                previousRollWasSpare = false;
                // If the second roll is not a miss, add the second roll.
                if (roll2 != MISS)
                {
                    score += int.Parse(roll2.ToString());
                }
            }
    
            // If the frame is a three-roll frame, add the third roll.
            if (frame.Length == 3)
            {
                score += int.Parse(frame[2].ToString());
            }
        }
    
        // If the final frame is a three-roll frame, add the third roll.
        if (frames.Length == 10 && frames[9].Length == 3)
        {
            score += int.Parse(frames[9][2].ToString());
        }
    
        return score;
    }
    
}
