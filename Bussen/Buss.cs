using System;
using System.Collections.Generic;
using System.Linq;
/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 * Då kan det vara läge att ställa in startvärden som jag gjort.
 * Man kan också skriva ut saker i konsollen i konstruktorn för att se att den "vaknar
 * Denna kod hjälper mest om du siktar mot betyget E och C
 * För högre betyg krävs mer självständigt arbete
 */

//Nedan är namnet på "namespace" - alltså projektet. 
//SKapa ett nytt konsollprojekt med namnet "Bussen" så kan ni kopiera över all koden rakt av från denna fil
namespace Bussen
{
    //Här ska menyn ligga för att göra saker
    //Jag rekommenderar switch och case här
    //I filmen nummer 1 för slutprojektet så skapar jag en meny på detta sätt.
    //Dessutom visar jag hur man anropar metoderna nedan via menyn
    //Börja nu med att köra koden för att se att det fungerar innan ni sätter igång med menyn.
    //Bygg sedan steg-för-steg och testkör koden.
    class Buss
    {
        private Passenger[] Seats = new Passenger[24];
        private int numberOfPassengers; 
        private int maxAge = 110; //Max age to set a limit.
        private int minAge = 1; // Minimum of limit.
        //Main Menu of the Program - DONE!
        public void Run()
        {
          
            while(true)
            {
                Console.WriteLine("---Welcome! Please choose your action!---\n");
                Console.WriteLine($"Press [1] to Add a Passenger.");
                Console.WriteLine($"Press [2] for Passenger interaction.");
                Console.WriteLine($"Press [3] list all the current Passengers.");
                Console.WriteLine($"Press [0] to Exit.");
                ConsoleKeyInfo userChoice = Console.ReadKey(true);

                switch (userChoice.Key)
                {
                    case ConsoleKey.D1:
                        AddPassenger(); //Method for adding passenger. 
                        break;

                    case ConsoleKey.D2:
                        SubmenuPassengers(); //Method for submenu for interactions. 
                        break;

                    case ConsoleKey.D3:
                        ShowPassengers(); //Method for printing current passengers onboard.
                        break;

                    case ConsoleKey.D0:
                        Console.WriteLine("Thanks for playing!");
                        return;

                    default:
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine($"Please use valid options!\n");
                            Console.WriteLine("Press any key...");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        //Adds a passenger to the bus, at the first available seat - DONE!
        private void AddPassenger()
        {
            string newName;
            string newSex = "";
            int newAge;
            Console.WriteLine("--- ADD PASSENGER ---\n");
            while (true)
            {
                Console.Write("Enter name of new passenger: ");

                bool result = false;
                newName = Console.ReadLine();
                result = newName.All(Char.IsLetter);
                if (result == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input! Only letters please!");
                }
            }

            while (true)
            {
                Console.Write("Enter age of the new passenger: ");
                try
                {
                    newAge = int.Parse(Console.ReadLine());
                    if (newAge > maxAge)
                    {
                        Console.WriteLine("Enter a lower age!");
                    }
                    else if (newAge < minAge)
                    {
                        Console.WriteLine("Enter a higher age!");
                    }
                    else 
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input! Only digits please!");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey(true);

                }
            }
            while (true)
            {
                string userInput = "";
                Console.WriteLine("Press [M] for Male.");
                Console.WriteLine("Press [F] for Female.");
                Console.WriteLine("Press [O] for Other/None-Binary");
                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "M":
                        {
                            newSex = "Male";
                        }
                        break;
                    case "F":
                        {
                            newSex = "Female";
                        }
                        break;
                    case "O":
                        {
                            newSex = "None-Binary person";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Use only valid options!");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press any key...");
                            Console.ReadKey(true);
                            continue;
                        }
                }

                for (int i = 0; i < Seats.Length - 1; i++)
                {
                    if (Seats[i] == null)
                    {
                        Seats[i] = new Passenger(newName, newAge, newSex);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine("Passanger added!");               
                break;
            }
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey(true);
            
            
        }
        //Prints all the current passangers + empty seats - DONE!
        private void ShowPassengers()
        {
            Console.Clear();
            Console.WriteLine("--- Current Passengers ---");
            Console.WriteLine("\n");
          
            numberOfPassengers = 0; //Reset for passenger counting.

            for (int i = 0; i < Seats.Length; i++)
            {
                Passenger passenger = Seats[i];
                if (passenger == null)
                {
                    Console.WriteLine($"Seatnumber {i + 1}, this seat is empty!");
                }
                else
                {
                    Console.WriteLine($"Seatnumber {i + 1}, {passenger.Name}. A {passenger.Sex} at {passenger.Age} years of age!");
                    numberOfPassengers++;
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"\nThere's a total of {numberOfPassengers} passengers onboard!");
            Console.WriteLine("\n");

            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey(true);
        }

        //Finds the total age of all current passengers. - DONE
        private int TotalAgeOfPassengers()
        {
            int totalAge = 0;

            foreach (Passenger person in Seats)
            {
                if (person == null)
                {
                    continue;
                }
                else
                {
                    totalAge += person.Age;
                }
            }
            return totalAge;
        }

        //Finds the Average age of all the Passengers - DONE!
        private float AverageAgeOfPassengers()
        {
            int personsOnBoard = 0;
            foreach (var person in Seats)
            {
                if (person == null)
                {
                    continue;
                }
                else
                {
                    personsOnBoard++;
                }
            }

            float averageAge = TotalAgeOfPassengers() / personsOnBoard;
            return averageAge;
        }

        //Finds the highest age among the passengers and prints it. - DONE!
        private int HighestAge()
        {
            int highestAge = 0;
            foreach (var person in Seats)
            {
                if (person == null)
                {
                    continue;
                }
                else if (person.Age > highestAge)
                {
                    highestAge = person.Age;
                }
            }
            return highestAge;
        }
        //Finds matches of all the passengers with a certain age. - DONE!
        private int FindCertainAge(int firstAge, int secondAge)
        {
            int passengersWithCertainAge = 0;
            List<Passenger> tempList = new List<Passenger>();


            if (secondAge != 0)
            {
                foreach (var person in Seats)
                {
                    if (person == null)
                    {
                        continue; //Seat is empty.
                    }
                    else if (person.Age >= firstAge)
                    {
                        tempList.Add(person);
                    }
                }

                foreach (var person in tempList.ToArray())
                {
                    if (person.Age > secondAge)
                    {
                        tempList.Remove(person);
                    }
                }
                return tempList.Count;
            }
            else
            {
                foreach (var person in Seats)
                {
                    if (person == null)
                    {
                        continue; //Seat is empty.
                    }
                    else if (person.Age == firstAge)
                    {
                        passengersWithCertainAge++;
                    }
                }
                return passengersWithCertainAge;
            }
        }

        //Sorts the bus by age. From youngest to highest. - DONE!
        private void SortBusByAge()
        {
            int max = Seats.Length - 1;
            for (int i = 0; i < max; i++)
            {
                int seatsLeft = max - 1;
                for (int j = 0; j < seatsLeft; j++)
                {
                    if (Seats[j + 1] == null)
                    {
                        continue;
                    }
                    else if (Seats[j].Age > Seats[j + 1].Age)
                    {
                        var tempObject = Seats[j];
                        Seats[j] = Seats[j + 1];
                        Seats[j + 1] = tempObject;
                    }
                }
            }
        }

        //Menu for Passenger interaction. - DONE!
        private void SubmenuPassengers()
        {

            Console.WriteLine("--- Passenger Interaction --- \n");
            Console.WriteLine("Press [T] for total age of all passengers onbard.");
            Console.WriteLine("Press [A] for average age of all passengers onbard.");
            Console.WriteLine("Press [H] for the highest age of a person onboard.");
            Console.WriteLine("Press [F] to choose an age or agespan to show.");
            Console.WriteLine("Press [S] to sort the passengers onboard by age");
            Console.WriteLine("Press [B] to go back to the Main Menu.");
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            switch (userInput.Key)
            {
                case ConsoleKey.T:
                    Console.WriteLine("\n");
                    Console.WriteLine($"The total age of all passengers on board is {TotalAgeOfPassengers()} years!");
                    Console.WriteLine("\n");

                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey(true);
                    break;

                case ConsoleKey.A:
                    Console.WriteLine("\n");
                    Console.WriteLine($"The average age of all passengers onboard is {AverageAgeOfPassengers()} years!");
                    Console.WriteLine("\n");

                    Console.WriteLine("Press any key to return to the main menu..."); 
                    Console.ReadKey(true);
                    break;

                case ConsoleKey.H:
                    Console.WriteLine("\n");
                    Console.WriteLine($"The oldest person on the bus is {HighestAge()} years old!");
                    Console.WriteLine("\n");

                    Console.WriteLine("Press any key to return to the main menu..."); 
                    Console.ReadKey(true);
                    break;

                case ConsoleKey.F:
                    Console.WriteLine("\n");
                    Console.Write($"Enter the first age to look for!");
                    int firstAge = int.Parse(Console.ReadLine());
                    Console.Write($"Enter a second age for the agespan, or just enter zero(0) to search for the first age only.");
                    int secondAge = int.Parse(Console.ReadLine());
                    int findAge = FindCertainAge(firstAge, secondAge);
                    Console.WriteLine("\n");
                    Console.WriteLine($"There are {findAge} passengers with that age or within that agespan onboard!");
                    Console.WriteLine("\n");

                    Console.WriteLine("Press any key to return to the main menu..."); 
                    break;

                case ConsoleKey.S:
                    SortBusByAge();
                    Console.WriteLine("\n");
                    Console.WriteLine($"Passengers were sorted by their age, select 'Current Passengers' option from the Main Menu to see the result!");
                    Console.WriteLine("\n");

                    Console.WriteLine("Press any key to return to the main menu..."); 
                    Console.ReadKey(true);
                    break;

                case ConsoleKey.B:
                    return;

                default:
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Use only valid options!");
                        Console.WriteLine("\n");

                        Console.WriteLine("Press any key...");
                        Console.ReadKey(true);
                    }
                    break;
            }
        }
    }
}


