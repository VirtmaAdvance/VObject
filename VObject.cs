using System.Collections;

namespace VObject
{
	/// <summary>
	/// An advanced <see cref="object"/> class.
	/// </summary>
	public class VObject : object
	{
		/// <summary>
		/// The value to store.
		/// </summary>
		public object Value { get; set; }
		/// <summary>
		/// Indicates whether the value is <see langword="null"/>.
		/// </summary>
		public bool IsNull => Value is null;
		/// <summary>
		/// Indicates whether the value is not <see langword="null"/>.
		/// </summary>
		public bool NotNull => Value is not null;
		/// <summary>
		/// Indicates whether the value is a COMObject.
		/// </summary>
		public bool IsComObject => NotNull && System.Runtime.InteropServices.Marshal.IsComObject(Value);
		/// <summary>
		/// Gets the <see cref="Type"/> object.
		/// </summary>
		public Type? DataType => (!IsComObject) ? Value?.GetType() : null;


		/// <summary>
		/// Creates a new instance of the <see cref="VObject"/> class.
		/// </summary>
		/// <param name="value">Any value.</param>
		public VObject(object value)
		{
			Value=value;
		}
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(string value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(char value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(byte value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(short value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(ushort value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(int value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(uint value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(long value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(ulong value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(decimal value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(float value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(double value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Reflection.MemberInfo value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Array value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(bool value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(DateTime value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Enum value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(TimeSpan value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Drawing.Color value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Net.NetworkInformation.NetworkInterface value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Net.IPAddress value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Net.NetworkInformation.PhysicalAddress value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Drawing.Point value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Exception value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(MarshalByRefObject value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(EventArgs value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Attribute value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.IO.FileSystemInfo value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Reflection.Pointer value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Task value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Thread value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Version value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Barrier value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(BinaryReader value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(BinaryWriter value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(BitArray value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(CollectionBase value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Comparer value) => new(value);


		public string ToString() => GetStringRepresentation(Value);

		public static string GetStringRepresentation(object value, bool addQuotes=false)
		{
			if(value is null)
				return "null";
			if(System.Runtime.InteropServices.Marshal.IsComObject(value))
				return "COMObject";
			if(value is string strVal)
				return addQuotes ? "\""+strVal+"\"" : strVal;
			if(value is Exception valueAsException)
				return valueAsException.Source + ": " + valueAsException.Message + "\r\n" + valueAsException.StackTrace;
			if(value is char charVal)
				return addQuotes ? "'" + charVal.ToString() + "'" : charVal.ToString();
			if(value is bool boolVal)
				return boolVal ? "true" : "false";
			if(value is byte byteValue)
				return byteValue.ToString("X2");
			if(value.IsNumber())
				return value.ToString()!;
			if(value is DateTime dtVal)
				return dtVal.ToString("MM-dd-yyyy | hh:mm:ss:fffffff tt");
			if(value is IDictionary dictVal)
				return GetStringFromCollection(dictVal);
			if(value is IEnumerable enumerableVal)
				return GetStringFromCollection(enumerableVal);
			return value.ToString()!;
		}

		private static string GetStringFromClass(object classObject)
		{
			Type type=classObject.GetType();
			System.Reflection.MemberInfo[] l=type.GetMembers();
			string res="class " + classObject.ToString() + "{";
			foreach(var sel in l)
				res+="\n\t"+
		}

		private static string Serialize(System.Reflection.MemberInfo value)
		{

		}
		/// <summary>
		/// Gets the access modifier of the member.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string GetAccessModifier(System.Reflection.MemberInfo value)
		{
			switch(value.MemberType)
			{
				case System.Reflection.MemberTypes.Field:
					return ((System.Reflection.FieldInfo)value).IsPublic ? "public" : ((System.Reflection.FieldInfo)value).IsPrivate ? "private" : ((System.Reflection.FieldInfo)value).IsFamilyOrAssembly ? "internal" : "protected";
				case System.Reflection.MemberTypes.Method:
					return ((System.Reflection.MethodInfo)value).IsPublic ? "public" : ((System.Reflection.MethodInfo)value).IsPrivate ? "private" : ((System.Reflection.MethodInfo)value).IsFamilyOrAssembly ? "internal" : "protected";
				case System.Reflection.MemberTypes.Constructor:
					return ((System.Reflection.ConstructorInfo)value).IsPublic ? "public" : ((System.Reflection.ConstructorInfo)value).IsPrivate ? "private" : ((System.Reflection.ConstructorInfo)value).IsFamilyOrAssembly ? "internal" : "protected";
				case System.Reflection.MemberTypes.TypeInfo:
					return ((System.Reflection.TypeInfo)value).IsPublic ? "public" : ((System.Reflection.TypeInfo)value).IsNotPublic ? "private" : "UNKNOWN";
			}
			return "UNKNOWN";
		}

		/// <inheritdoc cref="GetStringFromCollection(IDictionary)"/>
		private static string GetStringFromCollection(IEnumerable source)
		{
			string res="";
			foreach(var sel in source)
				res+=(res.Length>0 ? "," : "") + GetStringRepresentation(sel, true);
			return "["+res+"]";
		}
		/// <summary>
		/// Generates a JSON <see cref="string"/> representation of the collection.
		/// </summary>
		/// <param name="source">The collection to serialize.</param>
		/// <returns>a <see cref="string"/> representation of the collection.</returns>
		private static string GetStringFromCollection(IDictionary source)
		{
			string res="";
			foreach(var sel in source.Keys)
				res+=(res.Length>0 ? "," : "") + GetStringRepresentation(sel, true) + ":" + GetStringRepresentation(source[sel]!, true);
			return "{"+res+"}";
		}


	}
}