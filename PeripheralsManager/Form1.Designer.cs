namespace PeripheralsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            NotifyIcon = new NotifyIcon(components);
            Menu = new ContextMenuStrip(components);
            Profiles_TSMItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            AddProfile_TSMItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            Quit_TSMItem = new ToolStripMenuItem();
            Menu.SuspendLayout();
            SuspendLayout();
            // 
            // NotifyIcon
            // 
            NotifyIcon.Icon = (Icon)resources.GetObject("NotifyIcon.Icon");
            NotifyIcon.Text = "PeripheralsManager";
            NotifyIcon.Visible = true;
            // 
            // Menu
            // 
            Menu.ImageScalingSize = new Size(20, 20);
            Menu.Items.AddRange(new ToolStripItem[] { Profiles_TSMItem, toolStripSeparator1, Quit_TSMItem });
            Menu.Name = "contextMenuStrip1";
            Menu.Size = new Size(128, 58);
            // 
            // Profiles_TSMItem
            // 
            Profiles_TSMItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator2, AddProfile_TSMItem });
            Profiles_TSMItem.Name = "Profiles_TSMItem";
            Profiles_TSMItem.Size = new Size(127, 24);
            Profiles_TSMItem.Text = "Profiles";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(165, 6);
            // 
            // AddProfile_TSMItem
            // 
            AddProfile_TSMItem.Name = "AddProfile_TSMItem";
            AddProfile_TSMItem.Size = new Size(168, 26);
            AddProfile_TSMItem.Text = "Add profile";
            AddProfile_TSMItem.Click += AddProfile_TSMItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(124, 6);
            // 
            // Quit_TSMItem
            // 
            Quit_TSMItem.Name = "Quit_TSMItem";
            Quit_TSMItem.Size = new Size(127, 24);
            Quit_TSMItem.Text = "Quit";
            Quit_TSMItem.Click += Quit_TSMItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Name = "Form1";
            Text = "Form1";
            Shown += Form1_Shown;
            Menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon NotifyIcon;
        private ContextMenuStrip Menu;
        private ToolStripMenuItem Profiles_TSMItem;
        private ToolStripMenuItem Quit_TSMItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem AddProfile_TSMItem;
    }
}