Random roll = new Random();

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

Console.WriteLine("\nWelcome to the Lair of the Negasus!");
Console.WriteLine("Beware, for here there be 'monsters'.");
Console.WriteLine("NOTE: The ReadMe will be a valuable resource!");
Console.WriteLine("\nBefore we enter the dungeon, you must choose a class.");
Console.WriteLine("A - Knight: A well rounded warrior\nB - Mystic: The glass cannon\nC - Urchin: A nimble thief");
choice = Console.ReadLine().ToUpper();

while ((choice != "A") && (choice != "B") && (choice != "C"))
{
    Console.WriteLine("Whut?");
    choice = Console.ReadLine().ToUpper();
}

if (choice == "A")
    {
        player = job[0];
        playerHealth = 40;
        playerDef = 14;
        Console.WriteLine($"Ah, the stalwart {player}!");
    }
else if (choice == "B")
    {
        player = job[1];
        playerHealth = 20;
        playerDef = 12;
        Console.WriteLine($"Oh, the... mystical {player}!");
    }
else if (choice == "C")
    {
        player = job[2];
        playerHealth = 30;
        playerDef = 16;
        Console.WriteLine($"Hm, the shifty {player}!");
    }

Console.WriteLine("\n\nAnd now, we enter the dungeon! BOOM! CRASH! SOUND EFFECTS!");

//Room 1
while (roomOneClear == false)
{
    Console.WriteLine("\n\n\nYou descend the dimly lit staircase.");
    Console.WriteLine("The sporadic drip-drop of water echoes up the corridor.");
    Console.WriteLine("Stepping out from the stairwell, you behold the first chamber.");
    Console.WriteLine("The chamber is a natural cavern bisected by a large ravine.");
    Console.WriteLine("Spanning the ravine is a natural bridge.");
    Console.WriteLine("The bridge is guarded by...");
    Console.WriteLine("A small mushroom man! PROTECT YOUR SHINS!");


    //Remove these when implementing different monsters
    enemyDef = 12;
    enemyHealth = 20;

    while ((playerHealth > 0) && (enemyHealth > 0))
    {    
        if (playerHealth > 0 )
        {
            Console.WriteLine($"\n\n{player}-- HP: {playerHealth} / DEF: {playerDef}");
            Console.WriteLine("What will you do?\nA: Attack\nB: Defend");
            choice = Console.ReadLine().ToUpper();

            while ((choice != "A") && (choice != "B"))
            {
                Console.WriteLine("Whut?");
                choice = Console.ReadLine().ToUpper();
            }

                switch (choice)
                {
                    case "A":
                        Console.WriteLine($"{player} attacks!");
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
                            Console.WriteLine($"{player} hits for {totalDmg} damage!");
                            enemyHealth -= totalDmg;
                        }
                        else if (playerAtkRoll < enemyDef)
                        {
                            Console.WriteLine($"{player} misses!");
                        }
                        else if (playerAtkRoll == 20)
                        {
                            playerDmg = roll.Next(1, 9);
                            totalDmg = playerDmg * 2;
                            Console.WriteLine($"Critical hit!! {totalDmg} damage!");
                            enemyHealth -= totalDmg;
                        }
                        break;
                    
                    case "B":
                        Console.WriteLine($"{player} defends!");
                        playerDef += 2;
                        break;
                }
        }

        if (enemyHealth > 0)
        {
            Console.WriteLine($"\n\n{enemy[0]}'s Turn!");
            enemyAttack = roll.Next(1, 3);
            
            switch (enemyAttack)
            {
                case 1:
                    Console.WriteLine($"{enemy[0]} attacks!");
                    enemyAtkRoll = roll.Next(1, 21);

                    if ((enemyAtkRoll >= playerDef) && (enemyAtkRoll != 20))
                    {
                        enemyDmg = roll.Next(1,5);
                        totalDmg = enemyDmg;
                        Console.WriteLine($"{enemy[0]} hits for {totalDmg} damage!");
                        playerHealth -= totalDmg;
                    }
                    else if (enemyAtkRoll < playerDef)
                    {
                        Console.WriteLine($"{enemy[0]} misses!");
                    }
                    else if (enemyAtkRoll == 20)
                    {
                        enemyDmg = roll.Next(1, 5);
                        totalDmg = enemyDmg * 2;
                        Console.WriteLine($"Critical hit!! {totalDmg} damage!");
                        playerHealth -= totalDmg;
                    }
                    break;

                case 2:
                    Console.WriteLine($"{enemy[0]} makes a STRONG attack!");
                    enemyAtkRoll = roll.Next(1, 21);

                    if ((enemyAtkRoll >= playerDef) && (enemyAtkRoll != 20))
                    {
                        enemyDmg = roll.Next(2, 9);
                        totalDmg = enemyDmg;
                        Console.WriteLine($"{enemy[0]} hits for {totalDmg} damage!");
                        playerHealth -= totalDmg;
                    }
                    else if (enemyAtkRoll < playerDef)
                    {
                        Console.WriteLine($"{enemy[0]} misses!");
                    }
                    else if (enemyAtkRoll == 20)
                    {
                        enemyDmg = roll.Next(2, 9);
                        totalDmg = enemyDmg * 2;
                        Console.WriteLine($"Critical hit!! {totalDmg} damage!");
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
        Console.WriteLine($"\n{player} is victorious!");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else if ((enemyHealth >= 0) && (playerHealth <= 0))
    {
        roomOneClear = true;
        Console.WriteLine($"\n{player} has fallen...");
        Console.WriteLine("Press any key to rage quit.");
        Console.ReadKey();
    }
    //Should NOT happen until spells and abilities are added
    else if ((enemyHealth <= 0) && (playerHealth <= 0))
    {
        roomOneClear = true;
        Console.WriteLine("Both parties have fallen.... The end?");
        Console.ReadKey();
    }
}
if ((roomOneClear == true) && (playerHealth > 0))
{
    Console.WriteLine("\n\nThis chamber is a natural cavern bisected by a large ravine.");
    Console.WriteLine("Spanning the ravine is a natural bridge.");
    Console.WriteLine("On the bridge is a chalk outline resembling a small mushroom man.");
    Console.WriteLine("While this room DOES have exits, you can't use them.");
    Console.WriteLine("Coding is hard and this is only a prototype.");
    Console.WriteLine("Enjoy eternity in this one chamber!");

    Console.WriteLine("\n\nPress any key to rage quit.");
    Console.ReadKey();
}