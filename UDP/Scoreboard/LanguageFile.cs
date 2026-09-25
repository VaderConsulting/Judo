using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Scoreboard
{
    public class LanguageFile
    {
        #region Fields

        private Dictionary<string, string> _Strings = new Dictionary<string, string>();

        #endregion

        #region Properties

        public Dictionary<string, string> Strings
        {
            get
            {
                return _Strings;
            }
        }

        #endregion

        #region Constructors

        public LanguageFile(string Filename)
        {
            XmlDocument xDoc = new XmlDocument();

            if (System.IO.File.Exists(Filename))
            {
                try
                {
                    xDoc.Load(Filename);

                    XmlNodeList StringNodes = xDoc.GetElementsByTagName("String");

                    foreach (XmlNode Node in StringNodes)
                    {
                        if (Node.InnerText.Length > 0)
                        {
                            _Strings.Add(Node.Attributes[0].InnerText, Node.InnerText);
                        }
                    }
                }
                catch
                {
                    throw new System.IO.FileLoadException("The provided filename (" + Filename + ") could not be loaded");
                }
            }
            else
            {
                throw new System.IO.FileNotFoundException("The provided filename (" + Filename + ") could not be found");
            }
        }

        #endregion
    }
}
