using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBillProblem
{
    public class TripExpense
    {
        int maxPeople;
        decimal tripTotalExpense;
        IDictionary<int, IndividualExpense> expenses = new Dictionary<int, IndividualExpense>();
        List<string> splitBillResult = new List<string>();

        public void CalculateAllPayment()
        {
            foreach(var expense in expenses.Values)
            {
                var paymentForTrip = expense.myTotal - CalcuateSplitExpenseAverage();
                splitBillResult.Add(IndividualSplitExpense(paymentForTrip));
            }
        }

        public decimal CalcuateSplitExpenseAverage()
        {
            return tripTotalExpense / maxPeople;
        }

        public string IndividualSplitExpense(decimal tripCost)
        {
            if(tripCost > 0)
            {
                return "("+ DecimalRoundUp(tripCost) + ")";
            }
            else
            {
                return DecimalRoundUp(Math.Abs(tripCost));
            }
        }

        public string DecimalRoundUp(decimal value)
        {
            return Math.Round(value, 2).ToString();
        }

        public int MaxPeople
        {
            get { return maxPeople; }
            set { maxPeople = value; }
        }

        public void AddExpenses(int Id, decimal value)
        {
            if (expenses.TryGetValue(Id,out IndividualExpense result))
            {
                result.expense.Add(value);
                result.myTotal += (decimal)value;
            }
            else
            {
                expenses.Add(Id, new IndividualExpense(value));
            }
        }

        public int CountExpense()
        {
            var count = 0;
            foreach (var item in expenses.Values)
            {
                count += item.expense.Count;
            }
            return count;
        }

        public decimal TotalExpense
        {
            get { return tripTotalExpense; }
            set { tripTotalExpense = value; }
        }

        public decimal IndividualExpense(int id)
        {
            return expenses[id].myTotal;
        }

        public void AddSplitBill(string value)
        {
            if(splitBillResult == null)
            {
                splitBillResult = new List<string> { value };
            }
            else
            {
                splitBillResult.Add(value);
            }
        }

        public List<string> SplitBillResult
        {
            get { return splitBillResult; }
        }

    }
}
