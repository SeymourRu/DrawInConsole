using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

//Thanks to
//https://stackoverflow.com/questions/33538527/display-a-image-in-a-console-application

namespace ConsoleDrawingLib
{
    public class PictureWriter
    {
        public static void DrawAPicture(string picturePath,int x,int y, int width, int heigth)
        {
            var location = new Point(x, y);
            var imageSize = new Size(width, heigth); // desired image size in characters
            if (System.IO.File.Exists(picturePath))
            {
                using (Graphics g = Graphics.FromHwnd(WinAPIImports.GetConsoleWindow()))
                {
                    using (Image image = Image.FromFile(picturePath))
                    {
                        var fontSize = GetConsoleFontSize();

                        // translating the character positions to pixels
                        var imageRect = new Rectangle(
                            location.X * fontSize.Width,
                            location.Y * fontSize.Height,
                            imageSize.Width * fontSize.Width,
                            imageSize.Height * fontSize.Height);
                        g.DrawImage(image, imageRect);
                    }
                }
            }
            else
            {
                Console.WriteLine("No picture existing on path : " + picturePath);
            }
        }

        private static Size GetConsoleFontSize()
        {
            // getting the console out buffer handle
            IntPtr outHandle = WinAPIImports.CreateFile("CONOUT$", WinAPIImports.GENERIC_READ | WinAPIImports.GENERIC_WRITE,
                WinAPIImports.FILE_SHARE_READ | WinAPIImports.FILE_SHARE_WRITE,
                IntPtr.Zero,
                WinAPIImports.OPEN_EXISTING,
                0,
                IntPtr.Zero);
            int errorCode = Marshal.GetLastWin32Error();
            if (outHandle.ToInt32() == WinAPIImports.INVALID_HANDLE_VALUE)
            {
                throw new IOException("Unable to open CONOUT$", errorCode);
            }

            var cfi = new WinAPIImports.ConsoleFontInfo();
            if (!WinAPIImports.GetCurrentConsoleFont(outHandle, false, cfi))
            {
                throw new InvalidOperationException("Unable to get font information.");
            }

            return new Size(cfi.dwFontSize.X, cfi.dwFontSize.Y);
        }
    }
}