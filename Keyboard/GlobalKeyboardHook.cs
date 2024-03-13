using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows;
using System.Reflection.Metadata;
using System.Windows.Interop;
using SimpleTimers;

public class GlobalKeyboardHook
{
    // Windows API constants and structures
    public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private static LowLevelKeyboardProc _proc;
    private static IntPtr _hookID = IntPtr.Zero;
    private const int VK_CONTROL = 0x11; // Virtual-Key code for the Control key
    private const int VK_A = 0x41;
    private const int VK_B = 0x42;
    private const int VK_C = 0x43;
    private const int VK_D = 0x44;
    private const int VK_E = 0x45;
    private const int VK_F = 0x46;
    private const int VK_G = 0x47;
    private const int VK_H = 0x48;
    private const int VK_I = 0x49;
    private const int VK_J = 0x4A;
    private const int VK_K = 0x4B;
    private const int VK_L = 0x4C;
    private const int VK_M = 0x4D;
    private const int VK_N = 0x4E;
    private const int VK_O = 0x4F;
    private const int VK_P = 0x50;
    private const int VK_Q = 0x51;
    private const int VK_R = 0x52;
    private const int VK_S = 0x53;
    private const int VK_T = 0x54;
    private const int VK_U = 0x55;
    private const int VK_V = 0x56;
    private const int VK_W = 0x57;
    private const int VK_X = 0x58;
    private const int VK_Y = 0x59;
    private const int VK_Z = 0x5A;

    // Setting up the hook
    public static void SetHook()
    {
        _proc = HookCallback;
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc,
                GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    // Removing the hook
    public static void ReleaseHook()
    {
        UnhookWindowsHookEx(_hookID);
    }

    // The callback function that is called by the hook
    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        bool handled = false;
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            bool controlPressed = (GetKeyState(VK_CONTROL) & 0x8000) != 0; // Check if Control key is down

            if (controlPressed && vkCode == VK_E)
            {
                // Assuming you have a static reference to your main window
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    mainWindow?.StartTimer1(); // Call method to start the timer
                });
                handled = true;
            }
            else if (controlPressed && vkCode == VK_R)
            {
                // Assuming you have a static reference to your main window
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    mainWindow?.StartTimer2(); // Call method to start the timer
                });
                handled = true;
            }
        }
        // If handled, return a non-zero value; otherwise, call the next hook
        return handled ? (IntPtr)1 : CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    // P/Invoke declarations
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll")]
    private static extern short GetKeyState(int nVirtKey);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
}