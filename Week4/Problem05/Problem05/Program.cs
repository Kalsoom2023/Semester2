using System;
using System.Threading;
using Problem05.bl;
namespace Problem05
{
    class Program
    {
        static int pX = 20, pY = 20;
        static int eX = 15, eY = 2;
        static int cX = 30, cY = 5;
        static int fX = 4, fY = 5;
        static int FY;
        static int escore = 0;
        static int FX;
        static int gX, gY, vX, vY, dX, dY;
        static int Score = 0;
        static int oX = 25, oY = 10;
        static int kX = 50, kY = 10;
        static string statusEnemy = "alive";
        static string statusPlayer = "alive";
        static int HEALTH = 100;
        const int enemyHeight = 5;
        const int enemyWidth = 11;

        static char[,] board = {
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
    };


        static void Main()
        {

            string enemyDirection = "right";

            string enemyDirection2 = "down";

            string enemyDirection3 = "right";
            Enemy enemy = new Enemy(eX, eY);
            Enemy enemy2 = new Enemy(fX, fY);
            Enemy enemy3 = new Enemy(cX, cY);
            Player player = new Player(pX, pY);
            DrawBoard();
            PrintPlayer(player);

            while (true)
            {

                PrintHealth();
                Stars();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    ErasePlayer(player);
                    player.MovePlayer(key, player);
                    PrintPlayer(player);
                    if (key == ConsoleKey.Spacebar)
                    {
                        Fire(player, enemy, enemy2, enemy3);
                    }
                }
                EraseEnemy(enemy);
                enemy.MoveEnemy(enemyDirection, enemy);
                PrintEnemy(enemy);
                enemyDirection = enemy.ChangeDirection(enemyDirection, enemy);
                FireAtEnemy(enemy, player);
                EraseEnemy2(enemy2);
                enemy2.MoveEnemy2(enemyDirection2, enemy2);
                PrintEnemy2(enemy2);
                enemyDirection2 = enemy2.ChangeDirection2(enemyDirection2, enemy2);
                FireAtEnemy2(enemy2, player);
                enemyDirection3 = enemy3.ChangeDirection3(enemyDirection3, enemy3);
                EraseEnemy3(enemy3);
                enemy3.MoveEnemy3(enemyDirection3, enemy3);
                PrintEnemy3(enemy3);
                FireAtEnemy3(enemy3, player);
            }
        }

        static void PrintHealth()
        {
            Console.SetCursorPosition(2, 27);
            Console.WriteLine($"Status of player: {statusPlayer}\t\tStatus of Enemy: {statusEnemy}");
            Console.WriteLine($"Score of player: {Score}\t\tScore of Enemy: {escore}");
        }

        static void Stars()
        {
            Console.SetCursorPosition(oX, oY);
            Console.Write("*");
            Console.SetCursorPosition(kX, kY);
            Console.Write("*");
        }

