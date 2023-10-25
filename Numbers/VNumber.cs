using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VObject.Numbers
{
	/// <summary>
	/// Stores a numerical value and can dispense that value in the requested format.
	/// </summary>
	public readonly struct VNumber
	{
		/// <summary>
		/// The numerical value.
		/// </summary>
		public readonly object Value;
		/// <inheritdoc cref="Value"/>
		public byte ByteValue => (byte)Value;
		/// <inheritdoc cref="Value"/>
		public short ShortValue => (short)Value;
		/// <inheritdoc cref="Value"/>
		public ushort UShortValue => (ushort)Value;
		/// <inheritdoc cref="Value"/>
		public int IntValue => (int)Value;
		/// <inheritdoc cref="Value"/>
		public uint UIntValue => (uint)Value;
		/// <inheritdoc cref="Value"/>
		public long LongValue => (long)Value;
		/// <inheritdoc cref="Value"/>
		public ulong ULongValue => (ulong)Value;
		/// <inheritdoc cref="Value"/>
		public float FloatValue => (float)Value;
		/// <inheritdoc cref="Value"/>
		public decimal DecimalValue => (decimal)Value;
		/// <inheritdoc cref="Value"/>
		public double DoubleValue => (double)Value;
		/// <summary>
		/// The data-type of the <see cref="Value"/>.
		/// </summary>
		public readonly Type? DataType => Value?.GetType();


		/// <summary>
		/// Creates a new instance of the <see cref="VNumber"/> struct.
		/// </summary>
		/// <param name="value"></param>
		/// <exception cref="ArgumentException"></exception>
		public VNumber(object value)
		{
			if(value!.NotNull() && value!.IsNumber())
				Value=value;
			else
				throw new ArgumentException("The value must be a non-null numerical value.");
		}

		public static VNumber operator 

	}
}
