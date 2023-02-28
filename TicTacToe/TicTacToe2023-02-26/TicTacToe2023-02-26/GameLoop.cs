using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictac
{
    public class GameLoop : GameboardPrintout//ärva från Player så att man kan få tie++ och win++
    {
        private bool wcheck = false;

        public GameLoop()
        {
            Start();
        }
        //public GameLoop(3)
        //{
        //    Start(3);
        //}
        //public GameLoop(5, 5)
        //{
        //    Start(5, 5);
        //}
       
        public void Start() //Metod för att hämta spelarnamn så man kan method overloada start och (sen) även konstruktor-overloada. Bör nog heta "GetPlayerForGame" eller dylikt, men orkar inte ändra alla anrop
        {
            int bestOf3 = 3;
            Player player1 = new Player();
            Player player2 = new Player();
            StartGame(bestOf3, player1, player2);
        }

        public void RestartGame()//ska resetta boarden men funkar inte
        {
            gameboard = new string[] { "0", "1", "2", "3", "A", "", "", "", "B", "", "", "", "C", "", "", "" };
        }


        public void StartGame(int BestOf3, Player player1, Player player2) //BO3
        {
            bool gameOver = false;
            int player1wins = 0;
            int player2wins = 0;
            int Turncounter = 1;
            while (!gameOver) //Tills någon har 2 vinster.
            { 
                //Console.Clear();
                RestartGame();
                Console.ForegroundColor = ConsoleColor.White;
                base.PrintGameboard();
                wcheck = false;

                while (!wcheck) //tills boarden är full
                {
                    string Print;
                    string currentPlayer;
                    string PlayerSymbol;
                    if (Turncounter % 2 != 0)
                    {
                        Print = p1char;
                        PlayerSymbol = Print;
                        currentPlayer = player1.Name;
                    }
                    else
                    {
                        Print = p2char;
                        PlayerSymbol = Print;
                        currentPlayer = player2.Name;
                    }

                    Console.Write($"{currentPlayer} choose a space: ");
                    base.MoveInput(Print);
                    base.PrintGameboard();

                    if (base.gameboard[5] == PlayerSymbol && base.gameboard[6] == PlayerSymbol && base.gameboard[7] == PlayerSymbol ||
                        base.gameboard[9] == PlayerSymbol && base.gameboard[10] == PlayerSymbol && base.gameboard[11] == PlayerSymbol ||
                        base.gameboard[13] == PlayerSymbol && base.gameboard[14] == PlayerSymbol && base.gameboard[15] == PlayerSymbol ||
                        base.gameboard[5] == PlayerSymbol && base.gameboard[9] == PlayerSymbol && base.gameboard[13] == PlayerSymbol ||
                        base.gameboard[6] == PlayerSymbol && base.gameboard[10] == PlayerSymbol && base.gameboard[14] == PlayerSymbol ||
                        base.gameboard[7] == PlayerSymbol && base.gameboard[11] == PlayerSymbol && base.gameboard[15] == PlayerSymbol ||
                        base.gameboard[5] == PlayerSymbol && base.gameboard[10] == PlayerSymbol && base.gameboard[15] == PlayerSymbol ||
                        base.gameboard[7] == PlayerSymbol && base.gameboard[10] == PlayerSymbol && base.gameboard[13] == PlayerSymbol)
                    {
                        wcheck = true;
                        base.PrintGameboard();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{currentPlayer} wins");
                        if (currentPlayer == player1.Name) //lägger till och hämtar wins för varje spelare. Behövs för RestartGame sen som skall ha abstract injektion + constructor chaining
                        {
                            player1.AddWin();
                            player1.GetWin(currentPlayer);
                            player1wins++;
                            RestartGame();
                        }
                        else if (currentPlayer == player2.Name)
                        {
                            player2.AddWin();
                            player2.GetWin(currentPlayer);
                            player2wins++; 
                            RestartGame();
                        }
                    }

                    else if (ArrayFull(base.gameboard) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("It's a tie!");
                        wcheck = true;
                        RestartGame();
                    }
                    else
                        Turncounter++;

                    if (player1wins == 2)
                    {
                        gameOver = true;
                        Console.WriteLine(player1.Name + " Wins the best of three!");
                        PlayAgain();
                    }
                    else if (player2wins == 2)
                    {
                        gameOver = true;
                        Console.WriteLine(player2.Name + " Wins the best of three!");
                        PlayAgain();
                    }
                }
            }
        }
        public void StartGame(Player player1, Player player2) //vanliga "startmetoden", med orginal gameloop.
        {
            bool gameOver = false;
            int Turncounter = 1;
            base.PrintGameboard();
            do
            {
                string Print;
                string currentPlayer;
                string PlayerSymbol;
                if (Turncounter % 2 != 0)
                {
                    Print = p1char;
                    PlayerSymbol = Print;
                    currentPlayer = player1.Name;
                }
                else
                {
                    Print = p2char;
                    PlayerSymbol = Print;
                    currentPlayer = player2.Name;
                }

                Console.Write($"{currentPlayer} choose a space: ");
                base.MoveInput(Print);
                base.PrintGameboard();

                if (base.gameboard[5]  == PlayerSymbol && base.gameboard[6]  == PlayerSymbol && base.gameboard[7]  == PlayerSymbol ||
                    base.gameboard[9]  == PlayerSymbol && base.gameboard[10] == PlayerSymbol && base.gameboard[11] == PlayerSymbol ||
                    base.gameboard[13] == PlayerSymbol && base.gameboard[14] == PlayerSymbol && base.gameboard[15] == PlayerSymbol ||
                    base.gameboard[5]  == PlayerSymbol && base.gameboard[9]  == PlayerSymbol && base.gameboard[13] == PlayerSymbol ||
                    base.gameboard[6]  == PlayerSymbol && base.gameboard[10] == PlayerSymbol && base.gameboard[14] == PlayerSymbol ||
                    base.gameboard[7]  == PlayerSymbol && base.gameboard[11] == PlayerSymbol && base.gameboard[15] == PlayerSymbol ||
                    base.gameboard[5]  == PlayerSymbol && base.gameboard[10] == PlayerSymbol && base.gameboard[15] == PlayerSymbol ||
                    base.gameboard[7]  == PlayerSymbol && base.gameboard[10] == PlayerSymbol && base.gameboard[13] == PlayerSymbol)
                {
                    wcheck = true;
                    base.PrintGameboard();
                    Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{currentPlayer} wins");
                    if (currentPlayer == player1.Name) //lägger till och hämtar wins för varje spelare. Behövs för RestartGame sen som skall ha abstract injektion + constructor chaining
                    {
                        player1.AddWin();
                        player1.GetWin(currentPlayer);
                    }
                    else if (currentPlayer == player2.Name)
                    {
                        player2.AddWin();
                        player2.GetWin(currentPlayer);
                    }
                }

                else if (ArrayFull(base.gameboard) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("It's a tie!");
                    wcheck = true;
                }
                else
                    Turncounter++;
            }
            while (wcheck == false);
            if (gameOver == true) //metod som gör att den frågar om man vill spela igen
            {
                PlayAgain();
            }
        }

        private bool ArrayFull(string[] arrtest)
        {
            bool arrcheck = false;
            for (int i = 0; i < base.gameboard.Length; i++)
            {
                if (base.gameboard[i] == "")
                {
                    arrcheck = false;
                    break;
                }
                else
                    arrcheck = true;
            }
            return arrcheck;
        }

        protected string Color(string input)
        {
            if (wcheck)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (wcheck == false && ArrayFull(base.gameboard) == true)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                base.Color(input);
            return input;
        }

        protected void PlayAgain()//få in throw exceptions i felhanteringen här vid console.readkey
        {
            Console.WriteLine("Thank you for playing, do you want to play again? Press 1 to play one more, 2 to play BestOf3, 3 to play BestOf5 and 4 to quit.");
        }

    }
}
