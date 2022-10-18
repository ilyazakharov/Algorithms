namespace Algorithms.DynamicProgramming
{
    // DP is about building tables. Value of the cells is a characteristic to be optimized. Each cell is a subtask.
    // Palindrome example:
    //    d   a   b   a   b
    // b  0   0   b   0   b
    // a  0   a   0  ba   0
    // b  0   0  ab   0  bab
    // a  0   a   0  aba  0
    // d  d   0   0   0   0
    public class LongestPalindrome
    {
        public string LongestPalidromeDP(string s)
        {
            int len = s.Length;
            string max = string.Empty;
            string[,] dp = new string[len, len];
            for (int i = 0; i < len; i++)
            {
                for (int j = len -1; j >= 0; j--)
                {
                    if (s[i] == s[j])
                    {
                        if ( i != 0 && j != len - 1)
                        {
                            dp[i, j] += dp[i - 1, j + 1];
                        }

                        dp[i, j] += s[i];

                        if (max.Length < dp[i, j].Length)
                        {
                            max = dp[i, j];
                        }
                    }
                }
            }

            return max;
        }
    }
}