using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class DrawGame
    {
        /// <summary>
        /// Funkcja odpowiadająca za "pokazywanie" rozgrywki w czasie rzeczywistym
        /// </summary>
        /// <param name="firstPlayerTab">tablica pierwszego gracza</param>
        /// <param name="secondEnemyTab">tablica pierwszego gracza na której zaznaczane są strzały do gracza drugiego </param>
        /// <param name="secondPlayerTab">tablica drugiego gracza </param>
        /// <param name="firstEnemyTab">tablica drugiego gracza na której zaznaczane są strzały do gracza pierwszego</param>
        public void DrawBoard(string [,] firstPlayerTab, string [,] secondEnemyTab, string [,] secondPlayerTab, string [,] firstEnemyTab)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (firstPlayerTab[i, j] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;


                        Console.Write(firstPlayerTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (firstPlayerTab[i, j] == "[*]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;


                        Console.Write(firstPlayerTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (firstPlayerTab[i, j] == "[O]")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.Write(firstPlayerTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (firstPlayerTab[i, j] == "[X]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(firstPlayerTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(firstPlayerTab[i, j]);
                    }
                }
                Console.Write("\t");
                for (int j = 0; j < 11; j++)
                {
                    if (secondEnemyTab[i, j] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.Write(secondEnemyTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (secondEnemyTab[i, j] == "[O]")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.Write(secondEnemyTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (secondEnemyTab[i, j] == "[X]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(secondEnemyTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(secondEnemyTab[i, j]);
                    }

                }

                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (secondPlayerTab[i, j] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;


                        Console.Write(secondPlayerTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (secondPlayerTab[i, j] == "[*]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;


                        Console.Write(secondPlayerTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (secondEnemyTab[i, j] == "[O]")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.Write(secondEnemyTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (secondEnemyTab[i, j] == "[X]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(secondEnemyTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(secondPlayerTab[i, j]);
                    }
                }
                Console.Write("\t");
                for (int j = 0; j < 11; j++)
                {


                    if (firstEnemyTab[i, j] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.Write(firstEnemyTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (firstEnemyTab[i, j] == "[O]")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.Write(firstEnemyTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (firstEnemyTab[i, j] == "[X]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(firstEnemyTab[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(firstEnemyTab[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
