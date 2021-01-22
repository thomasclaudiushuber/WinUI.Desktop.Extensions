using System;
using System;
using System.Runtime.InteropServices;

using WinRT;

using Microsoft.UI.Xaml;
using Windows.ApplicationModel;

namespace WinUI.Desktop.Extensions
{
  public static class WindowExtensions
  {
    public static void SetWidth(this Window window, int width)
    {
      var hwnd = window.GetWindowHandle();
      var dpiScaledWidth = (int)(width * window.GetDpiScalingFactor());

      if (PInvoke.User32.GetWindowRect(hwnd, out PInvoke.RECT rect))
      {
        SetWindowPositionAndSize(hwnd, rect.left, rect.top, dpiScaledWidth, rect.bottom - rect.top);
      }
    }

    public static void SetHeight(this Window window, int height)
    {
      var hwnd = window.GetWindowHandle();
      var dpiScaledHeight = (int)(height * window.GetDpiScalingFactor());

      if (PInvoke.User32.GetWindowRect(hwnd, out PInvoke.RECT rect))
      {
        SetWindowPositionAndSize(hwnd, rect.left, rect.top, rect.right - rect.left, dpiScaledHeight);
      }
    }

    //public static void CenterOnScreen(this Window window)
    //{
    //  var hwnd = window.GetWindowHandle();
    //  var monitorHwnd = PInvoke.User32.MonitorFromWindow(hwnd, PInvoke.User32.MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
    //  if (PInvoke.User32.GetMonitorInfo(monitorHwnd,out PInvoke.User32.MONITORINFO monitorInfo))
    //  {
    //    if (PInvoke.User32.GetWindowRect(hwnd, out PInvoke.RECT windowRect))
    //    {
    //      var monitorRect = monitorInfo.rcMonitor;
    //      var monitorWidth = monitorRect.right - monitorRect.left;
    //      var monitorHeight = monitorRect.bottom - monitorRect.top;
    //      var windowWidth = windowRect.right - windowRect.left;
    //      var windowHeight = windowRect.bottom - windowRect.top;

    //      var horizontalSpace = monitorWidth - windowWidth;
    //      var verticalSpace = monitorHeight - windowHeight;

    //      SetWindowPositionAndSize(hwnd, horizontalSpace / 2, verticalSpace / 2, windowWidth, windowHeight);
    //    }
    //  }
    //}

    public static IntPtr GetWindowHandle(this Window window)
    {
      var windowNative = window.As<IWindowNative>();
      return windowNative.WindowHandle;
    }

    private static void SetWindowPositionAndSize(IntPtr hwnd, int x, int y, int width, int height)
    {
      PInvoke.User32.SetWindowPos(hwnd, PInvoke.User32.SpecialWindowHandles.HWND_TOP,
                                 x, y, width, height, PInvoke.User32.SetWindowPosFlags.SWP_SHOWWINDOW);
    }

    private static float GetDpiScalingFactor(this Window window)
    {
      var dpi = PInvoke.User32.GetDpiForWindow(window.GetWindowHandle());
      return (float)dpi / 96;
    }
  }
}
