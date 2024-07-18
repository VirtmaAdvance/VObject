using System.Collections;
using System.Reflection;

namespace VAdvanceObject
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
		public bool IsNull => Value.IsNull();
		/// <summary>
		/// Indicates whether the value is not <see langword="null"/>.
		/// </summary>
		public bool NotNull => Value.NotNull();
		/// <summary>
		/// Indicates whether the value is a COMObject.
		/// </summary>
		public bool IsComObject => Value!.IsComObject();
		/// <summary>
		/// Gets the <see cref="Type"/> object.
		/// </summary>
		public Type? DataType => !IsComObject ? Value?.GetType() : null;
		/// <summary>
		/// Contains all of the members related to this object.
		/// </summary>
		public readonly MemberInfo[] Members;
		/// <summary>
		/// Stores tag information.
		/// </summary>
		public readonly List<string> Tags;
		/// <summary>
		/// The version information about this object.
		/// </summary>
		public static Version VersionInfo => new(1, 2, 2, 10);


		/// <summary>
		/// Creates a new instance of the <see cref="VObject"/> class.
		/// </summary>
		/// <param name="value">Any value.</param>
		public VObject(object? value)
		{
			Tags = [];
			Value = value;
			Members = GetMembers();
		}
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
		public static implicit operator VObject(nint value) => new(value);
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
		public static implicit operator VObject(MemberInfo value) => new(value);
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
		public static implicit operator VObject(Pointer value) => new(value);
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
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.Regex value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.Capture value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.CaptureCollection value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.Group value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.GroupCollection value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.MatchEvaluator value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(HttpMessageInvoker value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.RegexOptions value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.RegexParseError value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.RegexParseException value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.RegexRunner value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(System.Text.RegularExpressions.RegexRunnerFactory value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Numbers.VNumber value) => new(value);
		/// <inheritdoc cref="VObject(object)"/>
		public static implicit operator VObject(Type value) => new(value);
		/// <summary>
		/// Gets the member information of the object.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static MemberInfo[] GetMembers(object? value) => (value?.GetType()?.GetMembers()) ?? Array.Empty<MemberInfo>();
		/// <inheritdoc cref="GetMembers(object?)"/>
		public MemberInfo[] GetMembers() => GetMembers(Value);
		/// <summary>
		/// Determines if a member exists.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool ContainsMember(string name) => Members.Any(q => q.Name.Equals(name));
		/// <summary>
		/// Attempts to get the <see cref="MemberInfo"/> object of an existing member.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public MemberInfo? GetMemberByName(string name) => Members.FirstOrDefault(q => q.Name.Equals(name));
		/// <summary>
		/// Determines if a tag exists within this object's tag collection.
		/// </summary>
		/// <param name="name">The name of the tag.</param>
		/// <returns></returns>
		public bool ContainsTag(string name) => Tags.Contains(name);
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
		public static string GetStringRepresentation(object? value, bool addQuotes = false)
		{
			if (value.NotNull() && System.Runtime.InteropServices.Marshal.IsComObject(value!))
				return "COMObject";
			string result = value switch
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
			Type type = classObject.GetType();
			MemberInfo[] l = type.GetMembers();
			string res = "class " + classObject.ToString() + "{";
			foreach (var sel in l)
				res += "\n\t" + Serialize(sel);
			return res;
		}
		/// <summary>
		/// Serializes an object.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string Serialize(MemberInfo value) => GetAccessModifier(value) + " " + (value.Name);
		/// <summary>
		/// Gets the access modifier of the member.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string GetAccessModifier(MemberInfo value) => value.GetAccessModifier();
		/// <inheritdoc cref="GetStringFromCollection(IDictionary)"/>
		private static string GetStringFromCollection(IEnumerable source)
		{
			string res = "";
			foreach (var sel in source)
				res += (res.Length > 0 ? "," : "") + GetStringRepresentation(sel, true);
			return "[" + res + "]";
		}
		/// <summary>
		/// Generates a JSON <see cref="string"/> representation of the collection.
		/// </summary>
		/// <param name="source">The collection to serialize.</param>
		/// <returns>a <see cref="string"/> representation of the collection.</returns>
		private static string GetStringFromCollection(IDictionary source)
		{
			string res = "";
			foreach (var sel in source.Keys)
				res += (res.Length > 0 ? "," : "") + GetStringRepresentation(sel, true) + ":" + GetStringRepresentation(source[sel]!, true);
			return "{" + res + "}";
		}
		/// <inheritdoc/>
		public bool Equals(VObject? other) => base.Equals(other);
		/// <inheritdoc/>
		public int CompareTo(VObject? value)
		{
			object? other = value?.Value;
			if (other is null && Value is null)
				return 0;
			if (other is null && Value is not null)
				return 1;
			if (Value is null)
				return -1;
			if (other!.Equals(Value))
				return 0;
			if (other is bool && Value is bool)
				return ((bool)other) == true && ((bool)Value == false) ? -1 : 1;
			if (other.IsNumber() && Value.IsNumber())
				return Convert.ToDouble(other) > Convert.ToDouble(Value) ? -1 : 1;
			if (other is char && Value is char || other is char && Value.IsNumber() || other.IsNumber() && Value is char)
				return Convert.ToDouble(other) < Convert.ToDouble(Value) ? -1 : 1;
			if (other is string && Value is string)
			{
				string strOther = (other as string)!;
				string strValue = (Value as string)!;
				int len = Math.Min(strOther.Length, strValue.Length);
				for (int i = 0; i < len; i++)
				{
					if (strOther[i] > strValue[i])
						return -1;
					else if (strOther[i] < strValue[i])
						return 1;
				}
				if (strOther.Length > strValue.Length)
					return -1;
				return 1;
			}
			string strOther0 = other.ToString()!;
			string strValue0 = Value.ToString()!;
			int len0 = Math.Min(strOther0.Length, strValue0.Length);
			for (int i = 0; i < len0; i++)
			{
				if (strOther0[i] > strValue0[i])
					return -1;
				else if (strOther0[i] < strValue0[i])
					return 1;
			}
			if (strOther0.Length > strValue0.Length)
				return -1;
			return 1;
		}
		/// <inheritdoc/>
		public void Dispose() => Value = null;
		/// <inheritdoc/>
		public object Clone() => new VObject(Value);
		/// <inheritdoc/>
		public TypeCode GetTypeCode() => TypeCode.Object;
		/// <inheritdoc/>
		public bool ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(Value);
		/// <inheritdoc/>
		public byte ToByte(IFormatProvider? provider) => Convert.ToByte(Value);
		/// <inheritdoc/>
		public char ToChar(IFormatProvider? provider) => Convert.ToChar(Value);
		/// <inheritdoc/>
		public DateTime ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(Value);
		/// <inheritdoc/>
		public decimal ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(Value);
		/// <inheritdoc/>
		public double ToDouble(IFormatProvider? provider) => Convert.ToDouble(Value);
		/// <inheritdoc/>
		public short ToInt16(IFormatProvider? provider) => Convert.ToInt16(Value);
		/// <inheritdoc/>
		public int ToInt32(IFormatProvider? provider) => Convert.ToInt32(Value);
		/// <inheritdoc/>
		public long ToInt64(IFormatProvider? provider) => Convert.ToInt64(Value);
		/// <inheritdoc/>
		public sbyte ToSByte(IFormatProvider? provider) => Convert.ToSByte(Value);
		/// <inheritdoc/>
		public float ToSingle(IFormatProvider? provider) => Convert.ToSingle(Value);
		/// <inheritdoc/>
		public string ToString(IFormatProvider? provider) => Value?.ToString() ?? "null";
		/// <inheritdoc/>
		public object ToType(Type conversionType, IFormatProvider? provider) => Value is Type ? (Type)Value : Value?.GetType() ?? typeof(VObject);
		/// <inheritdoc/>
		public ushort ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(Value);
		/// <inheritdoc/>
		public uint ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(Value);
		/// <inheritdoc/>
		public ulong ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(Value);
		/// <inheritdoc/>
		public string ToString(string? format, IFormatProvider? formatProvider) => Value?.ToString() ?? "null";
		/// <summary>
		/// Determines if this object equals another.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public override bool Equals(object? obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
			if (obj is null)
				return false;
			throw new NotImplementedException();
		}
		/// <inheritdoc/>
		public override int GetHashCode() => base.GetHashCode();
		/// <inheritdoc/>
		public static bool operator ==(VObject left, VObject right) => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.Equals(right);
		/// <inheritdoc/>
		public static bool operator !=(VObject left, VObject right) => !(left == right);
		/// <inheritdoc/>
		public static bool operator <(VObject left, VObject right) => ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
		/// <inheritdoc/>
		public static bool operator <=(VObject left, VObject right) => ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
		/// <inheritdoc/>
		public static bool operator >(VObject left, VObject right) => !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
		/// <inheritdoc/>
		public static bool operator >=(VObject left, VObject right) => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
	}
}