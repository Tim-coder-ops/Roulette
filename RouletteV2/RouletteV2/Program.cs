using System;

namespace RouletteV2
{
    class Program
    {
        public static int totalMoney = 0;
        public static int rollBet = 0;
        static void welcome()
        {
            Console.Write("  _      _                                                      \n"+ 
                          "   |  |  /          /                                            \n"+
                          " --|-/|-/-----__---/----__----__---_--_----__------_/_----__-----\n"+
                          "   |/ |/    /___) /   /   ' /   ) / /  ) /___)     /    /   )    \n" +
                          " __/__|____(___ _/___(___ _(___/_/_/__/_(___ _____(_ __(___/_____\n\n\n"+                                                                                                                                                      
                          " _________________________________________________               \n\n"+
                          "     ____                                                        \n"+
                          "     /    )                /                                     \n"+
                          " ---/___ /----__----------/----__--_/_--_/_----__-               \n"+
                          "   /    |   /   ) /   /  /   /___) /    /    /___)               \n"+
                          " _/_____|__(___/_(___(__/___(___ _(_ __(_ __(___ _  \n" +
                "\nThroughout this game you will select your choice by the number next to the choice.\n\n" +
                "How much money are you starting off with? (We only play with whole numbers here):");
            totalMoney = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Bet.bet();
        }

        public static void goodbye()
        {
            Console.WriteLine($"\nThank you for playing! You left the table with ${totalMoney}.");
        }
        static void Main(string[] args)
        {
            welcome();
        }
    }
}
