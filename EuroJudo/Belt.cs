using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroJudo
{
    [Serializable]
    public class Belt
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private Grade _Value = Grade.None;

        #endregion

        #region Properties

        public string Colour
        {
            get
            {
                switch (_Value)
                {
                    case Grade.None:
                        return "";
                        break;
                    case Grade.White:
                        return "White";
                        break;
                    case Grade.WhiteYellow:
                        return "White / Yellow";
                        break;
                    case Grade.Yellow:
                        return "Yellow";
                        break;
                    case Grade.YellowOrange:
                        return "Yellow / Orange";
                        break;
                    case Grade.Orange:
                        return "Orange";
                        break;
                    case Grade.OrangeGreen:
                        return "Orange / Green";
                        break;
                    case Grade.Green:
                        return "Green";
                        break;
                    case Grade.GreenBlue:
                        return "Green / Blue";
                        break;
                    case Grade.Blue:
                        return "Blue";
                        break;
                    case Grade.BlueBrown:
                        return "Blue / Brown";
                        break;
                    case Grade.Brown:
                        return "Brown";
                        break;
                    case Grade.Black1stDan:
                        return "Black";
                        break;
                    case Grade.Black2ndDan:
                        return "Black";
                        break;
                    case Grade.Black3rdDan:
                        return "Black";
                        break;
                    case Grade.Black4thDan:
                        return "Black";
                        break;
                    case Grade.Black5thDan:
                        return "Black";
                        break;
                    case Grade.Black6thDan:
                        return "Black or Red and White";
                        break;
                    case Grade.Black7thDan:
                        return "Black or Red and White";
                        break;
                    case Grade.Black8thDan:
                        return "Black or Red and White";
                        break;
                    case Grade.Black9thDan:
                        return "Black or Red";
                        break;
                    case Grade.Black10thDan:
                        return "Black or Red";
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }

        public int Numeric
        {
            get
            {
                return (int)Enum.Parse(typeof(Grade), Enum.GetName(typeof(Grade), _Value));
            }
        }

        public string Name
        {
            get
            {
                switch (_Value)
                {
                    case Grade.None:
                        return "";
                    case Grade.White:
                        return "6th Kyu";
                    case Grade.WhiteYellow:
                        return "White / Yellow";
                    case Grade.Yellow:
                        return "5th Kyu";
                    case Grade.YellowOrange:
                        return "Yellow / Orange";
                    case Grade.Orange:
                        return "4th Kyu";
                    case Grade.OrangeGreen:
                        return "Orange / Green";
                    case Grade.Green:
                        return "3rd Kyu";
                    case Grade.GreenBlue:
                        return "Green / Blue";
                    case Grade.Blue:
                        return "2nd Kyu";
                    case Grade.BlueBrown:
                        return "Blue / Brown";
                    case Grade.Brown:
                        return "1st Kyu";
                    case Grade.Black1stDan:
                        return "1st Dan";
                    case Grade.Black2ndDan:
                        return "2nd Dan";
                    case Grade.Black3rdDan:
                        return "3rd Dan";
                    case Grade.Black4thDan:
                        return "4th Dan";
                    case Grade.Black5thDan:
                        return "5th Dan";
                    case Grade.Black6thDan:
                        return "6th Dan";
                    case Grade.Black7thDan:
                        return "7th Dan";
                    case Grade.Black8thDan:
                        return "8th Dan";
                    case Grade.Black9thDan:
                        return "9th Dan";
                    case Grade.Black10thDan:
                        return "10th Dan";
                    default:
                        return "";
                }
            }
        }

        public string Rank
        {
            get
            {
                switch (_Value)
                {
                    case Grade.None:
                        return "[NONE]";
                    case Grade.White:
                        return "Hachikyu";
                    case Grade.WhiteYellow:
                        return "Hachikyu*";
                    case Grade.Yellow:
                        return "Shichikyu";
                    case Grade.YellowOrange:
                        return "Shichikyu*";
                    case Grade.Orange:
                        return "Yonkyu";
                    case Grade.OrangeGreen:
                        return "Yonkyu*";
                    case Grade.Green:
                        return "Sankyu";
                    case Grade.GreenBlue:
                        return "Sankyu*";
                    case Grade.Blue:
                        return "Nikyu";
                    case Grade.BlueBrown:
                        return "Nikyu*";
                    case Grade.Brown:
                        return "Ikkyu";
                    case Grade.Black1stDan:
                        return "Shodan";
                    case Grade.Black2ndDan:
                        return "Nidan";
                    case Grade.Black3rdDan:
                        return "Sandan";
                    case Grade.Black4thDan:
                        return "Yondan";
                    case Grade.Black5thDan:
                        return "Godan";
                    case Grade.Black6thDan:
                        return "Rokudan";
                    case Grade.Black7thDan:
                        return "Shichidan";
                    case Grade.Black8thDan:
                        return "Hachidan";
                    case Grade.Black9thDan:
                        return "Kudan";
                    case Grade.Black10thDan:
                        return "Judan";
                    default:
                        return "Unknown";
                }
            }
        }

        #endregion

        #region Constructors and Destructor

        public Belt()
        {

        }

        public Belt(Grade Value)
        {
            _Value = Value;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (Name != "")
            {
                return $"{Colour} ({Name})";
            }
            else
            {
                return $"{Colour}";
            }
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
