using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.bl
{
    public class Enemy
    {
        public char[,] enemy2D = {
        {' ', ' ', ' ', '|', '\\', '_', '/', '|', ' ', ' ', ' '},
        {'|', '\\', '_', '\\', '*', '=', '*', '/', '_', '/', '|'},
        {'|', ' ', ' ', ' ', '{', '^', '^', '}', ' ', ' ', '|'},
        {' ', '\\', ' ', ' ', ' ', '|', '|', ' ', ' ', '/', ' '},
        {' ', ' ', ' ', ' ', ' ', '/', '\\', ' ', ' ', ' ', ' '}
    };

        public string ChangeDirection(string direction, Enemy enemy)
        {
            if (direction == "right" && enemy.X >= 34)
            {
                direction = "left";
            }
            else if (direction == "left" && enemy.X <= 2)
            {
                direction = "right";
            }
            return direction;
        }
        public string ChangeDirection2(string direction2, Enemy enemy2)
        {
            if (direction2 == "down" && enemy2.Y >= 15)
            {
                direction2 = "up";
            }
            else if (direction2 == "up" && enemy2.Y <= 7)
            {
                direction2 = "down";
            }
            return direction2;
        }
        public string ChangeDirection3(string direction3, Enemy enemy3)
        {
            if (direction3 == "right" && enemy3.X >= 16)
            {
                direction3 = "down";
            }
            if (direction3 == "down" && enemy3.Y <= 11)
            {
                direction3 = "right";
            }
            return direction3;
        }
        public void MoveEnemy(string direction, Enemy enemy)
        {
            
            if (direction == "right")
            {
                enemy.X = enemy.X + 1;
            }
            else if (direction == "left")
            {
                enemy.X = enemy.X - 1;
            }

            
        }
        public void MoveEnemy3(string direction3, Enemy enemy3)
        {
            

            if (direction3 == "right")
            {
                enemy3.X = enemy3.X + 1;
                enemy3.Y = enemy3.Y + 1;
            }
            if (direction3 == "down")
            {
                enemy3.Y = enemy3.Y - 1;
                enemy3.X = enemy3.X - 1;
            }

            
        }
        public void MoveEnemy2(string direction2, Enemy enemy2)
        {
           
            if (direction2 == "down")
            {
                enemy2.Y = enemy2.Y + 1;
            }
            else if (direction2 == "up")
            {
                enemy2.Y = enemy2.Y - 1;
            }
           
        }
        public char[,] DisplayCharacter;
        public int X;
        public int Y;
        


        public Enemy( int x, int y)
        {

            
            X = x;
            Y = y;
        }
    }
    
    
    public class Player
    {
        public char[,] DisplayCharacter;
        public int X;
        public int Y;

        public char[,] player2D = {
        {' ', ' ', ' ', ' ', ' ', '/', '\\', ' ', ' ', ' ', ' ', ' '},
        {' ', ' ', ' ', '_', '/', ' ', ' ', '\\', '_', ' ', ' ', ' '},
        {' ', ' ', '/', ' ', '|', ' ', ' ', '|', ' ', '\\', ' ', ' '},
        {' ', '=', '=', '=', '.', ' ', ' ', '.', '=', '=', '=', ' '},
        {' ', ' ', ' ', ' ', '|', '|', '|', '|', ' ', ' ', ' ', ' '}
    };
        public void MovePlayer(ConsoleKey key, Player player)
        {
            

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (player.Y > 1)
                        player.Y -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    if (player.Y < 61)
                        player.Y += 1;
                    break;
                case ConsoleKey.UpArrow:
                    if (player.X > 1)
                        player.X -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (player.X < 20)
                        player.X += 1;
                    break;
            }

          
        }
        public Player( int x, int y)
        {
            
            X = x;
            Y = y;
        }
    }
}


