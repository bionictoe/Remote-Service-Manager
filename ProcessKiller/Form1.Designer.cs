namespace ProcessKiller
{
    partial class frmProcessKiller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessKiller));
            this.lstProcesses = new System.Windows.Forms.ListBox();
            this.btnUpdateProcessList = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslProcessCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnKill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstProcesses
            // 
            this.lstProcesses.FormattingEnabled = true;
            this.lstProcesses.Location = new System.Drawing.Point(12, 38);
            this.lstProcesses.Name = "lstProcesses";
            this.lstProcesses.Size = new System.Drawing.Size(226, 251);
            this.lstProcesses.TabIndex = 0;
            // 
            // btnUpdateProcessList
            // 
            this.btnUpdateProcessList.Location = new System.Drawing.Point(163, 298);
            this.btnUpdateProcessList.Name = "btnUpdateProcessList";
            this.btnUpdateProcessList.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateProcessList.TabIndex = 1;
            this.btnUpdateProcessList.Text = "Start";
            this.btnUpdateProcessList.UseVisualStyleBackColor = true;
            this.btnUpdateProcessList.Click += new System.EventHandler(this.btnUpdateProcessList_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslProcessCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(250, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslProcessCount
            // 
            this.tslProcessCount.Name = "tslProcessCount";
            this.tslProcessCount.Size = new System.Drawing.Size(109, 17);
            this.tslProcessCount.Text = "toolStripStatusLabel1";
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(163, 327);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(75, 23);
            this.btnKill.TabIndex = 3;
            this.btnKill.Text = "Stop";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Services List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // frmProcessKiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 386);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnUpdateProcessList);
            this.Controls.Add(this.lstProcesses);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProcessKiller";
            this.Text = "Service Manager";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstProcesses;
        private System.Windows.Forms.Button btnUpdateProcessList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslProcessCount;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

