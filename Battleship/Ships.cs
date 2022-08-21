using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ships
    {
        public List<Point> listOfPoints2Ship = new List<Point>();
        public List<Point> listOfPoints3Ship = new List<Point>();
        public List<Point> listOfPoints4Ship = new List<Point>();
        public List<Point> listOfPoints5Ship = new List<Point>();

        /// <summary>
        /// Funkcja tworząca statek o rozmiarze 2, za pomocą metody Next() losujemy miejsce w którym będzie miał swój początek i koniec.
        /// Zakres jest tak zrobiony, aby nie wypadł poza tablice.
        /// </summary>
        /// <param name="tab">tablica na której rozgrywa sie bitwa </param>
        public void Create2PointShip(string[,] tab)
        {

            Random position = new Random();
            int x = position.Next(1, 11);
            int y = position.Next(1, 11);
            Point point = new Point(x, y);

            listOfPoints2Ship.Add(point);


            Point point2 = new Point();

            //kod, który odpowiada, aby reszta statku nie wypadła poza tablicę i także nie wpadł na inny statek 
            while (point2.X == 0 && point2.Y == 0)
            {
                int z = position.Next(1, 4);
                switch (z)
                {
                    case 1:
                        if (y - 1 != 0)
                        {
                            if (tab[x, y - 1] == "[~]")
                            {
                                point2 = new Point(x, y - 1);
                                listOfPoints2Ship.Add(point2);
                            }
                        }
                        break;
                    case 2:
                        if (x + 1 != 11)
                        {
                            if (tab[x + 1, y] == "[~]")
                            {
                                point2 = new Point(x + 1, y);
                                listOfPoints2Ship.Add(point2);
                            }
                        }
                        break;
                    case 3:
                        if (y + 1 != 11)
                        {
                            if (tab[x, y + 1] == "[~]")
                            {
                                point2 = new Point(x, y + 1);
                                listOfPoints2Ship.Add(point2);
                            }
                        }
                        break;
                    case 4:
                        if (x - 1 != 0)
                        {
                            if (tab[x - 1, y] == "[~]")
                            {
                                point2 = new Point(x - 1, y);
                                listOfPoints2Ship.Add(point2);
                            }
                        }
                        break;
                }
            }

            foreach (var shipXY in listOfPoints2Ship)
            {
                tab[shipXY.X, shipXY.Y] = "[*]";
            }


        }
        /// <summary>
        ///  Funkcja tworząca statek o rozmiarze 3, za pomocą metody Next() losujemy miejsce w którym będzie miał swój początek i koniec.
        /// Zakres jest tak zrobiony, aby nie wypadł poza tablice. Ponad to sprawdzamy czy pierwszy punkt naszego statku nie pokrywa się z innym statkiem. 
        /// Statki mogą się ze sobą "sklejać" ale nie przecinać
        /// </summary>
        /// <param name="tab">tablica na której rozgrywa sie bitwa</param>
        public void Create3PointShip(string[,] tab)
        {
            /*
            Random position = new Random();
            int x = position.Next(1, 11);
            int y = position.Next(1, 11);
            Point point = new Point(x, y);
            */
            int x = 0;
            int y = 0;
            Random position = new Random();
            Point point = new Point();
            
            // kod, który odpowiada za dobór odpowiedniego miejsca startowego
            while (tab[point.X, point.Y] != "[~]")
            {
                int xHelp = position.Next(1, 11);
                int yHelp = position.Next(1, 11);
                point = new Point(xHelp, yHelp);
                x = xHelp;
                y = yHelp;
            }


            listOfPoints3Ship.Add(point);


            Point point2 = new Point();
            Point point3 = new Point();

            //kod, który odpowiada, aby reszta statku nie wypadła poza tablicę i także nie wpadł na inny statek 
            while (point3.X == 0 && point3.Y == 0)
            {
                int z = position.Next(1, 4);
                switch (z)
                {
                    case 1:
                        if (y - 1 != 0 && y - 2 != 0 )
                        {
                            if (tab[x, y - 1] == "[~]")
                            {
                                point2 = new Point(x, y - 1);
                                listOfPoints3Ship.Add(point2);
                                if (tab[x, y - 2] == "[~]")
                                {
                                    point3 = new Point(x, y - 2);
                                    listOfPoints3Ship.Add(point3);
                                }
                                else
                                {
                                    listOfPoints3Ship.Clear();
                                }
                            }
                        }
                        break;
                    case 2:
                        if (x + 1 != 11 && x + 2 != 11 )
                        {
                            if (tab[x + 1, y] == "[~]")
                            {
                                point2 = new Point(x + 1, y);
                                listOfPoints3Ship.Add(point2);
                                if (tab[x + 2, y] == "[~]")
                                {
                                    point3 = new Point(x + 2, y);
                                    listOfPoints3Ship.Add(point3);
                                }
                                else
                                {
                                    listOfPoints3Ship.Clear();
                                }
                            }
                        }
                        break;
                    case 3:
                        if (y + 1 != 11 && y + 2 != 11 )
                        {
                            if (tab[x, y + 1] == "[~]")
                            {
                                point2 = new Point(x, y + 1);
                                listOfPoints3Ship.Add(point2);
                                if (tab[x, y + 2] == "[~]")
                                {
                                    point3 = new Point(x, y + 2);
                                    listOfPoints3Ship.Add(point3);
                                }
                                else
                                {
                                    listOfPoints3Ship.Clear();
                                }
                            }
                        }
                        break;
                    case 4:
                        if (x - 1 != 0 && x - 2 != 0 )
                        {
                            if (tab[x - 1, y] == "[~]")
                            {
                                point2 = new Point(x - 1, y);
                                listOfPoints3Ship.Add(point2);
                                if (tab[x - 2, y] == "[~]")
                                {
                                    point3 = new Point(x - 2, y);
                                    listOfPoints3Ship.Add(point3);
                                }
                                else
                                {
                                    listOfPoints3Ship.Clear();
                                }
                            }
                        }
                        break;
                }
            }



            foreach (var shipXY in listOfPoints3Ship)
            {
                tab[shipXY.X, shipXY.Y] = "[*]";
            }


        }

        public void Create4PointShip(string[,] tab)
        {
            /*
            Random position = new Random();
            int x = position.Next(1, 11);
            int y = position.Next(1, 11);
            Point point = new Point(x, y);
            */
            int x = 0;
            int y = 0;
            Random position = new Random();
            Point point = new Point();
            while (tab[point.X, point.Y] != "[~]")
            {
                int xHelp = position.Next(1, 11);
                int yHelp = position.Next(1, 11);
                point = new Point(xHelp, yHelp);
                x = xHelp;
                y = yHelp;
            }



            listOfPoints4Ship.Add(point);


            Point point2 = new Point();
            Point point3 = new Point();
            Point point4 = new Point();

            while (point4.X == 0 && point4.Y == 0)
            {
                int z = position.Next(1, 4);
                switch (z)
                {
                    case 1:
                        if (y - 1 != 0 && y - 2 != 0 && y - 3 != 0)
                        {
                            if (tab[x, y - 1] == "[~]")
                            {
                                point2 = new Point(x, y - 1);
                                listOfPoints4Ship.Add(point2);
                                if (tab[x, y - 2] == "[~]")
                                {
                                    point3 = new Point(x, y - 2);
                                    listOfPoints4Ship.Add(point3);
                                    if (tab[x, y - 3] == "[~]")
                                    {
                                        point4 = new Point(x, y - 3);
                                        listOfPoints4Ship.Add(point4);
                                    }
                                    else
                                    {
                                        listOfPoints4Ship.Clear();
                                    }
                                }
                                else
                                {
                                    listOfPoints4Ship.Clear();
                                }

                            }
                        }
                        break;
                    case 2:
                        if (x + 1 != 11 && x + 2 != 11 && x + 3 != 11)
                        {
                            if (tab[x + 1, y] == "[~]")
                            {
                                point2 = new Point(x + 1, y);
                                listOfPoints4Ship.Add(point2);
                                if (tab[x + 2, y] == "[~]")
                                {
                                    point3 = new Point(x + 2, y);
                                    listOfPoints4Ship.Add(point3);
                                    if (tab[x + 3, y] == "[~]")
                                    {
                                        point4 = new Point(x + 3, y);
                                        listOfPoints4Ship.Add(point4);
                                    }
                                    else
                                    {
                                        listOfPoints4Ship.Clear();
                                    }
                                }
                                else
                                {
                                    listOfPoints4Ship.Clear();
                                }
                            }
                        }
                        break;
                    case 3:
                        if (y + 1 != 11 && y + 2 != 11 && y + 3 != 11)
                        {
                            if (tab[x, y + 1] == "[~]")
                            {
                                point2 = new Point(x, y + 1);
                                listOfPoints4Ship.Add(point2);
                                if (tab[x, y + 2] == "[~]")
                                {
                                    point3 = new Point(x, y + 2);
                                    listOfPoints4Ship.Add(point3);
                                    if (tab[x, y + 3] == "[~]")
                                    {
                                        point4 = new Point(x, y + 3);
                                        listOfPoints4Ship.Add(point4);
                                    }
                                    else
                                    {
                                        listOfPoints4Ship.Clear();
                                    }
                                }
                                else
                                {
                                    listOfPoints4Ship.Clear();
                                }
                            }
                        }
                        break;
                    case 4:
                        if (x - 1 != 0 && x - 2 != 0 && x - 3 != 0)
                        {
                            if (tab[x - 1, y] == "[~]")
                            {
                                point2 = new Point(x - 1, y);
                                listOfPoints4Ship.Add(point2);
                                if (tab[x - 2, y] == "[~]")
                                {
                                    point3 = new Point(x - 2, y);
                                    listOfPoints4Ship.Add(point3);
                                    if (tab[x - 3, y] == "[~]")
                                    {
                                        point4 = new Point(x - 3, y);
                                        listOfPoints4Ship.Add(point4);
                                    }
                                    else
                                    {
                                        listOfPoints4Ship.Clear();
                                    }
                                }
                                else
                                {
                                    listOfPoints4Ship.Clear();
                                }
                            }
                        }
                        break;
                }
            }



            foreach (var shipXY in listOfPoints4Ship)
            {
                tab[shipXY.X, shipXY.Y] = "[*]";
            }


        }

        public void Create5PointShip(string[,] tab)
        {
            /*
            Random position = new Random();
            int x = position.Next(1, 11);
            int y = position.Next(1, 11);
            Point point = new Point(x, y);
            */
            int x = 0;
            int y = 0;
            Random position = new Random();
            Point point = new Point();
            while (tab[point.X, point.Y] != "[~]")
            {
                int xHelp = position.Next(1, 11);
                int yHelp = position.Next(1, 11);
                point = new Point(xHelp, yHelp);
                x = xHelp;
                y = yHelp;
            }



            listOfPoints5Ship.Add(point);


            Point point2 = new Point();
            Point point3 = new Point();
            Point point4 = new Point();
            Point point5 = new Point();

            while (point5.X == 0 && point5.Y == 0)
            {
                int z = position.Next(1, 4);
                switch (z)
                {
                    case 1:
                        if (y - 1 != 0 && y - 2 != 0 && y - 3 != 0 && y - 4 != 0)
                        {
                            if (tab[x, y - 1] == "[~]")
                            {
                                point2 = new Point(x, y - 1);
                                listOfPoints5Ship.Add(point2);
                                if (tab[x, y - 2] == "[~]")
                                {
                                    point3 = new Point(x, y - 2);
                                    listOfPoints5Ship.Add(point3);
                                    if (tab[x, y - 3] == "[~]")
                                    {
                                        point4 = new Point(x, y - 3);
                                        listOfPoints5Ship.Add(point4);
                                        if (tab[x, y - 4] == "[~]")
                                        {
                                            point5 = new Point(x, y - 4);
                                            listOfPoints5Ship.Add(point5);
                                        }
                                        else
                                        {
                                            listOfPoints5Ship.Clear();
                                        }
                                    }
                                    else
                                    {
                                        listOfPoints5Ship.Clear();
                                    }
                                }
                                else
                                {
                                    listOfPoints5Ship.Clear();
                                }

                            }
                        }
                        break;
                    case 2:
                        if (x + 1 != 11 && x + 2 != 11 && x + 3 != 11 && x + 4 != 11)
                        {
                            if (tab[x + 1, y] == "[~]")
                            {
                                point2 = new Point(x + 1, y);
                                listOfPoints5Ship.Add(point2);
                                if (tab[x + 2, y] == "[~]")
                                {
                                    point3 = new Point(x + 2, y);
                                    listOfPoints5Ship.Add(point3);
                                    if (tab[x + 3, y] == "[~]")
                                    {
                                        point4 = new Point(x + 3, y);
                                        listOfPoints5Ship.Add(point4);
                                        if (tab[x + 4, y] == "[~]")
                                        {
                                            point5 = new Point(x + 4, y);
                                            listOfPoints5Ship.Add(point5);
                                        }
                                        else
                                        {
                                            listOfPoints5Ship.Clear();
                                        }
                                    }
                                    else
                                    {
                                        listOfPoints5Ship.Clear();
                                    }
                                }
                                else
                                {
                                    listOfPoints5Ship.Clear();
                                }
                            }
                        }
                        break;
                    case 3:
                        if (y + 1 != 11 && y + 2 != 11 && y + 3 != 11 && y + 4 != 11)
                        {
                            if (tab[x, y + 1] == "[~]")
                            {
                                point2 = new Point(x, y + 1);
                                listOfPoints5Ship.Add(point2);
                                if (tab[x, y + 2] == "[~]")
                                {
                                    point3 = new Point(x, y + 2);
                                    listOfPoints5Ship.Add(point3);
                                    if (tab[x, y + 3] == "[~]")
                                    {
                                        point4 = new Point(x, y + 3);
                                        listOfPoints5Ship.Add(point4);
                                        if (tab[x, y + 4] == "[~]")
                                        {
                                            point5 = new Point(x, y + 4);
                                            listOfPoints5Ship.Add(point5);
                                        }
                                        else
                                        {
                                            listOfPoints5Ship.Clear();
                                        }
                                    }
                                    else
                                    {
                                        listOfPoints5Ship.Clear();
                                    }
                                }
                                else
                                {
                                    listOfPoints5Ship.Clear();
                                }
                            }
                        }
                        break;
                    case 4:
                        if (x - 1 != 0 && x - 2 != 0 && x - 3 != 0 && x - 4 != 0)
                        {
                            if (tab[x - 1, y] == "[~]")
                            {
                                point2 = new Point(x - 1, y);
                                listOfPoints5Ship.Add(point2);
                                if (tab[x - 2, y] == "[~]")
                                {
                                    point3 = new Point(x - 2, y);
                                    listOfPoints5Ship.Add(point3);
                                    if (tab[x - 3, y] == "[~]")
                                    {
                                        point4 = new Point(x - 3, y);
                                        listOfPoints5Ship.Add(point4);
                                        if (tab[x - 4, y] == "[~]")
                                        {
                                            point5 = new Point(x - 4, y);
                                            listOfPoints5Ship.Add(point5);
                                        }
                                        else
                                        {
                                            listOfPoints5Ship.Clear();
                                        }
                                    }
                                    else
                                    {
                                        listOfPoints5Ship.Clear();
                                    }
                                }
                                else
                                {
                                    listOfPoints5Ship.Clear();
                                }
                            }

                        }
                        break;
                }
            }



            foreach (var shipXY in listOfPoints5Ship)
            {               
              
                tab[shipXY.X, shipXY.Y] = "[*]";
                
            }


        }
    }
}
