
namespace Zakirova
{
    partial class FormTruckParking
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
            this.pictureBoxParking = new System.Windows.Forms.PictureBox();
            this.button_parking = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Take = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxParking = new System.Windows.Forms.ListBox();
            this.AddPark = new System.Windows.Forms.Button();
            this.DelPark = new System.Windows.Forms.Button();
            this.textBoxLevelsName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxParking
            // 
            this.pictureBoxParking.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxParking.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxParking.Name = "pictureBoxParking";
            this.pictureBoxParking.Size = new System.Drawing.Size(660, 450);
            this.pictureBoxParking.TabIndex = 0;
            this.pictureBoxParking.TabStop = false;
            // 
            // button_parking
            // 
            this.button_parking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_parking.Location = new System.Drawing.Point(666, 246);
            this.button_parking.Name = "button_parking";
            this.button_parking.Size = new System.Drawing.Size(122, 44);
            this.button_parking.TabIndex = 1;
            this.button_parking.Text = "Припарковать самосвал";
            this.button_parking.UseVisualStyleBackColor = true;
            this.button_parking.Click += new System.EventHandler(this.button_parking_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_Take);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(666, 364);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Забрать самосвал";
            // 
            // button_Take
            // 
            this.button_Take.Location = new System.Drawing.Point(26, 49);
            this.button_Take.Name = "button_Take";
            this.button_Take.Size = new System.Drawing.Size(76, 25);
            this.button_Take.TabIndex = 2;
            this.button_Take.Text = "Забрать";
            this.button_Take.UseVisualStyleBackColor = true;
            this.button_Take.Click += new System.EventHandler(this.button_Take_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(53, 23);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(68, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Место:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(699, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Парковки:";
            // 
            // listBoxParking
            // 
            this.listBoxParking.FormattingEnabled = true;
            this.listBoxParking.Location = new System.Drawing.Point(666, 88);
            this.listBoxParking.Name = "listBoxParking";
            this.listBoxParking.Size = new System.Drawing.Size(132, 69);
            this.listBoxParking.TabIndex = 5;
            this.listBoxParking.SelectedIndexChanged += new System.EventHandler(this.listBoxParking_SelectedIndexChanged);
            // 
            // AddPark
            // 
            this.AddPark.Location = new System.Drawing.Point(666, 60);
            this.AddPark.Name = "AddPark";
            this.AddPark.Size = new System.Drawing.Size(131, 22);
            this.AddPark.TabIndex = 6;
            this.AddPark.Text = "Добавить парковку";
            this.AddPark.UseVisualStyleBackColor = true;
            this.AddPark.Click += new System.EventHandler(this.AddPark_Click);
            // 
            // DelPark
            // 
            this.DelPark.Location = new System.Drawing.Point(667, 163);
            this.DelPark.Name = "DelPark";
            this.DelPark.Size = new System.Drawing.Size(131, 20);
            this.DelPark.TabIndex = 7;
            this.DelPark.Text = "Удалить парковку";
            this.DelPark.UseVisualStyleBackColor = true;
            this.DelPark.Click += new System.EventHandler(this.DelPark_Click);
            // 
            // textBoxLevelsName
            // 
            this.textBoxLevelsName.Location = new System.Drawing.Point(668, 29);
            this.textBoxLevelsName.Name = "textBoxLevelsName";
            this.textBoxLevelsName.Size = new System.Drawing.Size(118, 20);
            this.textBoxLevelsName.TabIndex = 8;
            // 
            // FormTruckParking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxLevelsName);
            this.Controls.Add(this.DelPark);
            this.Controls.Add(this.AddPark);
            this.Controls.Add(this.listBoxParking);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_parking);
            this.Controls.Add(this.pictureBoxParking);
            this.Name = "FormTruckParking";
            this.Text = "Парковка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxParking;
        private System.Windows.Forms.Button button_parking;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Take;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxParking;
        private System.Windows.Forms.Button AddPark;
        private System.Windows.Forms.Button DelPark;
        private System.Windows.Forms.TextBox textBoxLevelsName;
    }
}