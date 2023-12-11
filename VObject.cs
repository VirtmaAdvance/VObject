using System.Collections;

namespace VObject
{
	/// <summary>
	/// An advanced <see cref="object"/> class.
	/// </summary>
	public class VObject : object, IEquatable<VObject>, IComparable<VObject>, IDisposable, ICloneable, IConvertible, IFormattable
	{
		/// <summary>
		/// The value to store.
		/// </summary>
		protected object? Value { get; set; }
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
		public bool IsComObject => NotNull && Value!.IsComObject();
		/// <summary>
		/// Gets the <see cref="Type"/> object.
		/// </summary>
		public Type? DataType => !IsComObject ? Value?.GetType() : null;


		/// <summary>
		/// Creates a new instance of the <see cref="VObject"/> class.
		/// </summary>
		/// <param name="value">Any value.</param>
		public VObject(object? value) => Value=value;
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(string value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(char value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(sbyte value) => new(value);
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
		public static implicit operator VObject(FileSystemInfo value) => new(value);
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
		/// <summary>
		/// Gets the <see cref="string"/> representation of this object.
		/// </summary>
		/// <returns></returns>
		public new string ToString() => GetStringRepresentation(Value);
		/// <summary>
		/// Gets the <see cref="string"/> representation of an object.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="addQuotes"></param>
		/// <returns></returns>
		public static string GetStringRepresentation(object? value, bool addQuotes=false)
		{
			if(System.Runtime.InteropServices.Marshal.IsComObject(value))
				return "COMObject";
			string result=value switch
			{
				null => "null",
				string strVal => strVal,
				Exception valueAsException => $"{valueAsException.Source}: {valueAsException.Message}\r\n{valueAsException.StackTrace}",
				char charVal => charVal.ToString(),
				bool boolVal => boolVal.ToString().ToLower(),
				byte byteValue => byteValue.ToString("X2"),
				_ when value.IsNumber() => value.ToString()!,
				DateTime dtVal => dtVal.ToString("MM-dd-yyyy | hh:mm:ss:fffffff tt"),
				IDictionary dictVal => GetStringFromCollection(dictVal),
				IEnumerable enumerableVal => GetStringFromCollection(enumerableVal),
				_ => value.ToString()!
			};
			return result;
		}
		/// <summary>
		/// Gets the string from the class object.
		/// </summary>
		/// <param name="classObject"></param>
		/// <returns></returns>
		private static string GetStringFromClass(object classObject)
		{
			Type type=classObject.GetType();
			System.Reflection.MemberInfo[] l=type.GetMembers();
			string res="class " + classObject.ToString() + "{";
			foreach(var sel in l)
				res+="\n\t"+Serialize(sel);
			return res;
		}
		/// <summary>
		/// Serializes an object.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string Serialize(System.Reflection.MemberInfo value)
		{
			return GetAccessModifier(value) + " " + (value.Name);
		}
		/// <summary>
		/// Gets the access modifier of the member.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string GetAccessModifier(System.Reflection.MemberInfo value)
		{
			return value.GetAccessModifier();
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
/// <inheritdoc/>

		public bool Equals(VObject? other)
		{
			return base.Equals(other);
		}
/// <inheritdoc/>

		public int CompareTo(VObject? value)
		{
			object? other=value?.Value;
			if(other is null && Value is null)
				return 0;
			if(other is null && Value is not null)
				return 1;
			if(Value is null)
				return -1;
			if(other!.Equals(Value))
				return 0;
			if(other is bool && Value is bool)
				return ((bool)other)==true && ((bool)Value==false) ? -1 : 1;
			if(other.IsNumber() && Value.IsNumber())
				return Convert.ToDouble(other)>Convert.ToDouble(Value) ? -1 : 1;
			if(other is char && Value is char || other is char && Value.IsNumber() || other.IsNumber() && Value is char)
				return Convert.ToDouble(other)<Convert.ToDouble(Value) ? -1 : 1;
			if(other is string && Value is string)
			{
				string strOther=(other as string)!;
				string strValue=(Value as string)!;
				int len=Math.Min(strOther.Length, strValue.Length);
				for(int i = 0;i<len;i++)
				{
					if(strOther[i]>strValue[i])
						return -1;
					else if(strOther[i]<strValue[i])
						return 1;
				}
				if(strOther.Length>strValue.Length)
					return -1;
				return 1;
			}
			string strOther0=other.ToString()!;
			string strValue0=Value.ToString()!;
			int len0=Math.Min(strOther0.Length, strValue0.Length);
			for(int i = 0;i<len0;i++)
			{
				if(strOther0[i]>strValue0[i])
					return -1;
				else if(strOther0[i]<strValue0[i])
					return 1;
			}
			if(strOther0.Length>strValue0.Length)
				return -1;
			return 1;
		}
/// <inheritdoc/>

		public void Dispose()
		{
			Value=null;
		}
/// <inheritdoc/>

		public object Clone()
		{
			return new VObject(Value);
		}
/// <inheritdoc/>

		public TypeCode GetTypeCode()
		{
			return TypeCode.Object;
		}
/// <inheritdoc/>

		public bool ToBoolean(IFormatProvider? provider)
		{
			return Convert.ToBoolean(Value);
		}
/// <inheritdoc/>

		public byte ToByte(IFormatProvider? provider)
		{
			return Convert.ToByte(Value);
		}
/// <inheritdoc/>

		public char ToChar(IFormatProvider? provider)
		{
			return Convert.ToChar(Value);
		}
/// <inheritdoc/>

		public DateTime ToDateTime(IFormatProvider? provider)
		{
			return Convert.ToDateTime(Value);
		}
/// <inheritdoc/>

		public decimal ToDecimal(IFormatProvider? provider)
		{
			return Convert.ToDecimal(Value);
		}
/// <inheritdoc/>

		public double ToDouble(IFormatProvider? provider)
		{
			return Convert.ToDouble(Value);
		}
/// <inheritdoc/>

		public short ToInt16(IFormatProvider? provider)
		{
			return Convert.ToInt16(Value);
		}
/// <inheritdoc/>

		public int ToInt32(IFormatProvider? provider)
		{
			return Convert.ToInt32(Value);
		}
/// <inheritdoc/>

		public long ToInt64(IFormatProvider? provider)
		{
			return Convert.ToInt64(Value);
		}
/// <inheritdoc/>

		public sbyte ToSByte(IFormatProvider? provider)
		{
			return Convert.ToSByte(Value);
		}
/// <inheritdoc/>

		public float ToSingle(IFormatProvider? provider)
		{
			return Convert.ToSingle(Value);
		}
/// <inheritdoc/>

		public string ToString(IFormatProvider? provider)
		{
			return Value?.ToString()??"null";
		}
/// <inheritdoc/>

		public object ToType(Type conversionType, IFormatProvider? provider)
		{
			return Value is Type ? (Type)Value : Value?.GetType()??typeof(VObject);
		}
/// <inheritdoc/>

		public ushort ToUInt16(IFormatProvider? provider)
		{
			return Convert.ToUInt16(Value);
		}
/// <inheritdoc/>

		public uint ToUInt32(IFormatProvider? provider)
		{
			return Convert.ToUInt32(Value);
		}
/// <inheritdoc/>

		public ulong ToUInt64(IFormatProvider? provider)
		{
			return Convert.ToUInt64(Value);
		}
/// <inheritdoc/>

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			return Value?.ToString()??"null";
		}

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(this, obj))
			{
				return true;
			}

			if(ReferenceEquals(obj, null))
			{
				return false;
			}

			throw new NotImplementedException();
		}
		/// <inheritdoc/>
		public override int GetHashCode() => base.GetHashCode();
		/// <inheritdoc/>
		public static bool operator ==(VObject left, VObject right) => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.Equals(right);
		/// <inheritdoc/>
		public static bool operator !=(VObject left, VObject right) => !(left==right);
		/// <inheritdoc/>
		public static bool operator <(VObject left, VObject right) => ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right)<0;
		/// <inheritdoc/>
		public static bool operator <=(VObject left, VObject right) => ReferenceEquals(left, null)||left.CompareTo(right)<=0;
		/// <inheritdoc/>
		public static bool operator >(VObject left, VObject right) => !ReferenceEquals(left, null)&&left.CompareTo(right)>0;
		/// <inheritdoc/>
		public static bool operator >=(VObject left, VObject right) => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right)>=0;
	}
}