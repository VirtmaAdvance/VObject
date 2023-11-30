using System.Reflection;

namespace VObject
{
	/// <summary>
	/// Provides information extension methods for the <see cref="MemberInfo"/> class.
	/// </summary>
	public static class MemberInfoExt
	{
		/// <summary>
		/// Gets the <see cref="string"/> representation of the access modifier for the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="MemberInfo"/> to analyze.</param>
		/// <returns>a <see cref="string"/> representation of the result.</returns>
		public static string GetAccessModifier(this MemberInfo value)
		{
			//var flags=value.GetInfo();
			//return flags.HasFlag(MemberInfoFlags.Public);
			switch(value.MemberType)
			{
				case MemberTypes.Field:
					return ((FieldInfo)value).IsPublic ? "public" : ((FieldInfo)value).IsPrivate ? "private" : ((FieldInfo)value).IsFamilyOrAssembly ? "internal" : "protected";
				case MemberTypes.Method:
					return ((MethodInfo)value).IsPublic ? "public" : ((MethodInfo)value).IsPrivate ? "private" : ((MethodInfo)value).IsFamilyOrAssembly ? "internal" : "protected";
				case MemberTypes.Constructor:
					return ((ConstructorInfo)value).IsPublic ? "public" : ((ConstructorInfo)value).IsPrivate ? "private" : ((ConstructorInfo)value).IsFamilyOrAssembly ? "internal" : "protected";
				case MemberTypes.TypeInfo:
					return ((TypeInfo)value).IsPublic ? "public" : ((TypeInfo)value).IsNotPublic ? "private" : "UNKNOWN";
			}
			return "UNKNOWN";
		}

		/// <summary>
		/// Gets the configurations of the <paramref name="value"/> and generates a <see cref="MemberInfoFlags"/> object consisting of the configurations for the member.
		/// </summary>
		/// <param name="value">The <see cref="MemberInfo"/> object to analyze.</param>
		/// <returns>a <see cref="MemberInfoFlags"/> enum representing the configurations of the <paramref name="value"/>.</returns>
		public static MemberInfoFlags GetInfo(this MemberInfo value)
		{
			MemberInfoFlags res=default;
			switch(value.MemberType)
			{
				case MemberTypes.TypeInfo:
					res|=MemberInfoFlags.TypeInfo; break;
				case MemberTypes.Field:
					res|=MemberInfoFlags.Field; break;
				case MemberTypes.Method:
					res|=MemberInfoFlags.Method; break;
				case MemberTypes.Constructor:
					res|=MemberInfoFlags.Constructor; break;
				case MemberTypes.Property:
					res|=MemberInfoFlags.Property; break;
				case MemberTypes.Event:
					res|=MemberInfoFlags.IsEvent; break;
				case MemberTypes.NestedType:
					res|=MemberInfoFlags.IsNestedType; break;
				case MemberTypes.Custom:
					res|=MemberInfoFlags.IsCustom; break;
			}
			if(res.HasFlag(MemberInfoFlags.Field))
			{
				var tmp=(FieldInfo)value;
				if(tmp.IsPublic)
					res|=MemberInfoFlags.Public;
				if(tmp.IsPrivate)
					res|=MemberInfoFlags.Private;
				if(tmp.IsAssembly)
					res|=MemberInfoFlags.Internal;
				if(tmp.IsFamily)
					res|=MemberInfoFlags.Protected;
				if(tmp.IsInitOnly)
					res|=MemberInfoFlags.ReadOnly;
				if(tmp.IsLiteral)
					res|=MemberInfoFlags.IsConstant;
				if(tmp.IsStatic)
					res|=MemberInfoFlags.Static;
			}
			else if(res.HasFlag(MemberInfoFlags.Method))
			{
				var tmp=(MethodInfo)value;
				if(tmp.IsPublic)
					res|=MemberInfoFlags.Public;
				if(tmp.IsPrivate)
					res|=MemberInfoFlags.Private;
				if(tmp.IsAssembly)
					res|=MemberInfoFlags.Internal;
				if(tmp.IsFamily)
					res|=MemberInfoFlags.Protected;
				if(tmp.IsVirtual)
					res|=MemberInfoFlags.Virtual;
				if(tmp.IsFinal)
					res|=MemberInfoFlags.IsConstant;
				if(tmp.IsStatic)
					res|=MemberInfoFlags.Static;
				if(tmp.ReturnType==null)
					res|=MemberInfoFlags.Void;
				if(tmp.GetParameters().Length>0)
					res|=MemberInfoFlags.AcceptsParameters;
			}
			else if(res.HasFlag(MemberInfoFlags.Constructor))
			{
				var tmp=(ConstructorInfo)value;
				if(tmp.IsPublic)
					res|=MemberInfoFlags.Public;
				if(tmp.IsPrivate)
					res|=MemberInfoFlags.Private;
				if(tmp.IsAssembly)
					res|=MemberInfoFlags.Internal;
				if(tmp.IsFamily)
					res|=MemberInfoFlags.Protected;
				if(tmp.IsVirtual)
					res|=MemberInfoFlags.Virtual;
				if(tmp.IsFinal)
					res|=MemberInfoFlags.IsConstant;
				if(tmp.IsStatic)
					res|=MemberInfoFlags.Static;
				res|=MemberInfoFlags.Void;
				if(tmp.GetParameters().Length>0)
					res|=MemberInfoFlags.AcceptsParameters;
			}
			else if(res.HasFlag(MemberInfoFlags.TypeInfo))
			{
				var tmp=(TypeInfo)value;
				if(tmp.IsPublic)
					res|=MemberInfoFlags.Public;
				if(tmp.IsNotPublic)
					res|=MemberInfoFlags.Private;
			}

			return res;
		}

	}
}
