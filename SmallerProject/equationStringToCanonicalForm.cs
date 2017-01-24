using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallerProject
{
   public class equationStringToCanonicalForm
    {
        public StringBuilder inputEquationStringToCanonicalString(string writtenText)
        {
            ScanningAlgorithm obj = new SmallerProject.ScanningAlgorithm();
            //Step 2.Create a list of the Left-Hand-Side algebraic blocks
            List<SmallerProject.AlgebraicBlockOfEqn.blockOfAlgebra> myLeftHandSideListofBlockAlgebra = obj.LeftRightEqn(writtenText, true);
            //Step 3.Create a list of the Right-Hand-Side algebraic blocks 
            List<SmallerProject.AlgebraicBlockOfEqn.blockOfAlgebra> myRightHandSideListofBlockAlgebra = obj.LeftRightEqn(writtenText, false);
            //Step 4.Add Coefficent, a, from both sides of the list (multiply all coefficients on RHS by -1 to bring them to the Left.)
            SmallerProject.addingCoefficients mergeBothLists = new SmallerProject.addingCoefficients();
            mergeBothLists.addCoefficients(myRightHandSideListofBlockAlgebra, myLeftHandSideListofBlockAlgebra);
            //Step 5. Now that both lists algebraic blocks are added, we now merge both lists together.
            var mergedBlocksOfAlgebraOnLhs = myLeftHandSideListofBlockAlgebra.Concat(myRightHandSideListofBlockAlgebra).ToList();
            //Step 6. Format Output Equation String
            SmallerProject.OutputStringFormatting strOutput = new SmallerProject.OutputStringFormatting();
            StringBuilder outputEqn = strOutput.formatSolutionStrForOutput(mergedBlocksOfAlgebraOnLhs);
            return outputEqn;
        }
    }
}
