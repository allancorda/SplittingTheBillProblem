using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBillProblem
{
    sealed class IndividualExpense
    {
        public List<decimal> expense;
        public decimal myTotal;

        public IndividualExpense(decimal value)
        {
            this.expense = new List<decimal> { value };
            this.myTotal = value;
        }

    }
}
