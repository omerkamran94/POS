namespace POS.UI
{
    partial class CashDrawerForm
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
            this.btnupdate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCashDrawerId = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCashDrawerStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCashDrawerAdded = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCashDrawerRemoved = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnupdate.Location = new System.Drawing.Point(253, 449);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(110, 38);
            this.btnupdate.TabIndex = 68;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label8.Location = new System.Drawing.Point(135, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 22);
            this.label8.TabIndex = 66;
            this.label8.Text = "ID";
            // 
            // txtCashDrawerId
            // 
            this.txtCashDrawerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCashDrawerId.Location = new System.Drawing.Point(232, 193);
            this.txtCashDrawerId.Name = "txtCashDrawerId";
            this.txtCashDrawerId.ReadOnly = true;
            this.txtCashDrawerId.Size = new System.Drawing.Size(224, 30);
            this.txtCashDrawerId.TabIndex = 65;
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnadd.Location = new System.Drawing.Point(142, 449);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(100, 38);
            this.btnadd.TabIndex = 64;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(68, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 63;
            this.label1.Text = "Cash Start";
            // 
            // txtCashDrawerStart
            // 
            this.txtCashDrawerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCashDrawerStart.Location = new System.Drawing.Point(232, 245);
            this.txtCashDrawerStart.Name = "txtCashDrawerStart";
            this.txtCashDrawerStart.Size = new System.Drawing.Size(224, 30);
            this.txtCashDrawerStart.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(212, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 48);
            this.label2.TabIndex = 60;
            this.label2.Text = "Cash Register";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(68, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 70;
            this.label3.Text = "Cash Added";
            // 
            // txtCashDrawerAdded
            // 
            this.txtCashDrawerAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCashDrawerAdded.Location = new System.Drawing.Point(232, 295);
            this.txtCashDrawerAdded.Name = "txtCashDrawerAdded";
            this.txtCashDrawerAdded.Size = new System.Drawing.Size(224, 30);
            this.txtCashDrawerAdded.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label4.Location = new System.Drawing.Point(68, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 22);
            this.label4.TabIndex = 72;
            this.label4.Text = "Cash Removed";
            // 
            // txtCashDrawerRemoved
            // 
            this.txtCashDrawerRemoved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCashDrawerRemoved.Location = new System.Drawing.Point(232, 344);
            this.txtCashDrawerRemoved.Name = "txtCashDrawerRemoved";
            this.txtCashDrawerRemoved.Size = new System.Drawing.Size(224, 30);
            this.txtCashDrawerRemoved.TabIndex = 71;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_del
            // 
            this.button_del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.button_del.Location = new System.Drawing.Point(369, 449);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(100, 38);
            this.button_del.TabIndex = 78;
            this.button_del.Text = "Delete";
            this.button_del.UseVisualStyleBackColor = false;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // CashDrawerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 577);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCashDrawerRemoved);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCashDrawerAdded);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCashDrawerId);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCashDrawerStart);
            this.Controls.Add(this.label2);
            this.Name = "CashDrawerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCashDrawerId;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCashDrawerStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCashDrawerAdded;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCashDrawerRemoved;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_del;
    }
}