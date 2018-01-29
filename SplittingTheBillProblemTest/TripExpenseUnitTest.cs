using System;
using System.Text;
using System.Collections.Generic;
using SplittingTheBillProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SplittingTheBillProblemTest
{
    /// <summary>
    /// Summary description for TripExpenseUnitTest
    /// </summary>
    [TestClass]
    public class TripExpenseUnitTest
    {

        [TestMethod]
        public void FinalPaymentCalculation()
        {
            TripExpense tripExp = new TripExpense();
            decimal value = -0.01m;
            var result = tripExp.IndividualSplitExpense(value);
            Assert.AreEqual(result, "0.01");
            value = 0.01m;
            result = tripExp.IndividualSplitExpense(value);
            Assert.AreEqual(result, "(0.01)");
        }

        [TestMethod]
        public void SplitPaymentAverage()
        {
            TripExpense tripExp = new TripExpense();
            tripExp.MaxPeople = 3;
            tripExp.TotalExpense = 30.33m;
            var result = tripExp.CalcuateSplitExpenseAverage();
            Assert.AreEqual(result, 10.11m);
        }

        [TestMethod]
        public void AddIndividualExpenses()
        {
            TripExpense tripExp = new TripExpense();
            tripExp.MaxPeople = 2;
            tripExp.AddExpenses(0,5.03m);
            tripExp.AddExpenses(0, 3.01m);
            tripExp.AddExpenses(0, 2.03m);
            tripExp.AddExpenses(1, 5.00m);
            tripExp.AddExpenses(1, 5.00m);
            tripExp.AddExpenses(1, 5.00m);
            Assert.IsTrue(tripExp.CountExpense() == 6);
            Assert.IsTrue(tripExp.IndividualExpense(0) == 10.07m);
            Assert.IsTrue(tripExp.IndividualExpense(1) == 15m);
            ;
        }
    }
}
