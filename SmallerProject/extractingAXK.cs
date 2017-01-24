using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallerProject
{
    //This class has functions that extract values a,x,and k of ax^k
   public class extractingAXK
    {   //AlgebraicBlockOfEqn takes in half of an eqn and determins if it's on LHS or RHS. If it's on RHS it will
        //multiply it's a coefficient with -1 to effectivly move that block of variable to the LHS. 
        //leftSideOfEqn tells you which side it's on.
        public AlgebraicBlockOfEqn.blockOfAlgebra axkExtractor(String axkStr, bool leftSideOfEqn)
        {
            double a = 1.0;
            implementingNegativeNumberStr negNumbr = new implementingNegativeNumberStr();
            negNumbr.implementNegNumber(ref axkStr, ref a);//This acknowledges the negative sign into a if needed
            a = a * extractingValueOfA(axkStr);// Extract value of a from string
            VariableAndExponentDictionary.vAEDictionary algebraicVariablesInBlock = extractalgebraicVariablesInBlock(axkStr); //Extract key value pairs of variables(as keys) and their corresponding powers(as values) and store them in 1 dictionary for a corresponding block.
            AlgebraicBlockOfEqn.blockOfAlgebra oneBlock = new AlgebraicBlockOfEqn.blockOfAlgebra(); //Now we store value of a and variables  blockOfAlgebra class to represent one block of Algebra.
            if (!leftSideOfEqn) //THIS IS Effectivley multiplying everything on RHS with Negative 1
                a = a * (-1);
            oneBlock.a = a;//stores value of a into algebraicblock instance, oneBlock
            oneBlock.dictionaryForOneBlock = algebraicVariablesInBlock;//stores dictionary value of variable and power of a into algebraicblock instance, oneBlock
            return oneBlock;
        }
        //This function is responsible for extracting the actual variables and powers to those variables.
        public VariableAndExponentDictionary.vAEDictionary extractalgebraicVariablesInBlock(string inputEquationStringAlgebraic)//we are concerning ourselves with something like 32(x^23)*yz(p^2)
        {
            int counter = 0;
            VariableAndExponentDictionary.vAEDictionary dictEntry = new VariableAndExponentDictionary.vAEDictionary();
            while (counter <= (inputEquationStringAlgebraic.Length - 1))//WHILE we have variables together like xy or (x^3)*y*(z^3)
            {
                {
                    if (inputEquationStringAlgebraic[counter] <= 'z' && inputEquationStringAlgebraic[counter] >= 'a') //when a variable is detected
                    {
                        char variableContainer = inputEquationStringAlgebraic[counter];                            //The variable is stored in a string.
                        int extractedValueOfK = 1;
                        if (((counter + 2) <= (inputEquationStringAlgebraic.Length - 1)) && (inputEquationStringAlgebraic[counter + 1] == '^'))//THIS MEANS THAT A K VALUE MUST EXIST & NEEDS TO BE EXTRACTED!!
                        { // now we KNOW that the integers here relate to power k of that last found variable.
                            extractedValueOfK = inputEquationStringAlgebraic[counter + 2] - '0'; //Assigns First Value of k ONLY for FIRST digit
                            counter = counter + 2; //NOW COUNTER IS AT FIRST DIGIT WHICH IS ALREADY RECORDED. Lets see if there is a second digit? If that second digit is an int?
                            if ((counter + 1) <= (inputEquationStringAlgebraic.Length - 1))//does another digit OR Bracket OR Variable excist?
                            {
                                if (inputEquationStringAlgebraic[counter + 1] <= '9' && inputEquationStringAlgebraic[counter + 1] >= '0')//is the digit an int? if it is then it is  part of k!
                                {
                                    extractedValueOfK = extractedValueOfK * 10 + inputEquationStringAlgebraic[counter + 1] - '0';//Now The SECOND Digit has been incoorporated into k
                                    counter++;
                                    while (((counter + 1) <= (inputEquationStringAlgebraic.Length - 1)) && inputEquationStringAlgebraic[counter + 1] <= '9' && inputEquationStringAlgebraic[counter + 1] >= '0')
                                    {
                                        extractedValueOfK = extractedValueOfK * 10 + (inputEquationStringAlgebraic[counter + 1] - '0');
                                        counter++;
                                    }
                                }// Now we must look at the third digit until we run out of digits. Counter is now at the second digit!                            
                            }
                        }
                        counter++;
                        dictEntry.varAndExponentDictionary.Add(variableContainer, extractedValueOfK);//STORES THE x and POWER k x^k for each instance it sees it
                    }
                    else
                        counter++;
                }
            }
            return dictEntry;
        }

        public double extractingValueOfA(string inputEquationStr)
        {
            int counter = 0;
            int internalndex = 0;
            double extractedValOfA = 1;
            if (inputEquationStr[0] <= '9' && inputEquationStr[0] >= '0')
            {
                extractedValOfA = inputEquationStr[0] - '0'; //Assigns First Value of A only for first digit
                counter++;
                internalndex++;
            }
            while (counter < inputEquationStr.Length && (counter == internalndex))
            {
                if (inputEquationStr[counter] <= '9' && inputEquationStr[counter] > '0')
                {
                    extractedValOfA = extractedValOfA * 10 + (inputEquationStr[counter] - '0');
                    internalndex++;
                    counter++;
                }
                else if (inputEquationStr[counter] == '.')
                {
                    double decimalCount = 1.0;
                    counter++;//must go AFTER the decimal to get number AFTER decimal
                    internalndex++;
                    if (inputEquationStr[counter] <= '9' && inputEquationStr[counter] > '0')
                    {
                        double strToDouble = Char.GetNumericValue(inputEquationStr[counter]);
                        extractedValOfA = extractedValOfA + (strToDouble / 10.0);  //Now we have digit after decimal
                        internalndex++;
                        decimalCount++;
                        counter++;
                    }
                    double denominatorTimesTen = 0.0; //this will be multiplied by 10 it will never be zero!
                    double numeratorOfStr = 1.0;
                    while (counter < inputEquationStr.Length && (counter == internalndex) && inputEquationStr[counter] <= '9' && inputEquationStr[counter] > '0')//36.58
                    {
                        numeratorOfStr = Char.GetNumericValue(inputEquationStr[counter]);
                        denominatorTimesTen = Math.Pow(10, decimalCount);
                        extractedValOfA = extractedValOfA + (numeratorOfStr / (denominatorTimesTen));
                        decimalCount++;
                        counter++;
                        internalndex++;
                    }
                }
                else
                    counter++;
            }
            return extractedValOfA;
        }

    }

}
