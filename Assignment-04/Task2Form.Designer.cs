namespace Calculator
{
    partial class Task2Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxResult = new TextBox();
            btnClear = new Button();
            btnMinus = new Button();
            btnDivision = new Button();
            btnOneRmv = new Button();
            btnMultiply = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btnPlus = new Button();
            btn3 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn0 = new Button();
            btnPoint = new Button();
            btnIsEqual = new Button();
            History = new ListBox();
            SuspendLayout();
            // 
            // textBoxResult
            // 
            textBoxResult.BackColor = SystemColors.ButtonFace;
            textBoxResult.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxResult.Location = new Point(69, 42);
            textBoxResult.Margin = new Padding(4, 3, 4, 3);
            textBoxResult.Multiline = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new Size(549, 87);
            textBoxResult.TabIndex = 0;
            textBoxResult.TextAlign = HorizontalAlignment.Right;
            textBoxResult.TextChanged += textBoxResult_TextChanged;
            textBoxResult.KeyDown += TextBoxResult_KeyDown;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.Location = new Point(282, 144);
            btnClear.Margin = new Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(78, 61);
            btnClear.TabIndex = 1;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += ButtonClear_Click;
            // 
            // btnMinus
            // 
            btnMinus.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnMinus.Location = new Point(368, 144);
            btnMinus.Margin = new Padding(4, 3, 4, 3);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(78, 61);
            btnMinus.TabIndex = 2;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += ButtonMinus_Click;
            // 
            // btnDivision
            // 
            btnDivision.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDivision.Location = new Point(454, 144);
            btnDivision.Margin = new Padding(4, 3, 4, 3);
            btnDivision.Name = "btnDivision";
            btnDivision.Size = new Size(78, 61);
            btnDivision.TabIndex = 3;
            btnDivision.Text = "/";
            btnDivision.UseVisualStyleBackColor = true;
            btnDivision.Click += ButtonDivision_Click;
            // 
            // btnOneRmv
            // 
            btnOneRmv.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnOneRmv.Location = new Point(540, 144);
            btnOneRmv.Margin = new Padding(4, 3, 4, 3);
            btnOneRmv.Name = "btnOneRmv";
            btnOneRmv.Size = new Size(78, 61);
            btnOneRmv.TabIndex = 4;
            btnOneRmv.Text = "X";
            btnOneRmv.UseVisualStyleBackColor = true;
            btnOneRmv.Click += ButtonOneRmv_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMultiply.Location = new Point(540, 211);
            btnMultiply.Margin = new Padding(4, 3, 4, 3);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(78, 61);
            btnMultiply.TabIndex = 8;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += ButtonMultiply_Click;
            // 
            // btn9
            // 
            btn9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn9.Location = new Point(454, 211);
            btn9.Margin = new Padding(4, 3, 4, 3);
            btn9.Name = "btn9";
            btn9.Size = new Size(78, 61);
            btn9.TabIndex = 7;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += Button9_Click;
            // 
            // btn8
            // 
            btn8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn8.Location = new Point(368, 211);
            btn8.Margin = new Padding(4, 3, 4, 3);
            btn8.Name = "btn8";
            btn8.Size = new Size(78, 61);
            btn8.TabIndex = 6;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += Button8_Click;
            // 
            // btn7
            // 
            btn7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn7.Location = new Point(282, 211);
            btn7.Margin = new Padding(4, 3, 4, 3);
            btn7.Name = "btn7";
            btn7.Size = new Size(78, 61);
            btn7.TabIndex = 5;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += Button7_Click;
            // 
            // btn6
            // 
            btn6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn6.Location = new Point(453, 278);
            btn6.Margin = new Padding(4, 3, 4, 3);
            btn6.Name = "btn6";
            btn6.Size = new Size(78, 61);
            btn6.TabIndex = 11;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += Button6_Click;
            // 
            // btn5
            // 
            btn5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn5.Location = new Point(368, 278);
            btn5.Margin = new Padding(4, 3, 4, 3);
            btn5.Name = "btn5";
            btn5.Size = new Size(78, 61);
            btn5.TabIndex = 10;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += Button5_Click;
            // 
            // btn4
            // 
            btn4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn4.Location = new Point(282, 278);
            btn4.Margin = new Padding(4, 3, 4, 3);
            btn4.Name = "btn4";
            btn4.Size = new Size(78, 61);
            btn4.TabIndex = 9;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += Button4_Click;
            // 
            // btnPlus
            // 
            btnPlus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPlus.Location = new Point(539, 278);
            btnPlus.Margin = new Padding(4, 3, 4, 3);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(78, 128);
            btnPlus.TabIndex = 16;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += ButtonPlus_Click;
            // 
            // btn3
            // 
            btn3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn3.Location = new Point(453, 345);
            btn3.Margin = new Padding(4, 3, 4, 3);
            btn3.Name = "btn3";
            btn3.Size = new Size(78, 61);
            btn3.TabIndex = 15;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += Button3_Click;
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn1.Location = new Point(282, 345);
            btn1.Margin = new Padding(4, 3, 4, 3);
            btn1.Name = "btn1";
            btn1.Size = new Size(78, 61);
            btn1.TabIndex = 13;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += Button1_Click;
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn2.Location = new Point(367, 345);
            btn2.Margin = new Padding(4, 3, 4, 3);
            btn2.Name = "btn2";
            btn2.Size = new Size(78, 61);
            btn2.TabIndex = 17;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += Button2_Click;
            // 
            // btn0
            // 
            btn0.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn0.Location = new Point(283, 412);
            btn0.Margin = new Padding(4, 3, 4, 3);
            btn0.Name = "btn0";
            btn0.Size = new Size(163, 51);
            btn0.TabIndex = 18;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += Button0_Click;
            // 
            // btnPoint
            // 
            btnPoint.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPoint.Location = new Point(454, 412);
            btnPoint.Margin = new Padding(4, 3, 4, 3);
            btnPoint.Name = "btnPoint";
            btnPoint.Size = new Size(78, 51);
            btnPoint.TabIndex = 19;
            btnPoint.Text = ".";
            btnPoint.UseVisualStyleBackColor = true;
            btnPoint.Click += ButtonPoint_Click;
            // 
            // btnIsEqual
            // 
            btnIsEqual.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnIsEqual.Location = new Point(539, 412);
            btnIsEqual.Margin = new Padding(4, 3, 4, 3);
            btnIsEqual.Name = "btnIsEqual";
            btnIsEqual.Size = new Size(78, 51);
            btnIsEqual.TabIndex = 20;
            btnIsEqual.Text = "=";
            btnIsEqual.UseVisualStyleBackColor = true;
            btnIsEqual.Click += ButtonIsEqual_Click;
            // 
            // History
            // 
            History.BackColor = SystemColors.InactiveCaption;
            History.FormattingEnabled = true;
            History.ItemHeight = 15;
            History.Items.AddRange(new object[] { "History" });
            History.Location = new Point(69, 144);
            History.Name = "History";
            History.Size = new Size(207, 319);
            History.TabIndex = 21;
            History.SelectedIndexChanged += History_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(630, 528);
            Controls.Add(History);
            Controls.Add(btnIsEqual);
            Controls.Add(btnPoint);
            Controls.Add(btn0);
            Controls.Add(btn2);
            Controls.Add(btnPlus);
            Controls.Add(btn3);
            Controls.Add(btn1);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btnMultiply);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btnOneRmv);
            Controls.Add(btnDivision);
            Controls.Add(btnMinus);
            Controls.Add(btnClear);
            Controls.Add(textBoxResult);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculator";
            Click += buttonClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxResult;
        private Button btnClear;
        private Button btnMinus;
        private Button btnDivision;
        private Button btnOneRmv;
        private Button btnMultiply;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btnPlus;
        private Button btn3;
        private Button btn1;
        private Button btn2;
        private Button btn0;
        private Button btnPoint;
        private Button btnIsEqual;
        private ListBox History;
    }
}