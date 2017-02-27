using System;
using System.Drawing;
using System.Runtime.InteropServices;


namespace Core
{
    public class WindowsApi
    {
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        /// <summary>
        /// 根据鼠标位置坐标,
        /// 获取指定点的窗口的句柄,
        /// 忽略屏蔽、隐藏以及透明窗口.
        /// </summary>
        /// <param name="pt">鼠标坐标</param>
        /// <returns>windows窗体应用程序句柄</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point pt);

        /// <summary>
        /// 在窗口列表中寻找与指定条件相符的第一个子窗口
        /// </summary>
        /// <param name="hWndParent"></param>
        /// <param name="hWndChildAfter"></param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// 获得整个窗口的范围矩形，窗口的边框、标题栏、滚动条及菜单等都在这个矩形内
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref Rect rect);

        /// <summary>
        /// 判断屏幕上一个指定点的客户区坐标
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="lpPt"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, out Point lpPt);

        /// <summary>
        /// 获取整个窗口（包括边框、滚动条、标题栏、菜单等）的设备场景
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>
        /// 通过应用一个指定的偏移，从而让矩形移动起来
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool OffsetRect(ref Rect rect, int dx, int dy);

        /// <summary>
        /// 在当前选定的刷子的基础上，用一个图案填充指定的设备场景
        /// </summary>
        /// <param name="hdc">欲描绘的一个设备场景的句柄</param>
        /// <param name="nXLeft">对目标DC中目标矩形左上角位置进行定义的x坐标，用逻辑坐标表示</param>
        /// <param name="nYLeft">对目标DC中目标矩形左上角位置进行定义的y坐标，用逻辑坐标表示</param>
        /// <param name="nWidth">目标矩形的宽度，用逻辑坐标表示</param>
        /// <param name="nHeight">目标矩形的高度，用逻辑坐标表示</param>
        /// <param name="dwRop">传输过程中欲进行的光栅运算。对一个源进行引用的光栅运算也许不能在这个函数中使用</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, int dwRop);


        /// <summary>
        /// 调用一个窗口的窗口函数,将一条消息发给那个窗口.
        /// 除非消息处理完毕,否则该函数不会返回.
        /// SendMessageBynum,SendMessageByString是该函数的“类型安全”声明形式
        /// </summary>
        /// <param name="hwnd">要接收消息的那个窗口的句柄</param>
        /// <param name="msg">消息的标识符</param>
        /// <param name="wParam">具体取决于消息</param>
        /// <param name="lParam">具体取决于消息</param>
        /// <returns>由具体的消息决定</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hwnd, uint msg, int wParam, int lParam);
    }
}
