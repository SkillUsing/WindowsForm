using System;
using Core;

namespace Tools
{
    public class ApiTools
    {
        /// <summary>
        /// 根据句柄得到的整个窗体,画一个矩形框架
        /// </summary>
        /// <param name="hwnd">对应的窗体句柄</param>
        public static void DrawRectFrame(IntPtr hwnd)
        {
            if (hwnd == IntPtr.Zero)
                return;
            var windowDc = WindowsApi.GetWindowDC(hwnd);
            var rect = default(WindowsApi.Rect);
            WindowsApi.GetWindowRect(hwnd, ref rect);
            WindowsApi.OffsetRect(ref rect, -rect.Left, -rect.Top);
            WindowsApi.PatBlt(windowDc, rect.Left, rect.Top, rect.Right - rect.Left, 3, 5570569);
            WindowsApi.PatBlt(windowDc, rect.Left, rect.Bottom - 3, 3, -(rect.Bottom - rect.Top - 6), 5570569);
            WindowsApi.PatBlt(windowDc, rect.Right - 3, rect.Top + 3, 3, rect.Bottom - rect.Top - 6, 5570569);
            WindowsApi.PatBlt(windowDc, rect.Right, rect.Bottom - 3, -(rect.Right - rect.Left), 3, 5570569);
        }
    }
}
