﻿// the ourAnimals array will store the following: 
using System.Runtime.Intrinsics.Arm;
using System.Xml.Serialization;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

//variables for case 5,6
bool validEntry = false;
int indexOfSelectedPetForUpdate = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

Console.Clear();

Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
do
{
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with their characteristics");
    Console.WriteLine(" 8. Display all dogs with their characteristics");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();

    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }
    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to continue.");
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            int currCount = 0;
            string anotherPet = "";

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    currCount++;
                }
            }

            if (currCount < maxPets)
                Console.WriteLine($"Current we have {currCount} pets at home. Our capacity for new animal friends is: {maxPets - currCount}");

            do
            {
                Console.WriteLine("Do you want to enter information for a new pet? (y/n)");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    anotherPet = readResult.ToLower();
                }
            } while (anotherPet == "");

            while (anotherPet == "y" && currCount < maxPets)
            {
                validEntry = false;

                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                animalID = animalSpecies.Substring(0, 1) + (currCount + 1).ToString();

                do
                {
                    Console.WriteLine("enter the age of the pet");
                    readResult = Console.ReadLine();
                    int petAge;

                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPhysicalDescription == "");

                do
                {
                    Console.WriteLine("Enter a personality description of the pet");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (animalPersonalityDescription == "");

                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }

                } while (animalNickname == "");

                ourAnimals[currCount, 0] = "ID #: " + animalID;
                ourAnimals[currCount, 0] = "ID #: " + animalID;
                ourAnimals[currCount, 1] = "Species: " + animalSpecies;
                ourAnimals[currCount, 2] = "Age: " + animalAge;
                ourAnimals[currCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[currCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[currCount, 5] = "Personality: " + animalPersonalityDescription;

                currCount += 1;

                if (currCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter infor for another pet? (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (currCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            Console.WriteLine("Press the Enter key to continue.");

            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    int petAge;

                    if (ourAnimals[i, 2] == "Age: ?" || ourAnimals[i, 2] == "Age: ")
                    {
                        validEntry = false;

                        do
                        {
                            Console.Write($"Enter an age for {ourAnimals[i, 0]}:");
                            Console.WriteLine();
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                if (int.TryParse(readResult, out petAge))
                                {
                                    validEntry = true;
                                    ourAnimals[i, 2] = "Age: " + readResult;
                                }
                            }
                        } while (validEntry == false);
                    }

                    if (ourAnimals[i, 4] == "Physical description: tbd" || ourAnimals[i, 4] == "Physical description: ")
                    {

                        do
                        {
                            Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)");
                            readResult = Console.ReadLine();

                            if (readResult != "")
                            {
                                ourAnimals[i, 4] = "Physical description: " + readResult.ToLower();
                            }

                        } while (ourAnimals[i, 4] == "Physical description: tbd" || ourAnimals[i, 4] == "Physical description: ");
                    }
                }
            }

            Console.WriteLine("Age and physical description fields are complete for all of our friends. \r\nPress the Enter key to continue");
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    if (ourAnimals[i, 3] == "Nickname: tbd" || ourAnimals[i, 3] == "Nickname: ")
                    {
                        do
                        {
                            Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();

                            if (readResult != "")
                            {
                                ourAnimals[i, 3] = "Nickname: " + readResult.ToLower();
                            }
                        } while (ourAnimals[i, 3] == "Nickname: tbd" || ourAnimals[i, 3] == "Nickname: ");
                    }

                    if (ourAnimals[i, 5] == "Personality: tbd" || ourAnimals[i, 5] == "Personality: ")
                    {
                        do
                        {
                            Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();

                            if (readResult != "")
                            {
                                ourAnimals[i, 5] = "Personality: " + readResult.ToLower();
                            }
                        } while (ourAnimals[i, 5] == "Personality: tbd" || ourAnimals[i, 5] == "Personality: ");
                    }
                }
            }

            Console.WriteLine("Nickname and personality description fields are complete for all of our friends. \r\nPress the Enter key to continue");
            break;

        case "5":
            // Edit an animal’s age
            Console.WriteLine("Please enter the animal ID of the animal you want to edit.");
            indexOfSelectedPetForUpdate = 0;
            validEntry = false;
            int updatedAge = 0;

            do
            {
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    for (int i = 0; i < maxPets; i++)
                    {
                        if ((String.Format("ID #: {0}", readResult) == ourAnimals[i, 0]) && (ourAnimals[i, 0] != "ID #: "))
                        {
                            Console.WriteLine($"you would like to edit the age of the animal with {ourAnimals[i, 0]}.");
                            indexOfSelectedPetForUpdate = i + 1;
                            validEntry = true;
                        }
                    }
                }
                Console.WriteLine("Please make sure you enter the valid animal ID.");
            } while (validEntry == false);

            do
            {
                validEntry = false;

                Console.WriteLine("Please enter the new age for our animal friend:");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    if (int.TryParse(readResult, out updatedAge))
                    {
                        ourAnimals[indexOfSelectedPetForUpdate - 1, 2] = "Age: " + readResult;
                        validEntry = true;
                        Console.WriteLine($"You have updated the age of animal with {ourAnimals[indexOfSelectedPetForUpdate, 0]} to be {readResult}");
                        Console.WriteLine("Please press Enter to continue.");
                        Console.WriteLine();
                    }
                }
            } while (validEntry == false);

            break;

        case "6":
            // Edit an animal’s personality description
            Console.WriteLine("Please enter the animal ID of the animal you want to edit.");
            validEntry = false;
            indexOfSelectedPetForUpdate = 0;

            do
            {
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    for (int i = 0; i < maxPets; i++)
                    {
                        if ((String.Format("ID #: {0}", readResult) == ourAnimals[i, 0]) && (ourAnimals[i, 0] != "ID #: "))
                        {
                            Console.WriteLine($"you would like to edit the age of the animal with {ourAnimals[i, 0]}.");
                            indexOfSelectedPetForUpdate = i + 1;
                            validEntry = true;
                        }
                    }
                }
                Console.WriteLine("Please make sure you enter the valid animal ID.");
            } while (validEntry == false);

            do
            {
                validEntry = false;
                Console.WriteLine("Please enter the new personality description for our animal friend:");
                readResult = Console.ReadLine();

                if (readResult != "")
                {
                    ourAnimals[indexOfSelectedPetForUpdate - 1, 5] = "Personality: " + readResult;
                    validEntry = true;
                    Console.WriteLine($"You have updated the personality of animal with {ourAnimals[indexOfSelectedPetForUpdate - 1, 0]} to be {readResult}");
                    Console.WriteLine("Please press Enter to continue.");
                    Console.WriteLine();
                }
            } while (validEntry == false);

            break;

        case "7":
            // Display all cats with their characteristics
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1] == "Species: cat")
                {
                    Console.WriteLine(ourAnimals[i, 0]);
                    Console.WriteLine(ourAnimals[i, 3]);
                    Console.WriteLine(ourAnimals[i, 4]);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            break;

        case "8":
            // Display all dogs with their characteristics
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1] == "Species: dog")
                {
                    Console.WriteLine(ourAnimals[i, 0]);
                    Console.WriteLine(ourAnimals[i, 3]);
                    Console.WriteLine(ourAnimals[i, 4]);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            break;
            break;

        default:
            break;
    }

    Console.ReadLine();

} while (menuSelection != "exit");