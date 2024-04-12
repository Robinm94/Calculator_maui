namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string currentOperation = "";

        private bool isJustCalculated = false;
        private bool isNumberJustEntered = false;


        public MainPage()
        {
            InitializeComponent();
        }

            void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            // Append the button text to the Entry field
            ResultEntry.Text += buttonText;

            switch (buttonText)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    currentOperation = buttonText;
                    isNumberJustEntered = false;
                    isJustCalculated = false;
                    break;
                case "=":
                    firstNumber = PerformOperation(firstNumber, secondNumber, currentOperation);
                    currentOperation = "";
                    CalculateResult();
                    // Clear the Entry field after calculating the result
                    break;
                case "C":
                    firstNumber = 0;
                    // Clear the Entry field when the "C" button is clicked
                    ResultEntry.Text = "";
                    break;
                default:
                    if (isJustCalculated)
                    {
                        ResultEntry.Text = "";
                        isJustCalculated = false;
                        ResultEntry.Text += buttonText;
                        firstNumber = 0;
                    }
                    double number;
                    if (double.TryParse(buttonText, out number))
                    {
                        if (currentOperation == "")
                        {
                            if (isNumberJustEntered)
                            {
                                firstNumber = firstNumber * 10 + number;
                            }
                            else
                            {
                                firstNumber = number;
                            }
                        }
                        else
                        {
                            if (isNumberJustEntered)
                            {
                                secondNumber = secondNumber * 10 + number;
                            }
                            else
                            {
                                secondNumber = number;
                            }
                            
                        }
                    }
                    isNumberJustEntered = true;
                    break;
            }
        }

        private double PerformOperation(double number1, double number2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    return number1 / number2;
                default:
                    return number2;
            }
        }

        private void CalculateResult()
        {

            currentOperation = "";
            isJustCalculated = true;
            secondNumber = 0;
            ResultEntry.Text = firstNumber.ToString();
        }
    }

}
