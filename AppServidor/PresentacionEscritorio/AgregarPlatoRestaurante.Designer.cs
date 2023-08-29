namespace PresentacionEscritorio
{
    partial class AgregarPlatoRestaurante
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            administradorListasBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            button1 = new Button();
            button2 = new Button();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)administradorListasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(227, 133);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(255, 192, 255);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 192, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.HotPink;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.GridColor = Color.FromArgb(255, 192, 192);
            dataGridView1.Location = new Point(245, 210);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(576, 139);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // administradorListasBindingSource
            // 
            administradorListasBindingSource.DataSource = typeof(LogicaDeNegocios.AdministradorListas);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 20);
            label1.Name = "label1";
            label1.Size = new Size(346, 20);
            label1.TabIndex = 2;
            label1.Text = "Ingreso de datos para ingresar platos a restaurante";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 141);
            label2.Name = "label2";
            label2.Size = new Size(174, 20);
            label2.TabIndex = 3;
            label2.Text = "Seleccione el restaurante";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 210);
            label3.Name = "label3";
            label3.Size = new Size(210, 20);
            label3.TabIndex = 4;
            label3.Text = "Seleccione los platos (10 max)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 56);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 5;
            label4.Text = "ID de asignacion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 96);
            label5.Name = "label5";
            label5.Size = new Size(143, 20);
            label5.TabIndex = 6;
            label5.Text = "Fecha de asignacion";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(227, 54);
            numericUpDown1.Maximum = new decimal(new int[] { -1530494977, 232830, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(105, 27);
            numericUpDown1.TabIndex = 47;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(227, 91);
            dateTimePicker1.MaxDate = new DateTime(2023, 7, 11, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(1905, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(278, 27);
            dateTimePicker1.TabIndex = 48;
            dateTimePicker1.Value = new DateTime(2023, 7, 11, 0, 0, 0, 0);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(578, 71);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 49;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 525);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 50;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(578, 98);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 51;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(578, 125);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 52;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(578, 150);
            label10.Name = "label10";
            label10.Size = new Size(0, 20);
            label10.TabIndex = 53;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(29, 365);
            label11.Name = "label11";
            label11.Size = new Size(146, 20);
            label11.TabIndex = 54;
            label11.Text = "Platos seleccionados";
            label11.Click += label11_Click;
            // 
            // button1
            // 
            button1.Location = new Point(699, 521);
            button1.Name = "button1";
            button1.Size = new Size(122, 29);
            button1.TabIndex = 56;
            button1.Text = "Asociar Platos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(131, 245);
            button2.Name = "button2";
            button2.Size = new Size(108, 29);
            button2.TabIndex = 57;
            button2.Text = "Agregar Seleccionados";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.BackgroundColor = Color.FromArgb(255, 192, 255);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 192, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.HotPink;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.GridColor = Color.FromArgb(255, 192, 192);
            dataGridView2.Location = new Point(245, 365);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(576, 139);
            dataGridView2.TabIndex = 58;
            // 
            // AgregarPlatoRestaurante
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(854, 576);
            Controls.Add(dataGridView2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(numericUpDown1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Name = "AgregarPlatoRestaurante";
            Text = "AgregarPlatoRestaurante";
            Load += AgregarPlatoRestaurante_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)administradorListasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private BindingSource administradorListasBindingSource;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView2;
    }
}