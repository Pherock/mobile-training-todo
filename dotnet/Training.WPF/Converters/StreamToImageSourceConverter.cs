﻿//
// StreamToImageSourceConverter.cs
//
// Author:
// 	Jim Borden  <jim.borden@couchbase.com>
//
// Copyright (c) 2016 Couchbase, Inc All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Training.WPF
{
    /// <summary>
    /// A converter to convert a streaminto an ImageSource for Xamarin Forms
    /// </summary>
    public class StreamToImageSourceConverter : IValueConverter
    {

        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(targetType != typeof(ImageSource)) {
                throw new NotSupportedException();
            }

            var source = value as Stream;
            if(source == null || source == Stream.Null) {
                return null;
            }

            var bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = source;
            bi.EndInit();
            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion

    }
}


