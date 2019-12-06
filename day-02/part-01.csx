var input = File.ReadAllText("./input.txt")
    .Split(',')
    .Select(int.Parse)
    .ToArray();

input[1] = 12;
input[2] = 2;

int ip = 0;

while (true)
{
    var opcode = input[ip];

    if (opcode == 99)
    {
        break;
    }
    else
    {
        var input0 = input[input[ip + 1]];
        var input1 = input[input[ip + 2]];
        var outputPos = input[ip + 3];

        int result;

        if (opcode == 1)
        {
            result = input0 + input1;
        }
        else if (opcode == 2)
        {
            result = input0 * input1;
        }
        else
        {
            throw new InvalidOperationException();
        }

        input[outputPos] = result;
    }

    ip += 4;
}

Console.WriteLine(input[0]);
