Add-Type @"
namespace RuleEngine
{
    using System;
    using System.Collections.Generic;

    public class Rule
    {
        #region Constructors
        public Rule(string signal, object value, Comparison comparisonType)
        {
            if (string.IsNullOrWhiteSpace(signal)) { throw new ArgumentNullException("signalName"); }
            if (value == null) { throw new ArgumentNullException("value"); }

            Signal = signal;
            Value = value;
            ComparisonType = comparisonType;
            ValueType = value.GetType().ToString().Split('.')[1];
        }

        #endregion
        
        #region Fields & Properties

        public string Signal { get; private set; }

        public Comparison ComparisonType { get; private set; }

        public object Value { get; private set; }

        public string ValueType { get; private set; }

        #endregion
    }

    public enum Comparison : short
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
    }
}

"@

$rules = @()
$rules += New-Object RuleEngine.Rule -ArgumentList @('ATL1', 240, [RuleEngine.Comparison]::LessThan)
$rules += New-Object RuleEngine.Rule -ArgumentList @('ATL2', 'LOW', [RuleEngine.Comparison]::Equal)
$rules += New-Object RuleEngine.Rule -ArgumentList @('ATL3', (Get-Date), [RuleEngine.Comparison]::GreaterThan)
$rules | Export-Csv 'C:\Users\Ashish Singh\Documents\Visual Studio 2017\Projects\RuleEngine\RuleEngine\Rules.csv' -Force -NoTypeInformation