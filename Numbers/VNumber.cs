namespace VAdvanceObject.Numbers
{
	/// <summary>
	/// Stores a numerical value and can dispense that value in the requested format.
	/// </summary>
	public struct VNumber : IComparable, IConvertible, ISpanFormattable, IComparable<VNumber>, IEquatable<VNumber>
	{
		private object _value;
		/// <summary>
		/// Used for larger numerical values.
		/// </summary>
		private int[] _scaledValues;
		/// <summary>
		/// Gets the decimal value information.
		/// </summary>
		public PointPrecisionValue PPValue => new(DoubleValue);
		/// <summary>
		/// The numerical value.
		/// </summary>
		public object Value
		{
			get => _value;
			set
			{
				if(value.IsNumber())
				{
					_value=value;
					DataType=value.GetType();
					NumberTypeInfo=GetNumberType(value);
				}
				else
					throw new ArgumentException(null, nameof(value));
			}
		}
		/// <inheritdoc cref="Value"/>
		public byte ByteValue => Convert.ToByte(Value);
		/// <inheritdoc cref="Value"/>
		public sbyte SByteValue => Convert.ToSByte(Value);
		/// <inheritdoc cref="Value"/>
		public short ShortValue => Convert.ToInt16(Value);
		/// <inheritdoc cref="Value"/>
		public ushort UShortValue => Convert.ToUInt16(Value);
		/// <inheritdoc cref="Value"/>
		public int IntValue => Convert.ToInt32(Value);
		/// <inheritdoc cref="Value"/>
		public uint UIntValue => Convert.ToUInt32(Value);
		/// <inheritdoc cref="Value"/>
		public long LongValue => Convert.ToInt64(Value);
		/// <inheritdoc cref="Value"/>
		public ulong ULongValue => Convert.ToUInt64(Value);
		/// <inheritdoc cref="Value"/>
		public float FloatValue => Convert.ToSingle(Value);
		/// <inheritdoc cref="Value"/>
		public decimal DecimalValue => Convert.ToDecimal(Value);
		/// <inheritdoc cref="Value"/>
		public double DoubleValue => Convert.ToDouble(Value);
		/// <inheritdoc cref="Value"/>
		public bool BitValue => Convert.ToBoolean(Value);
		/// <summary>
		/// Provides the type of number.
		/// </summary>
		public NumberType NumberTypeInfo { get; private set; }
		/// <summary>
		/// The data-type of the <see cref="Value"/>.
		/// </summary>
		public Type? DataType { get; private set; }


		/// <summary>
		/// Creates a new instance of the <see cref="VNumber"/> struct.
		/// </summary>
		/// <param name="value"></param>
		/// <exception cref="ArgumentException"></exception>
		public VNumber(object value)
		{
			if(value is VNumber vNumber)
				value=vNumber._value;
			if(value!.NotNull() && value.IsNumber())
			{
				_scaledValues=PointPrecisionValue.SegmentNumber(value.ToString()!);
				_value=value;
				DataType=value.GetType();
				NumberTypeInfo=GetNumberType(value);
			}
			else
				throw new ArgumentException("The value must be a non-null numerical value.", nameof(value));
		}
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(byte value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(sbyte value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(short value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(ushort value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(int value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(uint value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(long value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(ulong value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(double value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(float value) => new(value);
		/// <inheritdoc cref="VNumber(object)"/>
		public static implicit operator VNumber(decimal value) => new(value);
		/// <summary>
		/// Performs a comparison between <paramref name="a"/> and <paramref name="b"/>.
		/// </summary>
		/// <param name="a">A <see cref="VNumber"/> object.</param>
		/// <param name="b">A <see cref="VNumber"/> object.</param>
		/// <returns>a <see cref="bool">boolean</see> value where <see cref="bool">true</see> represents a successful operation, and <see cref="bool">false</see> represents otherwise.</returns>
		public static bool operator ==(VNumber a, VNumber b) => a._scaledValues==b._scaledValues;
		/// <inheritdoc cref="operator ==(VNumber, VNumber)"/>
		public static bool operator !=(VNumber a, VNumber b) => a._scaledValues!=b._scaledValues;
		// /// <inheritdoc cref="operator ==(VNumber, VNumber)"/>
		//public static bool operator >(VNumber a, VNumber b) => a._scaledValues.;
		// /// <inheritdoc cref="operator ==(VNumber, VNumber)"/>
		//public static bool operator <(VNumber a, VNumber b) => a.DoubleValue < b.DoubleValue;
		/// <inheritdoc cref="operator ==(VNumber, VNumber)"/>
		public static bool operator >=(VNumber a, VNumber b) => a.DoubleValue >= b.DoubleValue;
		/// <inheritdoc cref="operator ==(VNumber, VNumber)"/>
		public static bool operator <=(VNumber a, VNumber b) => a.DoubleValue <= b.DoubleValue;
		/// <inheritdoc cref="operator ==(VNumber, VNumber)"/>
		public static VNumber operator ++(VNumber a)
		{
			var q=a.NumberTypeInfo;
			if(q.HasFlag(NumberType.Boolean))
				return new(a.BitValue==false ? true : (byte)2);
			if(q.HasFlags(NumberType.Unsigned, NumberType.Byte))
				return new(a.SByteValue<sbyte.MaxValue ? (sbyte)(a.SByteValue+1) : ((short)sbyte.MaxValue)+(short)1);
			if(q.HasFlag(NumberType.Byte))
				return new(a.ByteValue<byte.MaxValue ? (byte)(a.ByteValue+1) : ((short)byte.MaxValue)+(short)1);
			if(q.HasFlags(NumberType.Unsigned, NumberType.Int16))
				return new(a.UShortValue<ushort.MaxValue ? (ushort)(a.UShortValue+1) : ((int)ushort.MaxValue)+1);
			if(q.HasFlag(NumberType.Int16))
				return new(a.ShortValue<short.MaxValue ? (short)(a.ShortValue+1) : ((int)short.MaxValue)+1);
			if(q.HasFlags(NumberType.Int32, NumberType.Unsigned))
				return new(a.UIntValue<uint.MaxValue ? (uint)(a.UIntValue+1) : ((long)uint.MaxValue)+1);
			if(q.HasFlag(NumberType.Int32))
				return new(a.IntValue<int.MaxValue ? a.IntValue+1 : ((long)int.MaxValue)+1);
			if(q.HasFlags(NumberType.Int64, NumberType.Unsigned))
				return new(a.ULongValue<ulong.MaxValue ? a.ULongValue+1 : ((float)ulong.MaxValue)+1);
			if(q.HasFlag(NumberType.Int64))
				return new(a.LongValue<long.MaxValue ? a.LongValue+1 : ((float)long.MaxValue)+1);
			if(q.HasFlag(NumberType.Single))
				return new(a.FloatValue<float.MaxValue ? a.FloatValue+1 : ((double)double.MaxValue)+1);
			return new(a.DoubleValue+1);
		}
		/// <inheritdoc cref="operator ==(VNumber, VNumber)"/>
		public static VNumber operator +(VNumber a, VNumber b)
		{
			var q=a.NumberTypeInfo;
			if(q.HasFlag(NumberType.Boolean))
				return new(a.BitValue==false ? true : (byte)b.ByteValue);
			if(q.HasFlags(NumberType.Unsigned, NumberType.Byte))
				return new(a.SByteValue<sbyte.MaxValue ? (sbyte)(a.SByteValue+b.ShortValue) : ((short)sbyte.MaxValue)+(short)b.ShortValue);
			if(q.HasFlag(NumberType.Byte))
				return new(a.ByteValue<byte.MaxValue ? (byte)(a.ByteValue+b.ByteValue) : ((short)byte.MaxValue)+(short)b.ShortValue);
			if(q.HasFlags(NumberType.Unsigned, NumberType.Int16))
				return new(a.UShortValue<ushort.MaxValue ? (ushort)(a.UShortValue+b.UShortValue) : ((int)ushort.MaxValue)+b.IntValue);
			if(q.HasFlag(NumberType.Int16))
				return new(a.ShortValue<short.MaxValue ? (short)(a.ShortValue+b.ShortValue) : ((int)short.MaxValue)+b.IntValue);
			if(q.HasFlags(NumberType.Int32, NumberType.Unsigned))
				return new(a.UIntValue<uint.MaxValue ? (uint)(a.UIntValue+b.ULongValue) : ((long)uint.MaxValue)+b.LongValue);
			if(q.HasFlag(NumberType.Int32))
				return new(a.IntValue<int.MaxValue ? a.IntValue+b.IntValue : ((long)int.MaxValue)+b.LongValue);
			if(q.HasFlags(NumberType.Int64, NumberType.Unsigned))
				return new(a.ULongValue<ulong.MaxValue ? a.ULongValue+b.ULongValue : ((float)ulong.MaxValue)+b.FloatValue);
			if(q.HasFlag(NumberType.Int64))
				return new(a.LongValue<long.MaxValue ? a.LongValue+b.LongValue : ((float)long.MaxValue)+b.FloatValue);
			if(q.HasFlag(NumberType.Single))
				return new(a.FloatValue<float.MaxValue ? a.FloatValue+b.FloatValue : ((double)double.MaxValue)+b.DoubleValue);
			return new(a.DoubleValue+b.DoubleValue);
		}
		/// <inheritdoc cref="operator ==(VNumber, VNumber)"/>
		public static VNumber operator -(VNumber a, VNumber b)
		{
			var q=a.NumberTypeInfo;
			if(q.HasFlag(NumberType.Boolean))
				return new(!a.BitValue);
			if(q.HasFlags(NumberType.Unsigned, NumberType.Byte))
				return new(a.SByteValue<sbyte.MaxValue ? (sbyte)(a.SByteValue-b.ShortValue) : ((short)sbyte.MaxValue)-(short)b.ShortValue);
			if(q.HasFlag(NumberType.Byte))
				return new(a.ByteValue<byte.MaxValue ? (byte)(a.ByteValue-b.ByteValue) : ((short)byte.MaxValue)-(short)b.ShortValue);
			if(q.HasFlags(NumberType.Unsigned, NumberType.Int16))
				return new(a.UShortValue<ushort.MaxValue ? (ushort)(a.UShortValue-b.UShortValue) : ((int)ushort.MaxValue)-b.IntValue);
			if(q.HasFlag(NumberType.Int16))
				return new(a.ShortValue<short.MaxValue ? (short)(a.ShortValue-b.ShortValue) : ((int)short.MaxValue)-b.IntValue);
			if(q.HasFlags(NumberType.Int32, NumberType.Unsigned))
				return new(a.UIntValue<uint.MaxValue ? (uint)(a.UIntValue-b.ULongValue) : ((long)uint.MaxValue)-b.LongValue);
			if(q.HasFlag(NumberType.Int32))
				return new(a.IntValue<int.MaxValue ? a.IntValue-b.IntValue : ((long)int.MaxValue)-b.LongValue);
			if(q.HasFlags(NumberType.Int64, NumberType.Unsigned))
				return new(a.ULongValue<ulong.MaxValue ? a.ULongValue-b.ULongValue : ((float)ulong.MaxValue)-b.FloatValue);
			if(q.HasFlag(NumberType.Int64))
				return new(a.LongValue<long.MaxValue ? a.LongValue-b.LongValue : ((float)long.MaxValue)-b.FloatValue);
			if(q.HasFlag(NumberType.Single))
				return new(a.FloatValue<float.MaxValue ? a.FloatValue-b.FloatValue : ((double)double.MaxValue)-b.DoubleValue);
			return new(a.DoubleValue-b.DoubleValue);
		}
		/// <inheritdoc cref="GetNumberType(Type)"/>
		public static NumberType GetNumberType(object value) => GetNumberType(value.GetType());
		/// <summary>
		/// Determines the number type of the data-type.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static NumberType GetNumberType(Type type)
		{
			NumberType res=default;
			if(type==typeof(bool))
				res|=NumberType.Boolean;
			if(type==typeof(sbyte))
				res|=NumberType.Unsigned | NumberType.Byte;
			if(type==typeof(byte))
				res|=NumberType.Byte;
			if(type==typeof(ushort))
				res|=NumberType.Unsigned | NumberType.Int16;
			if(type==typeof(short))
				res|=NumberType.Int16;
			if(type==typeof(uint))
				res|=NumberType.Unsigned | NumberType.Int32;
			if(type==typeof(ulong))
				res|=NumberType.Unsigned | NumberType.Int64;
			if(type==typeof(long))
				res|=NumberType.Int64;
			if(type==typeof(float))
				res|=NumberType.Single;
			if(type==typeof(decimal))
				res|=NumberType.Decimal;
			if(type==typeof(double))
				res|=NumberType.Double;
			return res;
		}
		/// <summary>
		/// Gets the scaled value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static object[] GetScaledValue(object value)
		{
			object[] res={ };
			if(value is double doubleValue)
			{
				if(doubleValue>=double.MaxValue-1)
				{
					Array.Resize(ref res, res.Length+1);
					res[0]=doubleValue-1;
					res[1]=1;
				}
			}
			return res;
		}
		/// <summary>
		/// Gets the decimal value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static int GetDecimals(object value)
		{
			if(value.Is(typeof(float), typeof(double), typeof(decimal)))
			{
				string q=value.ToString()!;
				var l=q.GetMatchGroup(@"[.](?<decimalValue>[\d]+)", "decimalValue");
				return l is not null ? Convert.ToInt32(l.Value) : 0;
			}
			throw new ArgumentException("The argument must be a numerical data-type that allows decimal-point precision.", nameof(value));
		}

		int IComparable.CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}

		TypeCode IConvertible.GetTypeCode()
		{
			throw new NotImplementedException();
		}

		bool IConvertible.ToBoolean(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		byte IConvertible.ToByte(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		char IConvertible.ToChar(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		DateTime IConvertible.ToDateTime(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		decimal IConvertible.ToDecimal(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		double IConvertible.ToDouble(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		short IConvertible.ToInt16(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		int IConvertible.ToInt32(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		long IConvertible.ToInt64(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		sbyte IConvertible.ToSByte(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		float IConvertible.ToSingle(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		string IConvertible.ToString(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		ushort IConvertible.ToUInt16(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		uint IConvertible.ToUInt32(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		ulong IConvertible.ToUInt64(IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
		{
			throw new NotImplementedException();
		}

		int IComparable<VNumber>.CompareTo(VNumber other)
		{
			return other.LongValue>LongValue ? -1 : other.LongValue>LongValue ? 1 : 0;
		}

		bool IEquatable<VNumber>.Equals(VNumber other)
		{
			throw new NotImplementedException();
		}

		public override bool Equals(object obj)
		{
			throw new NotImplementedException();
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		//public static bool operator <(VNumber left, VNumber right)
		//{
		//	return left.CompareTo(right)<0;
		//}

		//public static bool operator >(VNumber left, VNumber right)
		//{
		//	return left.CompareTo(right)>0;
		//}
	}
}
