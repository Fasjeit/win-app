﻿/*
MIT License

Copyright (c) 2022 Proton Technologies AG
Copyright (c) 2010 Bevan Arps

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;

namespace ProtonVPN.Core.Wpf.Markdown
{
    public class TextToFlowDocumentConverter : DependencyObject, IValueConverter
    {
        private readonly Thickness PagePadding = new(20,20,40,40);

        public Markdown Markdown
        {
            get => (Markdown)GetValue(MarkdownProperty);
            set => SetValue(MarkdownProperty, value);
        }

        // Using a DependencyProperty as the backing store for Markdown. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MarkdownProperty =
            DependencyProperty.Register("Markdown", typeof(Markdown), typeof(TextToFlowDocumentConverter), new PropertyMetadata(null));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }

            string text = (string)value;
            Markdown engine = Markdown ?? _mMarkdown.Value;
            FlowDocument document = engine.Transform(text);
            document.PagePadding = PagePadding;
            return document;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private readonly Lazy<Markdown> _mMarkdown = new Lazy<Markdown>(() => new Markdown());
    }
}
