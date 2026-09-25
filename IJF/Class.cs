using System;

namespace IJF
{
    [Serializable]
    public class Class : Judo.WeightCategory
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

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor
        
        public Class()
        {
        }

        public Class(string Name, int Minimum, int Maximum)
        {
            base.Name = Name;
            base.Minimum = Minimum;
            base.Maximum = Maximum;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{base.Name}";
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

        

    }
}
