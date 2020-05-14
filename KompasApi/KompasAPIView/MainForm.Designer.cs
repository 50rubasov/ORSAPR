namespace KompasAPIView
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonBuild = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SubDiameterTextBox = new System.Windows.Forms.NumericUpDown();
            this.NumberOfHolesTextBox = new System.Windows.Forms.NumericUpDown();
            this.ThicknessTextBox = new System.Windows.Forms.NumericUpDown();
            this.PortDiameterTextBox = new System.Windows.Forms.NumericUpDown();
            this.HeightTextBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.NumericUpDown();
            this.LengthTextBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.KompasCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubDiameterTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfHolesTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortDiameterTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonBuild
            // 
            this.ButtonBuild.Location = new System.Drawing.Point(12, 392);
            this.ButtonBuild.Name = "ButtonBuild";
            this.ButtonBuild.Size = new System.Drawing.Size(267, 31);
            this.ButtonBuild.TabIndex = 0;
            this.ButtonBuild.Text = "Построить";
            this.ButtonBuild.UseVisualStyleBackColor = true;
            this.ButtonBuild.Click += new System.EventHandler(this.ButtonBuild_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SubDiameterTextBox);
            this.groupBox1.Controls.Add(this.NumberOfHolesTextBox);
            this.groupBox1.Controls.Add(this.ThicknessTextBox);
            this.groupBox1.Controls.Add(this.PortDiameterTextBox);
            this.groupBox1.Controls.Add(this.HeightTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.WidthTextBox);
            this.groupBox1.Controls.Add(this.LengthTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 347);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Введите параметры сабвуфера";
            // 
            // SubDiameterTextBox
            // 
            this.SubDiameterTextBox.Location = new System.Drawing.Point(9, 88);
            this.SubDiameterTextBox.Name = "SubDiameterTextBox";
            this.SubDiameterTextBox.Size = new System.Drawing.Size(252, 22);
            this.SubDiameterTextBox.TabIndex = 3;
            this.SubDiameterTextBox.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.SubDiameterTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // NumberOfHolesTextBox
            // 
            this.NumberOfHolesTextBox.Location = new System.Drawing.Point(10, 39);
            this.NumberOfHolesTextBox.Name = "NumberOfHolesTextBox";
            this.NumberOfHolesTextBox.Size = new System.Drawing.Size(251, 22);
            this.NumberOfHolesTextBox.TabIndex = 2;
            this.NumberOfHolesTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberOfHolesTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // ThicknessTextBox
            // 
            this.ThicknessTextBox.Location = new System.Drawing.Point(10, 315);
            this.ThicknessTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThicknessTextBox.Name = "ThicknessTextBox";
            this.ThicknessTextBox.Size = new System.Drawing.Size(252, 22);
            this.ThicknessTextBox.TabIndex = 8;
            this.ThicknessTextBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ThicknessTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // PortDiameterTextBox
            // 
            this.PortDiameterTextBox.Location = new System.Drawing.Point(10, 269);
            this.PortDiameterTextBox.Name = "PortDiameterTextBox";
            this.PortDiameterTextBox.Size = new System.Drawing.Size(252, 22);
            this.PortDiameterTextBox.TabIndex = 7;
            this.PortDiameterTextBox.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.PortDiameterTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(9, 224);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(252, 22);
            this.HeightTextBox.TabIndex = 6;
            this.HeightTextBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.HeightTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Диаметр отверстия сабвуфера Dс";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Количество отверстий сабвуфера Nс";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(9, 179);
            this.WidthTextBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(252, 22);
            this.WidthTextBox.TabIndex = 5;
            this.WidthTextBox.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
            this.WidthTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(9, 134);
            this.LengthTextBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(252, 22);
            this.LengthTextBox.TabIndex = 4;
            this.LengthTextBox.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.LengthTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Толщина материала S";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Диаметр отверстия порта Dп";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Высота короба H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ширина короба W";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Длинна короба L";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 17);
            this.label9.TabIndex = 3;
            // 
            // KompasCheckBox
            // 
            this.KompasCheckBox.AutoSize = true;
            this.KompasCheckBox.Location = new System.Drawing.Point(22, 12);
            this.KompasCheckBox.Name = "KompasCheckBox";
            this.KompasCheckBox.Size = new System.Drawing.Size(237, 21);
            this.KompasCheckBox.TabIndex = 1;
            this.KompasCheckBox.Text = "Включите/Выключите КОМПАС";
            this.KompasCheckBox.UseVisualStyleBackColor = true;
            this.KompasCheckBox.CheckedChanged += new System.EventHandler(this.KompasCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 427);
            this.Controls.Add(this.KompasCheckBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonBuild);
            this.MaximumSize = new System.Drawing.Size(307, 474);
            this.MinimumSize = new System.Drawing.Size(307, 474);
            this.Name = "MainForm";
            this.Text = "Построение корпуса сабвуфера";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubDiameterTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfHolesTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortDiameterTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonBuild;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ThicknessTextBox;
        private System.Windows.Forms.NumericUpDown PortDiameterTextBox;
        private System.Windows.Forms.NumericUpDown HeightTextBox;
        private System.Windows.Forms.NumericUpDown WidthTextBox;
        private System.Windows.Forms.NumericUpDown LengthTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox KompasCheckBox;
        private System.Windows.Forms.NumericUpDown SubDiameterTextBox;
        private System.Windows.Forms.NumericUpDown NumberOfHolesTextBox;
    }
}

