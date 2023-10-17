namespace Bowling
{
    public class Bowling
    {
        public int CalculateScore(string inp)
        {
            string[] temp = inp.Split(' ');
            string lastRound = temp[9];
            int bonusThrows = 0;
            if (lastRound[0] == 'X')
            {
                bonusThrows = 2;
            }
            else if (lastRound[1] == '/')
            {
                bonusThrows = 1;
            }

            string results = String.Join("", temp).Replace("-", "0");

            int score = 0;
            for (int i = 0; i < results.Length - bonusThrows; i++)
            {
                // Strike
                if (results[i] == 'X')
                {
                    score += ParseScore(results, i);
                    score += ParseScore(results, i + 1);
                    score += ParseScore(results, i + 2);
                }
                else if (results[i] == '/')
                {
                    // sum up self
                    score += ParseScore(results, i);
                    // add next
                    score += ParseScore(results, i + 1);

                }
                else
                {
                    score += ParseScore(results, i);
                }

            }

            return score;
        }
        private static int ParseScore(string results, int i)
        {
            if (results[i] == 'X') return 10;
            if (results[i] == '/') return 10 - ParseScore(results, i - 1);
            return int.Parse(results[i].ToString());
        }
    }
}