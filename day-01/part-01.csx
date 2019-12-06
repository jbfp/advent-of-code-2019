var result = System.IO.File
    .ReadAllLines("./input.txt")
    .Select(double.Parse)
    .Sum(m => Math.Truncate(m / 3) - 2);

Console.WriteLine(result);
