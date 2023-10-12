// See https://aka.ms/new-console-template for more information
using AlgorithmAnalysisProject;
using System.Diagnostics;

GeneratePayoffMatrix generatePayoffMatrix = new GeneratePayoffMatrix();

int[] inputSizes = { 100, 1000, 5000, 10000 };
foreach(var input in inputSizes)
{
    var player1PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(input);
    var player2PayoffMatrix = generatePayoffMatrix.GenerateRandomPayoffMatrices(input);
    BruteForcePureNashEquilibrium pureNashEquilibrium = new BruteForcePureNashEquilibrium();
    DynamicProgrammingTwoPlayerNashEquilibrium dynamicProgrammingTwoPlayerNashEquilibrium = new DynamicProgrammingTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix);
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    pureNashEquilibrium.BruteForceTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, input);
    stopWatch.Stop();
    Console.WriteLine($"BruteForce RunTime (ms): {stopWatch.ElapsedMilliseconds}, Input Size: {input}");
    stopWatch.Reset();
    stopWatch.Start();
    dynamicProgrammingTwoPlayerNashEquilibrium.FindNashEquilibrium();
    stopWatch.Stop();
    Console.WriteLine($"DynamicProgramming RunTime (ms): {stopWatch.ElapsedMilliseconds}, Input Size: {input}");
    stopWatch.Reset();
}