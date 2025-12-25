/* This file is part of ThemeMii
 * Copyright (C) 2009 Leathl
 * 
 * ThemeMii is free software: you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ThemeMii is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
 
using System;
//using System.Windows.Forms;
using System.IO;

namespace ThemeMii
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //TODO:  What is ash.exe?  I don't like that this is just an exe...
            if (!File.Exists("ash.exe"))
            {
                //TODO:  Perhaps change to be an actual message?
                Console.Error.WriteLine("ASH.exe couldn't be found in the application directory...");
                Environment.Exit(-1);
            }

            //TODO:  The package reference should now include this.  I believe this makes this unneeded.
            if (!File.Exists("ICSharpCode.SharpZipLib.dll"))
            {
                Console.Error.WriteLine(
                    "\"ICSharpCode.SharpZipLib.dll couldn't be found in the application directory...\", \"Error\"");
                Environment.Exit(-1);
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ThemeMii_Main());
        }
    }
}
