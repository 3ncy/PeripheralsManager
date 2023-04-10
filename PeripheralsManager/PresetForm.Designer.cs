namespace PeripheralsManager
{
    partial class PresetForm
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
            Audio_Group = new GroupBox();
            Volume_UpDown = new NumericUpDown();
            label4 = new Label();
            AudioDevices_ListBox = new ListBox();
            Volume_TrackBar = new TrackBar();
            Mouse_Group = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            MouseDevices_ListBox = new ListBox();
            label1 = new Label();
            MouseSensitivity_TrackBar = new TrackBar();
            Audio_CB = new CheckBox();
            Mouse_CB = new CheckBox();
            Save_Btn = new Button();
            Cancel_Btn = new Button();
            Delete_Btn = new Button();
            Name_TB = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            Audio_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Volume_UpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Volume_TrackBar).BeginInit();
            Mouse_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MouseSensitivity_TrackBar).BeginInit();
            SuspendLayout();
            // 
            // Audio_Group
            // 
            Audio_Group.Controls.Add(button1);
            Audio_Group.Controls.Add(button2);
            Audio_Group.Controls.Add(button3);
            Audio_Group.Controls.Add(Volume_UpDown);
            Audio_Group.Controls.Add(label4);
            Audio_Group.Controls.Add(AudioDevices_ListBox);
            Audio_Group.Controls.Add(Volume_TrackBar);
            Audio_Group.Location = new Point(422, 155);
            Audio_Group.Margin = new Padding(3, 4, 3, 4);
            Audio_Group.Name = "Audio_Group";
            Audio_Group.Padding = new Padding(3, 4, 3, 4);
            Audio_Group.Size = new Size(323, 435);
            Audio_Group.TabIndex = 16;
            Audio_Group.TabStop = false;
            // 
            // Volume_UpDown
            // 
            Volume_UpDown.Location = new Point(256, 367);
            Volume_UpDown.Margin = new Padding(3, 4, 3, 4);
            Volume_UpDown.Name = "Volume_UpDown";
            Volume_UpDown.Size = new Size(43, 27);
            Volume_UpDown.TabIndex = 18;
            Volume_UpDown.ValueChanged += Volume_UpDown_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 313);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 19;
            label4.Text = "Volume";
            // 
            // AudioDevices_ListBox
            // 
            AudioDevices_ListBox.FormattingEnabled = true;
            AudioDevices_ListBox.ItemHeight = 20;
            AudioDevices_ListBox.Location = new Point(42, 47);
            AudioDevices_ListBox.Margin = new Padding(3, 4, 3, 4);
            AudioDevices_ListBox.Name = "AudioDevices_ListBox";
            AudioDevices_ListBox.Size = new Size(244, 244);
            AudioDevices_ListBox.TabIndex = 1;
            // 
            // Volume_TrackBar
            // 
            Volume_TrackBar.LargeChange = 10;
            Volume_TrackBar.Location = new Point(42, 353);
            Volume_TrackBar.Margin = new Padding(3, 4, 3, 4);
            Volume_TrackBar.Maximum = 100;
            Volume_TrackBar.Name = "Volume_TrackBar";
            Volume_TrackBar.Size = new Size(207, 56);
            Volume_TrackBar.TabIndex = 17;
            Volume_TrackBar.Scroll += Volume_TrackBar_Scroll;
            // 
            // Mouse_Group
            // 
            Mouse_Group.Controls.Add(label3);
            Mouse_Group.Controls.Add(label2);
            Mouse_Group.Controls.Add(MouseDevices_ListBox);
            Mouse_Group.Controls.Add(label1);
            Mouse_Group.Controls.Add(MouseSensitivity_TrackBar);
            Mouse_Group.Location = new Point(23, 155);
            Mouse_Group.Margin = new Padding(3, 4, 3, 4);
            Mouse_Group.Name = "Mouse_Group";
            Mouse_Group.Padding = new Padding(3, 4, 3, 4);
            Mouse_Group.Size = new Size(363, 435);
            Mouse_Group.TabIndex = 15;
            Mouse_Group.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 313);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 20;
            label3.Text = "Pointer speed:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(299, 353);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 19;
            label2.Text = "Fast";
            // 
            // MouseDevices_ListBox
            // 
            MouseDevices_ListBox.FormattingEnabled = true;
            MouseDevices_ListBox.ItemHeight = 20;
            MouseDevices_ListBox.Location = new Point(27, 47);
            MouseDevices_ListBox.Margin = new Padding(3, 4, 3, 4);
            MouseDevices_ListBox.Name = "MouseDevices_ListBox";
            MouseDevices_ListBox.Size = new Size(297, 244);
            MouseDevices_ListBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 353);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 18;
            label1.Text = "Slow";
            // 
            // MouseSensitivity_TrackBar
            // 
            MouseSensitivity_TrackBar.LargeChange = 1;
            MouseSensitivity_TrackBar.Location = new Point(59, 337);
            MouseSensitivity_TrackBar.Margin = new Padding(3, 4, 3, 4);
            MouseSensitivity_TrackBar.Maximum = 20;
            MouseSensitivity_TrackBar.Minimum = 1;
            MouseSensitivity_TrackBar.Name = "MouseSensitivity_TrackBar";
            MouseSensitivity_TrackBar.Size = new Size(233, 56);
            MouseSensitivity_TrackBar.TabIndex = 17;
            MouseSensitivity_TrackBar.Value = 2;
            // 
            // Audio_CB
            // 
            Audio_CB.AutoSize = true;
            Audio_CB.Checked = true;
            Audio_CB.CheckState = CheckState.Checked;
            Audio_CB.Location = new Point(422, 121);
            Audio_CB.Margin = new Padding(3, 4, 3, 4);
            Audio_CB.Name = "Audio_CB";
            Audio_CB.Size = new Size(185, 24);
            Audio_CB.TabIndex = 14;
            Audio_CB.Text = "Enable Volume settings";
            Audio_CB.UseVisualStyleBackColor = true;
            Audio_CB.CheckedChanged += Audio_CB_CheckedChanged;
            // 
            // Mouse_CB
            // 
            Mouse_CB.AutoSize = true;
            Mouse_CB.Checked = true;
            Mouse_CB.CheckState = CheckState.Checked;
            Mouse_CB.Location = new Point(33, 121);
            Mouse_CB.Margin = new Padding(3, 4, 3, 4);
            Mouse_CB.Name = "Mouse_CB";
            Mouse_CB.Size = new Size(179, 24);
            Mouse_CB.TabIndex = 13;
            Mouse_CB.Text = "Enable Mouse settings";
            Mouse_CB.UseVisualStyleBackColor = true;
            Mouse_CB.CheckedChanged += Mouse_CB_CheckedChanged;
            // 
            // Save_Btn
            // 
            Save_Btn.Location = new Point(623, 44);
            Save_Btn.Margin = new Padding(3, 4, 3, 4);
            Save_Btn.Name = "Save_Btn";
            Save_Btn.Size = new Size(86, 31);
            Save_Btn.TabIndex = 12;
            Save_Btn.Text = "Save";
            Save_Btn.UseVisualStyleBackColor = true;
            Save_Btn.Click += Save_Btn_Click;
            // 
            // Cancel_Btn
            // 
            Cancel_Btn.Location = new Point(511, 45);
            Cancel_Btn.Margin = new Padding(3, 4, 3, 4);
            Cancel_Btn.Name = "Cancel_Btn";
            Cancel_Btn.Size = new Size(86, 31);
            Cancel_Btn.TabIndex = 11;
            Cancel_Btn.Text = "Cancel";
            Cancel_Btn.UseVisualStyleBackColor = true;
            Cancel_Btn.Click += Cancel_Btn_Click;
            // 
            // Delete_Btn
            // 
            Delete_Btn.Location = new Point(389, 45);
            Delete_Btn.Margin = new Padding(3, 4, 3, 4);
            Delete_Btn.Name = "Delete_Btn";
            Delete_Btn.Size = new Size(86, 31);
            Delete_Btn.TabIndex = 10;
            Delete_Btn.Text = "Delete";
            Delete_Btn.UseVisualStyleBackColor = true;
            Delete_Btn.Click += Delete_Btn_Click;
            // 
            // Name_TB
            // 
            Name_TB.Location = new Point(33, 45);
            Name_TB.Margin = new Padding(3, 4, 3, 4);
            Name_TB.Name = "Name_TB";
            Name_TB.Size = new Size(300, 27);
            Name_TB.TabIndex = 9;
            Name_TB.TextChanged += Name_TB_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(0, 260);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 2;
            button1.Text = "down";
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(124, 260);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 1;
            button2.Text = "up";
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(231, 260);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 0;
            button3.Text = "mute toggle";
            button3.Click += button3_Click;
            // 
            // PresetForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 645);
            Controls.Add(Audio_Group);
            Controls.Add(Mouse_Group);
            Controls.Add(Audio_CB);
            Controls.Add(Mouse_CB);
            Controls.Add(Save_Btn);
            Controls.Add(Cancel_Btn);
            Controls.Add(Delete_Btn);
            Controls.Add(Name_TB);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PresetForm";
            Text = "PresetForm";
            Audio_Group.ResumeLayout(false);
            Audio_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Volume_UpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Volume_TrackBar).EndInit();
            Mouse_Group.ResumeLayout(false);
            Mouse_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MouseSensitivity_TrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox Audio_Group;
        private GroupBox Mouse_Group;
        private CheckBox Audio_CB;
        private CheckBox Mouse_CB;
        private Button Save_Btn;
        private Button Cancel_Btn;
        private Button Delete_Btn;
        private TextBox Name_TB;
        private ListBox MouseDevices_ListBox;
        private ListBox AudioDevices_ListBox;
        private TrackBar MouseSensitivity_TrackBar;
        private Label label1;
        private Label label2;
        private Label label3;
        private TrackBar Volume_TrackBar;
        private NumericUpDown Volume_UpDown;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}