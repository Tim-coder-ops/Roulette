using System;
using System.Collections.Generic;
using System.Text;


namespace RouletteV2
{
    class Wins
    {
        static int rollNum;
        static string rollColor;
        static string betType;
        static int betSpecific;
        static bool isHorizontal ;
        static int totalMoney;
        static int rollBet;

        
        public static void getWins(Tuple<int, string, bool> bet, Tuple<string, int> result)
        {
            rollNum = result.Item2;
            rollColor = result.Item1;
            betType = bet.Item2;
            betSpecific = bet.Item1;
            isHorizontal = bet.Item3;
            totalMoney = Program.totalMoney;
            rollBet = Program.rollBet;

            Console.WriteLine($"\nThe roll was {rollNum}, {rollColor}.");
            if (betType == "numberBet") GetNumberBet();
            else if (betType == "EvensOrOdds") GetEvenOrOdds();
            else if (betType == "RedOrBlack") GetRedOrBlack();
            else if (betType == "HighsOrLows") GetHighsOrLows();
            else if (betType == "Dozen") GetDozens();
            else if (betType == "Column") GetColumns();
            else if (betType == "Street") GetStreet();
            else if (betType == "DoubleRows") GetDoubleRows();
            else if (betType == "Split") GetSplit();
            else if (betType == "Corner") GetCorner();
            Console.WriteLine($"the bet specific is {betSpecific}");
            Program.totalMoney = totalMoney;
            Bet.bet();
        }
        static void GetNumberBet()
        {
            if (betSpecific == rollNum)
            {
                totalMoney += rollBet * 35;
                Console.WriteLine($"Nice! You won ${(rollBet * 35)}!\n" +
                    $"You now have ${totalMoney}.");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetEvenOrOdds()
        {
            if (betSpecific == 1 && rollNum % 2 == 0)
            {
                totalMoney += rollBet;
                Console.WriteLine($"Nice! You won ${rollBet}!\n" +
                    $"You now have ${totalMoney}");
            }
            else if (betSpecific == 2 && rollNum % 2 != 0)
            {
                totalMoney += rollBet;
                Console.WriteLine($"Nice! You won ${rollBet}!\n" +
                    $"You now have ${totalMoney}");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetRedOrBlack()
        {
            if (betSpecific == 1 && rollColor == "red")
            {
                totalMoney += rollBet;
                Console.WriteLine($"Nice! You won ${rollBet}!\n" +
                    $"You now have ${totalMoney}");
            }
            else if (betSpecific == 2 && rollColor == "black")
            {
                totalMoney += rollBet;
                Console.WriteLine($"Nice! You won ${rollBet}!\n" +
                    $"You now have ${totalMoney}");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetHighsOrLows()
        {
            if (betSpecific == 1 && rollNum >= 1 && rollNum <= 18)
            {
                totalMoney += rollBet;
                Console.WriteLine($"Nice! You won ${rollBet}!\n" +
                    $"You now have ${totalMoney}");
            }
            else if (betSpecific == 2 && rollNum >= 19 && rollNum <= 36)
            {
                totalMoney += rollBet;
                Console.WriteLine($"Nice! You won ${rollBet}!\n" +
                    $"You now have ${totalMoney}");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetDozens()
        {
            if (betSpecific == 1 && rollNum >= 1 && rollNum <= 12)
            {
                totalMoney += rollBet * 2;
                Console.WriteLine($"Nice! You won ${rollBet * 2}!\n" +
                    $"You now have ${totalMoney}");
            }
            else if (betSpecific == 2 && rollNum >= 13 && rollNum <= 24)
            {
                totalMoney += rollBet * 2;
                Console.WriteLine($"Nice! You won ${rollBet * 2}!\n" +
                    $"You now have ${totalMoney}");
            }
            else if (betSpecific == 3 && rollNum >= 25 && rollNum <= 36)
            {
                totalMoney += rollBet * 2;
                Console.WriteLine($"Nice! You won ${rollBet * 2}!\n" +
                    $"You now have ${totalMoney}");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetColumns()
        {
            if (betSpecific == 1 && rollNum % 3 == 1)
            {
                totalMoney += rollBet * 2;
                Console.WriteLine($"Nice! You won ${rollBet * 2}!\n" +
                    $"You now have ${totalMoney}");
            }
            else if (betSpecific == 2 && rollNum % 3 == 2)
            {
                totalMoney += rollBet * 2;
                Console.WriteLine($"Nice! You won ${rollBet * 2}!\n" +
                    $"You now have ${totalMoney}");
            }
            else if (betSpecific == 3 && rollNum % 3 == 0)
            {
                totalMoney += rollBet * 2;
                Console.WriteLine($"Nice! You won ${rollBet * 2}!\n" +
                    $"You now have ${totalMoney}");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetStreet()
        {
            int winNum = 0;
            if (rollNum % 3 != 0) winNum = rollNum / 3 + 1;
            else winNum = rollNum / 3;
            Console.WriteLine(winNum);

            if (betSpecific == winNum)
            {
                totalMoney += rollBet * 11;
                Console.WriteLine($"Nice! You won ${rollBet * 11}!\n" +
                    $"You now have ${totalMoney}");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetDoubleRows()
        {
            int winNum = 0;
            if (rollNum % 6 != 0) winNum = rollNum / 6 + 1;
            else winNum = rollNum / 6;

            if (betSpecific == winNum)
            {
                totalMoney += rollBet * 5;
                Console.WriteLine($"Nice! You won ${rollBet * 5}!\n" +
                    $"You now have ${totalMoney}");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetSplit()
        {
            bool isWin = false;

            if (isHorizontal == true)
            {
                int[] horizontalNums = new int[] {1,2,2,3,4,5,5,6,7,8,8,9,10,11,11,12,13,14,14,15,16,17,17,18,19,20
                    ,20,21,22,23,23,24,25,26,26,27,28,29,29,30,31,32,32,33,34,35,35,36};

                betSpecific = (betSpecific - 1) * 2;

                for (int i = betSpecific; i < betSpecific + 2; i++)
                {
                    if (horizontalNums[i] == rollNum) isWin = true;
                }

            }
            else if (isHorizontal == false && (betSpecific == rollNum || betSpecific + 3 == rollNum))
            {
                isWin = true;
            }

            if (isWin == true)
            {
                totalMoney += rollBet * 5;
                Console.WriteLine($"Nice! You won ${rollBet * 17}!\n" +
                    $"You now have ${totalMoney}");
            }
            else
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }

        static void GetCorner()
        {
            int[] corners = new int[] {1,2,4,5,2,3,5,6,4,5,7,8,5,6,8,9,7,8,10,11,8,9,11,12,10,11,13,14,11,12,14,15,
                13,14,16,17,14,15,17,18,16,17,19,20,17,18,20,21,19,20,22,23,20,21,23,23,22,23,25,25,23,24,26,27,25,26,28,29
                ,26,27,29,30,28,29,31,32,29,30,32,33,31,32,34,35,32,33,35,36};

            int index = (betSpecific - 1) * 4;
            bool win = false;
            for (int i = index; i < index + 4; i++)
            {
                if (corners[i] == rollNum)
                {
                    win = true;
                }
            }

            if (win == true)
            {
                totalMoney += rollBet * 8;
                Console.WriteLine($"Nice! You won ${rollBet * 8}!\n" +
                    $"You now have ${totalMoney}");
            }
            else if (win == false)
            {
                totalMoney -= rollBet;
                Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                    $"You now have ${totalMoney}");
            }
        }
    }
    
}
