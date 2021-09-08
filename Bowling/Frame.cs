using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Frame
    {
        int[] rolls = new int[21];
        int nextRoll = 0;
        public void Roll(int pins)
        {
            rolls[nextRoll++] = pins;
        }

        public int GetScore()
        {
            int rollIndex = 0;
            int score = 0;
            Func<bool>
                isStrike = () => rolls[rollIndex] == 10,
                isSpare = () => rolls[rollIndex] + rolls[rollIndex + 1] == 10;

            Func<int>
                strikeBonus = () => rolls[rollIndex + 1] + rolls[rollIndex + 2],
                spareBonus = () => rolls[rollIndex + 2],
                openRound = () => rolls[rollIndex] + rolls[rollIndex + 1];

            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike())
                {
                    score += 10 + strikeBonus();
                    rollIndex++;
                }
                else if (isSpare())
                {
                    score += 10 + spareBonus();
                    rollIndex += 2;
                }
                else
                {
                    score += openRound();
                    rollIndex += 2;
                }
            }
            return score;
        }
    }
}
