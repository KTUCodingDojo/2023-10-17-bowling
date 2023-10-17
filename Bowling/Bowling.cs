namespace Bowling
{
    public class Bowling
    {

        /// <summary>
        /// Calculates the total score for a series of bowling rolls.
        /// </summary>
        /// <param name="input">The string representation of the bowling rolls.</param>
        /// <returns>The total score for the provided series of rolls.</returns>
        public int CalculateScore(string input)
        {
            // Split the input string into individual frames.
            string[] frames = input.Split(' ');

            // Get the final frame for calculating bonus rolls.
            string finalFrame = frames[9];

            // Determine how many bonus rolls are in the final frame.
            int bonusRollsCount = GetBonusRollsCount(finalFrame);

            // Merge all frames into a single string of rolls.
            string rolls = String.Join("", frames);

            int totalScore = 0;

            // Iterate through each roll, excluding bonus throws.
            for (int i = 0; i < rolls.Length - bonusRollsCount; i++)
            {
                // Add the score of the current roll.
                totalScore += ParseRollScore(rolls, i);

                // If it's a strike, add the score of the next two rolls.
                if (IsStrike(rolls[i]))
                {
                    totalScore += ParseRollScore(rolls, i + 1) + ParseRollScore(rolls, i + 2);
                }
                // If it's a spare, add the score of the next roll.
                else if (IsSpare(rolls[i]))
                {
                    totalScore += ParseRollScore(rolls, i + 1);
                }
            }

            return totalScore;
        }

        /// <summary>
        /// Determines if a given roll is a strike.
        /// </summary>
        private bool IsStrike(char roll)
        {
            return roll == 'X';
        }

        /// <summary>
        /// Determines if a given roll is a spare.
        /// </summary>
        private bool IsSpare(char roll)
        {
            return roll == '/';
        }

        /// <summary>
        /// Determines if a given roll is a miss.
        /// </summary>
        private bool IsMiss(char roll)
        {
            return roll == '-';
        }

        /// <summary>
        /// Determines the number of bonus rolls in the final frame.
        /// </summary>
        private int GetBonusRollsCount(string lastFrame)
        {
            if (IsStrike(lastFrame[0]))
                return 2;
            if (IsSpare(lastFrame[1]))
                return 1;
            return 0;
        }

        /// <summary>
        /// Converts a roll character into its corresponding score value.
        /// </summary>
        private int ParseRollScore(string rolls, int position)
        {
            char roll = rolls[position];
            if (IsMiss(roll))
                return 0;
            if (IsStrike(roll))
                return 10;
            if (IsSpare(roll))
                return 10 - ParseRollScore(rolls, position - 1);
            return int.Parse(roll.ToString());
        }
    }
}