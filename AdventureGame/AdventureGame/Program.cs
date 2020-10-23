using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
 * "Into the Depths"
 * by Justin French
 */
namespace AdventureGame
{
    //establishing the game class
    public static class Game
    {
        public static string CharacterName;
        public static int Scenarios = 3;
        static List<string> Inventory = new List<string>();
        
        static string[] PartOne =
        {
            "At the front of the imposing building you see a weathered old man with a cart. As you near, you see the cart is filled with what looks like mostly junk and only a few useful items. All you have on you is a piece of chalk. You offer it to him, and he says he'll trade a flashlight or an umbrella for it.\nTo choose type either A for the flashlight, or B for the umbrella.",
            "The power in the building goes out - luckily you have a flashlight! You move the light around and a large animal is frightened by the sudden brightness and takes off. As you move the light again, something glitters. You reach down and pick up a coin!",
            "The power in the building goes out! As you move down the hallway you hear what sounds like a large animal nearby. You move the umbrella in a widening arc in front of you to scare it, and the animal skitters off.",
            "The lights return and you move into a room at the end of the hall. There is a vending machine.",
            "Luckily " + CharacterName + " you have that coin you found and you buy yourself a snack.",
            "Too bad you don't have a coin on you," + CharacterName + ",or you would have been able to get a snack.",
            "You begin to climb the stairs to the next floor."
        };

        static string[] PartTwo =
        {
            //Courtesy of Shane Cordray - MSSA JBLM #34 [DRAGONS]
            "Once you get to the top of the stairs, the entire build seems to warp and shift before your eyes. The stairs behind you disappear, the concrete floor and walls seem to change to stone, and the lights dim low. You are no longer in a wharehouse, but a cave. In the darkness before you, you see a faint glow. The glow blinks...out of the shadows steps an enormous dragon! His terrifying gaze set upon you. He bares his teeth, then roars a deafening roar. You look around to see if there was anything to get you out of this situation. You spot two items on the ground. On your right, you see a heap of rope on the ground. On your left, you spot an old pickaxe. Which do you go for? \nTo choose type either A for the rope, or B for the pickaxe.",
            "You lunge for the rope on the ground, just as the dragon lunges, mouth agape, for you. The dragon bites down on air just behind your feet as you stumble to the rope and pick it up. Now what? You begin to look around. You see a small hole in the wall just over head and out of reach. You then look back at the dragon just in time to see his ferocious maw coming toward you. You jump back just in time, but the dragons mouth shuts tight on the end of your rope. The dragon picks you up while you hold on for dear life. He begins to shake his head back and forth, as a dog with a chew toy. Your grip lets loose and you fly, but as luck would have it, you fly straight into that hole in the wall... Wow that was close...",
            "As you begin to run towards the pickaxe, the dragons head, teeth barred, lunges for you. You leap for the tool. Your hand grasp the hilt of the pick axe, but your feet don't touch the ground. You look back and notice the dragon holding on to the end of your pant leg. As he lifts you upward, you jam the pickaxe right into the dragons nostril out of pure terror. The dragon lets go and shrieks, baring it's chest. You see a soft patch of skin on its chest. Out of place, considering the rest of the dragon is covered in rock hard scales. With the pickaxe still in hand, you rush in and drive it directly into the dragon's bare flesh. Its shriek turns into a wale of pure agony. The dragon begins to squirm and role, shaking the ground beneath your feet. Stalagtites fall from the caverns ceiling. Three large rock formations fall and impale the dragon, ending the creatures life. You walk over and pick up the pickaxe that was shaken loose. The rocks have provided you a path through a hole in the cave wall. You proceed through it.",
            "You continue through this tunnel and arrive at the other side fairly quickly. You are still inside the building. You look back and only see a wall with no tunnel to be seen. When you look back forward, you notice in the corner a large locker with a lock on it.",
            "If only you had a way to break it open.",
            "You look down at the large pickaxe in hand, and back at the locker. As though you wished to fell another beast, you swing with all your might at the lock and smash it to pieces. Inside the locker you find a feintly glowing rock with a rune etched on it. You place it in your pocket.",
            "You begin to climb the stairs to the next floor...."
        };

