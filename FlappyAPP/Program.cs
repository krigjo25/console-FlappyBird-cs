﻿// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

namespace FlappyAPP;
class Program
{
   static void Main(string[] args)
    {
        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("This is a simple console application that simulates a flappy bird game.");
        Console.WriteLine("This application has the obstacle generation feature enabled.");

        int row = 12;
        int column = 73;

        DrawGameArea(row, column, "#");
    }

    static void DrawGameArea(int row, int column, string Obstacle)
    {
        int newColumn = 0;
        int n = column / 4;
        int CylinderRow = column / 12;
        string newlineCharacter = "(space)";

        while (true)
        {
            ConsoleConfig();
            for (int i = 0; i < row; i++)
            {
                if (i == 0 || i == row - 1)
                {
                    DrawColumns(column, Obstacle);
                    Console.Write("\n");
                }
                else if (i == 1 || i == row - 2)
                {

                    bool boolean = n < 8 ? true : false;

                    if (boolean && newColumn < CylinderRow - 1)
                    {
                        newColumn++;
                    }
                    DrawCylinder(CylinderRow, n, Obstacle, boolean, newColumn);
                }
                else
                {
                    //  TODO: Add a Figure to the game area
                    DrawColumns(1, newlineCharacter);
                    Console.Write("\n");
                }
            }
            Thread.Sleep(250);
            Console.Clear();

            n--;

            if (n == 0)
            {
                // Reset the column count
                n = (int)(column / 1.25);
                newColumn = 0;
            }
        }
    }

    static void DrawColumns(int column, string Obstacle)
    {
        for (int i = 0; i < column; i++)
        {
            Console.Write(Obstacle);
        }
    }

    static void DrawCylinder(int row, int column, string Obstacle, bool boolean, int counter, ConsoleColor color = ConsoleColor.Green)
    {
        column--;
        const int n = 55;
        int CylinderColumn = 5;
        Console.ForegroundColor = color;

        for (int i = 0; i < row; i++)
        {
            // For every 25th column, draw a pipe
            DrawColumns(column, " ");
            DrawColumns(CylinderColumn, Obstacle);

            if (column < 15)
            {
                DrawColumns(n, " ");
            }

            if (boolean)
            {
                DrawColumns(counter, Obstacle);

            }
            Console.Write("\n");
        }
    }

    static void ConsoleConfig()
    {
        Console.Title = "FlappyAPP";
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;
        }
}
