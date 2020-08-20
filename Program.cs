using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace Roulette
{

    class Program
    {
        static Tuple<int, string, bool> userBet = new Tuple<int, string, bool>(0, "null", true);
        static Tuple<string, int> rollResults = new Tuple<string, int>("null", 0);
        static int totalMoney = 0;
        static int rollBet = 0;
         
        static void getWins()
        {
            int rollNum = rollResults.Item2;
            string rollColor = rollResults.Item1;
            string betType = userBet.Item2;
            int betSpecific = userBet.Item1;
            bool isHorizontal = userBet.Item3; 

            Console.WriteLine($"\nThe roll was {rollNum}, {rollColor}.");
            if(betType == "numberBet" )
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

            else if(betType == "EvensOrOdds")
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
            else if(betType == "RedOrBlack")
            {
                if(betSpecific == 1 && rollColor == "red")
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
            else if(betType == "HighsOrLows")
            {
                if(betSpecific == 1 && rollNum >= 1 && rollNum <= 18)
                {
                    totalMoney += rollBet;
                    Console.WriteLine($"Nice! You won ${rollBet}!\n" +
                        $"You now have ${totalMoney}");
                }
                else if(betSpecific == 2 && rollNum >= 19 && rollNum <= 36)
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

            if(betType == "Dozen")
            {
                if (betSpecific == 1 && rollNum >= 1 && rollNum <= 12)
                {
                    totalMoney += rollBet*2;
                    Console.WriteLine($"Nice! You won ${rollBet*2}!\n" +
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
            if(betType == "Column")
            {
                if(betSpecific == 1 && rollNum%3 == 1)
                {
                    totalMoney += rollBet * 2;
                    Console.WriteLine($"Nice! You won ${rollBet * 2}!\n" +
                        $"You now have ${totalMoney}");
                }
                else if(betSpecific == 2 && rollNum%3 == 2)
                {
                    totalMoney += rollBet * 2;
                    Console.WriteLine($"Nice! You won ${rollBet * 2}!\n" +
                        $"You now have ${totalMoney}");
                }
                else if(betSpecific == 3 && rollNum%3 == 0)
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
            if(betType == "Street")
            {
                int winNum = 0;
                if (rollNum % 3 != 0) winNum = rollNum / 3 + 1;
                else winNum = rollNum / 3;
                Console.WriteLine(winNum);

                if(betSpecific == winNum)
                {
                    totalMoney += rollBet * 11;
                    Console.WriteLine($"Nice! You won ${rollBet * 11}!\n" +
                        $"You now have ${totalMoney}");
                }
                else {
                    totalMoney -= rollBet;
                    Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                        $"You now have ${totalMoney}");
                }
            }

            if(betType == "DoubleRows")
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

            if(betType == "Split")
            {
                bool isWin = false;

                if(isHorizontal == true )
                {
                    int[] horizontalNums = new int[] {1,2,2,3,4,5,5,6,7,8,8,9,10,11,11,12,13,14,14,15,16,17,17,18,19,20
                    ,20,21,22,23,23,24,25,26,26,27,28,29,29,30,31,32,32,33,34,35,35,36};

                    betSpecific = (betSpecific -1) * 2;
                    
                    for( int i = betSpecific; i < betSpecific + 2; i++)
                    {
                        if (horizontalNums[i] == rollNum) isWin = true;
                    }

                }
                else if(isHorizontal == false && (betSpecific == rollNum || betSpecific + 3 == rollNum))
                {
                    isWin = true;
                }

                if(isWin == true)
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
            if (betType == "Corner")
            {
                int[] corners = new int[] {1,2,4,5,2,3,5,6,4,5,7,8,5,6,8,9,7,8,10,11,8,9,11,12,10,11,13,14,11,12,14,15,
                13,14,16,17,14,15,17,18,16,17,19,20,17,18,20,21,19,20,22,23,20,21,23,23,22,23,25,25,23,24,26,27,25,26,28,29
                ,26,27,29,30,28,29,31,32,29,30,32,33,31,32,34,35,32,33,35,36};

                int index = (betSpecific - 1) *4;
                bool win = false;
                for(int i = index; i < index + 4; i++)
                {
                    if (corners[i] == rollNum)
                    {
                        win = true;
                    }
                }

                if(win == true)
                {
                    totalMoney += rollBet * 8;
                    Console.WriteLine($"Nice! You won ${rollBet * 8}!\n" +
                        $"You now have ${totalMoney}");
                }
                else if(win == false)
                {
                    totalMoney -= rollBet;
                    Console.WriteLine($"You lost ${rollBet}. Better luck next time!\n" +
                        $"You now have ${totalMoney}");
                }
             }

            bet();
        }

        static void dropBall()
        {
            Random random = new Random();
            string color = "";

            int[] numbers =
                new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,
                    22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,0,00};
            string[] colors = new string[] { "black", "red", "green" };

            int numResult = numbers[random.Next(0,38)];

            if ((numResult >= 1 && numResult <= 10) || (numResult >= 19 && numResult <= 28))
            {
                if (numResult % 2 == 0) color = colors[0];
                else color = colors[1];
            }
            else if ((numResult >= 11 && numResult <= 18) || (numResult >= 29 && numResult <= 36) )
            {
                if (numResult % 2 == 0) color = colors[1];
                else color = colors[0];
            }
            else if(numResult == 0) color = colors[2];

            rollResults = new Tuple<string, int>(color, numResult);
        }

        static void betSpecification(int input)
        {
            string type = "";
            int number = 0;
            bool isHorizontal = true;

            if (input == 1)
            {
                type = "numberBet";

                Console.Write("What number would you like to bet on? (1-36, 0, or 00):");
                number = int.Parse(Console.ReadLine());
                if(number <0 || number > 36)
                {
                    Console.WriteLine("Please enter a valid number");
                    betSpecification(1);
                }
            }
            else if(input == 2)
            {
                Console.Write("Would you like to bet evens or odds?:\n" +
                    "1. Evens\n" +
                    "2. Odds\n");
                number = int.Parse(Console.ReadLine());

                if (number == 1 || number == 2) type = "EvensOrOdds";
                else
                {
                    Console.WriteLine("Please enter either 1 or 2");
                    betSpecification(2);
                }
            }
            else if(input == 3)
            {
                Console.Write("Would you like to bet red or black?:\n" +
                     "1. red\n" +
                     "2. black\n");
                number = int.Parse(Console.ReadLine());

                if (number == 1 || number == 2) type = "RedOrBlack";
                else
                {
                    Console.WriteLine("Please enter either 1 or 2");
                    betSpecification(3);
                }
            }
            else if (input == 4)
            {
                Console.Write("Would you like to bet highs or lows?:\n" +
                     "1. Lows(1-18)\n" +
                     "2. Highs(19-38)");
                number = int.Parse(Console.ReadLine());

                if (number == 1 || number == 2) type = "HighsOrLows";
                else
                {
                    Console.WriteLine("Please enter either 1 or 2");
                    betSpecification(4);
                }
            }
            else if (input == 5)
            {
                Console.Write("What dozen (row third)  would you like to bet on?:\n" +
                     "1. 1-12\n" +
                     "2. 13-24\n" +
                     "3. 25-36\n");
                number = int.Parse(Console.ReadLine());

                if (number == 1 || number == 2|| number ==3) type = "Dozen";
                else
                {
                    Console.WriteLine("Please enter either 1, 2, or 3");
                    betSpecification(5);
                }
            }
            else if (input == 6)
            {
                Console.WriteLine("What column would you like to bet on?\n" +
                     "1. First column\n" +
                     "2. Second column\n" +
                     "3. Third column");
                number = int.Parse(Console.ReadLine());

                if (number == 1 || number == 2 || number == 3) type = "Column";
                else
                {
                    Console.WriteLine("Please enter either 1, 2, or 3");
                    betSpecification(6);
                }
            }
            else if (input == 7)
            {
                Console.WriteLine("What street (row) would you like to bet on?\n" +
                     "1. 1-3\n" +
                     "2. 4-6\n" +
                     "3. 7-9\n" +
                     "4. 10-12\n" +
                     "5. 13-15\n" +
                     "6. 16-18\n" +
                     "7. 19-21\n" +
                     "8. 22-24\n" +
                     "9. 25-27\n" +
                     "10. 28-30\n" +
                     "11. 31-33\n" +
                     "12. 34-36");
                number = int.Parse(Console.ReadLine());

                if (number > 0 && number < 13) type = "Street";
                else
                {
                    Console.WriteLine("Please enter 1-10 for your option.");
                    betSpecification(7);
                }
            }
            else if (input == 8)
            {
                Console.WriteLine("What 6 numbers (double rows) would you like to bet on?\n" +
                     "1. 1-6\n" +
                     "2. 7-12\n" +
                     "3. 13-18\n" +
                     "4. 19-24\n" +
                     "5. 25-30\n" +
                     "6. 31-36");
                number = int.Parse(Console.ReadLine());

                if (number > 0 && number < 7) type = "DoubleRows";
                else
                {
                    Console.WriteLine("Please enter 1-6 for your option");
                    betSpecification(8);
                }
            }
            else if (input == 9)
            {
                int splitSel;

                Console.WriteLine("Would you like to be on a\n" +
                    "1. Horizontal Split\n" +
                    "2. Vertical Split");
                splitSel = int.Parse(Console.ReadLine());
                if (splitSel == 1)
                {
                    isHorizontal = true;
                    Console.WriteLine("What split would you like to bet on?\n" +
                         "Horizontal Splits:\n" +
                         "1. 1/2      2. 2/3\n" +
                         "3. 4/5      4. 5/6\n" +
                         "5. 7/8      6. 8/9\n" +
                         "7. 10/11    8. 11/12\n" +
                         "9. 13/14    10. 14/15\n" +
                         "11. 16/17   12. 17/18\n" +
                         "13. 19/20   14. 20/21\n" +
                         "15. 22/23   16. 23/24\n" +
                         "17. 25/26   18. 26/27\n" +
                         "19. 28/29   20. 29/30\n" +
                         "21. 31/32   22. 32/33\n" +
                         "23. 34/35   24. 35/36" );

                }
                else if(splitSel == 2)
                {
                    isHorizontal = false;
                    Console.WriteLine("What split would you like to bet on?\n" +
                        "Vertical Splits:\n" +
                        "1. 1/4      2. 2/5      3. 3/6\n" +
                        "4. 4/7      5. 5/8      6. 6/9\n" +
                        "7. 7/10     8. 8/11     9. 9/12\n" +
                        "10. 10/13   11. 11/14   12. 12/15\n" +
                        "13. 13/16   14. 14/17   15. 15/18\n" +
                        "16. 16/19   17. 17/20   18. 18/21\n" +
                        "19. 19/22   20. 20/23   21. 21/24\n" +
                        "22. 22/25   23. 23/26   24. 24/27\n" +
                        "25. 25/28   26. 26/29   27. 27/30\n" +
                        "28. 28/31   29. 29/32   30. 30/33\n" +
                        "31. 31/34   32. 32/35   33. 33/36");
                }
                number = int.Parse(Console.ReadLine());

                if (splitSel == 1 && number > 0 && number < 25) type = "Split";
                else if (splitSel == 2 && number > 0 && number < 34) type = "Split";
                else
                {
                    Console.WriteLine("Please enter a valid selection");
                    betSpecification(9);
                }
            }
            else if (input == 10)
            {
                Console.WriteLine("What corner would you like to bet on?\n" +
                     "1. 1/2/3/4        2. 2/3/5/6\n" +
                     "3. 4/5/7/8        4. 5/6/8/9\n" +
                     "5. 7/8/10/11      6. 8/9/11/12\n" +
                     "7. 10/11/13/14    8. 11/12/14/15\n" +
                     "9. 13/14/16/17    10. 14/15/17/18\n" +
                     "11. 16/17/19/20   12. 17/18/20/21\n" +
                     "13. 19/20/22/23   14. 20/21/23/24\n" +
                     "15. 22/23/25/26   16. 23/24/26/27\n" +
                     "17. 25/26/28/29   18. 26/27/29/30\n" +
                     "19. 28/29/31/32   20. 29/30/32/33\n" +
                     "21. 31/32/34/35   22. 32/33/35/36");
                number = int.Parse(Console.ReadLine());

                if (number > 0 && number < 23) type = "Corner";
                else
                {
                    Console.WriteLine("Please enter 1-22 for your option");
                    betSpecification(10);
                }
            }
            userBet = new Tuple<int, string, bool>(number, type, isHorizontal);
            dropBall();
            getWins();
        }

        static void bet()
        {
            int selection = 0;
            try
            {
                Console.Write("\nHow much would you like to bet?:\n" +
                    "Enter \"0\" to quit the game:");
                rollBet = int.Parse(Console.ReadLine());

                if (rollBet == 0)
                {
                    goodbye();
                    return;
                }

                if (rollBet > totalMoney)
                {
                    Console.WriteLine($"You do not have enough money. You have ${totalMoney}. Place a lower bet please.");
                    bet();
                }
                Console.WriteLine();

                Console.WriteLine("1. Bet on one number\n" +
                    "2. Bet Evens or Odds\n" +
                    "3. Bet Red or Black\n" +
                    "4. Bet Highs or Lows\n" +
                    "5. Bet Dozens\n" +
                    "6. Bet columns\n" +
                    "7. Bet streets\n" +
                    "8. Bet double rows\n" +
                    "9. Bet split\n" +
                    "10. Bet corner\n");
                Console.Write("Enter the number for how you would like to bet:");
                selection = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(selection > 11|| selection < 1)
                {
                    Console.WriteLine("Please enter an integer between 1 and 10.");
                    bet();
                }
                
            }

            catch
            {
                Console.WriteLine("Please enter an integer.");
                bet();
            }

            betSpecification(selection);
            
        }

        static void welcome()
        {
            Console.Write("Welcome to the game of Roulette!\n" +
                " Throughout this game you will select your choice by the number next to the choice.\n\n" +
                "How much money are you starting off with? (We only play with whole numbers here):");
            totalMoney = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            bet();
        }

        static void goodbye()
        {
            Console.WriteLine($"\nThank you for playing! You left the table with ${totalMoney}.");
        }
        static void Main(string[] args)
        {
            welcome();
            
            
        }
    }
}
