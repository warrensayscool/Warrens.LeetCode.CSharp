﻿namespace Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Algorithm.Backtracking backtracking = new Algorithm.Backtracking();

            backtracking.KnightsTour(7);
        }
    }
}