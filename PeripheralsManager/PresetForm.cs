using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PeripheralsManager;

public partial class PresetForm : Form
{
    public string ProfileName { get; private set; } = "";
    public int MouseSpeed { get; private set; } = 10;
    //TODO: check this for mouse speed: https://liquipedia.net/counterstrike/Mouse_Settings#Windows_Sensitivity
    private AudioControl _audioControl;

    public PresetForm()
    {
        InitializeComponent();


        // find the devices
        //bruh
        string[] audioDevices = AudioControl.GetSoundDevices();
        foreach (string device in audioDevices)
        {
            AudioDevices_ListBox.Items.Add(device);
        }

        //var captureDevices = AudioControl.GetCaptureDevices();
        //foreach(AudioControl.DirectSoundDeviceInfo device in captureDevices)
        //{
        //    AudioDevices_ListBox.Items.Add(device.Description);
        //    MessageBox.Show($"{device.Guid}, {device.Module}, {device.Description}");
        //}
        //TODO: maybe I should add microphones too? hmmm...

        // maybe this way, huge block of code, but uses registry instead of external libs https://stackoverflow.com/a/50518590/12741390

        // Get current mouse sensitivity
        try
        {
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey("Control Panel\\Mouse")) //TODO: might have to save this to use it in the future for saving sens, idk
            {
                if (key != null)
                {
                    object? o = key.GetValue("MouseSensitivity");
                    if (o != null)
                    {
                        MouseSensitivity_TrackBar.Value = Convert.ToInt32(o.ToString());
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw; //TODO: ngl not sure what to do here
        }

        // Get current volume
        _audioControl = new AudioControl(this.Handle);

        // ?mby https://superuser.com/questions/1644356/how-to-get-system-volume-levelaudio-in-windows
        // → http://www.nirsoft.net/utils/sound_volume_view.html#command_line - spawnout proces teto aplikace a tahat z toho data

        // mozna https://blog.sverrirs.com/2016/02/windows-coreaudio-api-in-c.html ?

        //idek, tohle je nejake cpp https://learn.microsoft.com/en-us/windows/win32/coreaudio/audio-endpoint-devices
    }

    private void Mouse_CB_CheckedChanged(object sender, EventArgs e) => Mouse_Group.Enabled = Mouse_CB.Checked;

    private void Audio_CB_CheckedChanged(object sender, EventArgs e) => Audio_Group.Enabled = Audio_CB.Checked;

    private void Name_TB_TextChanged(object sender, EventArgs e) => ProfileName = Name_TB.Text;

    private void Save_Btn_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void Cancel_Btn_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void Delete_Btn_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Abort; //not the most correct choice of code, but it's the best there exists
    }

    private void Volume_TrackBar_Scroll(object sender, EventArgs e)
    {
        if (Volume_UpDown.Value != Volume_TrackBar.Value)
            Volume_UpDown.Value = Volume_TrackBar.Value;
        //TODO: this could (and prolly will) lead to cycling these two calls to infinity. Should prolly set a flag to not call the event or some shit
    }

    private void Volume_UpDown_ValueChanged(object sender, EventArgs e)
    {
        if (Volume_TrackBar.Value != Volume_UpDown.Value)
            Volume_TrackBar.Value = (int)Volume_UpDown.Value;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _audioControl.VolumeDown_Messages();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _audioControl.VolumeUp_Messages();
    }

    private void button3_Click(object sender, EventArgs e)
    {
       _audioControl.ToggleMute_Messages();
    }
}
