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

IEnumerable<(int s, (int x, int y) p)> TraceWire(IEnumerable<(Direction, int)> path)
{
    int x = 0;
    int y = 0;
    int s = 0;

    foreach (var (direction, steps) in path)
    {
        for (int i = 0; i < steps; i++)
        {
            yield return (s, (x, y));

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

            s++;
        }
    }
}

IReadOnlyDictionary<(int x, int y), int> TraceWireTotal(IEnumerable<(Direction, int)> path)
{
    return TraceWire(path)
    .GroupBy(e => e.p, e => e.s)
    .ToDictionary(x => x.Key, x => x.First());
}

var wire1 = TraceWireTotal(paths[0]);
var wire2 = TraceWireTotal(paths[1]);

var minSignalDelay = wire1.Keys.ToHashSet()
    .Intersect(wire2.Keys.ToHashSet())
    .Select(p => wire1[p] + wire2[p])
    .OrderBy(n => n)
    .Skip(1)
    .First();

Console.WriteLine(minSignalDelay);
