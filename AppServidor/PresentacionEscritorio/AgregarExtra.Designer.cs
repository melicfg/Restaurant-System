namespace PresentacionEscritorio
{
    partial class AgregarExtra
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
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label6 = new Label();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(58, 358);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 54;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Activo", "Inactivo" });
            comboBox1.Location = new Point(156, 233);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(303, 315);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(156, 90);
            numericUpDown1.Maximum = new decimal(new int[] { -1530494977, 232830, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(105, 27);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(156, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 236);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 52;
            label5.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 136);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 51;
            label3.Text = "Descripcion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 92);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 50;
            label2.Text = "ID (Numero)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 28);
            label1.Name = "label1";
            label1.Size = new Size(168, 20);
            label1.TabIndex = 49;
            label1.Text = "Agregar datos de Extras";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 189);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 55;
            label4.Text = "Categoria";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(156, 186);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(125, 28);
            comboBox2.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 282);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 57;
            label6.Text = "Precio";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(156, 280);
            numericUpDown2.Maximum = new decimal(new int[] { -1530494977, 232830, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(105, 27);
            numericUpDown2.TabIndex = 5;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // AgregarExtra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 419);
            Controls.Add(numericUpDown2);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AgregarExtra";
            Text = "AgregarExtra";
            Load += AgregarExtra_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private ComboBox comboBox1;
        private Button button1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private ComboBox comboBox2;
        private Label label6;
        private NumericUpDown numericUpDown2;
    }
}