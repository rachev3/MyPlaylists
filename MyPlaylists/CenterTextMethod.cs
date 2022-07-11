using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylists
{
    internal class CenterTextMethod
    {
        public static void CenterText(string text, int height, int rows = 0)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, (Console.WindowHeight - height) / 2 + rows);
        }
    }
}
