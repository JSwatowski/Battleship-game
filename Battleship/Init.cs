using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Init
    {

        /// <summary>
        /// Funkcja tworząca tablicę do gry, grywalnych pól jest 10x10
        /// </summary>
        /// <returns></returns>
        public string[,] MakeBoard()
        {
            string[,] boardTab = new string[11, 11];

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    boardTab[i,j] = "[~]";
                }
                
            }

            boardTab[0, 0] = "{" + " " + "}";
            char x = 'A';
            for (int i =1; i<11; i++)
            {
                boardTab[0, i] ="{" + x.ToString() + "}";
                x++;
            }
            char y = '1';
            for (int i = 1; i < 10; i++)
            {
                boardTab[i, 0] = "{" + y.ToString() + "}";
                y++;
            }
            boardTab[10, 0] = "{10}";
            return boardTab;

        }

    }
}