        static string[] PartThree =
        {
            "Once at the top of the stairs, the building changes again. This time, though, you seem to be in a narrow metal hallway. As you walk down the hallway, you see a window. You look out the window and see only the vast emptiness of space. Holy crap you're in a spaceship! You continue down the hallway until you come across a large hangar with a large spaceship. You wonder if you could fly it. Across the hangar you see a door. You run for the door. Once inside you see two glass cages. Each one has person inside. Human people! One the right is a middle aged man and on the left is a young woman. As you approach, they both notice you. They begin to move frantically with mouths opening but you hear nothing. While you watch both people, you surmize that each one wants to be saved, but doesn't want you to save the other. Each cage has what seems to be a 'release' button on it. Which one will you choose? \nPress A for the man or B for the woman.",
            "You press the button for the man's cage. It opens and he jumps out. 'Thank you so much for saving me, but we have to get out of here. In the hangar, where you came from, is a ship. I can fly it. Let's go.' ",
            "You press the button for the womman's cage. It opens and he jumps out. 'Thank you so much for saving me, but we have to get out of here. In the hangar, where you came from, is a ship. I can fly it. Let's go.' ",
            "As you and the newly released prisoner run into the hangar, you see a large amorphous blob. You stop in shear shock. You feel a strange feeling inside your skull.",
            "The man sees the alien then looks back at you. His face is white with terror. 'I'm sorry' is all he is able to say before his head explodes... Then your's.",
            "You look back at the woman. She stares at the alien with a grin on her face. 'Not this time!' she exclaims. She runs straight at the alien and leaps inside it's gelatinous body. A bright light emenates from the alien. Then it explodes. There stands the woman, looking right at you. 'Here you go!,' she says, as she tosses a key to you. You found it!!!",
            "You begin to climb the stairs to the next floor...."
        };

        //print out game title and overview
        public static void StartGame()
        {
            GameTitle();

            Console.WriteLine("It's time for an adventure!");

            NameCharacter();
            Choice();
            EndGame();
        }

