using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace PeripheralsManager;

internal class AudioControl
{
    //bruh, nejspis budu muset pouzit tu knihovnu
    // https://stackoverflow.com/a/75578979/12741390 (tohle je na nalezeni devices, umi to i audio control)
    // NAudio

    // tak me napada
    // lepsi asi bude odkazovat na takove to divne id tech zarizeni, ne jejich jmeno. Takove to s dvema parama {0000-0-0-0--000}.{alksdjflaksjflkasjdlfkj}




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

    #region detecting audio devices
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


}
