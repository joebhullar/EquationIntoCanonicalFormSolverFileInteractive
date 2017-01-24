using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestProject1
{
    [TestClass]
    public class EquationSolverTest
    {   //Here are unit tests for various cases
        [TestMethod]
        public void Test_EqnOneChecker()
        {
            //Arrange
            string EqnOneIn = "x^2 + 3.5xy + y = y^2 -xy +y";
            string EqnOneSolun = "Solution:  (x^2)+4.5xy-(y^2)= 0 \n\n";
            //Act
            TestEqnChecker CheckTestEqn = new TestEqnChecker();
            string comparisonStr = CheckTestEqn.TestEquationChecker(EqnOneIn);
            //Assert
            Assert.AreEqual(EqnOneSolun, comparisonStr);
        }
        [TestMethod]
        public void Test_EqnTwoChecker()
        {
            //Arrange
            string EqnOneIn = "x^2+3(x^2)(y^2)=y^2+4xy";
            string EqnOneSolun = "Solution:  (x^2)+3(x^2)(y^2)-(y^2)-4xy= 0 \n\n";
            //Act
            TestEqnChecker CheckTestEqn = new TestEqnChecker();
            string comparisonStr = CheckTestEqn.TestEquationChecker(EqnOneIn);
            //Assert
            Assert.AreEqual(EqnOneSolun, comparisonStr);

        }
        [TestMethod]
        public void Test_EqnThreeChecker()
        {
            //Arrange
            string EqnOneIn = "x^4+3(x^2)(y^2)z-y^2-0.5xy^2+1.5y(x^3)=y^2+4xy";
            string EqnOneSolun = "Solution:  (x^4)+3(x^2)(y^2)z-2(y^2)-0.5x(y^2)+1.5(x^3)y-4xy= 0 \n\n";
            //Act
            TestEqnChecker CheckTestEqn = new TestEqnChecker();
            string comparisonStr = CheckTestEqn.TestEquationChecker(EqnOneIn);
            //Assert
            Assert.AreEqual(EqnOneSolun, comparisonStr);
        }
        [TestMethod]
        public void Test_EqnFourChecker()
        {
            //Arrange
            string EqnOneIn = "y^3(x^2)z-4z^3(x^2)+xyz=xyz-z^234-x";
            string EqnOneSolun = "Solution:  (x^2)(y^3)z-4(x^2)(z^3)+(z^234)+x= 0 \n\n";
            //Act
            TestEqnChecker CheckTestEqn = new TestEqnChecker();
            string comparisonStr = CheckTestEqn.TestEquationChecker(EqnOneIn);
            //Assert
            Assert.AreEqual(EqnOneSolun, comparisonStr);
        }
        [TestMethod]
        public void Test_EqnFiveChecker()
        {
            //Arrange
            string EqnOneIn = "0.3x^2(z)-0.1y=0.3y-0.8(x^2)z";
            string EqnOneSolun = "Solution:  1.1(x^2)z-0.4y= 0 \n\n";
            //Act
            TestEqnChecker CheckTestEqn = new TestEqnChecker();
            string comparisonStr = CheckTestEqn.TestEquationChecker(EqnOneIn);
            //Assert
            Assert.AreEqual(EqnOneSolun, comparisonStr);
        }
        [TestMethod]
        public void Test_EqnSixChecker()
        {
            //Arrange
            string EqnOneIn = "9.4x-0.4y-0.1xyz=-9.9x^2+6.7y+9.93xyz";
            string EqnOneSolun = "Solution:  9.4x-7.1y-10.03xyz+9.9(x^2)= 0 \n\n";
            //Act
            TestEqnChecker CheckTestEqn = new TestEqnChecker();
            string comparisonStr = CheckTestEqn.TestEquationChecker(EqnOneIn);
            //Assert
            Assert.AreEqual(EqnOneSolun, comparisonStr);
        }

    }
}
