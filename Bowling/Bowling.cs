namespace Bowling
{
    public class Bowling
    {
        public int CalculateScore(string inp)
        {
            string results = inp.Replace(" ", "").Replace("-", "0");

            int score = 0;
            for (int i = 0; i < results.Length; i++)
            {
                if (IsBonusThrow(results, i))
                {
                    continue;
                }

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


                //    if (segment[0] == 'X')
                //    {
                //        strike++;
                //        continue;
                //    } else if(strike > 0)
                //    {
                //        score += strike * 10;
                //        strike = 0;
                //    }

                //    if (segment[0] == '-')
                //    {
                //        firstSegment = 0;
                //    } else
                //    {
                //        firstSegment = int.Parse(segment[0].ToString());
                //    }
                //    if (spare)
                //    {
                //        score += firstSegment;
                //        spare = false;
                //    }
                //    if (segment[1] == '-')
                //    {
                //        secondSegment = 0;
                //    }
                //    else if (segment[1] == '/')
                //    {
                //        spare = true;
                //        score += 10;
                //        continue;
                //    }
                //    else
                //    {
                //        secondSegment = int.Parse(segment[1].ToString());
                //    }




                //    score += firstSegment + secondSegment;
            }

            return score;
        }

        private static int ParseScore(string results, int i)
        {
            if (results[i] == 'X') return 10;
            if (results[i] == '/') return 10 - ParseScore(results, i - 1);
            return int.Parse(results[i].ToString());
        }

        private static bool IsBonusThrow(string results, int i)
        {
            int length = results.Length;
            if (i >= length - 2 && results[length - 3] == 'X')
            {
                return true;
            }
            if (i == length - 1 && results[length - 2] == '/')
            {
                return true;
            }
            return false;
        }
    }
}