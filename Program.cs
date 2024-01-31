//author: Rod M
//task: Unit 3 - Lab 3 - Dice Roller


Console.WriteLine("Hello, Player!");
Console.WriteLine("How many sides are on your dice?");

Random rand = new Random();
int result;

while (int.TryParse(Console.ReadLine(), out result) == false || result < 4)
{
    Console.WriteLine("Please try again with at least 4");
}

Console.WriteLine("Great! Ready to roll it? yes/no");

while (true)
{
    
    string startGame = Console.ReadLine();
    if (startGame != null && startGame.ToLower().Trim().Contains("n"))
    {
        Console.WriteLine("Thanks for playing!");
        break;
    }
    else
    {
        long firstRoll = rand.NextInt64(1, result);
        long secondRoll = rand.NextInt64(1, result);
        string combos = checkCombos(firstRoll, secondRoll);
        long points = firstRoll + secondRoll;

        Console.WriteLine("You rolled a {0} and {1} ({2} total)", 
            firstRoll, secondRoll, points);

        Console.WriteLine(getTotals(points));

        if (combos != "")
        {
            Console.WriteLine(combos);

        }
        Console.WriteLine();
        Console.WriteLine("Roll again? yes/no");
    }
}

static string checkCombos(long first, long second)
{
    string combos = first.ToString() + second.ToString();
    if (combos.Contains("11"))
    {
        return "Snake Eyes";
    }
    else if (combos.Contains("1") && combos.Contains("2"))
    {
        return "Ace Deuce";
    }
    else if (combos.Contains("66"))
    {
        return "Box Cars";
    }
    else return "";

}

static string getTotals(long points)
{
    if (points == 7 || points == 11) return "You Win!";
    else if (points == 2 || points == 3 || points == 12) return "Craps!";
    return "";
}