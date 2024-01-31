using System;
using System.Threading;
using Games.bl;
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
    static int kX = 67, kY = 10;
    static string statusEnemy = "alive";
    static string statusPlayer = "alive";
    static int HEALTH = 100;
    const int enemyHeight = 5;
    const int enemyWidth = 11;

    static char[,] player2D = {
        {' ', ' ', ' ', ' ', ' ', '/', '\\', ' ', ' ', ' ', ' ', ' '},
        {' ', ' ', ' ', '_', '/', ' ', ' ', '\\', '_', ' ', ' ', ' '},
        {' ', ' ', '/', ' ', '|', ' ', ' ', '|', ' ', '\\', ' ', ' '},
        {' ', '=', '=', '=', '.', ' ', ' ', '.', '=', '=', '=', ' '},
        {' ', ' ', ' ', ' ', '|', '|', '|', '|', ' ', ' ', ' ', ' '}
    };

    static char[,] enemy2D = {
        {' ', ' ', ' ', '|', '\\', '_', '/', '|', ' ', ' ', ' '},
        {'|', '\\', '_', '\\', '*', '=', '*', '/', '_', '/', '|'},
        {'|', ' ', ' ', ' ', '{', '^', '^', '}', ' ', ' ', '|'},
        {' ', '\\', ' ', ' ', ' ', '|', '|', ' ', ' ', '/', ' '},
        {' ', ' ', ' ', ' ', ' ', '/', '\\', ' ', ' ', ' ', ' '}
    };

    static char[,] enemy22D = {
        {' ', ' ', ' ', '|', '\\', '_', '/', '|', ' ', ' ', ' '},
        {'|', '\\', '_', '\\', '*', '=', '*', '/', '_', '/', '|'},
        {'|', ' ', ' ', ' ', '{', '^', '^', '}', ' ', ' ', '|'},
        {' ', '\\', ' ', ' ', ' ', '|', '|', ' ', ' ', '/', ' '},
        {' ', ' ', ' ', ' ', ' ', '/', '\\', ' ', ' ', ' ', ' '}
    };

    static char[,] enemyD = {
        {' ', ' ', ' ', '|', '\\', '_', '/', '|', ' ', ' ', ' '},
        {'|', '\\', '_', '\\', '*', '=', '*', '/', '_', '/', '|'},
        {'|', ' ', ' ', ' ', '{', '^', '^', '}', ' ', ' ', '|'},
        {' ', '\\', ' ', ' ', ' ', '|', '|', ' ', ' ', '/', ' '},
        {' ', ' ', ' ', ' ', ' ', '/', '\\', ' ', ' ', ' ', ' '}
    };

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
        string direction = "right";
        string enemyDirection = "right";
        string fireDirection = "right";
        string enemyDirection2 = "down";
        string fireDirection2 = "down";
        string enemyDirection3 = "right";
        Enemy enemy = new Enemy(enemy2D, eX, eY);
        Enemy2 enemy2 = new Enemy2(enemy2D, fX, fY);
        Enemy3 enemy3 = new Enemy3(enemy2D, cX, cY);
        Player player = new Player(player2D, pX, pY);
        DrawBoard();
        PrintPlayer(player);

        while (true)
        {

            PrintHealth();
            Stars();

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                MovePlayer(key,player);
                if (key == ConsoleKey.Spacebar)
                {
                    Fire(player,enemy,enemy2,enemy3);
                }
            }

            MoveEnemy(enemyDirection, enemy);
            enemyDirection = ChangeDirection(enemyDirection,enemy);
            FireAtEnemy(enemy);
            MoveEnemy2(enemyDirection2,enemy2);
            enemyDirection2 = ChangeDirection2(enemyDirection2,enemy2);
            FireAtEnemy2(enemy2);
            enemyDirection3 = ChangeDirection3(enemyDirection3,enemy3);
            MoveEnemy3(enemyDirection3,enemy3);
            FireAtEnemy3(enemy3);
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

    static void MovePlayer(ConsoleKey key,Player player)
    {
        ErasePlayer(player);

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

        PrintPlayer(player);
    }

    static void ErasePlayer(Player player)
    {
        for (int i = 0; i < player2D.GetLength(0); i++)
        {
            for (int j = 0; j < player2D.GetLength(1); j++)
            {
                Console.SetCursorPosition(player.Y + j, player.X + i);
                Console.Write(" ");
            }
        }
    }

    static void PrintPlayer(Player player)
    {
        for (int i = 0; i < player2D.GetLength(0); i++)
        {
            for (int j = 0; j < player2D.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.SetCursorPosition(player.Y + j, player.X + i);

                Console.WriteLine(player.DisplayCharacter[i, j]);
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
                Console.WriteLine(enemy.DisplayCharacter[i, j]);
                Console.ResetColor();
            }
        }
    }
    static void EraseEnemy2(Enemy2 enemy)
    {
        for (int i = 0; i < enemyHeight; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                Console.SetCursorPosition(enemy.X + j, enemy.Y + i);
                Console.Write(" ");
            }
        }
    }

    static void PrintEnemy2(Enemy2 enemy)
    {
        for (int i = 0; i < enemyHeight; i++)
        {
            for (int j = 0; j < enemyWidth; j++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(enemy.X + j, enemy.Y + i);
                Console.WriteLine(enemy.DisplayCharacter[i, j]);
                Console.ResetColor();
            }
        }
    }
    static void MoveEnemy(string direction,Enemy enemy)
    {
        EraseEnemy(enemy);

        if (direction == "right")
        {
            enemy.X = enemy.X + 1;
        }
        else if (direction == "left")
        {
            enemy.X = enemy.X - 1;
        }

        PrintEnemy(enemy);
    }
    static string ChangeDirection(string direction,Enemy enemy)
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

    static string ChangeDirection2(string direction2,Enemy2 enemy2)
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
    static void MoveEnemy2(string direction2,Enemy2 enemy)
    {
        EraseEnemy2(enemy);
        if (direction2 == "down")
        {
            enemy.Y = enemy.Y + 1;
        }
        else if (direction2 == "up")
        {
            enemy.Y = enemy.Y - 1;
        }
        PrintEnemy2(enemy);
    }

    static void FireAtEnemy(Enemy enemy)
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
        }
    }

    static void FireAtEnemy2(Enemy2 enemy2)
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
        }
    }

    static void FireAtEnemy3(Enemy3 enemy3)
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
        }
    }
    static void CheckFireCollision(Enemy enemy,Enemy2 enemy2,Enemy3 enemy3)
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

    static string ChangeDirection3(string direction3,Enemy3 enemy3)
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
    static void EraseEnemy3(Enemy3 enemy3) //removing enemy
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
    static void PrintEnemy3(Enemy3 enemy3)  //displaying enemy
    {
        for (int i = 0; i < enemyHeight; i++)
        {
            for (int j = 0; j < enemyWidth; j++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(enemy3.X + j, enemy3.Y + i);
                Console.WriteLine(enemyD[i, j]);
                Console.ResetColor();
            }
        }
    }

    static void MoveEnemy3(string direction3,Enemy3 enemy)
    {
        EraseEnemy3(enemy);

        if (direction3 == "right")
        {
            enemy.X = enemy.X + 1;
            enemy.Y = enemy.Y + 1;
        }
        if (direction3 == "down")
        {
            enemy.Y = enemy.Y - 1;
            enemy.X = enemy.X - 1;
        }

        PrintEnemy3(enemy);
    }


    static void Fire(Player player,Enemy enemy,Enemy2 enemy2,Enemy3 enemy3)
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

            CheckFireCollision(enemy,enemy2,enemy3);
            Booster();
        }
    }

    // ... (other methods)


    static void Booster()
    {
        if ((FX == oX && FY == oY) || (FX == kX && FY == kY))
        {
            Score += 20;
            PrintHealth();
        }
    }

    // ... (other methods)

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
