using Judo;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

using Utilities;
//using Microsoft.VisualBasic.FileIO;

namespace Foundation
{
    public class Tournament
    {
        #region Constants

        public const string KANJITYPENAME = "コンペ";
        public const string JAPANESETYPENAME = "Konpe";
        public const string ENGLISHTYPENAME = "Tournament";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private Guid _Identifier = Guid.Empty;
        private DateTime _Start = DateTime.MinValue;
        private DateTime _Finish = DateTime.MinValue;
        private Club _Sponsor = null;
        private Address _Address = null;
        private string _Name = string.Empty;
        private ObservableCollection<Mat> _Mats = null;
        private ObservableCollection<Person> _Officials = null;
        private ObservableCollection<Person> _Members = null;
        private ObservableCollection<WeightCategory> _WeightCategories = null;
        private ObservableCollection<AgeCategory> _AgeCategories = null;
        private ObservableCollection<Club> _Clubs = null;

        #region for loading time comparison

        private DateTime Timestamp1 = new DateTime();
        private DateTime Timestamp2 = new DateTime();

        #endregion

        #endregion

        #region Properties

        public Guid Identifier
        {
            get
            {
                return _Identifier;
            }
            set
            {
                _Identifier = value;
            }
        }

        public DateTime Start
        {
            get
            {
                return _Start;
            }
            set
            {
                _Start = value;
            }
        }

        public DateTime Finish
        {
            get
            {
                return _Finish;
            }
            set
            {
                _Finish = value;
            }
        }

        public Club Sponsor
        {
            get
            {
                return _Sponsor;
            }
            set
            {
                _Sponsor = value;
            }
        }

        public Address Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public ObservableCollection<Mat> Mats
        {
            get
            {
                return _Mats;
            }
            set
            {
                _Mats = value;
            }
        }

        public ObservableCollection<Person> Officials
        {
            get
            {
                return _Officials;
            }
            set
            {
                _Officials = value;
            }
        }

        public ObservableCollection<Person> Members
        {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value;
            }
        }

        public ObservableCollection<WeightCategory> WeightCategories
        {
            get
            {
                return _WeightCategories;
            }
            set
            {
                _WeightCategories = value;
            }
        }

