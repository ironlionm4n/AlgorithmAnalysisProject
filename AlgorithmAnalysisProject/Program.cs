using AlgorithmAnalysisProject;
using System.Diagnostics;


int[] inputSizes = { 10, 100, 1000, 5000, 10000, 25000 };
List<double> bruteForceRunTimes = new();
List<double> dynamicRunTimes = new();
List<double> decreaseConquerRunTimes = new();
List<double> divideRunTimes = new();
GeneratePayoffMatrix generatePayoffMatrix = new GeneratePayoffMatrix();
bool showLogs = false;
int maxRuns = 1;


foreach (var input in inputSizes)
{

    /*RunBruteForceWithLogging(input);
    RunDecreaseConquerWithLogging(input);
    RunDivideConquerWithLogging(input);*/

    RunBruteForce(input);
    RunDecreaseConquer(input);
    RunDivideConquer(input);
}

void RunBruteForce(int inputSize)
{
    BruteForceTwoPlayerPureNashEquilibrium pureNashEquilibrium = new();

    for (int i = 0; i < maxRuns; i++)
    {
        var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
        var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
        pureNashEquilibrium.BruteForceTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, inputSize);
    }
}

void RunBruteForceWithLogging(int inputSize)
{
    int nashEquilibriumsFound = 0;
    BruteForceTwoPlayerPureNashEquilibrium pureNashEquilibrium = new();
    using (StreamWriter streamWriter = new("BruteForce.txt", true))
    {
        streamWriter.WriteLine($"{inputSize}");
        Stopwatch stopWatch = new();
        for (int i = 0; i < maxRuns; i++)
        {
            var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
            var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
            stopWatch.Start();
            if(pureNashEquilibrium.BruteForceTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, inputSize))
            {
                nashEquilibriumsFound++;
            }
            stopWatch.Stop();
            var elapsedMilliseconds = (double)stopWatch.ElapsedTicks / Stopwatch.Frequency * 1000;
            bruteForceRunTimes.Add(elapsedMilliseconds);
            streamWriter.Write($"{Math.Round(elapsedMilliseconds, 3)},"); // need to round
            stopWatch.Reset();
        }

        streamWriter.WriteLine();
        streamWriter.WriteLine($"NE Found: {nashEquilibriumsFound}");
    }
}

void RunDecreaseConquer(int inputSize)
{
    DecreaseAndConquerTwoPlayerPureNashEquilibrium decreaseAndConquerTwoPlayerPureNashEquilibrium = new();

    for (int i = 0; i < maxRuns; i++)
    {
        var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
        var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
        decreaseAndConquerTwoPlayerPureNashEquilibrium.DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, 0, inputSize - 1, 0, inputSize - 1);
    }
}

void RunDecreaseConquerWithLogging(int inputSize)
{
    int nashEquilibriumsFound = 0;
    DecreaseAndConquerTwoPlayerPureNashEquilibrium decreaseAndConquerTwoPlayerPureNashEquilibrium = new();
    using (StreamWriter streamWriter = new("Decrease.txt", true))
    {
        Stopwatch stopWatch = new();
        streamWriter.WriteLine($"{inputSize}");
        for (int i = 0; i < maxRuns; i++)
        {
            var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
            var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
   
            stopWatch.Start();
            if(decreaseAndConquerTwoPlayerPureNashEquilibrium.DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, 0, inputSize - 1, 0, inputSize - 1))
            {
                nashEquilibriumsFound++;
            }
            stopWatch.Stop();
            var elapsedMilliseconds = (double)stopWatch.ElapsedTicks / Stopwatch.Frequency * 1000;
            decreaseConquerRunTimes.Add(elapsedMilliseconds);
            streamWriter.Write($"{Math.Round(elapsedMilliseconds, 3)},");
            stopWatch.Reset();
        }
        streamWriter.WriteLine();
        streamWriter.WriteLine($"NE Found: {nashEquilibriumsFound}");
    }
}

void RunDivideConquer(int inputSize)
{
    // Divide Conquer Programming Approach

    for (int i = 0; i < maxRuns; i++)
    {
        var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
        var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
        DivideConquerTwoPlayerNashEquilibrium divideConquerTwoPlayerNashEquilibrium = new();
        divideConquerTwoPlayerNashEquilibrium.DivideConquerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, 0, inputSize - 1);
    }
}

void RunDivideConquerWithLogging(int inputSize)
{
    // Divide Conquer Programming Approach

    int nashEquilibriumsFound = 0;
    using (StreamWriter streamWriter = new("Divide.txt", true))
    {
        Stopwatch stopWatch = new();
        streamWriter.WriteLine($"{inputSize}");
        for (int i = 0; i < maxRuns; i++)
        {
            var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
            var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(inputSize);
            DivideConquerTwoPlayerNashEquilibrium divideConquerTwoPlayerNashEquilibrium = new();
            stopWatch.Start();
            if (divideConquerTwoPlayerNashEquilibrium.DivideConquerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, 0, inputSize - 1))
            {
                nashEquilibriumsFound++;
            }
            stopWatch.Stop();
            var elapsedMilliseconds = (double)stopWatch.ElapsedTicks / Stopwatch.Frequency * 1000;
            divideRunTimes.Add(elapsedMilliseconds);
            streamWriter.Write($"{Math.Round(elapsedMilliseconds, 3)},");
            stopWatch.Reset();
        }
        streamWriter.WriteLine();
        streamWriter.WriteLine($"NE Found: {nashEquilibriumsFound}");
    }
}


if (showLogs)
{
    using (StreamWriter streamWriter = new("AverageTimes.txt", true))
    {
        streamWriter.WriteLine($"BruteForce Avg: {Math.Round(bruteForceRunTimes.Average(), 3)}");
        streamWriter.WriteLine($"DecreaseConquer Avg: {Math.Round(decreaseConquerRunTimes.Average(), 3)}");
        streamWriter.WriteLine($"DivideConquer Avg: {Math.Round(divideRunTimes.Average(), 3)}");
    }
    Console.WriteLine($"BruteForce Avg: {Math.Round(bruteForceRunTimes.Average(), 3)}");
    Console.WriteLine($"DecreaseConquer Avg: {Math.Round(decreaseConquerRunTimes.Average(), 3)}");
    Console.WriteLine($"DivideConquer Avg: {Math.Round(divideRunTimes.Average(), 3)}");
}