using System.Windows.Forms;

namespace Trivia_Frontend_AvivRoss
{
    partial class Statistics
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
            TXTstats = new Label();
            button1 = new Button();
            TBLpersStats = new TableLayoutPanel();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            TBLhighScores = new TableLayoutPanel();
            label7 = new Label();
            BTNrefresh = new Button();
            TBLpersStats.SuspendLayout();
            SuspendLayout();
            // 
            // TXTstats
            // 
            TXTstats.AutoSize = true;
            TXTstats.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TXTstats.ForeColor = Color.CadetBlue;
            TXTstats.ImageAlign = ContentAlignment.MiddleRight;
            TXTstats.Location = new Point(288, 27);
            TXTstats.Name = "TXTstats";
            TXTstats.Size = new Size(119, 37);
            TXTstats.TabIndex = 0;
            TXTstats.Text = "Statistics";
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Location = new Point(725, -2);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // TBLpersStats
            // 
            TBLpersStats.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TBLpersStats.ColumnCount = 2;
            TBLpersStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            TBLpersStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            TBLpersStats.Controls.Add(label3, 0, 2);
            TBLpersStats.Controls.Add(label1, 0, 0);
            TBLpersStats.Controls.Add(label2, 0, 1);
            TBLpersStats.Controls.Add(label4, 0, 3);
            TBLpersStats.Controls.Add(label5, 0, 4);
            TBLpersStats.ForeColor = Color.CadetBlue;
            TBLpersStats.Location = new Point(12, 108);
            TBLpersStats.Name = "TBLpersStats";
            TBLpersStats.Padding = new Padding(1);
            TBLpersStats.RowCount = 5;
            TBLpersStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLpersStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLpersStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLpersStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLpersStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLpersStats.Size = new Size(172, 266);
            TBLpersStats.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(5, 106);
            label3.Name = "label3";
            label3.Size = new Size(40, 24);
            label3.TabIndex = 3;
            label3.Text = "Total Answers";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Size = new Size(43, 36);
            label1.TabIndex = 3;
            label1.Text = "Average Answer Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(5, 54);
            label2.Name = "label2";
            label2.Size = new Size(40, 24);
            label2.TabIndex = 4;
            label2.Text = "Correct Answers";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(5, 158);
            label4.Name = "label4";
            label4.Size = new Size(35, 24);
            label4.TabIndex = 5;
            label4.Text = "Total Games";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(5, 210);
            label5.Name = "label5";
            label5.Size = new Size(29, 24);
            label5.TabIndex = 6;
            label5.Text = "Total Score";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Underline, GraphicsUnit.Point);
            label6.Location = new Point(50, 79);
            label6.Name = "label6";
            label6.Size = new Size(89, 17);
            label6.TabIndex = 3;
            label6.Text = "Personal stats";
            // 
            // TBLhighScores
            // 
            TBLhighScores.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TBLhighScores.ColumnCount = 2;
            TBLhighScores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            TBLhighScores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            TBLhighScores.ForeColor = Color.CadetBlue;
            TBLhighScores.Location = new Point(311, 108);
            TBLhighScores.Name = "TBLhighScores";
            TBLhighScores.Padding = new Padding(1);
            TBLhighScores.RowCount = 5;
            TBLhighScores.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLhighScores.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLhighScores.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLhighScores.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLhighScores.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TBLhighScores.Size = new Size(460, 266);
            TBLhighScores.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Underline, GraphicsUnit.Point);
            label7.Location = new Point(506, 79);
            label7.Name = "label7";
            label7.Size = new Size(84, 17);
            label7.TabIndex = 5;
            label7.Text = "Top 5 Scores";
            // 
            // BTNrefresh
            // 
            BTNrefresh.BackColor = SystemColors.ActiveCaption;
            BTNrefresh.FlatAppearance.BorderSize = 0;
            BTNrefresh.FlatStyle = FlatStyle.Flat;
            BTNrefresh.Location = new Point(209, 108);
            BTNrefresh.Name = "BTNrefresh";
            BTNrefresh.Size = new Size(75, 23);
            BTNrefresh.TabIndex = 6;
            BTNrefresh.Text = "Refresh";
            BTNrefresh.UseVisualStyleBackColor = false;
            BTNrefresh.Click += button2_Click;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTNrefresh);
            Controls.Add(label7);
            Controls.Add(TBLhighScores);
            Controls.Add(label6);
            Controls.Add(TBLpersStats);
            Controls.Add(button1);
            Controls.Add(TXTstats);
            Name = "Statistics";
            Text = "Statistics";
            FormClosed += Statistics_FormClosed;
            TBLpersStats.ResumeLayout(false);
            TBLpersStats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TXTstats;
        private Button button1;
        private TableLayoutPanel TBLpersStats;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TableLayoutPanel TBLhighScores;
        private Label label7;
        private Button BTNrefresh;
    }
}