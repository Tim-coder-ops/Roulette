using System;
using System.Collections.Generic;
using System.Text;

namespace RouletteV2
{
    class DropBall
    {
        public static Tuple<string, int> dropBall()
        {
            Random random = new Random();
            string color = "";

            int[] numbers =
                new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,
                    22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,0,00};
            string[] colors = new string[] { "black", "red", "green" };

            int numResult = numbers[random.Next(0, 38)];

            if ((numResult >= 1 && numResult <= 10) || (numResult >= 19 && numResult <= 28))
            {
                if (numResult % 2 == 0) color = colors[0];
                else color = colors[1];
            }
            else if ((numResult >= 11 && numResult <= 18) || (numResult >= 29 && numResult <= 36))
            {
                if (numResult % 2 == 0) color = colors[1];
                else color = colors[0];
            }
            else if (numResult == 0) color = colors[2];

              return new Tuple<string, int>(color, numResult);
            
        }
    }
}
