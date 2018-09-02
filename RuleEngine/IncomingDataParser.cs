namespace RuleEngine
{
    using System;
    using System.Text;

    /// <summary>
    /// This class is responsible for parsing the incoming data in more optimized way compared to the current implementation.
    /// <!-- TODO: Complete implementation -->
    /// </summary>
    public class IncomingDataParser
    {
        #region Fields and Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="IncomingDataParser"/> class.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public IncomingDataParser()
        {
            //TODO: Implement 
            throw new NotImplementedException();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Parses the specified JSON input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">input</exception>
        public dynamic Parse(string input)
        {
            if (string.IsNullOrEmpty(input)) { throw new ArgumentNullException("input"); }
            dynamic result = null;

            bool ignoreSpace = true; // Flag to ignore space if not a value
            bool isValue = false; // Flag representing whether current item represents a value
            int objectCounts = 0; // Total signal objects

            SignalData[] signals = new SignalData[8];

            StringBuilder tempStringBuilder = new StringBuilder();
            foreach (char c in input)
            {
                switch (c)
                {
                    case Constants.ArrayStart:
                        ignoreSpace = true;
                        isValue = false;
                        break;

                    case Constants.OjectStart:
                        ignoreSpace = true;
                        isValue = false;
                        break;

                    case Constants.ObjectWrapper:
                        break;

                    case Constants.ObjectSeparator:
                        break;

                    case Constants.ObjectEnd:
                        objectCounts++;
                        break;

                    case Constants.ElementSeparator:
                        ignoreSpace = true;
                        break;

                    case Constants.ArrayEnd:
                        break;

                    default:
                        break;
                }
            }

            return result;
        }

        #endregion

        #region Private/Internal Methods


        #endregion
    }
}
