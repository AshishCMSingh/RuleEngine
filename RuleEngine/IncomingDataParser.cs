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
        public IncomingDataParser()
        {

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Parses the specified json input.
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

            SignalUnit[] signals = new SignalUnit[8];

            for (int i = 0; i < 15; i++)
            {
                if (i < signals.Length)
                {
                    signals[i] = new SignalUnit("", "", "");
                }
                else
                {
                    Array.Resize(ref signals, signals.Length + 7);
                    signals[i] = new SignalUnit("", "", "");
                }
            }

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

                    case Constants.ObjectStringValueWrapper:
                        break;

                    case Constants.ObjectValueSeparator:
                        break;

                    case Constants.ObjectEnd:
                        objectCounts++;
                        break;

                    case Constants.ArrayValueSeparator:
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
