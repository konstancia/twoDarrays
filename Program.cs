using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1) Coordinates grid");
            Console.WriteLine("2) Number grid with colors");
            Console.WriteLine("3) User input grid");
            Console.WriteLine("0) Exit");
            Console.Write("Pick: ");
            string mode = Console.ReadLine();
            if (mode == "0") break;

            Console.Write("Rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Cols: ");
            int cols = int.Parse(Console.ReadLine());

            string[,] grid = new string[rows, cols];

            if (mode == "1")
            {
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                        grid[r, c] = r + "," + c;
            }
            else if (mode == "2")
            {
                int num = 0;
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                        grid[r, c] = num++.ToString();
            }
            else if (mode == "3")
            {
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                    {
                        Console.Write($"[{r},{c}]: ");
                        grid[r, c] = Console.ReadLine();
                    }
            }

            int w = 1;
            foreach (var cell in grid)
                if (cell.Length > w) w = cell.Length;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                    Console.Write("+" + new string('-', w));
                Console.WriteLine("+");

                for (int c = 0; c < cols; c++)
                {
                    Console.Write("|");
                    if (mode == "2")
                    {
                        int n = int.Parse(grid[r, c]);
                        if (n % 4 == 0) Console.ForegroundColor = ConsoleColor.Red;
                        else if (n % 4 == 1) Console.ForegroundColor = ConsoleColor.Green;
                        else if (n % 4 == 2) Console.ForegroundColor = ConsoleColor.Blue;
                        else Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(grid[r, c].PadLeft(w));
                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }
            for (int c = 0; c < cols; c++)
                Console.Write("+" + new string('-', w));
            Console.WriteLine("+");
        }
    }
}