        public ObservableCollection<AgeCategory> AgeCategories
        {
            get
            {
                return _AgeCategories;
            }
            set
            {
                _AgeCategories = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Tournament(DateTime Start, DateTime Finish, string Locality)
        {
            _Members = new ObservableCollection<Person>();
            _WeightCategories = new ObservableCollection<WeightCategory>();
            _AgeCategories = new ObservableCollection<AgeCategory>();
            _Name = SuggestedName();
            _Clubs = new ObservableCollection<Club>();
        }

        #endregion


        #region Private Methods

        private string FirstLetterToUpper(string InputString)
        {
            if (InputString == null)
            {
                return null;
            }

            if (InputString.Length > 1)
            {
                return char.ToUpper(InputString[0]) + InputString.Substring(1).ToLower();
            }

            return InputString.ToUpper();
        }

        #endregion

        #region Public Methods

        public string SuggestedName()
        {
            string Result = string.Empty;

            if (_Address != null)
            {
                Result = _Finish.Year + " " + _Address.Locality + " Judo Championship";
            }
            else
            {
                Result = _Finish.Year + " [Un-named locality] Judo Championship";
            }

            return Result;
        }

        public void SetMatCount(int Mats)
        {
            if (_Mats == null)
            {
                _Mats = new ObservableCollection<Mat>();
            }

            if (_Mats.Count < Mats)
            {
                for (int Counter = _Mats.Count; Counter < Mats; Counter++)
                {
                    _Mats.Add(new Mat("Mat " + (Counter + 1).ToString()));
                }
            }
            else
            {
                throw new Exception("There are Mats already in this tournament");

                // TODO:  Remove each of the Mats we don't want, and take all players already assigned to those Mats and redistribute them to the other Mats
            }
        }

        public short LoadCategories(string Filename)
        {
            Timestamp1 = DateTime.Now;
            XDocument Doc = new XDocument();

            if (System.IO.File.Exists(Filename))
            {
                try
                {
                    Doc = XDocument.Load(Filename);

                    // Add an Age category for each instance found
                    foreach (XElement AgeCategory in Doc.Descendants("AgeCategory"))
                    {
                        short AgeCategoryMinimumAge = -1;
                        short AgeCategoryMaximumAge = -1;
                        Utilities.Enums.Sex AgeCategorySex = Enums.Sex.Unknown;
                        bool AgeCategorySpecialNeeds = false;
                        string AgeCategoryName = "";
                        short AgeCategoryID = 0;
                        short AgeWeightLimitID = 0;
                        short Order = -1;
                        short GroupID = -1;

                        #region Get the Age Category Attributes

                        foreach (XAttribute AgeCategoryAttribute in AgeCategory.Attributes())
                        {
                            switch (AgeCategoryAttribute.Name.LocalName.ToLower())
                            {
                                case "minage":
                                    AgeCategoryMinimumAge = Convert.ToInt16(AgeCategoryAttribute.Value);
                                    break;
                                case "maxage":
                                    AgeCategoryMaximumAge = Convert.ToInt16(AgeCategoryAttribute.Value);
                                    break;
                                case "sex":
                                    switch (AgeCategoryAttribute.Value.ToLower())
                                    {
                                        case "male":
                                        case "m":
                                            AgeCategorySex = Enums.Sex.Male;
                                            break;
                                        case "female":
                                        case "f":
                                            AgeCategorySex = Enums.Sex.Female;
                                            break;
                                    }
                                    break;
                                case "specialneeds":
                                    AgeCategorySpecialNeeds = Convert.ToBoolean(AgeCategoryAttribute.Value);
                                    break;
                                case "name":
                                    AgeCategoryName = AgeCategoryAttribute.Value;
                                    break;
                                case "id":
                                    AgeCategoryID = Convert.ToInt16(AgeCategoryAttribute.Value);
                                    break;
                                case "weightlimitid":
                                    AgeWeightLimitID = Convert.ToInt16(AgeCategoryAttribute.Value);
                                    break;
                                case "order":
                                    Order = Convert.ToInt16(AgeCategoryAttribute.Value);
                                    break;
                                case "agegroupid":
                                    GroupID = Convert.ToInt16(AgeCategoryAttribute.Value);
                                    break;
                            }
                        }

                        #endregion

                        AgeCategory AgeCat = new AgeCategory(AgeCategoryMinimumAge,
                                                             AgeCategoryMaximumAge,
                                                             AgeCategorySex,
                                                             AgeCategoryID,
                                                             AgeWeightLimitID,
                                                             Order,
                                                             GroupID,
                                                             AgeCategorySpecialNeeds,
                                                             AgeCategoryName
                                                            );

                        Debug.WriteLine("Loaded Age Group definition: " + AgeCat.Name);

                        foreach (XElement WeightCategory in AgeCategory.Descendants("WeightCategory"))
                        {
                            float WeightCategoryMinWeight = -1;
                            float WeightCategoryMaxWeight = -1;
                            Enums.Sex WeightCategorySex = AgeCategorySex;
                            bool WeightCategorySpecialNeeds = AgeCategorySpecialNeeds;
                            string WeightCategoryName = "";

                            #region Get the Weight Category Attributes

                            foreach (XAttribute WeightCategoryAttribute in WeightCategory.Attributes())
                            {
                                switch (WeightCategoryAttribute.Name.LocalName.ToLower())
                                {
                                    case "min":
                                        WeightCategoryMinWeight = float.Parse(WeightCategoryAttribute.Value);
                                        break;
                                    case "max":
                                        WeightCategoryMaxWeight = float.Parse(WeightCategoryAttribute.Value);
                                        break;
                                    //case "Sex":
                                    //    switch (WeightCategoryAttribute.Value.ToLower())
                                    //    {
                                    //        case "male":
                                    //        case "m":
                                    //            WeightCategorySex = Enums.Sex.Male;
                                    //            break;
                                    //        case "female":
                                    //        case "f":
                                    //            WeightCategorySex = Enums.Sex.Female;
                                    //            break;
                                    //    }
                                    //    break;
                                    //case "SpecialNeeds":
                                    //    WeightCategorySpecialNeeds = Convert.ToBoolean(WeightCategoryAttribute.Value);
                                    //    break;
                                    case "name":
                                        WeightCategoryName = WeightCategoryAttribute.Value;
                                        break;
                                }
                            }

                            #endregion

                            //string ThisCategoryName = WeightCategorySex.ToString() + " " + AgeCat.MinimumAge + " to " + AgeCat.MaximumAge + " years " + AgeCat.Name + " (" + WeightCategoryMinimumAge + " to " + WeightCategoryMaximumAge + " Kg)";
                            string ThisAgeCategoryName = "";

                            if (WeightCategoryName.Trim().Length == 0)
                            {
                                if (WeightCategoryMinWeight == -1 && WeightCategoryMaxWeight == -1)
                                {
                                    ThisAgeCategoryName = AgeCat.Name + " (Open)";
                                }
                                else if (WeightCategoryMinWeight == -1 && WeightCategoryMaxWeight > -1)
                                {
                                    ThisAgeCategoryName = AgeCat.Name + " (under " + Convert.ToInt16(WeightCategoryMaxWeight) + " Kg)";
                                }
                                else if (WeightCategoryMinWeight > -1 && WeightCategoryMaxWeight == -1)
                                {
                                    ThisAgeCategoryName = AgeCat.Name + " (over " + Convert.ToInt16(WeightCategoryMinWeight) + " Kg)";
                                }
                                else
                                {
                                    ThisAgeCategoryName = AgeCat.Name + " (" + Convert.ToInt16(WeightCategoryMinWeight) + " to " + WeightCategoryMaxWeight + " Kg)";
                                }
                            }
                            else
                            {
                                ThisAgeCategoryName = AgeCat.Name + " (" + WeightCategoryName + ")";
                            }

                            WeightCategory WeightCat = new WeightCategory(WeightCategoryMinWeight,
                                                                                  WeightCategoryMaxWeight,
                                                                                  AgeCategoryMinimumAge,
                                                                                  AgeCategoryMaximumAge,
                                                                                  WeightCategorySex,
                                                                                  AgeCategoryID,
                                                                                  AgeWeightLimitID,
                                                                                  AgeCat,
                                                                                  WeightCategorySpecialNeeds,
                                                                                  ThisAgeCategoryName //WeightCategoryName
                                                                                 );

                            // Add a weight category for each one found
                            AgeCat.WeightCategories.Add(WeightCat);
                            _WeightCategories.Add(WeightCat);

                            //Debug.WriteLine("Loaded Weight Group definition: " + WeightCat.LowerWeightLimit + " - " + WeightCat.UpperWeightLimit);
                            Debug.WriteLine("Loaded Weight Group definition: " + ThisAgeCategoryName);
                        }

                        _AgeCategories.Add(AgeCat);
                    }

                    // Sort the Age categories
                    List<AgeCategory> OrderedAgeCategories = (from AgeCategory a in _AgeCategories
                                                              orderby a.Order
                                                              select a).ToList<AgeCategory>();

                    _AgeCategories = new ObservableCollection<AgeCategory>(OrderedAgeCategories);

                    // Sort the Weight categories - all except the no lower limit
                    List<WeightCategory> OrderedWeightCategories = (from WeightCategory w in _WeightCategories
                                                                    orderby w.LowerWeightLimit, w.UpperWeightLimit, w.Name
                                                                    where w.LowerWeightLimit > 0
                                                                    select w).ToList<WeightCategory>();

                    _WeightCategories = new ObservableCollection<WeightCategory>(OrderedWeightCategories);

                    // Get the weight categories where there is no lower limit
                    List<WeightCategory> LowWeightCategories = (from WeightCategory w in _WeightCategories
                                                                orderby w.LowerWeightLimit, w.UpperWeightLimit, w.Name
                                                                where w.LowerWeightLimit < 1
                                                                select w).ToList<WeightCategory>();

                    // Add these to the ordfered list
                    foreach (WeightCategory w in LowWeightCategories)
                    {
                        _WeightCategories.Insert(0, w);
                    }
                }
                catch (Exception e)
                {
                    Debug.Print("Error: " + e.ToString());
                }
            }

            return (short)_WeightCategories.Count();
        }

        public bool AddPerson(Person Person)
        {
            if (_Members.Count > 0)
            {
                if (_Members.Any(p => p.Name.First == Person.Name.First &&
                                      p.Name.Last == Person.Name.Last &&
                                      p.Sex == Person.Sex))
                {
                    // This Member already exists in the list
                    return false;
                }
            }

            // Find the age group and weight categories for this Player

            WeightCategory PrimaryWeightCat = GetPrimaryWeightCategory(Person);

            if (PrimaryWeightCat != null)
            {
                //Person.Player.Value.PrimaryWeightCategory = PrimaryWeightCat; // GetPrimaryWeightCategory(Person); // Also adds the person to the appropriate AgeGroup
                Person.Player.PrimaryWeightCategory = PrimaryWeightCat; // GetPrimaryWeightCategory(Person); // Also adds the person to the appropriate AgeGroup
                PrimaryWeightCat.Members.Add(Person);

                //Person.Player.Value.SystemComments.Add("Added to " + PrimaryWeightCat.Name);
                Person.Player.SystemComments.Add("Added to " + PrimaryWeightCat.Name);
            }

            //float WeightPlusFivePercent = Person.Player.Value.Weight.Kilograms + Percentage(5, Person.Player.Value.Weight.Kilograms);
            //float WeightMinusFivePercent = Person.Player.Value.Weight.Kilograms - Percentage(5, Person.Player.Value.Weight.Kilograms);

            //WeightCategory PlusFiveWeightCat = GetWeightCategory(GetAgeGroup(Person.Player.Value.AgeThisYear, Person.Sex, Person.SpecialNeeds), Person.Sex, Person.SpecialNeeds, WeightPlusFivePercent, Person.Player.Value.AgeThisYear);
            //WeightCategory MinusFiveWeightCat = GetWeightCategory(GetAgeGroup(Person.Player.Value.AgeThisYear, Person.Sex, Person.SpecialNeeds), Person.Sex, Person.SpecialNeeds, WeightMinusFivePercent, Person.Player.Value.AgeThisYear);

            //Person.Player.AddFivePercentWeightCategory = PlusFiveWeightCat;
            //Person.Player.RemoveFivePercentWeightCategory = MinusFiveWeightCat;
            //// Age Group
            //AgeCategory AgeGroup = (from Category in _AgeCategories
            //                        where Person.Player.Value.AgeThisYear >= Category.MinimumAge &&
            //                              (Person.Player.Value.AgeThisYear <= Category.MaximumAge || Category.MaximumAge == -1) &&
            //                              Person.Sex == Category.Sex &&
            //                              Person.SpecialNeeds == Category.SpecialNeeds
            //                        select Category).First();

            //if (AgeGroup != null)
            //{

            //    // Weight Category
            //    WeightCategory WeightGroup = (from Category in AgeGroup.WeightCategories
            //                                  where (Person.Player.Value.Weight.Kilograms >= Category.LowerWeightLimit || Category.LowerWeightLimit == -1) &&
            //                                        (Person.Player.Value.Weight.Kilograms <= Category.UpperWeightLimit || Category.UpperWeightLimit == -1) &&
            //                                        Person.Sex == Category.Sex &&
            //                                        Person.SpecialNeeds == Category.SpecialNeeds
            //                                  select Category).First();

            //    AgeGroup.Members.Add(Person);
            //    WeightGroup.Members.Add(Person);
            //    Person.Player.Value.PrimaryWeightCategory = WeightGroup;

            _Members.Add(Person);
            //}
            //else
            //{
            //    return false;
            //}

            return true;
        }

        //public void LoadEntrantsFromFile(string filename)
        //{
        //    //////////////////////////////////////////////////////////////////////////////////////////////
        //    ////// 2016 file format
        //    //////////////////////////////////////////////////////////////////////////////////////////////
        //    //  0 Entry Type,
        //    //  1 First Name,
        //    //  2 Last Name,
        //    //  3 Email Address,
        //    //  4 Mobile,
        //    //  5 Date Of Birth,
        //    //  6 Gender,
        //    //  7 Entry Amount,
        //    //  8 Entry Amount Paid,
        //    //  9 Total Amount Paid,
        //    // 10 What club are you registered with?,
        //    // 11 What is your current belt grade?,
        //    // 12 What is your age in 2016?,
        //    // 13 What is your current weight?,
        //    // 14 What weight division do you EXPECT to compete in at the competition?,
        //    // 15 Who can we contact in case of an emergency?,
        //    // 16 What is their contact phone number?

        //    //////////////////////////////////////////////////////////////////////////////////////////////
        //    ////// 2017 file format
        //    //////////////////////////////////////////////////////////////////////////////////////////////
        //    //  0 Reference,
        //    //  1 Member ID,
        //    //  2 Entry Type,
        //    //  3 Date,
        //    //  4 Time,
        //    //  5 Contestant First Name,
        //    //  6 Contestant Last Name,
        //    //  7 Club where you practice, 
        //    //  8 Email Address,
        //    //  9 Mobile,
        //    // 10 Date Of Birth,
        //    // 11 Gender,
        //    // 12 Entry Amount, 
        //    // 13 Entry Amount Paid, 
        //    // 14 Merchandise, 
        //    // 15 Merchandise Charge,
        //    // 16 Total Amount Paid,
        //    // 17 Payment Date, 
        //    // 18 Payment Time,
        //    // 19 Method,
        //    // 20 Receipt Number, 
        //    // 21 Bib, 
        //    // 22 Team, 
        //    // 23 Team Category,
        //    // 24 PIN,
        //    // 25 For extra divisions please ensure that you first enter an age category, 
        //    // 26 Who is your club coach ?,
        //    // 27 What is your belt grade ?,
        //    // 28 What is your age in 2017 ?,
        //    // 29 What is your current weight ?,
        //    // 30 What weight division do you expect to fight in?,
        //    // 31 Please provide an Emergency Contact person, 
        //    // 32 Please provide an Emergency Contact number,
        //    // 33 [NULL]

        //    //////////////////////////////////////////////////////////////////////////////////////////////
        //    ////// 2017 NEW File Format
        //    //  0 Reference,
        //    //  1 Member ID,
        //    //  2 Entry Type,
        //    //  3 Date,
        //    //  4 Time,
        //    //  5 First Name,
        //    //  6 Last Name,
        //    //  7 Email Address,
        //    //  8 Mobile,
        //    //  9 Date Of Birth,
        //    // 10 Gender,
        //    // 11 Entry Amount,
        //    // 12 Entry Amount Paid,
        //    // 13 Merchandise,
        //    // 14 Merchandise Charge,
        //    // 15 Total Amount Paid,
        //    // 16 Payment Date,
        //    // 17 Payment Time,
        //    // 18 Method,
        //    // 19 Receipt Number,
        //    // 20 Bib,
        //    // 21 Team,
        //    // 22 Team Category,
        //    // 23 PIN,
        //    // 24 Which club are you registered with?,
        //    // 25 What is your current belt grade?,
        //    // 26 What is your age in 2017?,
        //    // 27 What is your current weight?,
        //    // 28 What weight division will you compete in?,
        //    // 29 What weight division will you compete in?,
        //    // 30 What weight division will you compete in?,
        //    // 31 What weight division will you compete in?,
        //    // 32 What weight division will you compete in?,
        //    // 33 What weight division will you compete in?,
        //    // 34 What weight division will you compete in?,
        //    // 35 What weight division will you compete in?,
        //    // 36 What weight division will you compete in?,
        //    // 37 What weight division will you compete in?,
        //    // 38 PLEASE REMEMBER TO ENTER INTO YOUR AGE CATEGORY BEFORE ENTERING AN ADDITIONAL DIVISION,
        //    // 39 Who can we contact in case of an emergency?,
        //    // 40 What is their contact phone number?,
        //    //////////////////////////////////////////////////////////////////////////////////////////////
        //    Name name = null;
        //    Enums.Sex sex = Enums.Sex.Unknown;
        //    Person person = null;
        //    Player player = null;
        //    Club club = null;
        //    string belt = "";
        //    string primaryBeltColourName = "";
        //    Enums.Colours primaryBeltColour = Enums.Colours.None;
        //    string secondaryBeltColourName = "";
        //    Enums.Colours secondaryBeltColour = Enums.Colours.None;
        //    Rank attemptedRank = null;
        //    string[] entrants = System.IO.File.ReadAllLines(filename);

        //    int firstNameIndex = 0;
        //    int surnameIndex = 0;
        //    int genderIndex = 0;
        //    int mobileNumberIndex = 0;
        //    int birthDateIndex = 0;
        //    int weightIndex = 0;
        //    int clubNameIndex = 0;
        //    int beltNameIndex = 0;

        //    int format = 3;

        //    switch (format)
        //    {
        //        case 1:
        //            firstNameIndex = 1;
        //            surnameIndex = 2;
        //            genderIndex = 6;
        //            mobileNumberIndex = 4;
        //            birthDateIndex = 5;
        //            weightIndex = 13;
        //            clubNameIndex = 10;
        //            beltNameIndex = 11;

        //            break;
        //        case 2:
        //            firstNameIndex = 5;
        //            surnameIndex = 6;
        //            genderIndex = 11;
        //            mobileNumberIndex = 9;
        //            birthDateIndex = 10;
        //            weightIndex = 29;
        //            clubNameIndex = 7;
        //            beltNameIndex = 27;

        //            break;
        //        case 3:
        //            firstNameIndex = 4;
        //            surnameIndex = 5;
        //            genderIndex = 10;
        //            mobileNumberIndex = 8;
        //            birthDateIndex = 9;
        //            weightIndex = 14;
        //            clubNameIndex = 11;
        //            beltNameIndex = 12;

        //            break;
        //    }

        //    foreach (string entrant in entrants)
        //    {
        //        string[] personData; // = entrant.Split(',');
        //        TextFieldParser parser = new TextFieldParser(new StringReader(entrant));

        //        parser.HasFieldsEnclosedInQuotes = true;
        //        parser.SetDelimiters(",");

        //        personData = parser.ReadFields();

        //        name = new Name(personData[firstNameIndex], personData[surnameIndex]);
        //        sex = new Enums.Sex();

        //        switch (personData[genderIndex].ToLower())
        //        {
        //            case "male":
        //                sex = Enums.Sex.Male;
        //                break;
        //            case "female":
        //                sex = Enums.Sex.Female;
        //                break;
        //        }

        //        person = new Person(name, sex);
        //        player = new Player(person);
        //        person.PhoneNumber = new PhoneNumber(personData[mobileNumberIndex]);
        //        player.DateOfBirth = DateTime.Parse(personData[birthDateIndex]);

        //        if (personData[weightIndex].Length > 0)
        //        {
        //            string weight = personData[weightIndex].RemoveAlphaCharacters();
        //            player.Weight = new Weight(float.Parse(weight));
        //        }
        //        else
        //        {
        //            player.Weight = new Weight(999);
        //            player.ReviewFlag = true;
        //            player.SystemComments.Add("Could not determine player weight - used '999 Kg'");
        //        }

        //        club = new Club(personData[clubNameIndex]);

        //        if (_Clubs.Count == 0)
        //        {
        //            _Clubs.Add(club);

        //            player.Club = club;
        //        }
        //        else
        //        {
        //            Club ExistingClub = _Clubs.SingleOrDefault<Club>(c => c.Name.ToLower() == club.Name.ToLower());

        //            if (ExistingClub == null)
        //            {
        //                _Clubs.Add(club);

        //                player.Club = club;
        //            }
        //            else
        //            {
        //                player.Club = ExistingClub;
        //            }
        //        }

        //        try
        //        {
        //            belt = personData[beltNameIndex].Trim()
        //                                        .Replace("(", "/")
        //                                        .Replace(")", "")
        //                                        .Replace(" ", "/")
        //                                        .Replace("-", "/")
        //                                        .Replace("Belt", "")
        //                                        .Replace("belt", "")
        //                                        .Replace("blacktip", "")
        //                                        .Replace("Blacktip", "")
        //                                        .Replace("BlackTip", "")
        //                                        .Replace("black tip", "")
        //                                        .Replace("Black tip", "")
        //                                        .Replace("black tip", "");

        //            primaryBeltColourName = FirstLetterToUpper(belt.Split(' ')[0].Split('/')[0]);
        //            primaryBeltColour = Enums.Colours.None;
        //            secondaryBeltColourName = "";
        //            secondaryBeltColour = Enums.Colours.None;
        //            attemptedRank = new Rank(Enums.Colours.White);

        //            try
        //            {
        //                primaryBeltColour = (Enums.Colours)Enum.Parse(typeof(Enums.Colours), primaryBeltColourName);

        //                if (belt.Contains(@"/"))
        //                {
        //                    secondaryBeltColourName = FirstLetterToUpper(belt.Split('/', ' ')[1]);

        //                    try
        //                    {
        //                        secondaryBeltColour = (Enums.Colours)Enum.Parse(typeof(Enums.Colours), secondaryBeltColourName); //.Replace("blacktip", ""));

        //                        attemptedRank = new Rank(primaryBeltColour, secondaryBeltColour);
        //                    }
        //                    catch
        //                    {
        //                        player.ReviewFlag = true;
        //                        player.SystemComments.Add("Could not translate '" + personData[beltNameIndex] + "' to a belt colour");
        //                    }
        //                }
        //                else
        //                {
        //                    attemptedRank = new Rank(primaryBeltColour);
        //                }

        //                player.Rank = attemptedRank;
        //            }
        //            catch
        //            {
        //                player.ReviewFlag = true;
        //                player.SystemComments.Add("Could not translate '" + personData[beltNameIndex] + "' to a belt colour");
        //                player.Rank = new Rank(Enums.Colours.White);
        //            }

        //        }
        //        catch
        //        {
        //            Debug.WriteLine("Could not convert '" + personData[beltNameIndex] + "' to a belt");
        //        }

        //        person.Player = player;

        //        if (AddPerson(person))
        //        {
        //            Debug.WriteLine("Added " + name);
        //        }
        //        else
        //        {
        //            //Debug.WriteLine("Could not add " + Name);
        //        }
        //    }

        //    Debug.WriteLine("Sorting " + _Members.Count + " People...");
        //    _Members = new ObservableCollection<Person>(_Members.ToList<Person>().OrderBy(p => p.Name.Last).ThenBy(p => p.Name.First).ThenBy(p => p.Player.Age).ToList<Person>());

        //}

        #region Helper methods

        public WeightCategory GetPrimaryWeightCategory(Person p)
        {
            //AgeCategory AgeGroup = GetAgeGroup(p.Player.Value.AgeThisYear, p.Sex, p.SpecialNeeds);
            AgeCategory AgeGroup = GetAgeGroup(p.Player.AgeThisYear, p.Sex, p.SpecialNeeds);

            if (AgeGroup != null)
            {
                AgeGroup.Members.Add(p);
                p.Player.AgeCategory = AgeGroup;

                //return GetWeightCategory(AgeGroup, p.Sex, p.SpecialNeeds, p.Player.Value.Weight.Kilograms, p.Player.Value.AgeThisYear);
                return GetWeightCategory(AgeGroup, p.Sex, p.SpecialNeeds, p.Player.Weight.Kilograms, p.Player.AgeThisYear);
            }
            else
            {
                //p.Player.Value.SystemComments.Add("Could not determine an Age Group");
                p.Player.SystemComments.Add("Could not determine an Age Group");

                return null;
            }
        }

        public AgeCategory GetAgeGroup(float AgeThisYear, Enums.Sex Sex, bool SpecialNeeds)
        {
            AgeCategory Result = null;

            Result = (from Category in _AgeCategories
                      where AgeThisYear >= Category.MinimumAge &&
                           (AgeThisYear <= Category.MaximumAge || Category.MaximumAge == -1) &&
                            Sex == Category.Sex &&
                            SpecialNeeds == Category.SpecialNeeds
                      select Category).FirstOrDefault();

            return Result;
        }

        public WeightCategory GetWeightCategory(AgeCategory AgeGroup, Enums.Sex Sex, bool SpecialNeeds, float Weight, int AgeThisYear)
        {
            return GetWeightCategory(AgeGroup.WeightCategories.ToList(), Sex, SpecialNeeds, Weight, AgeThisYear);
            //return (from Category in AgeGroup.WeightCategories
            //        where (Weight >= Category.LowerWeightLimit || Category.LowerWeightLimit == -1) &&
            //              (Weight <= Category.UpperWeightLimit || Category.UpperWeightLimit == -1) &&
            //              Sex == Category.Sex &&
            //              SpecialNeeds == Category.SpecialNeeds
            //        select Category).FirstOrDefault();
        }

        public WeightCategory GetWeightCategory(AgeCategory AgeGroup, Enums.Sex Sex, bool SpecialNeeds, float Weight, int AgeThisYear, int WeightLimitID)
        {
            return GetWeightCategory(AgeGroup.WeightCategories.ToList(), Sex, SpecialNeeds, Weight, AgeThisYear, WeightLimitID);
        }

        public WeightCategory GetWeightCategory(List<WeightCategory> WeightCategories, Enums.Sex Sex, bool SpecialNeeds, float Weight, int AgeThisYear)
        {
            try
            {
                return (from Category in WeightCategories
                        where (Weight >= Category.LowerWeightLimit || Category.LowerWeightLimit == -1) &&
                              (Weight <= Category.UpperWeightLimit || Category.UpperWeightLimit == -1) &&
                              Sex == Category.Sex &&
                              SpecialNeeds == Category.SpecialNeeds
                        select Category).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public WeightCategory GetWeightCategory(List<WeightCategory> WeightCategories, Enums.Sex Sex, bool SpecialNeeds, float Weight, int AgeThisYear, int WeightLimitID)
        {
            WeightCategory Result = null;

            try
            {
                Result = (from Category in WeightCategories
                          where (Weight >= Category.LowerWeightLimit || Category.LowerWeightLimit == -1) &&
                                (Weight <= Category.UpperWeightLimit || Category.UpperWeightLimit == -1) &&
                                Sex == Category.Sex &&
                                SpecialNeeds == Category.SpecialNeeds &&
                                WeightLimitID == Category.ID
                          select Category).FirstOrDefault();
            }
            catch
            {
                return null;
            }

            return Result;
        }

        public WeightCategory GetWeightCategory(List<List<WeightCategory>> WeightCategoryLists, Enums.Sex Sex, bool SpecialNeeds, float Weight, int AgeThisYear, int WeightLimitID)
        {
            foreach (List<WeightCategory> l in WeightCategoryLists)
            {
                WeightCategory w = GetWeightCategory(l, Sex, SpecialNeeds, Weight, AgeThisYear, WeightLimitID);

                if (w != null)
                {
                    return w;
                }
            }

            return null;
        }

        public List<WeightCategory> GetEligibleWeightCategories(Person p)
        {
            List<WeightCategory> Result = new List<WeightCategory>();

            //Result = GetEligibleWeightCategories(p.Sex, p.SpecialNeeds, p.Player.Value.Weight.Kilograms, p.Player.Value.AgeThisYear, p.Player.Value.PrimaryWeightCategory);
            Result = GetEligibleWeightCategories(p.Sex, p.SpecialNeeds, p.Player.Weight.Kilograms, p.Player.AgeThisYear, p.Player.PrimaryWeightCategory);

            //if (Result.Count == 0)
            //{
            //    p.Player.Value.SystemComments.Add("Could not determine a weight category");
            //}

            return Result;
        }

        public List<WeightCategory> GetEligibleWeightCategories(Enums.Sex Sex, bool SpecialNeeds, float Weight, int AgeThisYear, WeightCategory PrimaryWeightCategory)
        {
            List<WeightCategory> Result = new List<WeightCategory>();

            try
            {
                Result = (from WeightCategory c in _WeightCategories
                          where c.Sex == Sex &&
                                c.SpecialNeeds == SpecialNeeds &&
                                (Weight >= c.LowerWeightLimit || c.LowerWeightLimit == -1) &&
                                (Weight <= c.UpperWeightLimit || c.UpperWeightLimit == -1) &&
                                (AgeThisYear <= c.UpperAgeLimit || c.UpperAgeLimit == -1) &&
                                c.ID <= PrimaryWeightCategory.WeightLimitID &&
                                PrimaryWeightCategory != c
                          select c).ToList();
            }
            catch (Exception)
            {
                // This is ok - there may not be another weight category for this age/weight combination
            }
            return Result;
        }

        #endregion

        public void DistributeWeightCategoriesAmongstMats(bool ShowEmptyWeightCategories)
        {
            List<WeightCategory> PopulatedWeightCategories = new List<WeightCategory>();
            List<List<WeightCategory>> OrderedCategories = new List<List<WeightCategory>>();
            List<Person> RevisitList = null;

            DeterminePlayerEligibleWeightCategories();

            OrderedCategories = AssignPlayersToWeightCategories();
            RevisitList = DeterminePlayerFinalWeightCategory(OrderedCategories);
            PopulatedWeightCategories = GetValidWeightCategories(true);

            SplitWeightCategoriesAmongstMats(PopulatedWeightCategories, ShowEmptyWeightCategories);
            ShowResults(RevisitList);
        }

        public List<WeightCategory> GetValidWeightCategories(bool all)
        {
            List<WeightCategory> Result = new List<WeightCategory>();
            List<AgeCategory> AgeCategories = (from AgeCategory a in _AgeCategories
                                               where a.WeightCategories.Count > 0
                                               select a).ToList<AgeCategory>();

            foreach (AgeCategory a in AgeCategories)
            {
                // Go through each weight category, and add it
                foreach (WeightCategory w in a.WeightCategories)
                {
                    if ((w.Members.Count > 0 && !all) || all)
                    {
                        Result.Add(w);
                    }
                }
            }

            return Result;
        }

        public void DeterminePlayerEligibleWeightCategories()
        {
            foreach (Person p in _Members)
            {
                // Find the weight categories that are compatible
                p.Player.EligibleWeightCategories = GetEligibleWeightCategories(p);
            }
        }

        public void SplitWeightCategoriesAmongstMats(List<WeightCategory> WeightCategories, bool ShowEmpty)
        {
            int MatNumber = 0;
            short PreviousGroupID = -1;

            foreach (WeightCategory w in WeightCategories)
            {
                if (w.Members.Count > 0)
                {
                    if (((w.AgeCategory.GroupID != PreviousGroupID) || (MatNumber == _Mats.Count)) && (PreviousGroupID != -1))
                    {
                        if (ShowEmpty)
                        {
                            for (int i = MatNumber; i < _Mats.Count; i++)
                            {
                                _Mats[i].WeightCategories.Add(new WeightCategory("[Empty Weight Category]"));
                            }
                        }

                        MatNumber = 0;
                    }

                    Mat m = _Mats[MatNumber];

                    m.WeightCategories.Add(w);

                    PreviousGroupID = w.AgeCategory.GroupID;

                    MatNumber++;
                }
            }
        }

        public List<List<WeightCategory>> AssignPlayersToWeightCategories()
        {
            List<List<WeightCategory>> OrderedCategories = new List<List<WeightCategory>>();

            Debug.WriteLine("========================================================");
            Debug.WriteLine("Assigning Players to Weight categories...");

            //List<Person> OrderedPeople = (from Person p in _Members
            //                              where p.Player.Value.PrimaryWeightCategory != null
            //                              orderby p.SpecialNeeds, p.Player.Value.PrimaryWeightCategory.ID, p.Player.Value.Weight.Kilograms, p.Player.Value.AgeThisYear
            //                              select p).ToList<Person>();

            List<Person> OrderedPeople = (from Person p in _Members
                                          where p.Player.PrimaryWeightCategory != null
                                          orderby p.SpecialNeeds, p.Player.PrimaryWeightCategory.ID, p.Player.Weight.Kilograms, p.Player.AgeThisYear
                                          select p).ToList<Person>();

            int CategoryID = 0;
            string AgeCat = "";
            Enums.Sex Sex = Enums.Sex.Unknown;
            List<WeightCategory> InternalList = new List<WeightCategory>();

            foreach (Person p in OrderedPeople)
            {
                //if (((CategoryID != p.Player.Value.PrimaryWeightCategory.ID || AgeCat != p.Player.Value.PrimaryWeightCategory.Name) && p.Player.Value.PrimaryWeightCategory.Members.Count > 2) || (Sex != p.Sex))
                if (((CategoryID != p.Player.PrimaryWeightCategory.ID || AgeCat != p.Player.PrimaryWeightCategory.Name) && p.Player.PrimaryWeightCategory.Members.Count > 2) || (Sex != p.Sex))
                {
                    //Debug.WriteLine("----" + p.Player.Value.PrimaryWeightCategory.Name);
                    Debug.WriteLine("----" + p.Player.PrimaryWeightCategory.Name);

                    if (InternalList.Count > 0)  // Prevent the list from being added when it is empty
                    {
                        OrderedCategories.Add(InternalList);
                    }
                    InternalList = new List<WeightCategory>();
                }

                //CategoryID = p.Player.Value.PrimaryWeightCategory.ID;
                CategoryID = p.Player.PrimaryWeightCategory.ID;
                //AgeCat = p.Player.Value.PrimaryWeightCategory.Name;
                AgeCat = p.Player.PrimaryWeightCategory.Name;
                Sex = p.Sex;

                //Debug.WriteLine("        " + p.Name + " (" + p.Player.Value.AgeThisYear + "): " + p.Player.Value.Weight.Kilograms + " Kg");
                Debug.WriteLine("        " + p.Name + " (" + p.Player.AgeThisYear + "): " + p.Player.Weight.Kilograms + " Kg");
                //InternalList.Add(p.Player.Value.PrimaryWeightCategory);
                InternalList.Add(p.Player.PrimaryWeightCategory);
            }

            return OrderedCategories;
        }

        //public List<Person> DeterminePlayerFinalWeightCategory(List<List<WeightCategory>> OrderedCategories)
        //{
        //    WeightCategory FivePercentLighterWeightCategory = null;
        //    WeightCategory FivePercentHeavierWeightCategory = null;
        //    int Index = 0;

        //    List<Person> RevisitList = new List<Person>();

        //    foreach (List<WeightCategory> ListOfWeightCategories in OrderedCategories)
        //    {
        //        foreach (WeightCategory w in ListOfWeightCategories)
        //        {
        //            for (int PersonIndex = 0; PersonIndex < w.Members.Count; PersonIndex++)
        //            {
        //                Person p = w.Members[PersonIndex];

        //                if (p.Player.Value.PrimaryWeightCategory.Members.Count == 1)
        //                {
        //                    FivePercentLighterWeightCategory = GetWeightCategory(p.Player.AgeCategory, p.Sex, p.SpecialNeeds, p.Player.Value.Weight.Minus5Percent, p.Player.Value.AgeThisYear, p.Player.Value.PrimaryWeightCategory.WeightLimitID);
        //                    FivePercentHeavierWeightCategory = GetWeightCategory(p.Player.AgeCategory, p.Sex, p.SpecialNeeds, p.Player.Value.Weight.Plus5Percent, p.Player.Value.AgeThisYear, p.Player.Value.PrimaryWeightCategory.WeightLimitID);

        //                    //if (p.Player.Value.PrimaryWeightCategory != WeightCategoryForThisPersonIfTheyAre5PercentHeavier && p.Player.Value.PrimaryWeightCategory != WeightCategoryForThisPersonIfTheyAre5PercentLighter)
        //                    //{
        //                    // What is the weight category before this one?
        //                    if ((FivePercentLighterWeightCategory != p.Player.Value.PrimaryWeightCategory) && FivePercentLighterWeightCategory != null && FivePercentLighterWeightCategory.Members.Count > 0)
        //                    {
        //                        p.Player.Value.SystemComments.Add("Removed from " + p.Player.Value.PrimaryWeightCategory.Name);
        //                        Debug.WriteLine("---- Removed " + p + " (" + p.Player.Value.Weight.Kilograms + " Kg) from " + p.Player.Value.PrimaryWeightCategory.Name);

        //                        // Remove them from this list
        //                        w.Members.Remove(p);

        //                        // Add them to the list for their weight-5%

        //                        WeightCategory NewCategory = GetWeightCategory(ListOfWeightCategories, p.Sex, p.SpecialNeeds, p.Player.Value.Weight.Minus5Percent, p.Player.Value.AgeThisYear, p.Player.Value.PrimaryWeightCategory.WeightLimitID);

        //                        if (NewCategory != null)
        //                        {
        //                            p.Player.Value.SystemComments.Add("Added to " + NewCategory.Name);
        //                            Debug.WriteLine("---- Added " + p + " to " + NewCategory.Name);

        //                            NewCategory.Members.Add(p);
        //                        }
        //                        else
        //                        {
        //                            RevisitList.Add(p);

        //                            p.Player.Flag = true;
        //                            p.Player.Value.SystemComments.Add("Could not determine -5% weight category");
        //                            Debug.WriteLine("---- Flagged " + p + " (" + p.Player.Value.Weight.Kilograms + " Kg)");
        //                        }
        //                    }
        //                    else if ((FivePercentHeavierWeightCategory != p.Player.Value.PrimaryWeightCategory) && FivePercentHeavierWeightCategory != null && FivePercentHeavierWeightCategory.Members.Count > 0)
        //                    {
        //                        p.Player.Value.SystemComments.Add("Removed from " + p.Player.Value.PrimaryWeightCategory.Name);
        //                        Debug.WriteLine("---- Removed " + p + " (" + p.Player.Value.Weight.Kilograms + " Kg) from " + p.Player.Value.PrimaryWeightCategory.Name);

        //                        // Remove them from this list
        //                        w.Members.Remove(p);

        //                        WeightCategory NewCategory = GetWeightCategory(OrderedCategories, p.Sex, p.SpecialNeeds, p.Player.Value.Weight.Plus5Percent, p.Player.Value.AgeThisYear, p.Player.Value.PrimaryWeightCategory.WeightLimitID);

        //                        if (NewCategory != null)
        //                        {
        //                            p.Player.Value.SystemComments.Add("Added to " + NewCategory.Name);
        //                            Debug.WriteLine("---- Added " + p + " to " + NewCategory.Name);

        //                            NewCategory.Members.Add(p);
        //                        }
        //                        else
        //                        {
        //                            RevisitList.Add(p);

        //                            p.Player.Flag = true;
        //                            p.Player.Value.SystemComments.Add("Could not determine +5% weight category");
        //                            Debug.WriteLine("---- Flagged " + p + " (" + p.Player.Value.Weight.Kilograms + " Kg)");
        //                        }

        //                    }
        //                    //}
        //                    else
        //                    {
        //                        RevisitList.Add(p);

        //                        p.Player.Flag = true;
        //                        p.Player.Value.SystemComments.Add("Could not determine another weight category where there are players");
        //                        Debug.WriteLine("---- Flagged " + p + " (" + p.Player.Value.Weight.Kilograms + " Kg)");
        //                    }
        //                }

        //                GetWeightCategory(p.Player.AgeCategory, p.Sex, p.SpecialNeeds, p.Player.Value.Weight.Kilograms, p.Player.Value.AgeThisYear, p.Player.Value.PrimaryWeightCategory.WeightLimitID);

        //                //PreviousWeightCategory = p.Player.Value.PrimaryWeightCategory;
        //                //NextWeightCategory = GetEligibleWeightCategories(p.Sex, p.SpecialNeeds, p.Player.Value.Weight.Kilograms, p.Player.Value.AgeThisYear, p.Player.Value.PrimaryWeightCategory)[0];

        //                //Index++;
        //            }
        //        }

        //        Index++;
        //    }

        //    Debug.WriteLine("There are " + RevisitList.Count + " people that require manual intervention to determine an appropriate weight category");

        //    return RevisitList;

        //}

        public List<Person> DeterminePlayerFinalWeightCategory(List<List<WeightCategory>> OrderedCategories)
        {
            WeightCategory FivePercentLighterWeightCategory = null;
            WeightCategory FivePercentHeavierWeightCategory = null;
            int Index = 0;

            List<Person> RevisitList = new List<Person>();

            foreach (List<WeightCategory> ListOfWeightCategories in OrderedCategories)
            {
                foreach (WeightCategory w in ListOfWeightCategories)
                {
                    for (int PersonIndex = 0; PersonIndex < w.Members.Count; PersonIndex++)
                    {
                        Person p = w.Members[PersonIndex];

                        if (p.Player.PrimaryWeightCategory.Members.Count == 1)
                        {
                            FivePercentLighterWeightCategory = GetWeightCategory(p.Player.AgeCategory, p.Sex, p.SpecialNeeds, p.Player.Weight.Minus5Percent, p.Player.AgeThisYear, p.Player.PrimaryWeightCategory.WeightLimitID);
                            FivePercentHeavierWeightCategory = GetWeightCategory(p.Player.AgeCategory, p.Sex, p.SpecialNeeds, p.Player.Weight.Plus5Percent, p.Player.AgeThisYear, p.Player.PrimaryWeightCategory.WeightLimitID);

                            //if (p.Player.PrimaryWeightCategory != WeightCategoryForThisPersonIfTheyAre5PercentHeavier && p.Player.PrimaryWeightCategory != WeightCategoryForThisPersonIfTheyAre5PercentLighter)
                            //{
                            // What is the weight category before this one?
                            if ((FivePercentLighterWeightCategory != p.Player.PrimaryWeightCategory) && FivePercentLighterWeightCategory != null && FivePercentLighterWeightCategory.Members.Count > 0)
                            {
                                p.Player.SystemComments.Add("Removed from " + p.Player.PrimaryWeightCategory.Name);
                                Debug.WriteLine("---- Removed " + p + " (" + p.Player.Weight.Kilograms + " Kg) from " + p.Player.PrimaryWeightCategory.Name);

                                // Remove them from this list
                                w.Members.Remove(p);

                                // Add them to the list for their weight-5%

                                WeightCategory NewCategory = GetWeightCategory(ListOfWeightCategories, p.Sex, p.SpecialNeeds, p.Player.Weight.Minus5Percent, p.Player.AgeThisYear, p.Player.PrimaryWeightCategory.WeightLimitID);

                                if (NewCategory != null)
                                {
                                    p.Player.SystemComments.Add("Added to " + NewCategory.Name);
                                    Debug.WriteLine("---- Added " + p + " to " + NewCategory.Name);

                                    NewCategory.Members.Add(p);
                                }
                                else
                                {
                                    RevisitList.Add(p);

                                    p.Player.ReviewFlag = true;
                                    p.Player.SystemComments.Add("Could not determine -5% weight category");
                                    Debug.WriteLine("---- Flagged " + p + " (" + p.Player.Weight.Kilograms + " Kg)");
                                }
                            }
                            else if ((FivePercentHeavierWeightCategory != p.Player.PrimaryWeightCategory) && FivePercentHeavierWeightCategory != null && FivePercentHeavierWeightCategory.Members.Count > 0)
                            {
                                p.Player.SystemComments.Add("Removed from " + p.Player.PrimaryWeightCategory.Name);
                                Debug.WriteLine("---- Removed " + p + " (" + p.Player.Weight.Kilograms + " Kg) from " + p.Player.PrimaryWeightCategory.Name);

                                // Remove them from this list
                                w.Members.Remove(p);

                                WeightCategory NewCategory = GetWeightCategory(OrderedCategories, p.Sex, p.SpecialNeeds, p.Player.Weight.Plus5Percent, p.Player.AgeThisYear, p.Player.PrimaryWeightCategory.WeightLimitID);

                                if (NewCategory != null)
                                {
                                    p.Player.SystemComments.Add("Added to " + NewCategory.Name);
                                    Debug.WriteLine("---- Added " + p + " to " + NewCategory.Name);

                                    NewCategory.Members.Add(p);
                                }
                                else
                                {
                                    RevisitList.Add(p);

                                    p.Player.ReviewFlag = true;
                                    p.Player.SystemComments.Add("Could not determine +5% weight category");
                                    Debug.WriteLine("---- Flagged " + p + " (" + p.Player.Weight.Kilograms + " Kg)");
                                }
                            }
                            //}
                            else
                            {
                                RevisitList.Add(p);

                                p.Player.ReviewFlag = true;
                                p.Player.SystemComments.Add("Could not determine another weight category where there are players");
                                Debug.WriteLine("---- Flagged " + p + " (" + p.Player.Weight.Kilograms + " Kg)");
                            }
                        }

                        GetWeightCategory(p.Player.AgeCategory, p.Sex, p.SpecialNeeds, p.Player.Weight.Kilograms, p.Player.AgeThisYear, p.Player.PrimaryWeightCategory.WeightLimitID);

                        //PreviousWeightCategory = p.Player.PrimaryWeightCategory;
                        //NextWeightCategory = GetEligibleWeightCategories(p.Sex, p.SpecialNeeds, p.Player.Weight.Kilograms, p.Player.AgeThisYear, p.Player.PrimaryWeightCategory)[0];

                        //Index++;
                    }
                }

                Index++;
            }

            Debug.WriteLine("There are " + RevisitList.Count + " people that require manual intervention to determine an appropriate weight category");

            return RevisitList;
        }

        public void ShowResults(List<Person> RevisitList)
        {
            Timestamp2 = DateTime.Now;
            int MatNumber = 0;

            TimeSpan ElapsedTime = Timestamp2 - Timestamp1;

            Debug.WriteLine("Total load time = " + Math.Round(ElapsedTime.TotalSeconds, 1) + " seconds");
            Debug.WriteLine("Mats...");

            MatNumber = 0;
            foreach (Mat m in _Mats)
            {
                Debug.WriteLine("Mat " + ((int)MatNumber + 1) + ":");

                foreach (WeightCategory w in m.WeightCategories)
                {
                    Debug.WriteLine(w.Name);
                    foreach (Person p in w.Members)
                    {
                        //Debug.WriteLine("   " + p.ToString() + " (" + p.Player.Value.Weight.Kilograms + " Kg)");
                        Debug.WriteLine("   " + p.ToString() + " (" + p.Player.Weight.Kilograms + " Kg)");
                    }
                    Debug.WriteLine("--------------------------------------------------------");
                }

                MatNumber++;
            }

            Debug.Print("Comments:");
            foreach (Person p in RevisitList)
            {
                //foreach (string Comment in p.Player.Value.SystemComments)
                foreach (string Comment in p.Player.SystemComments)
                {
                    if (!Comment.StartsWith("Added to"))
                    {
                        Debug.Print(p.Name + ": " + Comment);
                    }
                }
            }
        }

        #endregion

    }
}
