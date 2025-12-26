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
using Avalonia;

namespace ThemeMii
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //TODO:  What is ash.exe?  I don't like that this is just an exe...
            //We 
            if (!File.Exists("ash.exe"))
            {
                //TODO:  Perhaps change to be an actual message?
                Console.Error.WriteLine("ASH.exe couldn't be found in the application directory...");
                //For now, we will keep running anyways.
                //Environment.Exit(-1);
            }
            
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            return
                AppBuilder.Configure<App>()
                    .LogToTrace()
                    .UsePlatformDetect();
        }
    }
}
