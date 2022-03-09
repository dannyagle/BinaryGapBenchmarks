using BinaryGap;

var gap = new Gap();

for (int i = 1150; i < 1155; i++)
{
    Console.WriteLine($"{Convert.ToString(i, 2)} = {gap.LinqSolution(i)} v {gap.ShiftSolution(i)} v {gap.ArraySolution(i)}");
};
