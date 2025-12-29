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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;


namespace ThemeMii
{
    public partial class ThemeMii_ckInput : Window
    {
        public string Input { get; set; }

        public ThemeMii_ckInput()
        {
            InitializeComponent();
        }


        private void ThemeMii_ckInput_Load(object? sender, RoutedEventArgs e)
        {
            BoxInput.Focus();
        }

        private void btnCancel_Click(object? sender, RoutedEventArgs e)
        {
            Close(null);
        }

        private void btnOK_Click(object? sender, RoutedEventArgs e)
        {
            Input = BoxInput.Text ?? "";
            if (Input != "45e")
            {
                BoxInput.SelectAll();
                return;
            }

            Close(Input);
        }
        
    }
}
