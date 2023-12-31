﻿using System;
using System.Windows.Forms;

namespace modified_gol
{
    static class Program
    {
        public static Random _rand = new Random();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Utils.StartDebugger();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }

    public class Utils
    {
        public static bool DEBUGGING = false;

        public static void StartDebugger()
        {
            DEBUGGING = true;
        }

        public static void Debug(string s)
        {
            if (DEBUGGING)
                System.Diagnostics.Debug.WriteLine(s);
        }

        public static bool IsWithinBounds((int, int) vals, int lower, int upper) =>
            (lower <= vals.Item1 && vals.Item1 <= upper) && (lower <= vals.Item2 && vals.Item2 <= upper);

        public static String FlattenArrayOfBoolsToNumbers(bool[] arr)
        {
            string output = "";

            for (int i = 0; i < arr.Length; i++)
                if (arr[i])
                    output += (i+1).ToString();

            return output;
        }
    }
}
