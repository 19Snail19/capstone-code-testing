using System.Runtime.CompilerServices;

Random roll = new Random();

//This took me ENTIRELY too long to figure out
static void Typewrite(string text, int speed = 10)
{
    foreach (char c in text)
    {
        Console.Write(c);
        System.Threading.Thread.Sleep(speed);
    }
    Console.WriteLine();
}

bool inRoomOne = false;
bool inRoomTwo = false;
bool inRoomThree = false;
bool inRoomFour = false;
bool inRoomFive = false;
bool inRoomSix = false;
bool inRoomSeven = false;
bool inRoomEight = false;
bool inRoomNine = false;

bool roomOneClear = false;
bool roomTwoClear = false;
bool roomThreeClear = false;
bool roomFourClear = false;
bool roomFiveClear = false;
bool roomSixClear = false;
bool roomSevenClear = false;

int playerHealth = 0;
int playerDef = 0;
int playerAtkRoll = 0;
int playerDmg = 0;

int totalDmg = 0;
int chaliceUsedCount = 0;

int enemyHealth = 30;
int enemyDef = 0;
int enemyAtkRoll = 0;
int enemyDmg = 0;
int enemyAttack = 0;

string choice = "";
string player = "";
string[] job = ["Knight", "Mystic", "Urchin"];
string[] enemy = ["Fungus", "Skelly", "ROUS", "Beans", "Guy", "Vamp", "Rock"];
string boss = "Negasus";

