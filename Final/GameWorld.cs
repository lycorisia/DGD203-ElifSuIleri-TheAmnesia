using System;

namespace TheAmnesiaGame
{
    public class GameWorld
    {
        private Player player;
        private Map map;
        private bool newGame = true;

        public GameWorld()
        {
            player = new Player("Hero");
            map = new Map((0, 0));
        }

        public GameWorld(Player loadedPlayer)
        {
            newGame = false;
            player = loadedPlayer;
            map = new Map(loadedPlayer.Position);
        }

        public void Start()
        {
            if (newGame)
            {
                Console.WriteLine("You feel a slight throbbing in your head, like you hit your head on something");
                Console.WriteLine("You slowly open your eyes,the sun hitting your eyes. ");
                Console.WriteLine("You fight the pain and stand up, opening your eyes more ");
                Console.WriteLine("As your vision comes back you look around you you are in the middle of what seems to be a forest.");
                Console.WriteLine("You seem to be in the middle of what seems to be a forest, but how?");
                Console.WriteLine("You try to remember something anything but nothing... you can't remember what your name is.");
                Console.ReadKey();
            }
            
            while (true)
            {
                Console.Clear();
                AskToSaveGame();
                if (map.CurrentLocation == "forest")
                {
                    ForestInteraction();
                }
                else if (map.CurrentLocation == "village")
                {
                    VillageInteraction();
                }
                else if (map.CurrentLocation == "cliff")
                {
                    CliffInteraction();
                }
                else if (map.CurrentLocation == "cave")
                {
                    CaveInteraction();
                    
                }
            }
        }

