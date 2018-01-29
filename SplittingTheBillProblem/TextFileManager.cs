using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBillProblem
{
    public class TextFileManager
    {
        public IDictionary<int, TripExpense> GetTripExpense(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            IDictionary<int, TripExpense> fileTripExpense = new Dictionary<int, TripExpense> ();
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                var tripCounter = 0;

                while ((line = streamReader.ReadLine()) != null)
                {
                    TripExpense tripExpense = new TripExpense();
                    var tripTotal = 0.00m;
                    var numberOfParticipants = ConvertStringToInt(line);
                    for (int i = 0; i < numberOfParticipants; i++)
                    {
                        // Second line is # of paid ammount for this individual
                        var numberOfExpenses = ConvertStringToDecimal(streamReader.ReadLine());

                        for (int j = 0; j < numberOfExpenses; j++)
                        {
                            var moneyPaid = ConvertStringToDecimal(streamReader.ReadLine());
                            if (fileTripExpense.TryGetValue(tripCounter, out TripExpense result))
                            {
                                tripTotal += moneyPaid;
                                result.AddExpenses(i, moneyPaid);
                            }
                            else
                            {
                                tripTotal += moneyPaid;
                                tripExpense.MaxPeople = numberOfParticipants;
                                tripExpense.AddExpenses(i, moneyPaid);
                                fileTripExpense.Add(tripCounter, tripExpense);
                            }
                        }
                    }
                    tripExpense.TotalExpense = tripTotal;
                    tripCounter++;

                    // Now proceed with calucating Payment
                    tripExpense.CalculateAllPayment();
                }
            }
            return fileTripExpense;
        }

        public int ConvertStringToInt(string value)
        {
            return (Int32.TryParse(value,out int result)) ? result : 0;
        }

        public decimal ConvertStringToDecimal(string value)
        {
            return (Decimal.TryParse(value, out decimal result)) ? result : 0;
        }

        public void WriteToFile(IDictionary<int, TripExpense> splitBillExpenseResults, string filePath)
        {
            var notOverwriteFileSettings = false;
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(filePath, notOverwriteFileSettings))
            {
                foreach(var item in splitBillExpenseResults.Values)
                {
                    foreach(var writeToFile in item.SplitBillResult)
                    {
                        streamWriter.WriteLine(writeToFile);
                    }
                    streamWriter.WriteLine("");
                }
            }
        }
    }
}