Typewrite("\nWelcome to the Lair of the Negasus!");
Typewrite("It's time for some LORE!");
Typewrite("Would you like to hear it, or are you gonna break my heart?");
Console.WriteLine("\n|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
Console.WriteLine("| A: Stay a while and listen  |");
Console.WriteLine("| B: Break the DM's heart     |");
Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
choice = Console.ReadLine().ToUpper();

if (choice == "A")
{
    Typewrite("\nHokay, strap in friend. It's story time.");
    Typewrite("Long ago, a powerful, angry, and INCREDIBLY insane wizard began to");
    Typewrite("dabble in the forbidden art of slapping critter parts together");
    Typewrite("in order to make even worse critters.");
    Typewrite("\nThis nonsense continued for a few decades, giving rise to many");
    Typewrite("of the creatures we know and loathe today. You know the owlbear?");
    Typewrite("Blame the wizard.");
    Typewrite("\nFast forward a few MORE decades. The wizard finally completed his magnum opus.");
    Typewrite("Slapping the tail and bitey bits of a crocodile onto the body of a pegasus,");
    Typewrite("the wizard had created a truly monsterous beast...");
    Typewrite("THE NEGASUS!");
    Typewrite("\nBlessed with unnatural intelligence... for some reason... and a deep");
    Typewrite("hatred of player characters, the Negasus decided that, for the sake of a");
    Typewrite("text adventure game, it would slay the wizard and turn his foul laboratory");
    Typewrite("into the titular Lair of the Negasus.");
    Typewrite("\nFrom this warren of suckitude, the Negasus recruited some lackeys and began");
    Typewrite("to terrorize the land. Fields were salted. Homes were burned. Cows were tipped.");
    Typewrite("In order to bring peace to the land again, the king... wait. Where are you going?");
    Typewrite("Don't go down there. That's LITERALLY where the Negasus lives. Are you even");
    Typewrite("listening to me? You haven't even picked a class yet!");
}
else if (choice == "B")
{
    Typewrite("*Sad DM noises*");
}
else
{
    Typewrite("Whut?");
    choice = Console.ReadLine().ToUpper();
}

Typewrite("\nAs you descend the rough-hewn stairs, you figure you might as well pick a class.");
Console.WriteLine("\n|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
Console.WriteLine("| A: Knight - The well-rounded warrior  |");
Console.WriteLine("| B: Mystic - The glass cannon          |");
Console.WriteLine("| C: Urchin - The nimble thief          |");
Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
choice = Console.ReadLine().ToUpper();

while ((choice != "A") && (choice != "B") && (choice != "C"))
{
    Typewrite("\nWhut?");
    choice = Console.ReadLine().ToUpper();
}

if (choice == "A")
    {
        player = job[0];
        playerHealth = 40;
        playerDef = 14;
        Typewrite($"\nAh, the stalwart {player}!");
    }
else if (choice == "B")
    {
        player = job[1];
        playerHealth = 20;
        playerDef = 12;
        Typewrite($"\nOh, the... mystical {player}!");
    }
else if (choice == "C")
    {
        player = job[2];
        playerHealth = 30;
        playerDef = 16;
        Typewrite($"\nHm, the shifty {player}!");
    }

Typewrite("\n\nAnd now, we enter the dungeon! BOOM! CRASH! SOUND EFFECTS!");

//Room 1
while (roomOneClear == false)
{
    Typewrite("\n\n\nYou descend the dimly lit stairwell.");
    Typewrite("The sporadic drip-drop of water echoes up the corridor.");
    Typewrite("Stepping out from the stairwell, you behold the first chamber.");
    Typewrite("The chamber is a natural cavern bisected by a large ravine.");
    Typewrite("Spanning the ravine is a natural bridge.");
    Typewrite("The bridge is guarded by...");
    Typewrite("A small mushroom man! PROTECT YOUR SHINS!");

    while ((playerHealth > 0) && (enemyHealth > 0))
    {    
        enemyDef = 12;
        enemyHealth = 20;
        inRoomOne = true;

        if (playerHealth > 0 )
        {
            Typewrite($"\n\n{player}-- HP: {playerHealth} / DEF: {playerDef}");
            Console.WriteLine("\n|~~~~~~~~~~~~~~|");
            Console.WriteLine("| A: Attack    |");
            Console.WriteLine("| B: Defend    |");
            Console.WriteLine("|~~~~~~~~~~~~~~|");
            choice = Console.ReadLine().ToUpper();

            while ((choice != "A") && (choice != "B"))
            {
                Typewrite("Whut?");
                choice = Console.ReadLine().ToUpper();
            }

                switch (choice)
                {
                    case "A":
                        Typewrite($"\n{player} attacks!");
                        playerAtkRoll = roll.Next(1, 21);

                        if ((playerAtkRoll >= enemyDef) && (playerAtkRoll != 20))
                        {
                            if (player == job[0])
                            {
                                //playerDmg = roll.Next(1, 11);
                                playerDmg = 100;
                            }
                            else if (player == job[1])
                            {
                                playerDmg = roll.Next(1, 21);
                            }
                            else if (player == job[2])
                            {
                                playerDmg = roll.Next(1, 9);
                            }
                            totalDmg = playerDmg;
                            Typewrite($"{player} hits for {totalDmg} damage!");
                            enemyHealth -= totalDmg;
                        }
                        else if (playerAtkRoll < enemyDef)
                        {
                            Typewrite($"\n{player} misses!");
                        }
                        else if (playerAtkRoll == 20)
                        {
                            playerDmg = roll.Next(1, 9);
                            totalDmg = playerDmg * 2;
                            Typewrite($"\nCritical hit!! {totalDmg} damage!");
                            enemyHealth -= totalDmg;
                        }
                        break;
                    
                    case "B":
                        Typewrite($"\n{player} defends! +2 DEF until next round!");
                        playerDef += 2;
                        break;
                }
        }

        if (enemyHealth > 0)
        {
            Typewrite($"\n\n{enemy[0]}'s Turn!");
            enemyAttack = roll.Next(1, 3);
            
            switch (enemyAttack)
            {
                case 1:
                    Typewrite($"{enemy[0]} throws a punch!");
                    enemyAtkRoll = roll.Next(1, 21);

                    if ((enemyAtkRoll >= playerDef) && (enemyAtkRoll != 20))
                    {
                        enemyDmg = roll.Next(1,5);
                        totalDmg = enemyDmg;
                        Typewrite($"{enemy[0]} hits for {totalDmg} damage!");
                        playerHealth -= totalDmg;
                    }
                    else if (enemyAtkRoll < playerDef)
                    {
                        Typewrite($"{enemy[0]} misses!");
                    }
                    else if (enemyAtkRoll == 20)
                    {
                        enemyDmg = roll.Next(1, 5);
                        totalDmg = enemyDmg * 2;
                        Typewrite($"Critical hit!! {totalDmg} damage!");
                        playerHealth -= totalDmg;
                    }
                    break;

                case 2:
                    Typewrite($"{enemy[0]} tries to shank you with a pointy stick!");
                    enemyAtkRoll = roll.Next(1, 21);

                    if ((enemyAtkRoll >= playerDef) && (enemyAtkRoll != 20))
                    {
                        enemyDmg = roll.Next(2, 9);
                        totalDmg = enemyDmg;
                        Typewrite($"{enemy[0]} hits for {totalDmg} damage!");
                        playerHealth -= totalDmg;
                    }
                    else if (enemyAtkRoll < playerDef)
                    {
                        Typewrite($"{enemy[0]} misses!");
                    }
                    else if (enemyAtkRoll == 20)
                    {
                        enemyDmg = roll.Next(2, 9);
                        totalDmg = enemyDmg * 2;
                        Typewrite($"Critical hit!! {totalDmg} damage!");
                        playerHealth -= totalDmg;
                    }
                    break;
            }
        }
        if (choice == "B")
        {
            playerDef -= 2;
        }
    }

    if ((enemyHealth <= 0) && (playerHealth >= 0))
    {
        roomOneClear = true;
        Typewrite($"\n{player} is victorious!");
        Typewrite("Press any key to continue.");
        Console.ReadKey();
    }
    else if ((enemyHealth >= 0) && (playerHealth <= 0))
    {
        roomOneClear = true;
        Typewrite($"\n{player} has fallen...");
        Typewrite("Press any key to rage quit.");
        Console.ReadKey();
    }
    //Should NOT happen, but just in case.
    else if ((enemyHealth <= 0) && (playerHealth <= 0))
    {
        roomOneClear = true;
        Typewrite("Both parties have fallen.... The end?");
        Console.ReadKey();
    }
}
if ((roomOneClear == true) && (playerHealth > 0) && (inRoomOne == true))
{
    Typewrite("\n\nThis chamber is a natural cavern bisected by a large ravine.");
    Typewrite("Spanning the ravine is a natural bridge.");
    Typewrite("On the bridge is a chalk outline resembling a small mushroom man.");
    Typewrite("You can see three exits in the chamber.");
    Typewrite("There are two exits across the bridge; one on the north wall and one on the east wall.");
    Typewrite("On the south wall is the stairwell you entered by.");
    Typewrite("Because I am too lazy to code a world beyond this dungeon, it seems a large");
    Typewrite("iron portcullis now bars any escape.");
    Typewrite("Which way do you go?");
    Console.WriteLine("\n|~~~~~~~~~~|");
    Console.WriteLine("| A: North |");
    Console.WriteLine("| B: East  |");
    Console.WriteLine("|~~~~~~~~~~|");
    choice = Console.ReadLine().ToUpper();

    while (roomThreeClear == false)
    {
        if ((choice == "A") && (inRoomOne == true))
        {
            inRoomThree = true;
            inRoomOne = false;

            Typewrite("\n\nThis chamber doesn't look like an underground chamber at all.");
            Typewrite("Before you stretches a vast open plain of vibrant green grass.");
            Typewrite("Fluffy white clouds drift lazily across the pale blue sky.");
            Typewrite("The only things that ruins your immersion are the exits on");
            Typewrite("the east and west walls.");
            Typewrite("SANITY CHECK! To see if we can move backwards!");
            Typewrite("Choose A to go BACK to room 1!");

            choice = Console.ReadLine().ToUpper();
        }
            if (choice == "A")
            {
                inRoomOne = true;
                inRoomThree = false;                
            }
    }     
}