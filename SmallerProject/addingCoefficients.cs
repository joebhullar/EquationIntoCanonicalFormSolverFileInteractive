using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallerProject
{
    //This class is responsible for adding coefficients of a If and ONLY IF They have the exact same variables and corresponding powers
    //Ie) This class only adds coefficients if the dictionaries of two algebraic blocks are identical. (Of having same variable's and powers)
    public class addingCoefficients
    {
        // This function takes in two sets of lists of algebraic equations. One for the LHS one for the RHS.
        public void addCoefficients(List<AlgebraicBlockOfEqn.blockOfAlgebra> myRightHandSideListofBlockAlgebra, List<AlgebraicBlockOfEqn.blockOfAlgebra> myLeftHandSideListofBlockAlgebra)
        {
            foreach (var rightHandSideBlockOfAlgorithm in myRightHandSideListofBlockAlgebra) //for every block of algorithm on the RHS of the EQN
            {
                var rightHandSideOfList = rightHandSideBlockOfAlgorithm.dictionaryForOneBlock.varAndExponentDictionary.Keys.ToList();//put that corresponding block of algorithm's dictionary into a list
                rightHandSideOfList.Sort();//SORTS THAT SAME LIST OF THAT DICTIONARY OF ITS KEY VARIABLES
                foreach (var leftHandSideOfListItem in myLeftHandSideListofBlockAlgebra)
                {
                    var leftHandSideOfList = leftHandSideOfListItem.dictionaryForOneBlock.varAndExponentDictionary.Keys.ToList();//This is Essentially EACH Block of 
                    if (rightHandSideBlockOfAlgorithm.dictionaryForOneBlock.varAndExponentDictionary != null && (rightHandSideBlockOfAlgorithm.dictionaryForOneBlock.varAndExponentDictionary).SequenceEqual(leftHandSideOfListItem.dictionaryForOneBlock.varAndExponentDictionary)) 
                        {
                            leftHandSideOfListItem.a = leftHandSideOfListItem.a + rightHandSideBlockOfAlgorithm.a; //add right side of a to the left side.
                            rightHandSideBlockOfAlgorithm.a = 0;//since we added right to left, we no longer have a value for a
                            rightHandSideBlockOfAlgorithm.dictionaryForOneBlock.varAndExponentDictionary = null;
                        }
                    }
                }
            }

        }
    }

