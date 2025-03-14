﻿using VAdvanceObject.Numbers;

namespace VAdvanceObject
{
	/// <summary>
	/// Provides object manipulation extension methods.
	/// </summary>
	public static class ObjectManipulationExt
	{
		/// <summary>
		/// Converts an object into a <see cref="VObject"/>.
		/// </summary>
		/// <param name="value">The <see cref="object"/> to convert.></param>
		/// <returns>the <see cref="VObject"/> representation of the <paramref name="value"/>.</returns>
		public static VObject ToVObject(this object? value) => new (value);
		/// <summary>
		/// Appends the parameters to the object.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static object? Append(this object source, params object[] values)
		{
			object? res=default;
			if(source is Enum enumValue)
			{
				Type type=enumValue.GetUnderlyingType();
				if(type.Is(typeof(int)))
				{
					var tmp=Convert.ToInt32(enumValue);
					foreach(var sel in (Enum[])values)
						tmp|=Convert.ToInt32(sel);
					res=Convert.ChangeType(res, type);
				}
				else if(type.Is(typeof(long)))
				{
					var tmp=Convert.ToInt64(enumValue);
					foreach(var sel in (Enum[])values)
						tmp|=Convert.ToInt64(sel);
					res=Convert.ChangeType(res, type);
				}
			}
			else if(source is string stringValue)
			{
				foreach(var sel in (string[])values)
					stringValue+=sel;
				res=stringValue;
			}
			else if(source is char charValue)
			{
				string tmp=charValue.ToString();
				foreach(var sel in values.Select(v => (char)v))
					tmp+=sel;
			}
			else if(source.IsNumber())
			{
				VNumber tmp=new();
				foreach(var sel in values)
					tmp+=new VNumber(sel);
				res=tmp;
			}
			return res;
		}

	}
}
