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

        #region Constructor and Destructor

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

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
