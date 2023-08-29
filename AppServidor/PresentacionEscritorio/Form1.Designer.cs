namespace PresentacionEscritorio
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            fontDialog1 = new FontDialog();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            errorProvider1 = new ErrorProvider(components);
            label2 = new Label();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // fontDialog1
            // 
            fontDialog1.Apply += fontDialog1_Apply;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(247, 32);
            label1.Name = "label1";
            label1.Size = new Size(262, 20);
            label1.TabIndex = 0;
            label1.Text = "Bienvenido al sistema de Restaurantes";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(68, 184);
            button1.Name = "button1";
            button1.Size = new Size(168, 29);
            button1.TabIndex = 1;
            button1.Text = "Agregar Restaurante";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(286, 264);
            button2.Name = "button2";
            button2.Size = new Size(168, 29);
            button2.TabIndex = 2;
            button2.Text = "Agregar Clientes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(286, 184);
            button3.Name = "button3";
            button3.Size = new Size(168, 29);
            button3.TabIndex = 3;
            button3.Text = "Agregar Platos";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(68, 264);
            button4.Name = "button4";
            button4.Size = new Size(168, 29);
            button4.TabIndex = 4;
            button4.Text = "Agregar Categorias";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(511, 184);
            button5.Name = "button5";
            button5.Size = new Size(168, 29);
            button5.TabIndex = 5;
            button5.Text = "Agregar Extras";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_ClickAsync;
            // 
            // button6
            // 
            button6.Location = new Point(511, 264);
            button6.Name = "button6";
            button6.Size = new Size(168, 53);
            button6.TabIndex = 6;
            button6.Text = "Agregar Platos a Restaurantes";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 364);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 7;
            // 
            // button7
            // 
            button7.Location = new Point(286, 318);
            button7.Name = "button7";
            button7.Size = new Size(168, 29);
            button7.TabIndex = 8;
            button7.Text = "Mostrar Registros";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(325, 106);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 9;
            button8.Text = "Conexion";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(795, 421);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(label2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontDialog fontDialog1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private ErrorProvider errorProvider1;
        private Label label2;
        private Button button7;
        private Button button8;
    }
}