        static void DrawBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(board[i, j]);
                }
            }
        }



        static void ErasePlayer(Player player)
        {
            for (int i = 0; i < player.player2D.GetLength(0); i++)
            {
                for (int j = 0; j < player.player2D.GetLength(1); j++)
                {
                    Console.SetCursorPosition(player.Y + j, player.X + i);
                    Console.Write(" ");
                }
            }
        }

        static void PrintPlayer(Player player)
        {
            for (int i = 0; i < player.player2D.GetLength(0); i++)
            {
                for (int j = 0; j < player.player2D.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.SetCursorPosition(player.Y + j, player.X + i);

                    Console.WriteLine(player.player2D[i, j]);
                    Console.ResetColor();
                }
            }
        }

        static void EraseEnemy(Enemy enemy)
        {
            for (int i = 0; i < enemyHeight; i++)
            {
                for (int j = 0; j < enemyWidth; j++)
                {

                    Console.SetCursorPosition(enemy.X + j, enemy.Y + i);
                    Console.Write(" ");
                }
            }
        }

        static void PrintEnemy(Enemy enemy)
        {
            for (int i = 0; i < enemyHeight; i++)
            {
                for (int j = 0; j < enemyWidth; j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.SetCursorPosition(enemy.X + j, enemy.Y + i);
                    Console.WriteLine(enemy.enemy2D[i, j]);
                    Console.ResetColor();
                }
            }
        }
        static void EraseEnemy2(Enemy enemy2)
        {
            for (int i = 0; i < enemyHeight; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    Console.SetCursorPosition(enemy2.X + j, enemy2.Y + i);
                    Console.Write(" ");
                }
            }
        }

        static void PrintEnemy2(Enemy enemy2)
        {
            for (int i = 0; i < enemyHeight; i++)
            {
                for (int j = 0; j < enemyWidth; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(enemy2.X + j, enemy2.Y + i);
                    Console.WriteLine(enemy2.enemy2D[i, j]);
                    Console.ResetColor();
                }
            }
        }






        static void FireAtEnemy(Enemy enemy, Player player)
        {
            for (int i = 0; i <= 45; i++)
            {
                gY = enemy.Y + 2;
                gX = enemy.X + 11 + i;
                if (gX < 60)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(gX, gY);
                    Console.WriteLine("o");
                    System.Threading.Thread.Sleep(10);
                    Console.SetCursorPosition(gX, gY);
                    Console.WriteLine(" ");
                    Console.ResetColor();
                }
                CheckPlayerCollisionWithFire(player);
            }
        }

        static void FireAtEnemy2(Enemy enemy2, Player player)
        {
            for (int i = 0; i <= 45; i++)
            {
                dY = enemy2.Y + 5 + i;
                dX = enemy2.X + 5;
                if (dY < 25)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(dX, dY);
                    Console.WriteLine("o");
                    System.Threading.Thread.Sleep(10);
                    Console.SetCursorPosition(dX, dY);
                    Console.WriteLine(" ");
                    Console.ResetColor();
                }
                CheckPlayerCollisionWithFire(player);
            }
        }

        static void FireAtEnemy3(Enemy enemy3, Player player)
        {
            for (int i = 0; i <= 45; i++)
            {
                vY = enemy3.Y + 3 + i;
                vX = enemy3.X + 8 + i;
                if (vY < 25 && board[vY, vX] == ' ')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(vX, vY);
                    Console.WriteLine("o");
                    System.Threading.Thread.Sleep(10);
                    Console.SetCursorPosition(vX, vY);
                    Console.WriteLine(" ");
                    Console.ResetColor();
                }
                CheckPlayerCollisionWithFire(player);
            }
        }
        static void CheckFireCollision(Enemy enemy, Enemy enemy2, Enemy enemy3)
        {
            if (Score == 300)
            {

                PlayerWon();
            }

            if ((FY == enemy.Y + 2) && (FX >= enemy.X && FX <= enemy.X + 10))
            {
                Score += 10;
                PrintHealth();
            }

            if ((FY == enemy3.Y) && (FX >= enemy3.X && FX <= enemy3.X + 10))
            {
                Score += 10;
                PrintHealth();
            }

            if ((FY == enemy2.Y) && (FX >= enemy2.X && FX <= enemy2.X + 10))
            {
                Score += 10;
                PrintHealth();
            }

            if (Score == 300)
            {

                PlayerWon();
            }
        }


        static void EraseEnemy3(Enemy enemy3) //removing enemy
        {
            for (int i = 0; i < enemyHeight; i++)
            {
                for (int j = 0; j < enemyWidth; j++)
                {
                    Console.SetCursorPosition(enemy3.X + j, enemy3.Y + i);
                    Console.Write(" ");
                }
            }
        }
        static void PrintEnemy3(Enemy enemy3)  //displaying enemy
        {
            for (int i = 0; i < enemyHeight; i++)
            {
                for (int j = 0; j < enemyWidth; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(enemy3.X + j, enemy3.Y + i);
                    Console.WriteLine(enemy3.enemy2D[i, j]);
                    Console.ResetColor();
                }
            }
        }




        static void Fire(Player player, Enemy enemy, Enemy enemy2, Enemy enemy3)
        {
            for (int i = 0; i <= 20; i++)
            {
                FY = player.X - 2 - i;
                FX = player.Y + 6;

                if (FY > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(FX, FY);
                    Console.Write("l");
                    Thread.Sleep(10);
                    Console.SetCursorPosition(FX, FY);
                    Console.Write(" ");
                    Console.ResetColor();
                }

                CheckFireCollision(enemy, enemy2, enemy3);
                Booster();
            }
        }

        // ... (other methods)


        static void Booster()
        {
            if ((FY == oY && FX == oX) || FY == kY && FX == kX)
            {
                Score += 20;
                PrintHealth();
            }
        }

        static void CheckPlayerCollisionWithFire(Player player)
        {

            if ((gY >= player.X && gY <= player.X + player.player2D.GetLength(0)) && (gX >= player.Y && gX <= player.Y + player.player2D.GetLength(1)))
            {

                Console.Clear();
                Console.WriteLine("GAME OVER ------> Player hit by enemy fire");
                Environment.Exit(0);
            }
        }

        static void PlayerWon()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER ------> Player Won");
            Environment.Exit(0);
        }

        static void EnemyWon()
        {
            Console.SetCursorPosition(90, 15);
            Console.WriteLine("GAME OVER ------> Enemy Won");
            Environment.Exit(0);
        }
    }
}
