namespace PeripheralsManager;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        NotifyIcon.ContextMenuStrip = Menu;

        // setting up the icon in notification tray
        this.WindowState = FormWindowState.Minimized;
        this.Hide();
        this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        this.ShowInTaskbar = false;
    }

    private void Quit_TSMItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void AddProfile_TSMItem_Click(object sender, EventArgs e)
    {
        PresetForm presetForm = new PresetForm();
        presetForm.Show();
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

    private void Profile_TSMItem_Click(object? sender, EventArgs e)
    {
        ToolStripMenuItem item = (ToolStripMenuItem)sender;

        //TODO: logic for switching profiles
    }


}