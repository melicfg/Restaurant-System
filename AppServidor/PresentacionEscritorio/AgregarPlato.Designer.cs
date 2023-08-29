namespace PresentacionEscritorio
{
    partial class AgregarPlato
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label7 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            label6 = new Label();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(53, 290);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 45;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(151, 229);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(298, 247);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(57, 180);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 43;
            label6.Text = "Precio";
            label6.Click += label6_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(155, 88);
            numericUpDown1.Maximum = new decimal(new int[] { -1530494977, 232830, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(105, 27);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 131);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(53, 232);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 42;
            label5.Text = "Categoria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 134);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 40;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 90);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 39;
            label2.Text = "ID (Numero)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 26);
            label1.Name = "label1";
            label1.Size = new Size(168, 20);
            label1.TabIndex = 38;
            label1.Text = "Agregar datos del plato";
            label1.Click += label1_Click;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(155, 178);
            numericUpDown2.Maximum = new decimal(new int[] { -1530494977, 232830, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(105, 27);
            numericUpDown2.TabIndex = 3;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // AgregarPlato
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 362);
            Controls.Add(numericUpDown2);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AgregarPlato";
            Text = "AgregarPlato";
            Load += AgregarPlato_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private ComboBox comboBox1;
        private Button button1;
        private Label label6;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDown2;
    }
}