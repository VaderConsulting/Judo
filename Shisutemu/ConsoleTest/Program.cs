using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Tournament RockinghamOpen = new Tournament(new DateTime(2017,01,01),new DateTime(2017,09,10), "Port Kennedy");

            RockinghamOpen.SetMatCount(3);
            RockinghamOpen.LoadCategories(@"C:\Users\YourUser\Documents\Visual Studio 2017\Projects\Shisutemu\Data\Categories.xml");
            //RockinghamOpen.LoadCategories(@"C:\Users\YourUser\Documents\Visual Studio 2017\Projects\Shisutemu\Data\Female Categories.xml");
            

            //////////////////////////////////////////////////////////////////////////////////

            //Person Individual1 = new Person(new Name("Dave", "Robinson"), Enums.Sex.Male);
            //Player Jodoka1 = new Player();

            //Jodoka1.Rank = new Rank(Enums.Colours.White);

            //Jodoka1.Weight = new Weight(71.5);
            //Jodoka1.DateOfBirth = new DateTime(1968, 10, 7);
            //Individual1.Player = Jodoka1;

            

            ////////////////////////////////////////////////////////////////////////////////////

            //Person Individual2 = new Person(new Name("Cody", "Robinson"), Enums.Sex.Male);
            //Player Jodoka2 = new Player();

            //Jodoka2.Rank = new Rank(Enums.Colours.Blue);

            //Jodoka2.Weight = new Weight(60);
            //Jodoka2.DateOfBirth = new DateTime(1995, 2, 26);
            //Individual2.Player = Jodoka2;


            //RockinghamOpen.AddPerson(Individual1);
            //RockinghamOpen.AddPerson(Individual2);


            // Load from csv
            //RockinghamOpen.LoadEntrantsFromFile(@"C:\Users\YourUser\Documents\Visual Studio 2017\Projects\Shisutemu\Data\2016_Entrants.csv");

            RockinghamOpen.DistributeWeightCategoriesAmongstMats(true);


            Console.ReadKey();
        }
    }
}
