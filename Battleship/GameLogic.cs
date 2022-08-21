using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// klasa ułatwiająca strzały podczas symulacji 
    /// </summary>
    class Bullet
    {
        public int flag = 0;
        public Point bulletXY;
    }
    class GameLogic
    {

        List<Bullet> firstPlayerShooting = new List<Bullet>();
        List<Bullet> secondPlayerShooting = new List<Bullet>();

        /// <summary>
        /// Funkcja odpowiadająca za całą logikę gry, strzał wybierany jest losowo lecz jeśli będzie to już miejsce wcześniej wylosowane to powinniśmy wylosować jeszcze raz za pomocą continue
        /// jeśli strzał będzie pudłem na tablicy zaznaczone miejsce będzie wyglądało [O], jeśli trafiony [X], nie ma bonusowej tury po trafieniu
        /// aby przyśpieszyć rozgrywkę, zapamiętujemy czy ostatni strzał był trafiony, jeśli tak to gracz dostaje 6tego zmysłu i program przeszukuje miejsce w gdzie jest następna część statku
        /// jeśli nie ma już takiego miejsca, znowu strzela na ślepo 
        /// gra kończy się po zniszczeniu wszystkich statków, które posiada gracz lub przeciwnik
        /// </summary>
        /// <param name="firstPlayerTab">tablica pierwszego gracza</param>
        /// <param name="secondEnemyTab">tablica pierwszego gracza na której zaznaczane są strzały do gracza drugiego</param>
        /// <param name="secondPlayerTab">tablica drugiego gracza</param>
        /// <param name="firstEnemyTab">tablica drugiego gracza na której zaznaczane są strzały do gracza pierwszego</param>
        /// <param name="firstPlayerShips">lista statków pierwszego gracza</param>
        /// <param name="secondPlayerShips">lista statków drugiego gracza</param>
        public void FreeShooting2(string[,] firstPlayerTab, string[,] secondEnemyTab, string[,] secondPlayerTab, string[,] firstEnemyTab, Ships firstPlayerShips, Ships secondPlayerShips)
        {
            int winner = 0;
            int flag = 0;
            DrawGame drawBoard = new DrawGame();
            //   while ((secondPlayerShips.listOfPoints2Ship.Any() && secondPlayerShips.listOfPoints3Ship.Any() && secondPlayerShips.listOfPoints4Ship.Any() && secondPlayerShips.listOfPoints5Ship.Any())
            //       || (firstPlayerShips.listOfPoints2Ship.Any() && firstPlayerShips.listOfPoints3Ship.Any() && firstPlayerShips.listOfPoints4Ship.Any() && firstPlayerShips.listOfPoints5Ship.Any()))
            while (winner != 1)
            {

                //tura 1 gracza
                Random position = new Random();
                if (flag == 0)
                {
                    int x = position.Next(1, 11);
                    int y = position.Next(1, 11);
                    Point point = new Point(x, y);
                    if (firstEnemyTab[point.X, point.Y] == "[0]" || firstEnemyTab[point.X, point.Y] == "[X]")
                    {
                        continue;
                    }

                    // mechanizm strzelania 6tego zmysłu 
                    if (firstPlayerShooting.Count > 0)
                    {
                        if (firstPlayerShooting[firstPlayerShooting.Count - 1].flag == 1)
                        {


                            if (firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X + 1 != 11)
                            {
                                if (secondPlayerTab[firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X + 1, firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y] == "[*]")
                                {
                                    point = new Point(firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X + 1, firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y);
                                    // break;
                                }

                            }
                            if (firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y + 1 != 11)
                            {
                                if (secondPlayerTab[firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X, firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y + 1] == "[*]")
                                {
                                    point = new Point(firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X, firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y + 1);
                                }

                            }
                            if (secondPlayerTab[firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X - 1, firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y] == "[*]")
                            {
                                point = new Point(firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X - 1, firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y);
                            }
                            if (secondPlayerTab[firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X, firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y - 1] == "[*]")
                            {
                                point = new Point(firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.X, firstPlayerShooting[firstPlayerShooting.Count - 1].bulletXY.Y - 1);
                            }
                        }
                    }

                    if (secondPlayerTab[point.X, point.Y] == "[~]")
                    {
                        secondEnemyTab[point.X, point.Y] = "[O]";
                        secondPlayerTab[point.X, point.Y] = "[O]";
                        Bullet bullet = new Bullet();
                        bullet.bulletXY = point;
                        firstPlayerShooting.Add(bullet);
                    }
                    if (secondPlayerTab[point.X, point.Y] == "[*]")
                    {
                        secondEnemyTab[point.X, point.Y] = "[X]";
                        Bullet bullet = new Bullet();
                        bullet.bulletXY = point;
                        bullet.flag = 1;
                        firstPlayerShooting.Add(bullet);
                        foreach (var item in secondPlayerShips.listOfPoints2Ship)
                        {
                            if (item.X == point.X && item.Y == point.Y)
                            {
                                secondPlayerShips.listOfPoints2Ship.Remove(item);
                                break;

                            }
                        }
                        foreach (var item in secondPlayerShips.listOfPoints3Ship)
                        {
                            if (item.X == point.X && item.Y == point.Y)
                            {
                                secondPlayerShips.listOfPoints3Ship.Remove(item);
                                break;

                            }
                        }
                        foreach (var item in secondPlayerShips.listOfPoints4Ship)
                        {
                            if (item.X == point.X && item.Y == point.Y)
                            {
                                secondPlayerShips.listOfPoints4Ship.Remove(item);
                                break;

                            }
                        }
                        foreach (var item in secondPlayerShips.listOfPoints5Ship)
                        {
                            if (item.X == point.X && item.Y == point.Y)
                            {
                                secondPlayerShips.listOfPoints5Ship.Remove(item);
                                break;

                            }
                        }


                        secondPlayerTab[point.X, point.Y] = "[X]";
                    }
                    Console.Clear();

                    drawBoard.DrawBoard(firstPlayerTab, secondEnemyTab, secondPlayerTab, firstEnemyTab);

                    flag = 1;
                    Thread.Sleep(100);

                    if (secondPlayerShips.listOfPoints2Ship.Count == 0)
                    {
                        if (secondPlayerShips.listOfPoints3Ship.Count == 0)
                        {
                            if (secondPlayerShips.listOfPoints4Ship.Count == 0)
                            {
                                if (secondPlayerShips.listOfPoints5Ship.Count == 0)
                                {
                                    winner = 1;
                                    Console.WriteLine("First Player is the winner");
                                }
                            }
                        }
                    }

                }


                if (flag == 1)
                {

                    int x = position.Next(1, 11);
                    int y = position.Next(1, 11);
                    Point point = new Point(x, y);
                    if (firstEnemyTab[point.X, point.Y] == "[0]" || firstEnemyTab[point.X, point.Y] == "[X]")
                    {
                        continue;
                    }

                    if (secondPlayerShooting.Count > 0)
                    {
                        if (secondPlayerShooting[secondPlayerShooting.Count - 1].flag == 1)
                        {


                            if (secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X + 1 != 11)
                            {
                                if (firstPlayerTab[secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X + 1, secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y] == "[*]")
                                {
                                    point = new Point(secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X + 1, secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y); ;
                                    // break;
                                }

                            }
                            if (secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y + 1 != 11)
                            {
                                if (firstPlayerTab[secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X, secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y + 1] == "[*]")
                                {
                                    point = new Point(secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X, secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y + 1);
                                }

                            }
                            if (firstPlayerTab[secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X - 1, secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y] == "[*]")
                            {
                                point = new Point(secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X - 1, secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y);
                            }
                            if (firstPlayerTab[secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X, secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y - 1] == "[*]")
                            {
                                point = new Point(secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.X, secondPlayerShooting[secondPlayerShooting.Count - 1].bulletXY.Y - 1);
                            }
                        }
                    }

                    if (firstPlayerTab[point.X, point.Y] == "[~]")
                    {
                        firstEnemyTab[point.X, point.Y] = "[O]";
                        firstPlayerTab[point.X, point.Y] = "[O]";
                        Bullet bullet = new Bullet();
                        bullet.bulletXY = point;
                        secondPlayerShooting.Add(bullet);
                    }
                    if (firstPlayerTab[point.X, point.Y] == "[*]")
                    {
                        firstEnemyTab[point.X, point.Y] = "[X]";
                        Bullet bullet = new Bullet();
                        bullet.bulletXY = point;
                        bullet.flag = 1;
                        secondPlayerShooting.Add(bullet);
                        foreach (var item in firstPlayerShips.listOfPoints2Ship)
                        {
                            if (item.X == point.X && item.Y == point.Y)
                            {
                                firstPlayerShips.listOfPoints2Ship.Remove(item);
                                break;

                            }
                        }
                        foreach (var item in firstPlayerShips.listOfPoints3Ship)
                        {
                            if (item.X == point.X && item.Y == point.Y)
                            {
                                firstPlayerShips.listOfPoints3Ship.Remove(item);
                                break;

                            }
                        }
                        foreach (var item in firstPlayerShips.listOfPoints4Ship)
                        {
                            if (item.X == point.X && item.Y == point.Y)
                            {
                                firstPlayerShips.listOfPoints4Ship.Remove(item);
                                break;

                            }
                        }
                        foreach (var item in firstPlayerShips.listOfPoints5Ship)
                        {
                            if (item.X == point.X && item.Y == point.Y)
                            {
                                firstPlayerShips.listOfPoints5Ship.Remove(item);
                                break;

                            }
                        }


                        firstPlayerTab[point.X, point.Y] = "[X]";
                    }
                    Console.Clear();

                    drawBoard.DrawBoard(firstPlayerTab, secondEnemyTab, secondPlayerTab, firstEnemyTab);

                    flag = 0;
                    Thread.Sleep(100);

                    if (firstPlayerShips.listOfPoints2Ship.Count == 0)
                    {
                        if (firstPlayerShips.listOfPoints3Ship.Count == 0)
                        {
                            if (firstPlayerShips.listOfPoints4Ship.Count == 0)
                            {
                                if (firstPlayerShips.listOfPoints5Ship.Count == 0)
                                {
                                    winner = 1;

                                    Console.WriteLine("Second Player is the winner");
                                }
                            }
                        }
                    }
                }
            }

        }

    }
}
