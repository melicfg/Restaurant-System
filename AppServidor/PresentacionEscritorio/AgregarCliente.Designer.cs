namespace PresentacionEscritorio
{
    partial class AgregarCliente
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
            textBox3 = new TextBox();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label8 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(72, 406);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 45;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "F", "M" });
            comboBox1.Location = new Point(170, 345);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(317, 363);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 44;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(170, 244);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(147, 27);
            textBox3.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 247);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 43;
            label6.Text = "Apellido 2";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(170, 193);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(147, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(170, 139);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 348);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 42;
            label5.Text = "Genero";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 193);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 41;
            label4.Text = "Apellido 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 142);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 40;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 98);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 39;
            label2.Text = "ID (Numero)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 34);
            label1.Name = "label1";
            label1.Size = new Size(203, 20);
            label1.TabIndex = 38;
            label1.Text = "Agregar datos de restaurante";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(72, 299);
            label8.Name = "label8";
            label8.Size = new Size(91, 20);
            label8.TabIndex = 46;
            label8.Text = "Cumpleaños";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(169, 294);
            dateTimePicker1.MaxDate = new DateTime(2023, 7, 11, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(1905, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(278, 27);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2023, 7, 11, 0, 0, 0, 0);
            // 
            // textBox4
            // 
            textBox4.Location = new Point(170, 95);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 1;
            // 
            // AgregarCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 450);
            Controls.Add(textBox4);
            Controls.Add(dateTimePicker1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AgregarCliente";
            Text = "AgregarCliente";
            Load += AgregarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private ComboBox comboBox1;
        private Button button1;
        private TextBox textBox3;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label8;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox4;
    }
}