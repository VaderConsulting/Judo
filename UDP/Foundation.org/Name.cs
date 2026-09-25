using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Judo
{
    public class Name
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

        private string _First = string.Empty;
        private string _Last = string.Empty;
        private string _Long = string.Empty;
        private string _Short = string.Empty;

        #endregion

        #region Properties

        public string First
        {
            get
            {
                return _First;
            }
            set
            {
                _First = Capitalise(value);
            }
        }

        public string Last
        {
            get
            {
                return _Last;
            }
            set
            {
                _Last = Capitalise(value);
            }
        }

        public string Long
        {
            get
            {
                return _Long;
            }
            set
            {
                _Long = value;
            }
        }

        public string Short
        {
            get
            {
                return _Short;
            }
            set
            {
                _Short = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Name(string First, string Last)
        {
            _First = UnPascalCase(Capitalise(First.ToLower()));
            _Last = UnPascalCase(Capitalise(Last.ToLower()));
            _Long = _Last + ", " + _First;

            if (_First.Length > 0)
            {
                _Short = _Last.ToUpper() + " " + _First.Substring(0, 1) + ".";
            }
            else
            {
                _Short = _Last.ToUpper();
            }
        }

        public Name(string Long, bool LastFirst = true)
        {
            _Long = UnPascalCase(Capitalise(Long.ToLower()));
            _Long = _Long.Trim(',',' '); // Remove leading and trailing spaces and comma's

            if (_Long.Contains(" "))
            {
                if (LastFirst || Long.Contains(","))
                {
                    _Last = _Long.Substring(0, _Long.IndexOf(' ')).Trim().Replace(",", "");
                    _First = _Long.Substring(_Long.IndexOf(' ')).Trim();
                }
                else
                {
                    _First = _Long.Substring(0, _Long.IndexOf(' ')).Trim().Replace(",", "");
                    _Last = _Long.Substring(_Long.IndexOf(' ')).Trim();
                }

                if (_First.Length > 0)
                {
                    _Short = _Last.ToUpper() + " " + _First.Substring(0, 1) + ".";
                }
                else
                {
                    _Short = _Last.ToUpper();
                }
            }
            else
            {
                _Last = _Long;
                _First = "";
                _Short = _Long;
            }
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        private string Capitalise(string InputString)
        {
            string Result = InputString;

            if (InputString == null)
            {
                return null;
            }

            if (InputString.Length > 1)
            {
                //Result = char.ToUpper(InputString[0]) + InputString.Substring(1).ToLower();

                // Capitalise everything to the right of a space or hyphen
                StringBuilder r = new StringBuilder();

                // First character is always uppercase
                r.Append(InputString[0].ToString().ToUpper());

                for (int i = 1; i < InputString.Length; i++)
                {
                    if (InputString[i - 1] == (char)32 || InputString[i - 1] == Convert.ToChar("-"))
                    {
                        r.Append(InputString[i].ToString().ToUpper());
                    }
                    else
                    {
                        r.Append(InputString[i].ToString());
                    }
                }

                Result = r.ToString();
            }
            else
            {
                return InputString.ToUpper();
            }

            return Result;
        }

        private string UnPascalCase(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            StringBuilder newText = new StringBuilder(text.Length * 2);

            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                bool currentUpper = char.IsUpper(text[i]);
                bool prevUpper = char.IsUpper(text[i - 1]);
                bool nextUpper = (text.Length > i + 1) ? char.IsUpper(text[i + 1]) || char.IsWhiteSpace(text[i + 1]) : prevUpper;
                bool spaceExists = char.IsWhiteSpace(text[i - 1]);

                if (currentUpper && !spaceExists && (!nextUpper || !prevUpper))
                {
                    newText.Append(' ');
                }

                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        #endregion

        #region Public Methods

        public string FullName()
        {
            return ToString();
        }

        public override string ToString()
        {
            if (_Long.Length > 0)
            {
                return _Long;
            }
            else if (_Short.Length > 0)
            {
                return _Short;
            }
            else
            {
                return _First + " " + Last;
            }
        }

        #endregion



    }
}
