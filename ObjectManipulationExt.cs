using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VObject
{
	public static class ObjectManipulationExt
	{

		public static object? Append(this object source, params object[] values)
		{
			object? res=default;
			if(source is Enum enumValue)
			{
				Type type=Enum.GetUnderlyingType(enumValue.GetType());
				if(type==typeof(int))
				{
					var tmp=Convert.ToInt32(enumValue);
					foreach(var sel in (Enum[])values)
						tmp|=Convert.ToInt32(sel);
					res=Convert.ChangeType(res, type);
				}
				else if(type==typeof(long))
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
				foreach(var sel in values)
					res+=sel;
			}
			return res;
		}

	}
}
