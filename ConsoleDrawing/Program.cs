using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ConsoleDrawing
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ConsoleDrawingLib.PictureWriter.DrawAPicture("result.jpg", 0, 0, 30, 20);
            System.Threading.Thread.Sleep(10000);

            //OpenFileDialog od = new OpenFileDialog();
            //if (od.ShowDialog() == DialogResult.OK)
            //{
            //    ConsoleDrawingLib.PictureWriter.DrawAPicture(od.FileName, 0, 30, 20, 30);
            //}
            //Console.
            //Console.ReadLine();
        }
    }
}