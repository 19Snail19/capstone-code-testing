Random roll = new Random();

int playerHealth = 30;
int playerDef = 0;
int playerAtk = 0;
int playerDmg = 0;
int totalDmg = 0;

int enemyHealth = 30;
int enemyDef = 0;
int enemyAtk = 0;
int enemyDmg = 0;
int enemyMove = 0;

string player = "";
string[] job = ["Knight", "Mystic", "Urchin"];
string[] enemy = ["Fungus", "Skelly", "ROUS", "Beans", "Guy", "Vamp", "Rock"];
string boss = "Negasus";

Console.WriteLine("\nWelcome to the Lair of the Negasus!");
Console.WriteLine("Beware, for here there be 'monsters'.");
Console.WriteLine("NOTE: The ReadMe will be a valuable resource!");
Console.WriteLine("\nBefore we enter the dungeon, you must choose a class.");
Console.WriteLine("A - Knight: A well rounded warrior\nB - Mystic: The glass cannon\nC - Urchin: A nimble thief");

string choice = Console.ReadLine().ToUpper();

while ((choice != "A") && (choice != "B") && (choice != "C"))
{
    Console.WriteLine("Whut?");
    choice = Console.ReadLine().ToUpper();
}

if (choice == "A")
    {
        player = job[0];
        playerHealth = 50;
        playerDef = 13;
        Console.WriteLine($"Ah, the stalwart {player}!");
    }
else if (choice == "B")
    {
        player = job[1];
        playerHealth = 20;
        playerDef = 10;
        Console.WriteLine($"Oh, the... mystical {player}!");
    }
else if (choice == "C")
    {
        player = job[2];
        playerHealth = 40;
        playerDef = 16;
        Console.WriteLine($"Hm, the shifty {player}!");
    }

Console.WriteLine("\n\nAnd now, we enter the dungeon! BOOM! CRASH! SOUND EFFECTS!");
Console.WriteLine("\n\n\nYou descend the dimly lit staircase.");
Console.WriteLine("The sporadic drip-drop of water echoes up the corridor.");
Console.WriteLine("Stepping out from the stairwell, you behold the first chamber.");
Console.WriteLine("The chamber is a natural cavern bisected by a large ravine.");
Console.WriteLine("Spanning the ravine is a natural bridge, guarded by...");
Console.WriteLine("A SMALL MUSHROOM MAN! PREPARE FOR COMBAT!");

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
                    playerAtk = roll.Next(1, 21);

                    if ((playerAtk >= enemyDef) && (playerAtk != 20))
                    {
                        playerDmg = roll.Next(1, 9);
                        totalDmg = playerDmg;
                        Console.WriteLine($"{player} hits for {totalDmg} damage! Rolled {playerAtk}");
                        enemyHealth -= totalDmg;
                    }
                    else if (playerAtk < enemyDef)
                    {
                        Console.WriteLine($"{player} misses!");
                    }
                    else if (playerAtk == 20)
                    {
                        playerDmg = roll.Next(1, 9);
                        totalDmg = playerDmg * 2;
                        Console.WriteLine($"Critical hit!! {totalDmg} damage! Rolled {playerAtk}");
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
        enemyMove = roll.Next(1, 3);
        
        switch (enemyMove)
        {
            case 1:
                Console.WriteLine($"{enemy[0]} attacks!");
                enemyAtk = roll.Next(1, 21);

                if ((enemyAtk >= playerDef) && (enemyAtk != 20))
                {
                    enemyDmg = roll.Next(1,5);
                    totalDmg = enemyDmg;
                    Console.WriteLine($"{enemy[0]} hits for {totalDmg} damage! Rolled {enemyAtk}");
                    playerHealth -= totalDmg;
                }
                else if (enemyAtk < playerDef)
                {
                    Console.WriteLine($"{enemy[0]} misses!");
                }
                else if (enemyAtk == 20)
                {
                    enemyDmg = roll.Next(1, 5);
                    totalDmg = enemyDmg * 2;
                    Console.WriteLine($"Critical hit!! {totalDmg} damage! Rolled {enemyAtk}");
                    playerHealth -= totalDmg;
                }
                break;

            case 2:
                Console.WriteLine($"{enemy[0]} makes a STRONG attack!");
                enemyAtk = roll.Next(1, 21);

                if ((enemyAtk >= playerDef) && (enemyAtk != 20))
                {
                    enemyDmg = roll.Next(2, 9);
                    totalDmg = enemyDmg;
                    Console.WriteLine($"{enemy[0]} hits for {totalDmg} damage! Rolled {enemyAtk}");
                    playerHealth -= totalDmg;
                }
                else if (enemyAtk < playerDef)
                {
                    Console.WriteLine($"{enemy[0]} misses!");
                }
                else if (enemyAtk == 20)
                {
                    enemyDmg = roll.Next(2, 9);
                    totalDmg = enemyDmg * 2;
                    Console.WriteLine($"Critical hit!! {totalDmg} damage! Rolled {enemyAtk}");
                    playerHealth -= totalDmg;
                }
                break;
        }
    }
}

if ((enemyHealth <= 0) && (playerHealth >= 0))
{
    Console.WriteLine($"\n{player} is victorious!");
}
else if ((enemyHealth >= 0) && (playerHealth <= 0))
{
    Console.WriteLine($"/n{player} has fallen...");
}
else if ((enemyHealth <= 0) && (playerHealth <= 0))
{
    Console.WriteLine("Both parties have fallen.... The end?");
}