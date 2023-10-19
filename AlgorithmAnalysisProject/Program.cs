// See https://aka.ms/new-console-template for more information
using AlgorithmAnalysisProject;
using System.Diagnostics;



int[] inputSizes = { 500, 1000, 5000, 10000 };
List<long> bruteForceRunTimes = new();
List<long> dynamicRunTimes = new();
List<long> decreaseConquerRunTimes = new();

for (int i = 0; i < 5; i++)
{
    GeneratePayoffMatrix generatePayoffMatrix = new GeneratePayoffMatrix();
    Console.WriteLine($"------------------ Run {i + 1} ------------------");
    foreach (var input in inputSizes)
    {
        var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(input);
        var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(input);
        BruteForceTwoPlayerPureNashEquilibrium pureNashEquilibrium = new BruteForceTwoPlayerPureNashEquilibrium();
        DynamicProgrammingTwoPlayerNashEquilibrium dynamicProgrammingTwoPlayerNashEquilibrium = new DynamicProgrammingTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix);
        DecreaseAndConquerTwoPlayerPureNashEquilibrium decreaseAndConquerTwoPlayerPureNashEquilibrium = new DecreaseAndConquerTwoPlayerPureNashEquilibrium();
        Stopwatch stopWatch = new();
        stopWatch.Start();
        pureNashEquilibrium.BruteForceTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, input);
        stopWatch.Stop();
        bruteForceRunTimes.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"BruteForce RunTime (ms): {stopWatch.ElapsedMilliseconds}, Input Size: {input}");
        stopWatch.Reset();
        stopWatch.Start();
        dynamicProgrammingTwoPlayerNashEquilibrium.FindNashEquilibrium();
        stopWatch.Stop();
        dynamicRunTimes.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"DynamicProgramming RunTime (ms): {stopWatch.ElapsedMilliseconds}, Input Size: {input}");
        stopWatch.Reset();
        var n = player1PayoffMatrix.GetLength(0);
        stopWatch.Start();
        decreaseAndConquerTwoPlayerPureNashEquilibrium.DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, 0, n - 1, 0, n - 1);
        stopWatch.Stop();
        decreaseConquerRunTimes.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"DecreaseConquer RunTime (ms): {stopWatch.ElapsedMilliseconds}, Input Size: {input}");
        stopWatch.Reset();
        using (StreamWriter streamWriter = new StreamWriter("RunTimeResults.txt", true))
        {
            streamWriter.WriteLine($"Input Size: {input}");
            streamWriter.WriteLine($"{bruteForceRunTimes[i]},{decreaseConquerRunTimes[i]},{dynamicRunTimes[i]}");
        }
    }

    Console.WriteLine($"-------------------------------------------------");
}

Console.WriteLine($"BruteForce Avg: {bruteForceRunTimes.Average()}");
Console.WriteLine($"Dynamic Avg: {dynamicRunTimes.Average()}");
Console.WriteLine($"DecreaseConquer Avg: {decreaseConquerRunTimes.Average()}");