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


    public PresetForm()
    {
        InitializeComponent();


        // find the devices
        var devices = AudioControl.GetDevices();
        for (int i = 0; i < devices.Count; i++)
        {
            AudioControl.AudioDevice device = devices[i];

            switch (device.State)
            {
                case NAudio.CoreAudioApi.DeviceState.Active:
                    AudioDevices_ListBox.Items.Add(device.Name);
                    break;
                case NAudio.CoreAudioApi.DeviceState.Disabled:
                    AudioDevices_ListBox.Items.Add("[Disbl'd] " + device.Name);
                    break;
                case NAudio.CoreAudioApi.DeviceState.Unplugged:
                    AudioDevices_ListBox.Items.Add("[Unplug'd] " + device.Name);
                    break;
            }
        }





        // ========== Get current mouse sensitivity
        //TODO: move to separate class?
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




        // ==========  Get current volume

        int masterVolume = (int)(AudioControl.GetVolumeNaudio() * 100);
        Volume_TrackBar.Value = masterVolume;
        Volume_UpDown.Value = masterVolume;




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
        AudioControl.SetVolume(int.Parse(Volume_UpDown.Value.ToString())); //TODO: mby call this on every volume change?
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {

    }
}
