using System;
using System.Threading;
using games.bl;
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
        Player player = new Player(player, pX, pY);
        DrawBoard();
        PrintPlayer();

        while (true)
        {
            
            PrintHealth();
            Stars();

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                MovePlayer(key);
                if (key==ConsoleKey.Spacebar)
                {
                    Fire();
                }
            }

            MoveEnemy(enemyDirection);
            enemyDirection = ChangeDirection(enemyDirection);
            FireAtEnemy();
            MoveEnemy2(enemyDirection2);
            enemyDirection2 = ChangeDirection2(enemyDirection2);
            FireAtEnemy2();
            enemyDirection3 = ChangeDirection3(enemyDirection3);
            MoveEnemy3(enemyDirection3);
            FireAtEnemy3();
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

    static void MovePlayer(ConsoleKey key)
    {
        ErasePlayer();

        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (pY > 1) pY--;
                break;
            case ConsoleKey.RightArrow:
                if (pY < 61) pY++;
                break;
            case ConsoleKey.UpArrow:
                if (pX > 1) pX--;
                break;
            case ConsoleKey.DownArrow:
                if (pX < 20) pX++;
                break;
        }

        PrintPlayer();
    }

    static void ErasePlayer()
    {
        for (int i = 0; i < player2D.GetLength(0); i++)
        {
            for (int j = 0; j < player2D.GetLength(1); j++)
            {
                Console.SetCursorPosition(pY + j, pX + i);
                Console.Write(" ");
            }
        }
    }

    static void PrintPlayer()
    {
        for (int i = 0; i < player2D.GetLength(0); i++)
        {
            for (int j = 0; j < player2D.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(pY + j, pX + i);

                Console.WriteLine(player2D[i, j]);
                Console.ResetColor();
            }
        }
    }

   static void EraseEnemy()
{
    for (int i = 0; i < enemyHeight; i++)
    {
        for (int j = 0; j < enemyWidth; j++)
        {
                
            Console.SetCursorPosition(eX + j, eY + i);
            Console.Write(" ");
        }
    }
}

static void PrintEnemy()
{
    for (int i = 0; i < enemyHeight; i++)
    {
        for (int j = 0; j < enemyWidth; j++)
        {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(eX + j, eY + i);
            Console.WriteLine(enemy2D[i, j]);
                Console.ResetColor();
        }
    }
}
static void EraseEnemy2()
{
    for (int i = 0; i < enemyHeight; i++)
    {
        for (int j = 0; j < 14; j++)
        {
            Console.SetCursorPosition(fX + j, fY + i);
            Console.Write(" ");
        }
    }
}

static void PrintEnemy2()
{
    for (int i = 0; i < enemyHeight; i++)
    {
        for (int j = 0; j < enemyWidth; j++)
        {
                Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(fX + j, fY + i);
            Console.WriteLine(enemy22D[i, j]);
                Console.ResetColor();
        }
    }
}
static void MoveEnemy(string direction)
{
    EraseEnemy();

    if (direction == "right")
    {
        eX = eX + 1;
    }
    else if (direction == "left")
    {
        eX = eX - 1;
    }

    PrintEnemy();
}
static string ChangeDirection(string direction)
{
    if (direction == "right" && eX >= 34)
    {
        direction = "left";
    }
    else if (direction == "left" && eX <= 2)
    {
        direction = "right";
    }
    return direction;
}

static string ChangeDirection2(string direction2)
{
    if (direction2 == "down" && fY >= 15)
    {
        direction2 = "up";
    }
    else if (direction2 == "up" && fY <= 7)
    {
        direction2 = "down";
    }
    return direction2;
}
static void MoveEnemy2(string direction2)
{
    EraseEnemy2();
    if (direction2 == "down")
    {
        fY = fY + 1;
    }
    else if (direction2 == "up")
    {
        fY = fY - 1;
    }
    PrintEnemy2();
}

static void FireAtEnemy()
{
    for (int i = 0; i <= 45; i++)
    {
        gY = eY + 2;
        gX = eX + 11 + i;
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

static void FireAtEnemy2()
{
    for (int i = 0; i <= 45; i++)
    {
        dY = fY + 5 + i;
        dX = fX + 5;
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

static void FireAtEnemy3()
{
    for (int i = 0; i <= 45; i++)
    {
        vY = cY + 3 + i;
        vX = cX + 8 + i;
        if (vY < 25 && board[vY,vX] == ' ')
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
static void CheckFireCollision()
{
    if (Score == 300)
    {
       
        PlayerWon();
    }

    if ((FY == eY + 2) && (FX >= eX && FX <= eX + 10))
    {
        Score += 10;
        PrintHealth();
    }

    if ((FY == cY) && (FX >= cX && FX <= cX + 10))
    {
        Score += 10;
        PrintHealth();
    }

    if ((FY == fY) && (FX >= fX && FX <= fX + 10))
    {
        Score += 10;
        PrintHealth();
    }

    if (Score == 300)
    {
       
        PlayerWon();
    }
}

static string ChangeDirection3(string direction3)
{
    if (direction3 == "right" && cX >= 16)
    {
        direction3 = "down";
    }
    if (direction3 == "down" && cY <= 11)
    {
        direction3 = "right";
    }
    return direction3;
}
    static void EraseEnemy3() //removing enemy
    {
        for (int i = 0; i < enemyHeight; i++)
        {
            for (int j = 0; j < enemyWidth; j++)
            {
                Console.SetCursorPosition(cX + j, cY + i);
                Console.Write(" ");
            }
        }
    }
    static void PrintEnemy3()  //displaying enemy
    {
        for (int i = 0; i < enemyHeight; i++)
        {
            for (int j = 0; j < enemyWidth; j++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(cX + j, cY + i);
                Console.WriteLine(enemyD[i,j]);
                Console.ResetColor();
            }
        }
    }

    static void MoveEnemy3(string direction3)
{
    EraseEnemy3();

    if (direction3 == "right")
    {
        cX = cX + 1;
        cY = cY + 1;
    }
    if (direction3 == "down")
    {
        cY = cY - 1;
        cX = cX - 1;
    }

    PrintEnemy3();
}


    static void Fire()
    {
        for (int i = 0; i <= 20; i++)
        {
            FY = pX - 2 - i;
            FX = pY + 6;

            if (FY > 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(FX, FY);
                Console.Write("l");
                Thread.Sleep(10);
                Console.SetCursorPosition(FX, FY);
                Console.Write(" ");
                Console.ResetColor ();
            }

            CheckFireCollision();
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

