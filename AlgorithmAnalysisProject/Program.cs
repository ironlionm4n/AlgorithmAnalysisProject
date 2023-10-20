using AlgorithmAnalysisProject;
using System.Diagnostics;


int[] inputSizes = { 5, 50, 100, 500, 1000, 2500, 5000, 7500, 10000 };
List<long> bruteForceRunTimes = new();
List<long> dynamicRunTimes = new();
List<long> decreaseConquerRunTimes = new();
GeneratePayoffMatrix generatePayoffMatrix = new GeneratePayoffMatrix();
bool _showLogs = true;

foreach (var input in inputSizes)
{
    // Creating payoff matrices of strategies for the given input size
    var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(input);
    var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(input);

    // Creating objects of the different algorithms
    BruteForceTwoPlayerPureNashEquilibrium pureNashEquilibrium = new BruteForceTwoPlayerPureNashEquilibrium();
    DynamicProgrammingTwoPlayerNashEquilibrium dynamicProgrammingTwoPlayerNashEquilibrium = new DynamicProgrammingTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix);
    DecreaseAndConquerTwoPlayerPureNashEquilibrium decreaseAndConquerTwoPlayerPureNashEquilibrium = new DecreaseAndConquerTwoPlayerPureNashEquilibrium();

    Stopwatch stopWatch = new();

    // Brute Force 
    stopWatch.Start();
    pureNashEquilibrium.BruteForceTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, input);
    stopWatch.Stop();
    bruteForceRunTimes.Add(stopWatch.ElapsedMilliseconds);
    if(_showLogs)
        Console.WriteLine($"BruteForce RunTime (ms): {stopWatch.ElapsedMilliseconds}, Input Size: {input}");

    using (StreamWriter streamWriter = new StreamWriter("BruteForceRunTimes.txt", true))
    {
        streamWriter.WriteLine($"{input},{stopWatch.ElapsedMilliseconds}");
    }

    // Resetting stopwatch after each algorithm
    stopWatch.Reset();
        
    // Dynamic Programming
    stopWatch.Start();
    dynamicProgrammingTwoPlayerNashEquilibrium.FindNashEquilibrium();
    stopWatch.Stop();
    dynamicRunTimes.Add(stopWatch.ElapsedMilliseconds);
    if(_showLogs)
        Console.WriteLine($"DynamicProgramming RunTime (ms): {stopWatch.ElapsedMilliseconds}, Input Size: {input}");

    using (StreamWriter streamWriter = new StreamWriter("DynamicRunTimes.txt", true))
    {
        streamWriter.WriteLine($"{input},{stopWatch.ElapsedMilliseconds}");
    }

    // Resetting stopwatch after each algorithm
    stopWatch.Reset();

    // Decrease and Conquer
    //var n = player1PayoffMatrix.GetLength(0);
    stopWatch.Start();
    decreaseAndConquerTwoPlayerPureNashEquilibrium.DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, 0, input - 1, 0, input - 1);
    stopWatch.Stop();
    decreaseConquerRunTimes.Add(stopWatch.ElapsedMilliseconds);
    if(_showLogs)
        Console.WriteLine($"DecreaseConquer RunTime (ms): {stopWatch.ElapsedMilliseconds}, Input Size: {input}");

    using (StreamWriter streamWriter = new StreamWriter("DecreaseConquer.txt", true))
    {
        streamWriter.WriteLine($"{input},{stopWatch.ElapsedMilliseconds}");
    }

    // Resetting stopwatch after each algorithm
    stopWatch.Reset();

}

using (StreamWriter streamWriter = new StreamWriter("AverageTimes.txt", true))
{
    streamWriter.WriteLine($"BruteForce Avg: {Math.Round(bruteForceRunTimes.Average(), 2)}");
    streamWriter.WriteLine($"Dynamic Avg: {Math.Round(dynamicRunTimes.Average()),2}");
    streamWriter.WriteLine($"DecreaseConquer Avg: {Math.Round(decreaseConquerRunTimes.Average(), 2)}");
}


if (_showLogs)
{
    Console.WriteLine($"BruteForce Avg: {Math.Round(bruteForceRunTimes.Average(), 2)}");
    Console.WriteLine($"Dynamic Avg: {Math.Round(dynamicRunTimes.Average(), 2)}");
    Console.WriteLine($"DecreaseConquer Avg: {Math.Round(decreaseConquerRunTimes.Average(), 2)}");
}

// Clear all the lists of runtimes for next iteration
bruteForceRunTimes.Clear();
dynamicRunTimes.Clear();
decreaseConquerRunTimes.Clear();