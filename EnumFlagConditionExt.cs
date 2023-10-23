using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VObject
{
	public static class EnumFlagConditionExt
	{

		public static TOut? ForAll<TIn, TOut>(this TIn source, Func<TIn, TIn, TOut> predicate, params TIn[] values) where TIn : Enum
		{
			TOut? res=default;
			foreach(var sel in values)
			{
				res.Append(predicate(source, sel));
			}
		}

	}
}
