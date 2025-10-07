using System;

class Program
{
    static void Main()
    {
        // 1) ask user for dimensions
        int rows = ReadPositiveInt("How many rows? ");
        int cols = ReadPositiveInt("How many columns? ");

        // 2) create the grid
        string[,] grid = new string[rows, cols];

        // 3) fill the grid with user input
        Console.WriteLine("\nNow fill the grid!");
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write($"Enter value for cell [{r},{c}]: ");
                grid[r, c] = Console.ReadLine() ?? "";
            }
        }

        // 4) print the completed grid
        Console.WriteLine("\nHere’s your grid:");
        PrintGrid(grid);
    }

    // number >0
    static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value > 0)
                return value;

            Console.WriteLine("Please enter a whole number > 0.");
        }
    }

    static void PrintGrid(string[,] grid)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        // compute width for neat columns
        int cellWidth = 1;
        foreach (var cell in grid)
            cellWidth = Math.Max(cellWidth, (cell ?? "").Length);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                string cell = grid[r, c] ?? "";
                Console.Write(cell.PadLeft(cellWidth) + " ");
            }
            Console.WriteLine();
        }
    }
}