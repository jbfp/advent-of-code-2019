var input = File.ReadAllText("./input.txt")
    .Split(',')
    .Select(int.Parse)
    .ToArray();

int[] Reset()
{
    var arr = new int[input.Length];
    input.CopyTo(arr, 0);
    return arr;
}

void RunProgram(int[] memory)
{
    int ip = 0;

    while (true)
    {
        var opcode = memory[ip];

        if (opcode == 99)
        {
            break;
        }
        else
        {
            var input0 = memory[memory[ip + 1]];
            var input1 = memory[memory[ip + 2]];
            var outputPos = memory[ip + 3];

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

            memory[outputPos] = result;
        }

        ip += 4;
    }
}

for (int noun = 0; noun < 100; noun++)
{
    for (int verb = 0; verb < 100; verb++)
    {
        var memory = Reset();
        memory[1] = noun;
        memory[2] = verb;
        RunProgram(memory);
        
        if (memory[0] == 1969_07_20)
        {
            Console.WriteLine("100 * {0} + {1} = {2}", noun, verb, 100 * noun + verb);
        }
    }
}
