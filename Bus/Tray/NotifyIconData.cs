using System;
using System.Runtime.InteropServices;

namespace Bus.Tray
{
    [StructLayout(LayoutKind.Sequential)]
    struct GUID
    {
        public int a;
        public short b;
        public short c;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] d;
    }
    struct NOTIFYICONDATA
    {
        /// <summary>
        /// Size of this structure, in bytes. 
        /// </summary>
        public int cbSize;

        /// <summary>
        /// Handle to the window that receives notification messages associated with an icon in the 
        /// taskbar status area. The Shell uses hWnd and uID to identify which icon to operate on 
        /// when Shell_NotifyIcon is invoked. 
        /// </summary>
        public IntPtr hwnd;

        /// <summary>
        /// Application-defined identifier of the taskbar icon. The Shell uses hWnd and uID to identify 
        /// which icon to operate on when Shell_NotifyIcon is invoked. You can have multiple icons 
        /// associated with a single hWnd by assigning each a different uID. 
        /// </summary>
        public int uID;

        /// <summary>
        /// Flags that indicate which of the other members contain valid data. This member can be 
        /// a combination of the NIF_XXX constants.
        /// </summary>
        public int uFlags;

        /// <summary>
        /// Application-defined message identifier. The system uses this identifier to send 
        /// notifications to the window identified in hWnd. 
        /// </summary>
        public int uCallbackMessage;

        /// <summary>
        /// Handle to the icon to be added, modified, or deleted. 
        /// </summary>
        public IntPtr hIcon;

        /// <summary>
        /// String with the text for a standard ToolTip. It can have a maximum of 64 characters including 
        /// the terminating NULL. For Version 5.0 and later, szTip can have a maximum of 
        /// 128 characters, including the terminating NULL.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szTip;

        /// <summary>
        /// State of the icon. 
        /// </summary>
        public int dwState;

        /// <summary>
        /// A value that specifies which bits of the state member are retrieved or modified. 
        /// For example, setting this member to NIS_HIDDEN causes only the item's hidden state to be retrieved. 
        /// </summary>
        public int dwStateMask;

        /// <summary>
        /// String with the text for a balloon ToolTip. It can have a maximum of 255 characters. 
        /// To remove the ToolTip, set the NIF_INFO flag in uFlags and set szInfo to an empty string. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szInfo;

        /// <summary>
        /// NOTE: This field is also used for the Timeout value. Specifies whether the Shell notify 
        /// icon interface should use Windows 95 or Windows 2000 
        /// behavior. For more information on the differences in these two behaviors, see 
        /// Shell_NotifyIcon. This member is only employed when using Shell_NotifyIcon to send an 
        /// NIM_VERSION message. 
        /// </summary>
        public int uVersion;

        /// <summary>
        /// String containing a title for a balloon ToolTip. This title appears in boldface 
        /// above the text. It can have a maximum of 63 characters. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szInfoTitle;

        /// <summary>
        /// Adds an icon to a balloon ToolTip. It is placed to the left of the title. If the 
        /// szTitleInfo member is zero-length, the icon is not shown. See 
        /// <see cref="BalloonIconStyle">RMUtils.WinAPI.Structs.BalloonIconStyle</see> for more
        /// information.
        /// </summary>
        public int dwInfoFlags;

        public GUID guidItem;

        public IntPtr hBalloonIcon;
    }
}
