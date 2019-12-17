var paths = File
    .ReadAllLines("./input.txt")
    .Select(line => line
        .Split(',')
        .Select(ParseComponent))
    .ToList();

enum Direction { L, U, R, D }

(Direction, int) ParseComponent(string component)
{
    var direction = (Direction)Enum.Parse(typeof(Direction), component.Substring(0, 1));
    var steps = int.Parse(component.Substring(1));
    return (direction, steps);
}

IEnumerable<(int, int)> TraceWire(IEnumerable<(Direction, int)> path)
{
    int x = 0;
    int y = 0;

    foreach (var (direction, steps) in path)
    {
        for (int i = 0; i < steps; i++)
        {
            yield return (x, y);

            switch (direction)
            {
                case Direction.L:
                    x -= 1;
                    break;
                case Direction.U:
                    y += 1;
                    break;
                case Direction.R:
                    x += 1;
                    break;
                case Direction.D:
                    y -= 1;
                    break;
            }
        }
    }
}

int ManhattanDistance((int x, int y) point) => Math.Abs(point.x) + Math.Abs(point.y);

var wire1 = TraceWire(paths[0]);
var wire2 = TraceWire(paths[1]);

var shortest = wire1
    .Intersect(wire2)
    .Select(ManhattanDistance)
    .OrderBy(n => n)
    .Skip(1)
    .First();

Console.WriteLine(shortest);
