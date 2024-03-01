
string choice = Console.ReadLine();
string choice2 = Console.ReadLine();

switch (choice2)
{
    case "rock":
        switch (choice)
        {
            case "rock":
                Console.WriteLine("Try again");
                break;
            case "paper":
                Console.WriteLine("Player1 you win!");
                break;
            case "scissors":
                Console.WriteLine("Player1 you loose");
                break;
        }
        break;
    case "paper":
        switch (choice)
        {
            case "rock":
                Console.WriteLine("Player1 you loose!");
                break;
            case "paper":
                Console.WriteLine("Try again.");
                break;
            case "scissors":
                Console.WriteLine("Player1 you win!");
                break;
        }
        break;
    case "scissors":
        switch (choice)
        {
            case "rock":
                Console.WriteLine("Player1 you win!");
                break;
            case "paper":
                Console.WriteLine("Player1 you loose!");
                break;
            case "scissors":
                Console.WriteLine("Try again");
                break;
        }
        break;
}