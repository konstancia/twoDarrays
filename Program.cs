using System;

class Program
{
    static void Main()
    {
        const string MENU_COORD = "1";
        const string MENU_NUM   = "2";
        const string MENU_USER  = "3";
        const string MENU_EXIT  = "0";

        const char CORNER = '+';
        const char HLINE  = '-';
        const char VLINE  = '|';

        const int MIN_CELL_WIDTH = 1;
        const int COLOR_BUCKETS  = 4;

        while (true)
        {
            Console.WriteLine("1) Coordinates grid");
            Console.WriteLine("2) Number grid with colors");
            Console.WriteLine("3) User input grid");
            Console.WriteLine("0) Exit");
            Console.Write("Pick: ");
            string mode = Console.ReadLine() ?? "";

            if (mode == MENU_EXIT)
            {
                break;
            }

            Console.Write("Rows: ");
            int rows = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Cols: ");
            int cols = int.Parse(Console.ReadLine() ?? "0");

            string[,] grid = new string[rows, cols];

            if (mode == MENU_COORD)
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        grid[r, c] = r + "," + c;
                    }
                }
            }
            else if (mode == MENU_NUM)
            {
                int num = 0;
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        grid[r, c] = (num++).ToString();
                    }
                }
            }
            else if (mode == MENU_USER)
            {
                Console.WriteLine("Fill the grid:");
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        Console.Write("[" + r + "," + c + "]: ");
                        grid[r, c] = Console.ReadLine() ?? "";
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

            int w = MIN_CELL_WIDTH;
            foreach (var cell in grid)
            {
                string s = cell ?? "";
                if (s.Length > w)
                {
                    w = s.Length;
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(CORNER);
                    Console.Write(new string(HLINE, w));
                }
                Console.WriteLine(CORNER);

                for (int c = 0; c < cols; c++)
                {
                    Console.Write(VLINE);
                    if (mode == MENU_NUM)
                    {
                        int n = int.Parse(grid[r, c]);
                        int bucket = n % COLOR_BUCKETS;

                        if (bucket == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (bucket == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (bucket == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        Console.Write(grid[r, c].PadLeft(w));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(grid[r, c].PadLeft(w));
                    }
                }
                Console.WriteLine(VLINE);
            }

            for (int c = 0; c < cols; c++)
            {
                Console.Write(CORNER);
                Console.Write(new string(HLINE, w));
            }
            Console.WriteLine(CORNER);
        }
    }
}
