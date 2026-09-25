using System.Collections.Generic;

namespace Classes
{
    public class Belts
    {


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private string _ConnectionString = string.Empty;
        private List<Belt> _List = new List<Belt>();
        //private sq

        #endregion

        #region Properties

        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        public List<Belt> List
        {
            get
            {
                return _List;
            }
            set
            {
                _List = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Belts()
        {
        }

        #endregion


        #region Private Methods

        #endregion

        #region Public Methods

        public void Load()
        {
            //string Query = string.Empty;

            //Query = "SELECT Identifier, Colour FROM Belt";

            //DataSet Data = Utilities.Data.Execute(Query, _ConnectionString);

            //foreach (DataRow Row in Data.Tables[0].Rows)
            //{
            //    Guid GuidRepresentation = (Guid)Row.ItemArray[0];
            //    string BeltColourName = (string)Row.ItemArray[1];

            //    Belt Obi = new Belt(BeltColourName, GuidRepresentation);

            //    _List.Add(Obi);
            //}

        }

        #endregion

    }
}
