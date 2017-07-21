#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SimCorp.TextManipulation.StringManipulation.Format;

#endregion
namespace SimCorp.TextManipulation.StringManipulation
{
    /// <summary>
    /// Manipulates input text  up stream yesss
    /// </summary>
    public class TextManipulate
    {
        #region ProcessInputText

        /// <summary>
        ///Takes a string input and return a list of formated object
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns>Returns a list of formatted data</returns>
        public List<FormattedResult> GetFormattedData(string inputText)
        {
            if (string.IsNullOrEmpty(inputText)) throw new ArgumentNullException(nameof(inputText));

            var keywords = inputText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
            if (!keywords.Any()) return null;

            var regex = new Regex("\\w+");
            var frequencyList = regex.Matches(inputText)
                .Cast<Match>()
                .Select(s => s.Value)
                .Where(s => keywords.Contains(s))
                .GroupBy(s => s)
                .Select(g => new FormattedResult() { Word = g.Key, WorkCount = g.Count() });

            return frequencyList.ToList();

        }

        #endregion
    }
}
