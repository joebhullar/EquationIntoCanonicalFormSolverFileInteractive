using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmallerProject
{   //This class is responsible for dealing with fileModeOfOperation & Console mode of operation.
    class OperationMode
    {   //In the file mode of operation, the class needs to have an int number of lines returned 
        //for the whole loop to know how long it should keep going.
        public int modeOfOperation(bool checkForFileModeOfOperation)
        {
            int lineCount = 1;//If in console mode lineCount=1 which defaults the while loop to an infinite loop to run on console.
            if (checkForFileModeOfOperation) //only reads file in checkForFileModeOfOperation
                lineCount = File.ReadLines(@"C:\test\paramater.txt").Count();
            return lineCount;
        }
        //returns index for argument of while loop in main. we use valueOfInputEquationString to tell us in while if we are dealing with
        //The File mode or the Interactive Mode. For the file mode the inputeqn is at an index, otherwise in console mode it's always at index 0.
        public string valueOfInputEquationString(bool checkForFileModeOfOperation, int inputIndexOfStrEqn)
        {
            string writtenText = "";
            string[] arrayOfFileInputString = { };
            OperationMode obj = new OperationMode();
            arrayOfFileInputString = obj.readingInMode(checkForFileModeOfOperation);
            if (checkForFileModeOfOperation)
                return writtenText = arrayOfFileInputString[inputIndexOfStrEqn]; //For fileModeOfOperation
            else
                return writtenText = arrayOfFileInputString[0];//For Interactive mode
        }

        //This function is responsible for declaring path to read math eqn files.
        //It is also responsible for declaring number of inputlines to store for fileModeOfOperation. (in our case i wrote down 1000)
        public string[] readingInMode(bool fileModeOfOperation)
        {
            string[] writtenText = new string[1000]; // can have up to 1000 lines of input filecode to run!
            //List<string> writtenText = new List<string>();
            if (fileModeOfOperation)
            {   //fileModeOfOperation has no introline because we are just writing solutions to a file in fileModeOfOperation.
                using (StreamReader reader = new StreamReader(@"C:\test\paramater.txt"))
                {
                    int inputIndexOfStrEqn = 0;
                    string algebraicLineInputEquation;
                    while ((algebraicLineInputEquation = reader.ReadLine()) != null) // reads each input line of the file!
                    {//NOw you have the algebraic eqn called algebraicLineInputEquation
                        writtenText[inputIndexOfStrEqn] = algebraicLineInputEquation;
                        inputIndexOfStrEqn++;
                    }
                }
                return writtenText;
            }
            else //Interactive Console Mode.
            {   //Below is our input line for consoleMode.
                Console.WriteLine("Welcome To Joe's Program: Please Enter an Equation and it will be solved \n ");
                //writtenText[0] is  indexed at zero to be in a while loop in main. This is so the user can keep
                //entering in input equations until he/she presses Ctrl+C
                writtenText[0] = Console.ReadLine();//COMMENTED OUT FOR IO TESTING!! UNCOMMENT FOR CONSOLE TESTING!!
                return writtenText;
            }
        }

        public void WriteOutMode(StringBuilder strToOutput, bool fileModeOfOperation, ref int inputIndexOfStrEqn, int lineCount)
        {
            if (fileModeOfOperation)
            {
                using (var writer = new StreamWriter(@"C:\test\mydoc.out", true))//if  i dont want to append the existing file i enter false
                    writer.WriteLine(strToOutput);
            }
            else //We Want Interactive Mode
                Console.Write(strToOutput);
            if (fileModeOfOperation)
            {
                if (inputIndexOfStrEqn <= lineCount)
                    inputIndexOfStrEqn++;
            }
        }
    }
}
