namespace VObject.Numbers
{
	/// <summary>
	/// Provides an enumeration indicating the data-type of a numerical value.
	/// </summary>
	[Flags]
	public enum NumberType
	{
		/// <summary>
		/// Unknown numerical data-type.
		/// </summary>
		Unknown=0x0,
		/// <summary>
		/// The value is either a 0 or a 1 (TRUE or FALSE).
		/// </summary>
		Boolean=0x1,
		/// <summary>
		/// Indicates that the numerical data-type is unsigned (This flag is included alongside another flag to represent the numerical value as unsigned).
		/// <para>
		///		Note that if used with <see cref="NumberType.Byte"/>, this flag represents <see cref="SByte"/> instead.
		/// </para>
		/// </summary>
		Unsigned=0x2,
		/// <summary>
		/// Consists of 8 bits (0 - 255).
		/// </summary>
		Byte=0x3,
		/// <summary>
		/// Represents a <see cref="short"/>.
		/// </summary>
		Int16=0x6,
		/// <summary>
		/// Represents a <see cref="int"/>.
		/// </summary>
		Int32=0x9,
		/// <summary>
		/// Represents a <see cref="long"/>.
		/// </summary>
		Int64=0xC,
		/// <summary>
		/// Represents a <see cref="float"/>.
		/// </summary>
		Single=0xF,
		/// <summary>
		/// Represents a <see cref="decimal"/>.
		/// </summary>
		Decimal=0x12,
		/// <summary>
		/// Represents a <see cref="double"/>.
		/// </summary>
		Double=0x15,
	}
}
