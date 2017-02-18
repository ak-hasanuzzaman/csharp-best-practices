#region Using

using System;
using System.IO;
using System.Linq;
using SimCorp.TextManipulation.StringManipulation;

#endregion

namespace SimCorp.TextManipulation.StartUpProject
{
    /// <summary>
    /// Written by : AK Hasanuzzaman
    /// Date:16.02.2017
    /// This is a test application to display the output according to the specification
    /// and to write the program with possible best practices.
    /// </summary> 
    class Program
    {
        #region Main

        static void Main(string[] args)
        {
            try
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TextFiles\\inputdate.txt");

                if (!string.IsNullOrEmpty(filePath))
                    ShowFormattedText(filePath);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                //TODO:Log exception using a custom exception handler
            }
        }
        #endregion

        #region ProcessInputText
        /// <summary>
        /// Reads a file and starts to format the text of that file
        /// </summary>
        /// <param name="filePath"></param>
        private static void ShowFormattedText(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return;
                var inputText = File.ReadAllText(filePath);
                 
                var textManipulate = new TextManipulate();
                var frequencyList = textManipulate.GetFormattedData(inputText);

                if (frequencyList == null) return;

                foreach (var item in frequencyList)
                {
                    Console.WriteLine($"{item.WorkCount}: {item.Word}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                //TODO:Log exception using a custom exception handler
            }
        }
        #endregion
    }
}
