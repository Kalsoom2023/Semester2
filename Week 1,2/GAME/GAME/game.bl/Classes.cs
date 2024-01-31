﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.bl
{
    public class Enemy
    {
        public char[,] DisplayCharacter;
        public int X;
        public int Y;

       
        public Enemy(char[,] displayCharacter, int x, int y)
        {
            DisplayCharacter = displayCharacter;
            X = x;
            Y = y;
        }
    }
    public class Enemy2
    {
        public char[,] DisplayCharacter;
        public int X;
        public int Y;


        public Enemy2(char[,] displayCharacter, int x, int y)
        {
            DisplayCharacter = displayCharacter;
            X = x;
            Y = y;
        }
    }
    public class Enemy3
    {
        public char[,] DisplayCharacter;
        public int X;
        public int Y;


        public Enemy3(char[,] displayCharacter, int x, int y)
        {
            DisplayCharacter = displayCharacter;
            X = x;
            Y = y;
        }
    }

    public class Player
    {
        public char[,] DisplayCharacter;
        public int X;
        public int Y;

       
        public Player(char[,] displayCharacter, int x, int y)
        {
            DisplayCharacter = displayCharacter;
            X = x;
            Y = y;
        }
    }
}


