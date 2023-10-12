// See https://aka.ms/new-console-template for more information
using AlgorithmAnalysisProject;

PureNashEquilibrium pureNashEquilibrium = new PureNashEquilibrium();
Console.WriteLine(pureNashEquilibrium.BruteForceTwoPlayerNashEquilibrium());
DynamicProgrammingTwoPlayerNashEquilibrium dynamicProgrammingTwoPlayerNashEquilibrium = new DynamicProgrammingTwoPlayerNashEquilibrium();
Console.WriteLine(dynamicProgrammingTwoPlayerNashEquilibrium.FindNashEquilibrium());
