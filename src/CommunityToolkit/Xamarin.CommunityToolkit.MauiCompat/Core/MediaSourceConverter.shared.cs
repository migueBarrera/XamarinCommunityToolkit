﻿using System;
using Microsoft.Maui; using Microsoft.Maui.Controls; using Microsoft.Maui.Graphics; using Microsoft.Maui.Controls.Compatibility;

namespace Xamarin.CommunityToolkit.Core
{
	public sealed class MediaSourceConverter : System.ComponentModel.TypeConverter
	{
		public override object? ConvertFrom(System.ComponentModel.ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object value)
		{
			if (value == null)
				throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(MediaSource)}");

			return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme != "file"
				? MediaSource.FromUri(uri)
				: MediaSource.FromFile(value);
		}
	}
}