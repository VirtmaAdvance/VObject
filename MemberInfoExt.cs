using System.Reflection;

namespace VAdvanceObject
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

		private static MemberInfoFlags PrependMemberType(this MemberInfo value)
		{
			switch (value.MemberType)
			{
				case MemberTypes.TypeInfo:
					return MemberInfoFlags.TypeInfo;
				case MemberTypes.Field:
					return MemberInfoFlags.Field;
				case MemberTypes.Method:
					return MemberInfoFlags.Method;
				case MemberTypes.Constructor:
					return MemberInfoFlags.Constructor;
				case MemberTypes.Property:
					return MemberInfoFlags.Property;
				case MemberTypes.Event:
					return MemberInfoFlags.IsEvent;
				case MemberTypes.NestedType:
					return MemberInfoFlags.IsNestedType;
				case MemberTypes.Custom:
					return MemberInfoFlags.IsCustom;
				default:
					return MemberInfoFlags.Unknown;
			}
		}

		private static MemberInfoFlags GetFieldInfoFlags(this MemberInfo value, MemberInfoFlags res)
		{
			var tmp = (FieldInfo)value;
			if (tmp.IsPublic)
				res |= MemberInfoFlags.Public;
			if (tmp.IsPrivate)
				res |= MemberInfoFlags.Private;
			if (tmp.IsAssembly)
				res |= MemberInfoFlags.Internal;
			if (tmp.IsFamily)
				res |= MemberInfoFlags.Protected;
			if (tmp.IsInitOnly)
				res |= MemberInfoFlags.ReadOnly;
			if (tmp.IsLiteral)
				res |= MemberInfoFlags.IsConstant;
			if (tmp.IsStatic)
				res |= MemberInfoFlags.Static;
			return res;
		}

		private static MemberInfoFlags GetMethodInfoFlags(this MemberInfo value, MemberInfoFlags res)
		{
			var tmp = (MethodInfo)value;
			if (tmp.IsPublic)
				res |= MemberInfoFlags.Public;
			if (tmp.IsPrivate)
				res |= MemberInfoFlags.Private;
			if (tmp.IsAssembly)
				res |= MemberInfoFlags.Internal;
			if (tmp.IsFamily)
				res |= MemberInfoFlags.Protected;
			if (tmp.IsVirtual)
				res |= MemberInfoFlags.Virtual;
			if (tmp.IsFinal)
				res |= MemberInfoFlags.IsConstant;
			if (tmp.IsStatic)
				res |= MemberInfoFlags.Static;
			if (tmp.ReturnType == null)
				res |= MemberInfoFlags.Void;
			if (tmp.GetParameters().Length > 0)
				res |= MemberInfoFlags.AcceptsParameters;
			return res;
		}

		private static MemberInfoFlags GetConstructorFlags(this MemberInfo value, MemberInfoFlags res)
		{
			var tmp = (ConstructorInfo)value;
			if (tmp.IsPublic)
				res |= MemberInfoFlags.Public;
			if (tmp.IsPrivate)
				res |= MemberInfoFlags.Private;
			if (tmp.IsAssembly)
				res |= MemberInfoFlags.Internal;
			if (tmp.IsFamily)
				res |= MemberInfoFlags.Protected;
			if (tmp.IsVirtual)
				res |= MemberInfoFlags.Virtual;
			if (tmp.IsFinal)
				res |= MemberInfoFlags.IsConstant;
			if (tmp.IsStatic)
				res |= MemberInfoFlags.Static;
			res |= MemberInfoFlags.Void;
			if (tmp.GetParameters().Length > 0)
				res |= MemberInfoFlags.AcceptsParameters;
			return res;
		}

		private static MemberInfoFlags GetTypeInfoFlags(this MemberInfo value, MemberInfoFlags res)
		{
			var tmp = (TypeInfo)value;
			if (tmp.IsPublic)
				res |= MemberInfoFlags.Public;
			if (tmp.IsNotPublic)
				res |= MemberInfoFlags.Private;
			return res;
		}
		/// <summary>
		/// Gets the configurations of the <paramref name="value"/> and generates a <see cref="MemberInfoFlags"/> object consisting of the configurations for the member.
		/// </summary>
		/// <param name="value">The <see cref="MemberInfo"/> object to analyze.</param>
		/// <returns>a <see cref="MemberInfoFlags"/> enum representing the configurations of the <paramref name="value"/>.</returns>
		public static MemberInfoFlags GetInfo(this MemberInfo value)
		{
			MemberInfoFlags res = PrependMemberType(value);
			if(res.HasFlag(MemberInfoFlags.Field))
				return GetFieldInfoFlags(value, res);
			else if(res.HasFlag(MemberInfoFlags.Method))
				return GetMethodInfoFlags(value, res);
			else if(res.HasFlag(MemberInfoFlags.Constructor))
				return GetConstructorFlags(value, res);
			else if(res.HasFlag(MemberInfoFlags.TypeInfo))
				return GetTypeInfoFlags(value, res);
			return res;
		}

	}
}