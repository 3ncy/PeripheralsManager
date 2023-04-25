using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using NAudio.CoreAudioApi;

namespace PeripheralsManager;

internal class AudioControl
{
    //bruh, nejspis budu muset pouzit tu knihovnu
    // https://stackoverflow.com/a/75578979/12741390 (tohle je na nalezeni devices, umi to i audio control)
    // NAudio

    // tak me napada
    // lepsi asi bude odkazovat na takove to divne id tech zarizeni, ne jejich jmeno. Takove to s dvema parama {0000-0-0-0--000}.{alksdjflaksjflkasjdlfkj}

    #region NAudio 
    public static float GetVolumeNaudio()
    {
        MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        return device.AudioEndpointVolume.MasterVolumeLevelScalar;
    }

    //
    //  What properties do I need about a device:
    //      Name - display it to the user
    //      ID  - identify the device, more devices can share a name
    //      attribute - volume/sens
    //      
    //  What to display
    //      Name
    //      change color when disabled/unplugged
    //

    public record struct AudioDevice
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public float Volume { get; set; }
        public NAudio.CoreAudioApi.DeviceState State { get; set; }
    }

    public static List<AudioDevice> GetDevices()
    {
        List<AudioDevice> devices = new();
        MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        MMDeviceCollection MMDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active | DeviceState.Disabled | DeviceState.Unplugged); //get all devices, but "NotPresent"

        foreach (MMDevice device in MMDevices)
        {
            string deviceName = "";
            for (int i = 0; i < device.Properties.Count; i++)
            {
                if (device.Properties[i].Key.propertyId != 14) continue;
                deviceName = device.Properties[i].Value.ToString() ?? "Unnamed device"; //idk, it was shouting at me that it can b null
            }

            devices.Add(new AudioDevice()
            {
                Name = deviceName,
                Id = Guid.Parse(device.ID.Split("}.")[1]), //TODO: keep an eye on this, maybe all device IDs don't follow the same format? Can't really test it tho
                Volume = device.AudioEndpointVolume.MasterVolumeLevelScalar,
                State = device.State
            });

        }

        return devices;
    }

    public static void SetVolume(int volume)
    {
        volume = Math.Clamp(volume, 0, 100);
        MMDeviceEnumerator enumerator = new MMDeviceEnumerator(); //TODO: maybe I should store this?
        MMDevice defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volume / 100f;
    }

    
    #endregion


    #region VolumeUp/Down, method with SendMessage()
    // source https://stackoverflow.com/a/57373074/12741390
    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    const int WM_APPCOMMAND = 0x319;
    const int APPCOMMAND_VOLUME_MUTE = 0x80000;
    const int APPCOMMAND_VOLUME_DOWN = 0x90000;
    const int APPCOMMAND_VOLUME_UP = 0xA0000;
    readonly IntPtr _handle;

    public AudioControl(IntPtr handle)
    {
        _handle = handle;
    }

    public void VolumeUp_Messages()
    //TODO: not ideal, only works in increments of 2???!
    {
        SendMessage(_handle, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_VOLUME_UP);
    }

    public void VolumeDown_Messages()
    {
        SendMessage(_handle, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_VOLUME_DOWN);
    }

    public void ToggleMute_Messages()
    {
        SendMessage(_handle, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_VOLUME_MUTE);
    }
    #endregion

    #region detecting audio capture devices
    //TODO: decide and move to a separate file from this one 
    [DllImport("winmm.dll", SetLastError = true)] static extern uint waveOutGetNumDevs();
    [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)] public static extern uint waveOutGetDevCaps(uint hwo, ref WAVEOUTCAPS pwoc, uint cbwoc);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WAVEOUTCAPS
    {
        public ushort wMid;
        public ushort wPid;
        public uint vDriverVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string szPname; //TODO: ziskat cela jmena z registruy podle https://stackoverflow.com/a/17467009/12741390 //note: WAVEOUTCAPS pry vraci guid, podle toho by to slo jednoduseji hledat, nez podle jmena
        public uint dwFormats;
        public ushort wChannels;
        public ushort wReserved1;
        public uint dwSupport;
    }

    public static string[] GetSoundDevices()
    {
        uint devices = waveOutGetNumDevs();
        string[] result = new string[devices];
        WAVEOUTCAPS caps = new WAVEOUTCAPS();

        for (uint i = 0; i < devices; i++)
        {
            waveOutGetDevCaps(i, ref caps, (uint)Marshal.SizeOf(caps));
            result[i] = caps.szPname;
        }
        return result;
    }

    // ----
    [DllImport("dsound.dll", CharSet = CharSet.Ansi)] static extern void DirectSoundCaptureEnumerate(DSEnumCallback callback, IntPtr context);

    delegate bool DSEnumCallback([MarshalAs(UnmanagedType.LPStruct)] Guid guid, string description, string module, IntPtr lpContext);

    static bool EnumCallback(Guid guid, string description, string module, IntPtr context)
    {
        if (guid != Guid.Empty)
            captureDevices.Add(new DirectSoundDeviceInfo(guid, description, module));
        return true;
    }
    private static List<DirectSoundDeviceInfo> captureDevices;

    public static IEnumerable<DirectSoundDeviceInfo> GetCaptureDevices()
    {
        captureDevices = new List<DirectSoundDeviceInfo>();
        DirectSoundCaptureEnumerate(new DSEnumCallback(EnumCallback), IntPtr.Zero);
        return captureDevices;
    }

    public class DirectSoundDeviceInfo
    {
        public DirectSoundDeviceInfo(Guid guid, string description, string module)
        { Guid = guid; Description = description; Module = module; }
        public Guid Guid { get; }
        public string Description { get; }
        public string Module { get; }
    }
    #endregion

    #region another try on detecting devices and getting IDs

    public List<string> GetMouseId()
    {
        List<string> res = new();
        var mbs = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
        ManagementObjectCollection mbsList = mbs.Get();
        foreach (ManagementObject mo in mbsList)
        {




        }

        return res;
    }

    #endregion

}
