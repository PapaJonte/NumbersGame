namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till gissningsspelet!");

            //
            // GAME START
            //

            bool gameRunning = true; // As long as this bool is true, the program will keep running

            while (gameRunning)
            {
                int maxNumber = 0; // An integer to store the highest number the random number will be
                int maxGuesses = 0; // An integer to store the amount of guesses the user gets

                //
                // CHOOSE A LEVEL
                //

                bool chooseLevel = true; // As long as this is true, the user will be asked to pick a level

                Console.WriteLine("Vänligen välj svårighetsgrad mellan 1-5:");

                while (chooseLevel)
                {
                    if (int.TryParse(Console.ReadLine(), out int levelChoice)) // Converts the user's input from a string to an integer to choose the level for the game
                    {
                        switch (levelChoice)
                        {
                            // Depending on what level the user picked we will declare the highest number the randomizer can pick and how many guesses the user will get
                            // When the user pick the difficulty we will set the bool to be false to end the while-loop
                            case 1:
                                maxNumber = 10;
                                maxGuesses = 6;
                                chooseLevel = false;
                                break;

                            case 2:
                                maxNumber = 20;
                                maxGuesses = 5;
                                chooseLevel = false;
                                break;

                            case 3:
                                maxNumber = 25;
                                maxGuesses = 4;
                                chooseLevel = false;
                                break;

                            case 4:
                                maxNumber = 50;
                                maxGuesses = 3;
                                chooseLevel = false;
                                break;

                            case 5:
                                maxNumber = 100;
                                maxGuesses = 2;
                                chooseLevel = false;
                                break;

                            // In case the user chooses an incorrect number we keep asking the user to pick again
                            default:
                                Console.WriteLine("Ogiltigt val! Välj ett nummer mellan 1-5:");
                                break;
                        }
                    }
                    else // In case the user would type in a character or symbol instead of a number this else statement triggers to let them pick again
                    {
                        Console.WriteLine("Ogiltigt val! Välj ett nummer mellan 1-5:");
                    }
                }

                //
                // RANDOMIZER
                //

                Random random = new Random(); // Here we create a Random object to handle our random outputs
                int number = random.Next(1, maxNumber + 1); // maxNumber + 1, because random.Next(1, 20) would only be a number between 1 and 19

                bool stillGuessing = true; // As long as this bool is true the user will still be able to guess

                Console.WriteLine($"Jag tänker på ett nummer mellan 1 och {maxNumber}. Kan du gissa vilket? Du får {maxGuesses} försök.");

                // String arrays to include more than one message when the user guess too high or too low
                string[] tooHigh =
                {
                        "Tyvärr, du gissade för högt!",
                        "Bra gissat, men tänk lägre!",
                        "Numret är mindre än din gissning!",
                        "Det där var lite väl högt va?",
                        "Kom igen, lite lägre!"
                    };

                string[] tooLow =
                {
                        "Tyvärr, du gissade för lågt!",
                        "Öka!",
                        "Lite högre kan du!",
                        "Oj, det var lågt!",
                        "Här nere finns inte ditt nummer!"
                    };

                //
                // COMPARISON
                //


                for (int i = 1; i <= maxGuesses; i++) // For-loop that runs until the max amount of guesses is reached, will fluctuate depending on level
                {
                    // Here we convert the user's guess from the string value it reads from the input to an integer we can use to compare their number to our random number
                    int userGuess = Convert.ToInt32(Console.ReadLine());

                    // Depending on what the random number is and what the user guess each time, we either tell them that they guess too high, too low or correct
                    if (userGuess > number)
                    {
                        // What this code essentially do is to write out a random message from our string array from before
                        // Since we created a Random object before we can also use it here to randomize the index in the array it pulls the message from
                        // Length is used to make sure we only get an index that exists in the array
                        Console.WriteLine(tooHigh[random.Next(tooHigh.Length)]);
                    }
                    else if (userGuess < number)
                    {
                        Console.WriteLine(tooLow[random.Next(tooLow.Length)]);
                    }
                    else
                    {
                        // If the user guess the correct number we let them know and then change the value of the bool to false
                        // We then break out of the loop to prevent the user from being forced to continue guessing
                        Console.WriteLine("Wohoo! Du klarade det");
                        stillGuessing = false;
                        break;
                    }
                }

                // If the user doesn't guess the correct number in the amount of guesses they received, this message will tell them that they failed
                // If the user did guess the correct number, the bool will now be set to false and this code block won't run at all
                if (stillGuessing)
                {
                    Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på {maxGuesses} försök!");
                }

                //
                // RESTART OR EXIT THE GAME
                //

                // Ask the user if they want to continue or exit the game
                Console.WriteLine("Om du vill spela igen, tryck på valfri tangent. Annars skriv 'nej'");
                string restartGame = Console.ReadLine();
                Console.Clear();

                // If they type "nej" the bool value from the start will change to false, forcing the while-loop to end and the program to close
                if (restartGame == "nej")
                {
                    gameRunning = false;
                }

                //
                // FUNDERINGAR
                //

                // Jag valde att bara inkludera ett nej som svar här, anledningen var att det känndes som ett ja-alternativ var överflödigt.
                // Finns det något exempel i en sån här situation där både ja och nej hade varit användbart?

                // Jag skippade utmaningen "Det bränns!" men jag skulle gärna vilja veta vad man använder för något för att lösa den uppgiften.
                // Rent spontant tänker jag mig att man räknar ut skillnaden mellan talen och bedömer hur nära gissningen var utifrån hur många nummer det var ifrån det rätta svaret.
            }
        }
    }
}
