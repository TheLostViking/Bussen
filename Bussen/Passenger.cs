using System;
using System.Collections.Generic;
using System.Text;

namespace Bussen
{
	//Class of the Passengers
	public class Passenger
	{
		//Private fields for propterties. 
		private string _name;
		private int _age;
		private string _sex;

		//Public properties for the class.
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_age = value;
			}
		}
		public string Sex
		{
			get
			{
				return _sex;
			}
			set
			{
				_sex = value;
			} 
		}
		//The constructor for the class - DONE
        public Passenger(string name, int age, string sex)
        {
			 Name = name;
			 Age = age;
			 Sex = sex;
        }

		//This value is shown in the "Show Passenger" selection - DONE!
		public string print_sex()
		{
			string sex = "";
			if (_sex == "Female")
			{
				sex = _sex;
			}
			else if (_sex == "Male")
            {
				sex = _sex;
            }
			else
            {
				sex = _sex;
            }
			return sex;
		}

		/*
		public void poke()
		{
			//Betyg A
			//Vilken passagerare ska vi peta på?
			//Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
			//Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
			//Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön.
		}

		public void getting_off()
		{
			//Betyg A
			//En passagerare kan stiga av
			//Detta gör det svårare vid inmatning av nya passagerare (som sätter sig på första lediga plats)
			//Sortering blir också klurigare
			//Den mest lämpliga lösningen (men kanske inte mest realistisk) är att passagerare bakom den plats..
			//.. som tillhörde den som lämnade bussen, får flytta fram en plats.
			//Då finns aldrig någon tom plats mellan passagerare.
		}
		*/

	}
}
