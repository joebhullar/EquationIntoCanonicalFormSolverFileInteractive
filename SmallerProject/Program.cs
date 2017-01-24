using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Welcoime to my test assignment for News360! Today I'll be your host: Joe Bhullar 403-701-9561
//This program is:
//A Console Application for transofrming an input equation into Canonical Form.
//For Example:                           
//              input equation x^2+3.5xy+y=y^2-xy+y
//                 Solution:  (x^2)+4.5xy-(y^2)= 0   

//              input equation x^2+3(x^2)(y^2)=y^2+4xy 
//                 Solution:  (x^2)+3(x^2)(y^2)-(y^2)-4xy= 0 
//
//This program also has two seperate modes of operation. It has a File mode and a Console Interactive mode.
//SET line 40 bool checkForFileModeOfOperation = true For File Mode
//SET line 40 bool checkForFileModeOfOperation = false For Interactive Mode
//For File mode:*****************************************************************************
//               input file equations are in this directory and file "C:\test\paramater.txt"
//                *the input file, paramater.txt, contains lines with equations. 
//                  with each equation on a seperate line.
//                *Solutions to the equation will be Appended to the output file, mydoc.out!
//               output file solution equations are in directory and file "C:\test\mydoc.out"
//For Interactive mode:**********************************************************************
//              the application prompts user to enter equation and display result on enter.
//              this is repeated until the user presses Ctrl+C on the keyboard.

//        Assumption: Algebraic equation entries are entered in the same way as in example above.

namespace SmallerProject
{
    class Program
    {
        static void Main(string[] args) //static means you can have only one instance of it
        {
            //Switch between file and interactive mode of operation
            bool checkForFileModeOfOperation = false;
            ScanningAlgorithm obj = new SmallerProject.ScanningAlgorithm(); //create a new object of scannerblock to use functions to scan blocks of data 
            int inputIndexOfStrEqn = 0; //index of string entries for checkForFileModeOfOperation. This is needed here because it increments at the end of reading a complete eqn input ONLY in fileModeOfOperation with more than one entry.
            OperationMode methodOfReadingInputAndWritingOutput = new OperationMode(); //Instantiating OperationMode class to use ModeofOperation function which will return lineCount. This is needed to determine File/Interactive Mode.
            //this integer lineCount is responsible for telling us how many times we must go through an equation. In File Mode, it returns # of lines for inputeqn. For console, it goes in an infine loop until user hits Ctrl+C to Exit console.
            int lineCount = methodOfReadingInputAndWritingOutput.modeOfOperation(checkForFileModeOfOperation);// Loops through Equation Entries.
            while (inputIndexOfStrEqn < lineCount)//for each line of input equation (whether it's for fileModeOfOperation or Interactive Mode)
            {
                //Put the input Algebraic string (from File or Interactive Console, depending on mode of operation) into string written text
                string writtenText = methodOfReadingInputAndWritingOutput.valueOfInputEquationString(checkForFileModeOfOperation, inputIndexOfStrEqn);
                //Pass the original equation into function which returns output string in Canonical form of StringBuilder type.
                equationStringToCanonicalForm eqnStrToCanonical = new equationStringToCanonicalForm();
                //outputEqn has the canonical form of the equation. StringBuilder is used because it is easier to append strings with string builder.  
                StringBuilder outputEqn =eqnStrToCanonical.inputEquationStringToCanonicalString(writtenText);
                //Write Solution String to Output (Either Console or File depending on operation)
                methodOfReadingInputAndWritingOutput.WriteOutMode(outputEqn, checkForFileModeOfOperation, ref inputIndexOfStrEqn, lineCount);
            }
        }
    }
}