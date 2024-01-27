using System.Data;
using System.Linq.Expressions;
namespace Calculator
{
    public partial class Task2Form : Form
    {
        double val1, val2;
        string oprtr = string.Empty;
        double result = 0;
        string total = string.Empty;
        private List<string> historyList = new List<string>();
        private bool newNumberStarted = false;

        public Task2Form()
        {
            InitializeComponent();
            historyList.Add("History");
            textBoxResult.Text = "0";
            textBoxResult.TextAlign = HorizontalAlignment.Right;
        }


        private void Button0_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "0";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "0";
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "1";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "1";
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "2";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "2";
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "3";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "3";
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "4";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "4";
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "5";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "5";
            }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "6";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "6";
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "7";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "7";
            }
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "8";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "8";
            }
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                textBoxResult.Clear();
                newNumberStarted = false;
            }
            if (textBoxResult.Text != null && textBoxResult.Text == "0")
            {

                textBoxResult.Text = "9";
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "9";
            }
        }
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                newNumberStarted = false;
            }
            val1 = double.Parse(textBoxResult.Text);
            oprtr = "+";
            textBoxResult.Text += oprtr;
        }
        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                newNumberStarted = false;
            }
            val1 = double.Parse(textBoxResult.Text);
            oprtr = "-";
            textBoxResult.Text += oprtr;
        }
        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                newNumberStarted = false;
            }
            val1 = double.Parse(textBoxResult.Text);
            oprtr = "*";
            textBoxResult.Text += oprtr;
        }

        private void ButtonDivision_Click(object sender, EventArgs e)
        {
            if (newNumberStarted)
            {
                newNumberStarted = false;
            }
            val1 = double.Parse(textBoxResult.Text);
            oprtr = "/";
            textBoxResult.Text += oprtr;
        }
        private void ButtonPoint_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = textBoxResult.Text + ".";
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = " ";
        }
        private void ButtonOneRmv_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text.Length > 0)
            {
                textBoxResult.Text = textBoxResult.Text.Substring(0, textBoxResult.Text.Length - 1);
            }
        }
        private void ButtonIsEqual_Click(object sender, EventArgs e)
        {
            string input = textBoxResult.Text;
            string[] parts = System.Text.RegularExpressions.Regex.Split(input, @"(?<=[-+*/])|(?=[-+*/])");

            if (parts.Length != 3)
            {
                MessageBox.Show("Input string was not correct.");
                return;
            }

            val1 = double.Parse(parts[0]);
            oprtr = parts[1];
            val2 = double.Parse(parts[2]);

            switch (oprtr)
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                case "/":
                    if (val2 != 0)
                    {
                        result = val1 / val2;
                    }
                    else
                    {
                        textBoxResult.Text = "Cannot divide by zero";
                        newNumberStarted = true;
                        return;
                    }
                    break;
            }

            textBoxResult.Text = "" + result;
            string equation = textBoxResult.Text;
            string equationWithResult = equation;
            // If the equation is not empty, calculate and add the result to the history
            if (!string.IsNullOrEmpty(equation))
            {
                string result = CalculateResult(equation);
                equationWithResult += " = " + result;
            }

            // Add the history item to the list
            historyList.Add($"{val1} {oprtr} {val2} = {result}");
            ButtonShowHistory_Click(sender, e);
            newNumberStarted = true;
        }
        private void ButtonShowHistory_Click(object sender, EventArgs e)
        {
            History.Items.Clear();
            // Add history items to the ListBox
            foreach (string historyItem in historyList)
            {
                History.Items.Add(historyItem);
            }
        }

        private string CalculateResult(string equation)
        {
            string[] parts = equation.Split(' ');
            if (parts.Length != 3)
            {
                return "invalid equation";
            }

            double val1 = double.Parse(parts[0]);
            string oprtr = parts[1];
            double val2 = double.Parse(parts[2]);

            double result = 0.0;

            switch (oprtr)
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                case "/":
                    if (val2 != 0)
                    {
                        result = val1 / val2;
                    }
                    else
                    {
                        return "Cannot divide by zero";
                    }
                    break;
            }

            return result.ToString();
        }
        private void buttonClick(object sender, EventArgs e)
        {

        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }
        private void History_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonIsEqual_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }
}