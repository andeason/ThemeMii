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
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ThemeMii
{
    public partial class ThemeMii_Help : Window
    {
        public bool Tutorial { get; set; }

        public ThemeMii_Help()
        {
            InitializeComponent();
        }

        //TODO:  This is pretty broken without richtext.  Look into a way to resolve?
        private void ThemeMii_Help_Load(object sender, RoutedEventArgs e)
        {
            
            string rtfInfo = "See help online";
            try
            {
                rtfInfo = Tutorial
                    ? File.ReadAllText("../../../Resources/HealthTut.rtf")
                    : File.ReadAllText("../../../Resources/ThemeMiiBasics.rtf");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                Console.Error.WriteLine("Unable to dislay, so falling back.");
            }
            
            HelpInfo.Text = rtfInfo;
                
        }
    }
}