        private void CaveInteraction()
        {
            int stepsForward = 0;
            while (true)
            {
                Console.Clear();

                if (stepsForward == 0)
                {
                    if (!player.Inventory.HasItem("Key"))
                    {
                        Console.WriteLine("There's a obviously old cave, looks older then you. You would enter but there's a door blocking your way.");
                        Console.WriteLine("1. Go back");
                        Console.WriteLine("2. Try to open the door with force");
                        Console.WriteLine("3. Open the door (requires key)");

                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            map.MovePlayer(player, "south");
                            return;
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("The door shook a little bit but didn’t open, It is a good DOOR.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("You don’t have the key to open the door.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Try again.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You unlock the door with the key and enter the cave.");
                        stepsForward = 1; 
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (stepsForward >= 1 && stepsForward < 4)
                {
                    Console.WriteLine("You are inside the cave. It’s dark and narrow.");
                    Console.WriteLine("1. Go forward");
                    Console.WriteLine("2. Go back");

                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        stepsForward++;
                    }
                    else if (choice == "2")
                    {
                        stepsForward--;
                        if (stepsForward == 0)
                        {
                            Console.WriteLine("You exit the cave and return to the village.");
                            map.MovePlayer(player, "south");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                }
                else if (stepsForward == 4)
                {
                    Console.WriteLine("You find a door deep inside the cave.");
                    Console.WriteLine("1. Open the door");
                    Console.WriteLine("2. Don’t open the door");

                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("You open the door and step inside...");
                        Console.WriteLine("You find the book the woman was talking about, opening it you realize it's empty");
                        Console.WriteLine("Confused you flip till the last page where you see a flower");
                        Console.WriteLine("A Spider Lilly, LYCORIS");
                        Console.WriteLine("WAIT! LYCORIS, THATS YOUR.. well OUR name");
                        Console.WriteLine("You take the book outside now remembering why you where here");
                        Console.WriteLine("To retrieve your dad's old notebook, so yo can be an adventurer just like him");
                        Console.WriteLine("Hopefully along your journey, you can finally see him again");
                        Console.WriteLine("The TRUE ENDING");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Menu.DisplayMainMenu();
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("So, what now?");
                        Console.WriteLine("1. Go back outside");

                        string backChoice = Console.ReadLine();
                        if (backChoice == "1")
                        {
                            Console.WriteLine("You leave the cave, deciding to give up on the journey.");
                            Console.WriteLine("GAME OVER, You will always be a nameless.");
                            Console.WriteLine("Press any key to return to the main menu.");
                            Console.ReadKey();
                            Menu.DisplayMainMenu();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                }
            }
        }

        private void VillageInteraction()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("As you enter the village the sun shines above you. It is a lovely enviroment. Where do you want to go?");
                Console.WriteLine("1. Forward (to the cave)");
                Console.WriteLine("2. Right (to the mayor's house)");
                Console.WriteLine("3. Left (to talk to the NPC)");
                Console.WriteLine("4. Go back");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        map.MovePlayer(player, "north");
                        return;
                    case "2":
                        MayorsHouseInteraction();
                        break;
                    case "3":
                        NpcInteraction();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("You return to the path. Shall you head north or south?");
                        Console.WriteLine("1. North");
                        Console.WriteLine("2. South");

                        string pathChoice = Console.ReadLine();
                        string direction = "";
                        if (pathChoice == "1")
                        {
                            direction = "north";

                        }
                        else if (pathChoice == "2")
                        {
                            direction = "south";

                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Try again.");
                            Console.ReadKey();
                        }
                        map.MovePlayer(player, direction);
                        return;
                        
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void MayorsHouseInteraction()
        {
            if (player.Inventory.HasItem("Knife"))
            {
                Console.Clear();
                Console.WriteLine("You picklock the Mayor's door with the knife, You go inside and search a bit till you find a weirdly shaped key.");
                player.Inventory.AddItem("Key");
                Console.WriteLine("You got a key! Press any key to return to the village.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The mayor's house is locked. You could break in if you had something sharp, but you don't.");
                Console.WriteLine("1. Leave");
                Console.WriteLine("2. Wait");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("You decide to leave. Press any key to return to the village.");
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("You wait outside the mayor's house, hoping for someone to return. Days pass, and you eventually fade into obscurity...");
                    Console.WriteLine("GAME OVER, You waited so long you turned into STONE");
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadKey();
                    Menu.DisplayMainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
        private void NpcInteraction()
        {
            Console.Clear();
            Console.WriteLine("NPC: Oh my... you look lost little one, do you need help?");
            Console.WriteLine("??? (YOU): I don't know where I am or who I am for that matter. I am lost.");
            Console.WriteLine("NPC: Amnesia huh... hmmm...");
            Console.WriteLine("*There was a brief pause*");
            Console.WriteLine("NPC: There are rumors that in the north cave there is a book that can answer any question you ask. But the cave is locked by the mayor, and he won't be back for a while. Sorry.");
            Console.WriteLine("I guess she wasn't helpful sheesh");
            Console.WriteLine("Press any key to return to the village.");
            Console.ReadKey();
        }

        private void ForestInteraction()
        {
            int stayCount = 0;
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("It seems like there's a path nearby. Shall we?");
                Console.WriteLine("1. Go to the path");
                Console.WriteLine("2. Stay and question yourself");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    
                    Console.Clear();
                    Console.WriteLine("You approach the path. It splits ahead: north or south?");
                    Console.WriteLine("1. North");
                    Console.WriteLine("2. South");

                    string pathChoice = Console.ReadLine();
                    string direction = "";
                    if (pathChoice == "1")
                    {
                        direction = "north";

                    }
                    else if (pathChoice == "2")
                    {
                        direction = "south";

                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                        return;
                    }

                     map.MovePlayer(player, direction);
                    return;
                    
                }
                else if (choice == "2")
                {
                    stayCount++;
                    if (stayCount >= 5)
                    {
                        Console.Clear();
                        Console.WriteLine("You sit in the forest for too long, lost in your thoughts.");
                        Console.WriteLine("You spend so much time trying to understand you forget about your own well being");
                        Console.WriteLine("GAME OVER, You died because you thought too much");
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                        Menu.DisplayMainMenu();
                        return;
                    }
                    Console.WriteLine("You stay and question yourself but find nothing. Should we go?");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        private void CliffInteraction()
        {
            while (true)
            {
                
                Console.Clear();
                Console.WriteLine("There’s a cliff that you can’t jump, but oh, what is that?");
                Console.WriteLine("1. Inspect");
                Console.WriteLine("2. Go back");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("It seems to be a knife! Will you take it?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    string knifeChoice = Console.ReadLine();

                    if (knifeChoice == "1")
                    {
                        player.Inventory.AddItem("Knife");
                        Console.WriteLine("You got a knife! Staby stab stab.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                    else if (knifeChoice == "2")
                    {
                        Console.WriteLine("I guess we won’t need that. We can go back then.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("You head back to the path. Do you wish to head North or South?");
                    Console.WriteLine("1. North");
                    Console.WriteLine("2. South");

                    string pathChoice = Console.ReadLine();
                    string direction = "";
                    if (pathChoice == "1")
                    {
                        direction = "north";
                        
                    }
                    else if (pathChoice == "2")
                    {
                        direction = "south";
                        
                    }
                    else 
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                    }
                    
                    map.MovePlayer(player, direction);
                    return;
                    

                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        private void AskToSaveGame()
        {
            Console.WriteLine("Do you want to save your progress? (yes/no)");
            string saveChoice = Console.ReadLine().ToLower();
            if (saveChoice == "yes")
            {
                SaveManager saveManager = new SaveManager();
                saveManager.SaveGame(player);
                Console.ReadKey();
                
            }
            
        }
    }
}