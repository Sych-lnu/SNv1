namespace SNv1Forms
{
    partial class Form2
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
            this.PostsList = new System.Windows.Forms.ListBox();
            this.PostContentField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PostButton = new System.Windows.Forms.Button();
            this.Return = new System.Windows.Forms.Button();
            this.LikeButton = new System.Windows.Forms.Button();
            this.UsersListOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PostsList
            // 
            this.PostsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PostsList.FormattingEnabled = true;
            this.PostsList.HorizontalScrollbar = true;
            this.PostsList.ItemHeight = 16;
            this.PostsList.Location = new System.Drawing.Point(12, 12);
            this.PostsList.Name = "PostsList";
            this.PostsList.Size = new System.Drawing.Size(317, 548);
            this.PostsList.TabIndex = 0;
            this.PostsList.SelectedIndexChanged += new System.EventHandler(this.PostsList_SelectedIndexChanged);
            // 
            // PostContentField
            // 
            this.PostContentField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PostContentField.Location = new System.Drawing.Point(662, 79);
            this.PostContentField.Name = "PostContentField";
            this.PostContentField.Size = new System.Drawing.Size(405, 23);
            this.PostContentField.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(729, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Create new post!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PostButton
            // 
            this.PostButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PostButton.Location = new System.Drawing.Point(733, 136);
            this.PostButton.Name = "PostButton";
            this.PostButton.Size = new System.Drawing.Size(156, 62);
            this.PostButton.TabIndex = 3;
            this.PostButton.Text = "Post Now";
            this.PostButton.UseVisualStyleBackColor = true;
            this.PostButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // Return
            // 
            this.Return.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Return.Location = new System.Drawing.Point(733, 481);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(156, 64);
            this.Return.TabIndex = 4;
            this.Return.Text = "Return";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // LikeButton
            // 
            this.LikeButton.Enabled = false;
            this.LikeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LikeButton.Location = new System.Drawing.Point(733, 221);
            this.LikeButton.Name = "LikeButton";
            this.LikeButton.Size = new System.Drawing.Size(156, 55);
            this.LikeButton.TabIndex = 5;
            this.LikeButton.Text = "Like";
            this.LikeButton.UseVisualStyleBackColor = true;
            this.LikeButton.Click += new System.EventHandler(this.LikeButton_Click);
            // 
            // UsersListOpen
            // 
            this.UsersListOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersListOpen.Location = new System.Drawing.Point(505, 481);
            this.UsersListOpen.Name = "UsersListOpen";
            this.UsersListOpen.Size = new System.Drawing.Size(156, 64);
            this.UsersListOpen.TabIndex = 6;
            this.UsersListOpen.Text = "Users";
            this.UsersListOpen.UseVisualStyleBackColor = true;
            this.UsersListOpen.Click += new System.EventHandler(this.UsersListOpen_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 631);
            this.Controls.Add(this.UsersListOpen);
            this.Controls.Add(this.LikeButton);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.PostButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PostContentField);
            this.Controls.Add(this.PostsList);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PostsList;
        private System.Windows.Forms.TextBox PostContentField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PostButton;
        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.Button LikeButton;
        private System.Windows.Forms.Button UsersListOpen;
    }
}