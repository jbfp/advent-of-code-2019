double CalculateFuel(double mass)
{
    return Math.Truncate(mass / 3) - 2;
}

var input = System.IO.File
    .ReadAllLines("./input.txt")
    .Select(double.Parse);

var total = 0.0;

foreach (var moduleMass in input)
{
    var fuel = CalculateFuel(moduleMass);
    total += fuel;

    var currentFuel = fuel;

    while (currentFuel > 0)
    {
        var x = CalculateFuel(currentFuel);

        if (x < 0)
        {
            x = 0;
        }

        total += x;
        currentFuel = x;
    }
}

Console.WriteLine(total);
