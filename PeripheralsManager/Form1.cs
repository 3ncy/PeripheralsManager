namespace PeripheralsManager;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        NotifyIcon.ContextMenuStrip = Menu;
    }

    private void Quit_TSMItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void AddProfile_TSMItem_Click(object sender, EventArgs e)
    {
        PresetForm presetForm = new PresetForm();
        presetForm.Show();
        presetForm.FormClosed += PresetForm_FormClosed;
        //TODO: handle result from preset Form. PRolly by subscribing to it's closing method and then checking its DialogResult

        ToolStripMenuItem profileItem = new()
        {
            Text = "Profile1"
        };
        profileItem.Click += Profile_TSMItem_Click;

        ToolStripMenuItem editProfileItem = new()
        {
            Text = "Edit"
        };
        editProfileItem.Click += (object? sender, EventArgs e) =>
        {
            PresetForm presetForm = new PresetForm();
            presetForm.Show();
            //TODO: handle result from preset Form. PRolly by subscribing to it's closing method and then checking its DialogResult
            //TODO: this is suspicously the same code in two places.... hmmm....
        };

        profileItem.DropDown.Items.Add(editProfileItem);


        Profiles_TSMItem.DropDown.Items.Insert(0, profileItem);
    }

    private void PresetForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        PresetForm presetForm = (sender as PresetForm)!; // we go yolo, I still haven't found a source why sender can be null

        if (presetForm.DialogResult == DialogResult.Cancel)
            return;

        if (presetForm.DialogResult == DialogResult.Abort) // means "delete"
        {

        }

        if (presetForm.DialogResult == DialogResult.OK) // process and save stuff
        {
            /*
             * Check if the user was editing or creating a new profile:
             *  editing:
             *      Edit the tray icon menu profile name
             *      
             *      
             *  creating:
             *      Add the profile into the tray icon menu
             *          Add an "edit" option to the menu
             *              Register the Click event
             *      Send data to API
             *      
             *      
             */
             
        }
    }

    private void Profile_TSMItem_Click(object? sender, EventArgs e)
    {
        ToolStripMenuItem item = (ToolStripMenuItem)sender;

        //TODO: logic for switching profiles
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
        // setting up the icon in notification tray
        this.Visible = false;
        //this.WindowState = FormWindowState.Minimized;
        this.Hide();
        //this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        this.ShowInTaskbar = false;
        //TODO: if all doesn't work, try this to hide the form "completely"     form.Location = new Point(-10000, -10000);
    }
}