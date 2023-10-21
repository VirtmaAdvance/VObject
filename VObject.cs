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


	}
}