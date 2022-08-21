using System;

namespace Battleship
{
    class Program
    {
        /// <summary>
        /// Na początku tworzymy dwie tablice do gry, każdy z graczy ma po 4 statki, potem zaczynamy gre za pomocą metody FreeShooting2
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Init init = new Init();
            string[,] firstPlayerTab = init.MakeBoard();
            string[,] secondEnemyTab = init.MakeBoard();
            
            Ships shipFristPlayer = new Ships();

            shipFristPlayer.Create2PointShip(firstPlayerTab);
            shipFristPlayer.Create3PointShip(firstPlayerTab);
            shipFristPlayer.Create4PointShip(firstPlayerTab);
            shipFristPlayer.Create5PointShip(firstPlayerTab);    

            string[,] secondPlayerTab = init.MakeBoard();
            string[,] firstEnemyTab = init.MakeBoard();

            Ships shipSecondPlayer = new Ships();

            shipSecondPlayer.Create2PointShip(secondPlayerTab);
            shipSecondPlayer.Create3PointShip(secondPlayerTab);
            shipSecondPlayer.Create4PointShip(secondPlayerTab);
            shipSecondPlayer.Create5PointShip(secondPlayerTab);

          
            GameLogic startGame = new GameLogic();
            startGame.FreeShooting2(firstPlayerTab, secondEnemyTab, secondPlayerTab, firstEnemyTab, shipFristPlayer, shipSecondPlayer);

        
        }
    }
}
