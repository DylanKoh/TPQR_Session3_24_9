namespace TPQR_Session3_24_9
{
    partial class UpdateInfo
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCompetitors = new System.Windows.Forms.NumericUpDown();
            this.nudDelegates = new System.Windows.Forms.NumericUpDown();
            this.nudHead = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompetitors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelegates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 623);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1160, 53);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 94);
            this.panel1.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 32);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 37);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(959, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14F);
            this.label2.Location = new System.Drawing.Point(430, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Update Info / Booking";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(488, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Competitors";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(488, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(236, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Delegates (Excluding Head)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Head of Delegation";
            // 
            // nudCompetitors
            // 
            this.nudCompetitors.Location = new System.Drawing.Point(362, 211);
            this.nudCompetitors.Name = "nudCompetitors";
            this.nudCompetitors.Size = new System.Drawing.Size(120, 27);
            this.nudCompetitors.TabIndex = 20;
            // 
            // nudDelegates
            // 
            this.nudDelegates.Location = new System.Drawing.Point(362, 178);
            this.nudDelegates.Name = "nudDelegates";
            this.nudDelegates.Size = new System.Drawing.Size(120, 27);
            this.nudDelegates.TabIndex = 19;
            // 
            // nudHead
            // 
            this.nudHead.Location = new System.Drawing.Point(362, 145);
            this.nudHead.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHead.Name = "nudHead";
            this.nudHead.Size = new System.Drawing.Size(120, 27);
            this.nudHead.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "No. Of Pax: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(889, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "TOTAL ($): ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(998, 543);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(18, 18);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "0";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1011, 579);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 38);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 275);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1136, 256);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Room Type";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 122;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Room Rate Per Night ($)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 147;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Available No. of Rooms";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 155;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Rooms Booked";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 141;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "New No. of Rooms Required";
            this.Column6.Name = "Column6";
            this.Column6.Width = 174;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "New Sub-Total ($)";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 142;
            // 
            // UpdateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 676);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudCompetitors);
            this.Controls.Add(this.nudDelegates);
            this.Controls.Add(this.nudHead);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UpdateInfo";
            this.Text = "Update Info";
            this.Load += new System.EventHandler(this.UpdateInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompetitors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelegates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudCompetitors;
        private System.Windows.Forms.NumericUpDown nudDelegates;
        private System.Windows.Forms.NumericUpDown nudHead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}