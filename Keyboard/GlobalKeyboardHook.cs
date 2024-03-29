﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows;
using System.Reflection.Metadata;
using System.Windows.Interop;
using SimpleTimers;


public class KeyboardBinding
{
    public string? ModifierKey { get; set; }
    public string Key { get; set; }
    public bool PassThrough { get; set; }
    public Action Callback { get; set; }
}

public class GlobalKeyboardHook
{
    public static List<KeyboardBinding> _keyboardBindings { get; set; }

    // Windows API constants and structures
    public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private static LowLevelKeyboardProc _proc;
    private static IntPtr _hookID = IntPtr.Zero;

    private const int VK_SHIFT = 0x10;
    private const int VK_CONTROL = 0x11;
    private const int VK_MENU = 0x12;
    public const int K_0 = 0x30;
    public const int K_1 = 0x31;
    public const int K_2 = 0x32;
    public const int K_3 = 0x33;
    public const int K_4 = 0x34;
    public const int K_5 = 0x35;
    public const int K_6 = 0x36;
    public const int K_7 = 0x37;
    public const int K_8 = 0x38;
    public const int K_9 = 0x39;
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
    private static Dictionary<int, string> KeyLookup = new Dictionary<int, string>
    {
        { K_0, "0" },
        { K_1, "1" },
        { K_2, "2" },
        { K_3, "3" },
        { K_4, "4" },
        { K_5, "5" },
        { K_6, "6" },
        { K_7, "7" },
        { K_8, "8" },
        { K_9, "9" },
        { VK_A, "a" },
        { VK_B, "b" },
        { VK_C, "c" },
        { VK_D, "d" },
        { VK_E, "e" },
        { VK_F, "f" },
        { VK_G, "g" },
        { VK_H, "h" },
        { VK_I, "i" },
        { VK_J, "j" },
        { VK_K, "k" },
        { VK_L, "l" },
        { VK_M, "m" },
        { VK_N, "n" },
        { VK_O, "o" },
        { VK_P, "p" },
        { VK_Q, "q" },
        { VK_R, "r" },
        { VK_S, "s" },
        { VK_T, "t" },
        { VK_U, "u" },
        { VK_V, "v" },
        { VK_W, "w" },
        { VK_X, "x" },
        { VK_Y, "y" },
        { VK_Z, "z" },
    };

    // Setting up the hook
    public static void SetHook(List<KeyboardBinding> keyboardBindings)
    {
        _proc = HookCallback;
        _keyboardBindings = keyboardBindings;
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(curModule.ModuleName), 0);
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
            bool controlPressed = (GetKeyState(VK_CONTROL) & 0x8000) != 0;
            bool shiftPressed = (GetKeyState(VK_SHIFT) & 0x8000) != 0;
            bool altPressed = (GetKeyState(VK_MENU) & 0x8000) != 0;

           foreach (var binding in _keyboardBindings)
            {
                //Debug.Print("---");
                //Debug.Print("Binding: " + binding.ModifierKey + "+" + binding.Key);
                bool modPressed =
                    (controlPressed && binding.ModifierKey == "control") ||
                    (shiftPressed && binding.ModifierKey == "shift") ||
                    (altPressed && binding.ModifierKey == "alt") ||
                    (!controlPressed && !shiftPressed && !altPressed && binding.ModifierKey == null);

                //if (KeyLookup.ContainsKey(vkCode))
                //{
                //    Debug.Print("Checking key event, modPressed: " + modPressed + ", altPressed: " + altPressed + " key: " + KeyLookup[vkCode]);
                //}

                if (modPressed && KeyLookup.ContainsKey(vkCode) && KeyLookup[vkCode] == binding.Key)
                {
                    binding.Callback();
                    handled = !binding.PassThrough;
                }
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