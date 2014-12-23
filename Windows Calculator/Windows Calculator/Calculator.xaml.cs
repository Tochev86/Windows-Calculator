using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Windows_Calculator
{
    public partial class MainWindow : Window
    {
        private bool shouldResetMainScreen = false;
        private bool isCommaSet = false;
        private bool shouldMasterReset = false;
        private string mathOperation = "";
        private decimal numberForOperation = 0;
        private bool isReciprocalPressed = false;
        private bool isNegativePositivePressed = false;
        private decimal numberForRepeatedOperations = 0;
        private bool isEqualPresset = true;
        private bool isPercentPressed = false;
        private bool isSquareRootPressed = false;
        private string secondScreenBuffer = "";
        private decimal percentNumber = 0;
        private decimal NegativePositiveNumber = 0;
        private decimal mNumber = 0;

        private void button_0(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            string labelAsString = label.Content.ToString();
            if (shouldMasterReset == true)
                label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            if (labelAsString.Length == 1 && labelAsString[0] == '0')
            {
                label.Content = "0";
            }
            else
            {
                label.Content += "0";
                TrimMainScreen(label.Content.ToString());
            }
        }

        private void button_1(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "1";
            TrimMainScreen(label.Content.ToString());
        }

        private void button_2(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "2";
            TrimMainScreen(label.Content.ToString());
        }


        private void button_3(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "3";
            TrimMainScreen(label.Content.ToString());
        }
        private void button_4(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "4";
            TrimMainScreen(label.Content.ToString());
        }
        private void button_5(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "5";
            TrimMainScreen(label.Content.ToString());
        }
        private void button_6(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "6";
            TrimMainScreen(label.Content.ToString());
        }
        private void button_7(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "7";
            TrimMainScreen(label.Content.ToString());
        }
        private void button_8(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "8";
            TrimMainScreen(label.Content.ToString());
        }
        private void button_9(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            label.Content = IsOnlyOneZero(label.Content);
            label.Content = CheckMainScreen(label.Content);
            label.Content += "9";
            TrimMainScreen(label.Content.ToString());
        }

        private void button_Comma(object sender, RoutedEventArgs e)
        {
            Label label = mainScreen;
            string labelAsString = label.Content.ToString();
            if (shouldMasterReset == true)
            {
                MasterReset();
            }

            for (int i = 0; i < labelAsString.Length; i++)
            {
                if (labelAsString[i] == ',')
                {
                    isCommaSet = true;
                    break;
                }
                else
                {
                    isCommaSet = false;
                }
            }

            if (isCommaSet == false && shouldResetMainScreen == false)
            {
                label.Content += ",";
            }
            else if (isCommaSet == false && shouldMasterReset == false)
            {
                label.Content = "0,";
                shouldResetMainScreen = false;
            }
        }

        private void button_Minus(object sender, RoutedEventArgs e)
        {
            PerformOperation("-");
        }

        private void button_Plus(object sender, RoutedEventArgs e)
        {
            PerformOperation("+");
        }

        private void button_Multiply(object sender, RoutedEventArgs e)
        {
            PerformOperation("*");
        }

        private void button_Divide(object sender, RoutedEventArgs e)
        {
            PerformOperation("/");
        }

        private void button_Equal(object sender, RoutedEventArgs e)
        {
            Label firstNumber = mainScreen;
            Label secondNumber = secondScreen;

            if (firstNumber.Content != "" && firstNumber.Content != null)
            {
                decimal result = decimal.Parse(firstNumber.Content.ToString());
                if (secondNumber.Content != "" && secondNumber.Content != null && isEqualPresset == false)
                {
                    decimal secondNumb = decimal.Parse(firstNumber.Content.ToString());
                    result = CheckForMathOperation(numberForOperation, secondNumb, mathOperation);
                    numberForRepeatedOperations = secondNumb;
                    isEqualPresset = true;
                }
                else if (isEqualPresset == true)
                {
                    decimal mainNumber = decimal.Parse(firstNumber.Content.ToString());
                    result = CheckForMathOperation(mainNumber, numberForRepeatedOperations, mathOperation);
                }

                firstNumber.Content = CheckMainScreen(firstNumber.Content);
                shouldResetMainScreen = true;
                numberForOperation = result;
                if (messageScreen.Content != "" && messageScreen.Content != null)
                {
                    firstNumber.Content = "";
                    shouldMasterReset = true;
                }
                else
                {
                    //firstNumber.Content = result.ToString();
                    if (result.ToString().IndexOf(',') >= 0)
                    {
                        result = decimal.Parse(result.ToString().TrimEnd('0').TrimEnd(','));
                    }
                    else if (result.ToString().IndexOf('.') >= 0)
                    {
                        result = decimal.Parse(result.ToString().TrimEnd('0').TrimEnd('.'));
                    }

                    TrimMainScreen(result.ToString());
                    secondScreenBuffer = "";
                    secondNumber.Content = secondScreenBuffer;
                    //secondNumber.Content = "";
                }
            }

            isPercentPressed = false;
            isReciprocalPressed = false;
            isNegativePositivePressed = false;
            isSquareRootPressed = false;
        }

        private void button_BackSpace(object sender, RoutedEventArgs e)
        {
            Label mainLabel = mainScreen;
            if (mainLabel.Content != "" && mainLabel.Content != null)
            {
                string content = mainLabel.Content.ToString();
                string newMessage = null;
                if (content.Length > 1)
                {
                    for (int i = 0; i < content.Length - 1; i++)
                    {
                        newMessage += content[i].ToString();
                    }

                    TrimMainScreen(newMessage);
                    //mainLabel.Content = newMessage;
                }
                else
                {
                    mainLabel.Content = "0";
                }
            }
        }

        private void button_CE(object sender, RoutedEventArgs e)
        {
            if (mathOperation != "")
            {
                mainScreen.Content = "0";
                mainScreen.FontSize = 24;
                mainScreen.FontWeight = FontWeights.Normal;
                mainScreen.Padding = new Thickness(0, 12, 4, 0);

                if (isEqualPresset == true)
                {
                    numberForOperation = 0;
                    numberForRepeatedOperations = 0;
                }
                else if (isReciprocalPressed == true || isPercentPressed == true || isNegativePositivePressed == true || isSquareRootPressed == true)
                {
                    numberForRepeatedOperations = 0;
                    string newSecondScreenResult = "";
                    //int index = secondScreen.Content.ToString().LastIndexOf(Convert.ToChar(mathOperation));
                    int index = secondScreenBuffer.LastIndexOf(Convert.ToChar(mathOperation));
                    for (int i = 0; i < index + 1; i++)
                    {
                        //newSecondScreenResult += secondScreen.Content.ToString()[i];
                        newSecondScreenResult += secondScreenBuffer[i];
                    }

                    secondScreenBuffer = newSecondScreenResult;
                    secondScreen.Content = secondScreenBuffer;
                    //secondScreen.Content = newSecondScreenResult;
                    isReciprocalPressed = false;
                    isPercentPressed = false;
                    isNegativePositivePressed = false;
                    isSquareRootPressed = false;
                }
            }
            else
            {
                MasterReset();
                numberForOperation = 0;
            }
        }

        private void button_C(object sender, RoutedEventArgs e)
        {
            MasterReset();
            numberForOperation = 0;
        }

        private void button_Reciprocal(object sender, RoutedEventArgs e)
        {
            if (mainScreen.Content != "" && mainScreen.Content != null)
            {
                if (messageScreen.Content != "" && messageScreen.Content != null)
                {
                    MasterReset();
                }

                if (mainScreen.Content != "" || mainScreen.Content != null)
                {
                    decimal firstNumber = 1;
                    decimal secondNumber = decimal.Parse(mainScreen.Content.ToString());
                    decimal result = 0;
                    bool showResult = true;

                    if (secondNumber == 0)
                    {
                        messageScreen.Content = "cannot divide by zero";
                        shouldMasterReset = true;
                        showResult = false;
                    }
                    else
                    {
                        result = firstNumber / secondNumber;
                    }

                    if (showResult == true)
                    {
                        //mainScreen.Content = result.ToString();
                        TrimMainScreen(result.ToString());
                    }
                    else
                    {
                        mainScreen.Content = "";
                    }

                    if (secondScreen.Content == "" || secondScreen.Content == null)
                    {
                        secondScreenBuffer = "reciproc(" + secondNumber + ")";
                        TrimSecondScreen(secondScreenBuffer);
                    }
                    else if (mathOperation != "" && isReciprocalPressed == false && isPercentPressed == false && isNegativePositivePressed == false && isSquareRootPressed == false)
                    {
                        string newSecondScreenMessageFirstPart = "";
                        string newSecondScreenMessageSecondPart = "";
                        int index = secondScreenBuffer.LastIndexOf(Convert.ToChar(mathOperation));
                        for (int i = 0; i < secondScreenBuffer.Length; i++)
                        {
                            if (i <= index)
                            {
                                newSecondScreenMessageFirstPart += secondScreenBuffer[i];
                            }
                            else
                            {
                                newSecondScreenMessageSecondPart += secondScreenBuffer[i];
                            }
                        }

                        if (mainScreen.Content == "")
                        {
                            secondScreenBuffer = newSecondScreenMessageFirstPart + " reciproc(" + newSecondScreenMessageSecondPart + "0)";
                        }
                        else
                        {
                            secondScreenBuffer = newSecondScreenMessageFirstPart + " reciproc(" + newSecondScreenMessageSecondPart + secondNumber + ")";
                        }

                        TrimSecondScreen(secondScreenBuffer);
                    }
                    else
                    {
                        string newSecondScreenMessageFirstPart = "";
                        string newSecondScreenMessageSecondPart = "";
                        int index = secondScreenBuffer.LastIndexOf(" ");
                        for (int i = 0; i < secondScreenBuffer.Length; i++)
                        {
                            if (i <= index)
                            {
                                newSecondScreenMessageFirstPart += secondScreenBuffer[i];
                            }
                            else
                            {
                                newSecondScreenMessageSecondPart += secondScreenBuffer[i];
                            }
                        }
                        secondScreenBuffer = newSecondScreenMessageFirstPart + "reciproc(" + newSecondScreenMessageSecondPart + ")";
                        TrimSecondScreen(secondScreenBuffer);
                    }

                    isReciprocalPressed = true;
                }
            }
        }

        private void button_Percent(object sender, RoutedEventArgs e)
        {
            if (isPercentPressed == false && mainScreen.Content != "" && mainScreen.Content != null)
            {
                string result = ((numberForOperation / 100) * decimal.Parse(mainScreen.Content.ToString())).ToString();
                percentNumber = decimal.Parse(mainScreen.Content.ToString());
                if (result == "0,0" || result == "0.0")
                {
                    TrimMainScreen("0");
                }
                else
                {
                    if (isPercentPressed == false)
                    {
                        button_CE(new object(), new RoutedEventArgs());
                    }
                    TrimMainScreen(result);
                }
                //mainScreen.Content = result;
                if (mathOperation == "" || mathOperation == null)
                {
                    secondScreenBuffer = "0";
                    secondScreen.Content = secondScreenBuffer;
                }
                else
                {
                    if (mainScreen.Content.ToString().IndexOf(',') >= 0)
                    {
                        mainScreen.Content = mainScreen.Content.ToString().TrimEnd('0').TrimEnd(',');
                    }
                    else if (secondScreenBuffer.IndexOf('.') >= 0)
                    {
                        mainScreen.Content = mainScreen.Content.ToString().TrimEnd('0').TrimEnd('.');
                    }

                    secondScreenBuffer += " " + mainScreen.Content.ToString();
                    TrimSecondScreen(secondScreenBuffer);
                    //secondScreen.Content = secondScreenBuffer;
                }
            }
            else if (isPercentPressed == true && mainScreen.Content != "" && mainScreen.Content != null)
            {

                if (percentNumber != 0 && mathOperation != "" && mathOperation != null)
                {
                    string result = ((decimal.Parse(mainScreen.Content.ToString()) / 100) * percentNumber).ToString();
                    decimal firstNumber = CheckForMathOperation(decimal.Parse(mainScreen.Content.ToString()), decimal.Parse(result), mathOperation);
                    int index = secondScreenBuffer.LastIndexOf(mathOperation);
                    TrimMainScreen(firstNumber.ToString());
                    //mainScreen.Content = firstNumber.ToString();
                    string buffer = "";
                    for (int i = 0; i < index + 1; i++)
                    {
                        buffer += secondScreenBuffer[i];
                    }

                    if (mainScreen.Content.ToString().IndexOf(',') >= 0)
                    {
                        mainScreen.Content = mainScreen.Content.ToString().TrimEnd('0').TrimEnd(',');
                    }
                    else if (mainScreen.Content.ToString().IndexOf('.') >= 0)
                    {
                        mainScreen.Content = mainScreen.Content.ToString().TrimEnd('0').TrimEnd('.');
                    }

                    secondScreenBuffer = buffer;
                    secondScreenBuffer += " " + mainScreen.Content.ToString();
                    TrimSecondScreen(secondScreenBuffer);
                    //secondScreen.Content = secondScreenBuffer;
                }
            }

            isPercentPressed = true;
        }

        private void ButtonNegative_Positive(object sender, RoutedEventArgs e)
        {
            Label mainLabel = mainScreen;
            Label secondNumber = secondScreen;
            if (mainLabel.Content != "" && mainLabel.Content != null)
            {
                decimal mainNumber = decimal.Parse(mainLabel.Content.ToString());
                if (mainNumber < 0 || mainNumber > 0)
                {
                    mainNumber *= -1;
                }

                if (mainNumber.ToString().IndexOf(',') >= 0)
                {
                    mainNumber = decimal.Parse(mainNumber.ToString().TrimEnd('0').TrimEnd(','));
                }
                else if (mainNumber.ToString().IndexOf('.') >= 0)
                {
                    mainNumber = decimal.Parse(mainNumber.ToString().TrimEnd('0').TrimEnd('.'));
                }

                if ((shouldResetMainScreen == true || isReciprocalPressed == true || isSquareRootPressed == true) || mainNumber != 0)
                {
                    if (secondScreen.Content == "" || secondScreen.Content == null)
                    {
                        secondScreenBuffer = "negate(" + mainLabel.Content + ")";
                        TrimSecondScreen(secondScreenBuffer);
                    }
                    else if (mathOperation != "" && isNegativePositivePressed == false && isReciprocalPressed == false)
                    {
                        string newSecondScreenMessageFirstPart = "";
                        string newSecondScreenMessageSecondPart = "";
                        int index = secondScreenBuffer.LastIndexOf(Convert.ToChar(mathOperation));
                        for (int i = 0; i < secondScreenBuffer.Length; i++)
                        {
                            if (i <= index)
                            {
                                newSecondScreenMessageFirstPart += secondScreenBuffer[i];
                            }
                            else
                            {
                                newSecondScreenMessageSecondPart += secondScreenBuffer[i];
                            }
                        }

                        secondScreenBuffer = newSecondScreenMessageFirstPart + " negate(" + newSecondScreenMessageSecondPart + mainLabel.Content + ")";
                        TrimSecondScreen(secondScreenBuffer);
                    }
                    else
                    {
                        string newSecondScreenMessageFirstPart = "";
                        string newSecondScreenMessageSecondPart = "";
                        int index = secondScreenBuffer.LastIndexOf(" ");
                        for (int i = 0; i < secondScreenBuffer.Length; i++)
                        {
                            if (i <= index)
                            {
                                newSecondScreenMessageFirstPart += secondScreenBuffer[i];
                            }
                            else
                            {
                                newSecondScreenMessageSecondPart += secondScreenBuffer[i];
                            }
                        }
                        secondScreenBuffer = newSecondScreenMessageFirstPart + "negate(" + newSecondScreenMessageSecondPart + ")";
                        TrimSecondScreen(secondScreenBuffer);
                    }

                    isNegativePositivePressed = true;
                }
                else
                {
                    NegativePositiveNumber = mainNumber;
                }

                mainLabel.Content = mainNumber.ToString();
            }
        }

        private void ButtonSquareRoot(object sender, RoutedEventArgs e)
        {
            if (mainScreen.Content != "" && mainScreen.Content != null)
            {
                if (messageScreen.Content != "" && messageScreen.Content != null)
                {
                    MasterReset();
                }

                if (mainScreen.Content != "" || mainScreen.Content != null)
                {
                    double firstNumber = double.Parse(mainScreen.Content.ToString());
                    double result = 0;
                    bool showResult = true;

                    if (firstNumber < 0)
                    {
                        messageScreen.Content = "Inavalid input";
                        shouldMasterReset = true;
                        showResult = false;
                    }
                    else
                    {
                        result = Math.Sqrt(firstNumber);
                    }

                    if (showResult == true)
                    {
                        //mainScreen.Content = result.ToString();
                        if (result.ToString().IndexOf(',') >= 0)
                        {
                            result = double.Parse(result.ToString().TrimEnd('0').TrimEnd(','));
                        }
                        else if (result.ToString().IndexOf('.') >= 0)
                        {
                            result = double.Parse(result.ToString().TrimEnd('0').TrimEnd('.'));
                        }

                        TrimMainScreen(result.ToString());
                    }
                    else
                    {
                        mainScreen.Content = "";
                    }

                    if (secondScreen.Content == "" || secondScreen.Content == null)
                    {
                        secondScreenBuffer = "sqrt(" + firstNumber + ")";
                        TrimSecondScreen(secondScreenBuffer);
                    }
                    else if (mathOperation != "" && isPercentPressed == false && isSquareRootPressed == false && isReciprocalPressed == false && isNegativePositivePressed == false)
                    {
                        string newSecondScreenMessageFirstPart = "";
                        string newSecondScreenMessageSecondPart = "";
                        int index = secondScreenBuffer.LastIndexOf(Convert.ToChar(mathOperation));
                        for (int i = 0; i < secondScreenBuffer.Length; i++)
                        {
                            if (i <= index)
                            {
                                newSecondScreenMessageFirstPart += secondScreenBuffer[i];
                            }
                            else
                            {
                                newSecondScreenMessageSecondPart += secondScreenBuffer[i];
                            }
                        }

                        if (mainScreen.Content == "")
                        {
                            secondScreenBuffer = newSecondScreenMessageFirstPart + " sqrt(" + newSecondScreenMessageSecondPart + "0)";
                        }
                        else
                        {
                            secondScreenBuffer = newSecondScreenMessageFirstPart + " sqrt(" + newSecondScreenMessageSecondPart + firstNumber + ")";
                        }

                        TrimSecondScreen(secondScreenBuffer);
                    }
                    else
                    {
                        string newSecondScreenMessageFirstPart = "";
                        string newSecondScreenMessageSecondPart = "";
                        int index = secondScreenBuffer.LastIndexOf(" ");
                        for (int i = 0; i < secondScreenBuffer.Length; i++)
                        {
                            if (i <= index)
                            {
                                newSecondScreenMessageFirstPart += secondScreenBuffer[i];
                            }
                            else
                            {
                                newSecondScreenMessageSecondPart += secondScreenBuffer[i];
                            }
                        }
                        secondScreenBuffer = newSecondScreenMessageFirstPart + "sqrt(" + newSecondScreenMessageSecondPart + ")";
                        TrimSecondScreen(secondScreenBuffer);
                    }

                    isSquareRootPressed = true;
                }
            }
        }

        private void ButtonMS(object sender, RoutedEventArgs e)
        {
            if (mainScreen.Content != "" && mainScreen.Content != null)
            {
                mNumber = decimal.Parse(mainScreen.Content.ToString());
                if (mNumber == 0)
                {
                    shouldResetMainScreen = false;
                    mContainer.Content = "";
                }
                else
                {
                    shouldResetMainScreen = true;
                    mContainer.Content = "M";
                }

                if (isReciprocalPressed == true || isPercentPressed == true || isNegativePositivePressed == true || isSquareRootPressed == true)
                {
                    string newSecondScreenResult = "";
                    int index = 0;
                    if (mathOperation != "")
                    {
                        index = secondScreenBuffer.LastIndexOf(Convert.ToChar(mathOperation));
                        for (int i = 0; i < index + 1; i++)
                        {
                            newSecondScreenResult += secondScreenBuffer[i];
                        }

                        secondScreenBuffer = newSecondScreenResult;
                        secondScreen.Content = secondScreenBuffer;
                    }
                    else
                    {
                        secondScreenBuffer = "";
                        secondScreen.Content = secondScreenBuffer;
                    }
                }
            }
        }

        private void ButtonMPlus(object sender, RoutedEventArgs e)
        {
            if (mainScreen.Content != "" && mainScreen.Content != null)
            {
                mNumber += decimal.Parse(mainScreen.Content.ToString());
                if (mNumber == 0)
                {
                    shouldResetMainScreen = false;
                    mContainer.Content = "";
                }
                else
                {
                    shouldResetMainScreen = true;
                    mContainer.Content = "M";
                }

                if (isReciprocalPressed == true || isPercentPressed == true || isNegativePositivePressed == true || isSquareRootPressed == true)
                {
                    string newSecondScreenResult = "";
                    int index = 0;
                    if (mathOperation != "")
                    {
                        index = secondScreenBuffer.LastIndexOf(Convert.ToChar(mathOperation));
                        for (int i = 0; i < index + 1; i++)
                        {
                            newSecondScreenResult += secondScreenBuffer[i];
                        }

                        //secondScreenBuffer = newSecondScreenResult;
                        TrimSecondScreen(newSecondScreenResult);
                        isReciprocalPressed = false;
                        isPercentPressed = false;
                        isNegativePositivePressed = false;
                        isSquareRootPressed = false;
                    }
                    else
                    {
                        //secondScreenBuffer = "";
                        TrimSecondScreen("");
                    }
                }
            }
        }

        private void ButtonMMinus(object sender, RoutedEventArgs e)
        {
            if (mainScreen.Content != "" && mainScreen.Content != null)
            {
                mNumber -= decimal.Parse(mainScreen.Content.ToString());
                if (mNumber == 0)
                {
                    shouldResetMainScreen = false;
                    mContainer.Content = "";
                }
                else
                {
                    shouldResetMainScreen = true;
                    mContainer.Content = "M";
                }

                if (isReciprocalPressed == true || isPercentPressed == true || isNegativePositivePressed == true || isSquareRootPressed == true)
                {
                    string newSecondScreenResult = "";
                    int index = 0;
                    if (mathOperation != "")
                    {
                        index = secondScreenBuffer.LastIndexOf(Convert.ToChar(mathOperation));
                        for (int i = 0; i < index + 1; i++)
                        {
                            newSecondScreenResult += secondScreenBuffer[i];
                        }

                        secondScreenBuffer = newSecondScreenResult;
                        secondScreen.Content = secondScreenBuffer;
                    }
                    else
                    {
                        secondScreenBuffer = "";
                        secondScreen.Content = secondScreenBuffer;
                    }
                }
            }
        }

        private void ButtonMR(object sender, RoutedEventArgs e)
        {
            if (messageScreen.Content == "" || messageScreen.Content == null)
            {
                TrimMainScreen(mNumber.ToString());
                if (mNumber == 0)
                {
                    shouldResetMainScreen = false;
                    mContainer.Content = "";
                }
                else
                {
                    shouldResetMainScreen = true;
                    mContainer.Content = "M";
                }

                if (isReciprocalPressed == true || isPercentPressed == true || isNegativePositivePressed == true || isSquareRootPressed == true)
                {
                    string newSecondScreenResult = "";
                    int index = 0;
                    if (mathOperation != "")
                    {
                        index = secondScreenBuffer.LastIndexOf(Convert.ToChar(mathOperation));
                        for (int i = 0; i < index + 1; i++)
                        {
                            newSecondScreenResult += secondScreenBuffer[i];
                        }

                        secondScreenBuffer = newSecondScreenResult;
                        secondScreen.Content = secondScreenBuffer;
                    }
                    else
                    {
                        secondScreenBuffer = "";
                        secondScreen.Content = secondScreenBuffer;
                    }
                }
            }
        }

        private void ButtonMC(object sender, RoutedEventArgs e)
        {
            mNumber = 0;
            mContainer.Content = "";
        }

        private void ButtonCopy(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(mainScreen.Content.ToString());
        }

        private void ButtonPaste(object sender, RoutedEventArgs e)
        {
            string clipboardInput = Clipboard.GetText();
            decimal clipboardNumber = 0;
            bool isClipboardInputCorrect = decimal.TryParse(clipboardInput, out clipboardNumber);
            if (isClipboardInputCorrect == true)
            {
                TrimMainScreen(clipboardInput);
            }
        }

        private string IsOnlyOneZero(object content)
        {
            if (content.ToString() == "0")
            {
                content = "";
            }

            return content.ToString();
        }

        private string CheckMainScreen(object content)
        {
            if (shouldResetMainScreen == true)
            {
                content = "";
                shouldResetMainScreen = false;
            }

            if (shouldMasterReset == true)
            {
                MasterReset();
            }

            return content.ToString();
        }

        private void TrimSecondScreen(string inputTextSecondScreen)
        {
            if (inputTextSecondScreen.IndexOf(',') >= 0)
            {
                inputTextSecondScreen = inputTextSecondScreen.TrimEnd('0').TrimEnd(',');
            }
            else if (inputTextSecondScreen.IndexOf('.') >= 0)
            {
                inputTextSecondScreen = inputTextSecondScreen.TrimEnd('0').TrimEnd('.');
            }

            string newSecondScreenText = inputTextSecondScreen;
            if (inputTextSecondScreen.Length > 26)
            {
                newSecondScreenText = "<<";
                for (int i = inputTextSecondScreen.Length - 26; i < inputTextSecondScreen.Length; i++)
                {
                    newSecondScreenText += inputTextSecondScreen[i];
                }
            }

            secondScreen.Content = newSecondScreenText;
        }

        private void TrimMainScreen(string inputTextMainscreen)
        {
            //inputTextMainscreen = inputTextMainscreen.TrimEnd('0');
            string newMainScreenText = inputTextMainscreen;
            if (inputTextMainscreen.Length > 11)
            {
                mainScreen.FontSize = 18;
                mainScreen.FontWeight = FontWeights.Thin;
                mainScreen.Padding = new Thickness(0, 20, 4, 0);
            }
            else
            {
                mainScreen.FontSize = 24;
                mainScreen.FontWeight = FontWeights.Normal;
                mainScreen.Padding = new Thickness(0, 12, 4, 0);
            }

            if (isEqualPresset == true && shouldResetMainScreen == true && inputTextMainscreen.Length > 11)
            {
                mainScreen.FontSize = 16;
            }

            if (inputTextMainscreen.Length > 16 && shouldMasterReset == false && decimal.Parse(inputTextMainscreen) >= 0)
            {
                newMainScreenText = "";
                for (int i = 0; i < 16; i++)
                {
                    newMainScreenText += inputTextMainscreen[i];
                }
            }
            else if (inputTextMainscreen.Length > 16 && shouldResetMainScreen == false && decimal.Parse(inputTextMainscreen) < 0)
            {
                newMainScreenText = "";
                for (int i = 0; i < 17; i++)
                {
                    newMainScreenText += inputTextMainscreen[i];
                }
            }
            else if (inputTextMainscreen.Length > 18)
            {
                newMainScreenText = "";
                for (int i = 0; i < 18; i++)
                {
                    newMainScreenText += inputTextMainscreen[i];
                }
            }

            mainScreen.Content = newMainScreenText;
        }

        private void MasterReset()
        {
            mainScreen.Content = "0";
            secondScreen.Content = "";
            secondScreenBuffer = "";
            messageScreen.Content = "";
            mathOperation = "";
            numberForRepeatedOperations = 0;
            percentNumber = 0;
            NegativePositiveNumber = 0;
            isEqualPresset = true;
            shouldResetMainScreen = true;
            isReciprocalPressed = false;
            isNegativePositivePressed = false;
            isCommaSet = false;
            shouldMasterReset = false;
            isPercentPressed = false;
            isSquareRootPressed = false;
            mainScreen.FontSize = 24;
            mainScreen.FontWeight = FontWeights.Normal;
            mainScreen.Padding = new Thickness(0, 12, 4, 0);
        }

        private void PerformOperation(string sign)
        {
            Label firstNumber = mainScreen;
            Label secondNumber = secondScreen;

            if (firstNumber.Content != "" && firstNumber.Content != null)
            {
                if (isNegativePositivePressed == true && shouldResetMainScreen == false && isPercentPressed == false && isReciprocalPressed == false)
                {
                    secondScreenBuffer += " " + NegativePositiveNumber;
                    TrimSecondScreen(secondScreenBuffer);
                }
                if (shouldResetMainScreen == false || isEqualPresset == true || isReciprocalPressed == true || isPercentPressed == true ||
                    isNegativePositivePressed == true || isSquareRootPressed == true || mNumber != 0)
                {
                    decimal result = decimal.Parse(firstNumber.Content.ToString());
                    if (secondNumber.Content != "" && secondNumber.Content != null && mathOperation != "")
                    {
                        decimal secondNumb = decimal.Parse(firstNumber.Content.ToString());
                        result = CheckForMathOperation(numberForOperation, secondNumb, mathOperation);
                    }

                    if (isReciprocalPressed == true || isPercentPressed == true || isNegativePositivePressed == true || isSquareRootPressed == true)
                    {
                        //secondNumber.Content += " " + sign;
                        if (secondScreenBuffer.IndexOf(',') >= 0)
                        {
                            secondScreenBuffer = secondScreenBuffer.TrimEnd('0').TrimEnd(',');
                        }
                        else if (secondScreenBuffer.IndexOf('.') >= 0)
                        {
                            secondScreenBuffer = secondScreenBuffer.TrimEnd('0').TrimEnd('.');
                        }

                        secondScreenBuffer += " " + sign;
                        //secondNumber.Content = secondScreenBuffer;//
                        TrimSecondScreen(secondScreenBuffer);
                    }
                    else
                    {
                        //secondNumber.Content += " " + firstNumber.Content + " " + sign;
                        if (firstNumber.Content.ToString().IndexOf(',') >= 0)
                        {
                            firstNumber.Content = firstNumber.Content.ToString().TrimEnd('0').TrimEnd(',');
                        }
                        else if (secondScreenBuffer.IndexOf('.') >= 0)
                        {
                            firstNumber.Content = firstNumber.Content.ToString().TrimEnd('0').TrimEnd('.');
                        }

                        secondScreenBuffer += " " + firstNumber.Content + " " + sign;
                        //secondNumber.Content = secondScreenBuffer;//
                        TrimSecondScreen(secondScreenBuffer);
                    }

                    firstNumber.Content = CheckMainScreen(firstNumber.Content);



                    numberForOperation = result;
                    if (messageScreen.Content != "" && messageScreen.Content != null)
                    {
                        firstNumber.Content = "";
                        shouldMasterReset = true;
                    }
                    else
                    {
                        if (result.ToString().IndexOf(',') >= 0)
                        {
                            result = decimal.Parse(result.ToString().TrimEnd('0').TrimEnd(','));
                        }
                        else if (result.ToString().IndexOf('.') >= 0)
                        {
                            result = decimal.Parse(result.ToString().TrimEnd('0').TrimEnd('.'));
                        }

                        TrimMainScreen(result.ToString());
                        //firstNumber.Content = result.ToString();
                    }

                    shouldResetMainScreen = true;
                    mathOperation = sign;
                }
                else if (mathOperation != sign && secondNumber.Content != "" && secondNumber.Content != null)
                {
                    string changedSingt = "";
                    //for (int i = 0; i < secondNumber.Content.ToString().Length - 1; i++)
                    for (int i = 0; i < secondScreenBuffer.Length - 1; i++)
                    {
                        //changedSingt += secondNumber.Content.ToString()[i];
                        changedSingt += secondScreenBuffer[i];
                    }

                    changedSingt += sign;
                    secondScreenBuffer = changedSingt;
                    //secondNumber.Content = secondScreenBuffer;//
                    TrimSecondScreen(secondScreenBuffer);
                    mathOperation = sign;
                }
            }

            isEqualPresset = false;
            isReciprocalPressed = false;
            isPercentPressed = false;
            isNegativePositivePressed = false;
            isSquareRootPressed = false;
        }

        private decimal CheckForMathOperation(decimal firstNumber, decimal secondNumber, string sign)
        {
            decimal result = firstNumber;
            if (sign == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (sign == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (sign == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (sign == "/")
            {
                if (secondNumber == 0)
                {
                    messageScreen.Content = "cannot divide by zero";
                }
                else
                {
                    result = firstNumber / secondNumber;
                }
            }

            return result;
        }
    }
}