        static void GameTitle()
        {
            string Title = "ADVENTURE";


            Console.Title = Title;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"                   _______  ______            _______  _       _________          _______  _______ 
                  (  ___  )(  __  \ |\     /|(  ____ \( (    /|\__   __/|\     /|(  ____ )(  ____ \
                  | (   ) || (  \  )| )   ( || (    \/|  \  ( |   ) (   | )   ( || (    )|| (    \/
                  | (___) || |   ) || |   | || (__    |   \ | |   | |   | |   | || (____)|| (__    
                  |  ___  || |   | |( (   ) )|  __)   | (\ \) |   | |   | |   | ||     __)|  __)   
                  | (   ) || |   ) | \ \_/ / | (      | | \   |   | |   | |   | || (\ (   | (      
                  | )   ( || (__/  )  \   /  | (____/\| )  \  |   | |   | (___) || ) \ \__| (____/\
                  |/     \|(______/    \_/   (_______/|/    )_)   )_(   (_______)|/   \__/(_______/");
            Console.ResetColor();
            Console.WriteLine("\nPress enter to proceed...");
            Console.ReadKey();
            Console.Clear();
        }

        //ask player for a name, and save it
        public static void NameCharacter()
        {
            //reading the input of the characters name
            Console.WriteLine("You've woken up on the side of a dirt road. You have nothing on you but the clothes on your back and a piece of chalk in your pocket. You don't know who you are, where you are, or how you got here. You only remember your name. \nWhat is your name?");
            CharacterName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Find they key, " + CharacterName + ".");
            Console.ResetColor();
            Console.WriteLine("You begin to walk down the road.");
            Console.ReadKey();
            Console.Clear();
        }

        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        //creating branching narratives
        public static void Choice()
        {
            for (int section = 1; section <= Scenarios; section++)
            {
                string input = "";

                switch (section)
                {
                    case 1:
                        //Part One

                        //same pattern for each of the sections. 
                        //1) print the first part of the section
                        Console.WriteLine(PartOne[0]);

                        //2)read in player's choice (a or b)
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write("Enter your choice: ");
                        input = Console.ReadLine();
                        input = input.ToLower();
                        Console.ResetColor();

                        //3) if a, print the next part of the array, otherwise skip next and print 3rd
                        if (input == "a")
                        {
                            Console.WriteLine(PartOne[1]);
                            Inventory.Add("flashlight");
                        }
                        else
                        {
                            Console.WriteLine(PartOne[2]);
                            Inventory.Add("umbrella");
                        }

                        //4) print next part of the section
                        Console.WriteLine(PartOne[3]);

                        //5) again if a, print next, otherwise skip ahead
                        if (input == "a")
                        {
                            Console.WriteLine(PartOne[4]);
                            Inventory.Add("snack");
                        }
                        else
                        {
                            Console.WriteLine(PartOne[5]);
                        }

                        //6) print last piece of the section
                        Console.WriteLine(PartOne[6]);

                        break;

                    case 2:
                        //Part Two

                        Console.WriteLine(PartTwo[0]);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter your choice: ");
                        input = Console.ReadLine();
                        input = input.ToLower();
                        Console.ResetColor();
                        if (input == "a")
                        {
                            Console.WriteLine(PartTwo[1]);
                        }
                        else
                        {
                            Console.WriteLine(PartTwo[2]);
                            Inventory.Add("pickaxe");
                        }
                        Console.WriteLine(PartTwo[3]);
                        if (input == "a")
                        {
                            Console.WriteLine(PartTwo[4]);
                        }
                        else
                        {
                            Console.WriteLine(PartTwo[5]);
                            Inventory.Add("rune");
                        }
                        Console.WriteLine(PartTwo[6]);

                        break;

                    case 3:
                        //Part Three

                        Console.WriteLine(PartThree[0]);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter your choice: ");
                        input = Console.ReadLine();
                        input = input.ToLower();
                        Console.ResetColor();
                        if (input == "a")
                        {
                            Console.WriteLine(PartThree[1]);
                        }
                        else
                        {
                            Console.WriteLine(PartThree[2]);
                        }
                        Console.WriteLine(PartThree[3]);
                        if (input == "a")
                        {
                            Console.WriteLine(PartThree[4]);
                        }
                        else
                        {
                            Console.WriteLine(PartThree[5]);
                            Inventory.Add("!!KEY!!");//big Key objective item
                        }

                        break;

                    default:
                        //default if section number does not match one of the above
                        break;
                }
                //let the player advance when ready, then clear the screen
                Console.WriteLine("Press enter to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        //The End
        private static void EndGame()
        {

            StreamWriter fileWriter = new StreamWriter("file1.txt");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The End...or is it?");
            Console.WriteLine("You collected these items on your journey: ");
            fileWriter.WriteLine("You collected these items on your journey: ");
            foreach (string item in Inventory)
            {
                Console.WriteLine(item);
                fileWriter.WriteLine(item);
            }

            if (Inventory.Contains("!!KEY!!"))
            {
                Console.WriteLine("Congratulations! You accomplished the goal! You found the key!");
                fileWriter.WriteLine("Congratulations! You accomplished the goal! You found the key!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("You didn't find the key...");
                fileWriter.WriteLine("You didn't find the key...");
            }
            Console.WriteLine("Press Enter to exit.");
            fileWriter.Close();
        }
    }

    //establishing a class for objects the user can interact with
    public class Item
    {
        //default is a stone
        public string Name = "Small stone";
        public string Description = "Unimpressive object.";

        string[] Items = { "shoe", "can", "pair of chopsticks" };
        string[] Descriptions = { "Size 10 sneaker", "Empty root beer can", "Pink plastic chopsticks" };

        //constructor
        public Item()
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next(Items.Length);
            Name = Items[number];
            Description = Descriptions[number];
            Console.WriteLine("\nYou found a " + Name + " (" + Description + ").\n");
        }        
    }

    public class Program
    {
        static void Main()
        {
            Game.StartGame();
            Console.Read();
        }
    }
}
