namespace RuleEngine
{
    public interface IRule
    {
        string Signal { get; }
        dynamic Value { get; }

        Comparison ComparisonType { get; }

        /// <summary>
        /// Returns true if the input signal doesn't match with this rule.
        /// </summary>
        /// <param name="input">The input signal.</param>
        /// <returns>
        ///   <c>true</c> if the input signal doesn't match with this rule; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(SignalData input);
    }
}