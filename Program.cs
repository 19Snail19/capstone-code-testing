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
Typewrite("Beware, for here there be 'monsters'.");
Typewrite("NOTE: The ReadMe will be a valuable resource!");
Typewrite("\nBefore we enter the dungeon, you must choose a class.");
Typewrite("A - Knight: A well rounded warrior\nB - Mystic: The glass cannon\nC - Urchin: A nimble thief");
choice = Console.ReadLine().ToUpper();

while ((choice != "A") && (choice != "B") && (choice != "C"))
{
    Typewrite("Whut?");
    choice = Console.ReadLine().ToUpper();
}

if (choice == "A")
    {
        player = job[0];
        playerHealth = 40;
        playerDef = 14;
        Typewrite($"Ah, the stalwart {player}!");
    }
else if (choice == "B")
    {
        player = job[1];
        playerHealth = 20;
        playerDef = 12;
        Typewrite($"Oh, the... mystical {player}!");
    }
else if (choice == "C")
    {
        player = job[2];
        playerHealth = 30;
        playerDef = 16;
        Typewrite($"Hm, the shifty {player}!");
    }

Typewrite("\n\nAnd now, we enter the dungeon! BOOM! CRASH! SOUND EFFECTS!");

//Room 1
while (roomOneClear == false)
{
    Typewrite("\n\n\nYou descend the dimly lit staircase.");
    Typewrite("The sporadic drip-drop of water echoes up the corridor.");
    Typewrite("Stepping out from the stairwell, you behold the first chamber.");
    Typewrite("The chamber is a natural cavern bisected by a large ravine.");
    Typewrite("Spanning the ravine is a natural bridge.");
    Typewrite("The bridge is guarded by...");
    Typewrite("A small mushroom man! PROTECT YOUR SHINS!");


    //Remove these when implementing different monsters
    enemyDef = 12;
    enemyHealth = 20;

    while ((playerHealth > 0) && (enemyHealth > 0))
    {    
        if (playerHealth > 0 )
        {
            Typewrite($"\n\n{player}-- HP: {playerHealth} / DEF: {playerDef}");
            Typewrite("What will you do?\nA: Attack\nB: Defend");
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
                                playerDmg = roll.Next(1, 11);
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
                    Typewrite($"{enemy[0]} attacks!");
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
                    Typewrite($"{enemy[0]} makes a STRONG attack!");
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
if ((roomOneClear == true) && (playerHealth > 0))
{
    Typewrite("\n\nThis chamber is a natural cavern bisected by a large ravine.");
    Typewrite("Spanning the ravine is a natural bridge.");
    Typewrite("On the bridge is a chalk outline resembling a small mushroom man.");
    Typewrite("While this room DOES have exits, you can't use them.");
    Typewrite("Coding is hard and this is only a prototype.");
    Typewrite("Enjoy eternity in this one chamber!");

    Typewrite("\n\nPress any key to rage quit.");
    Console.ReadKey();
}