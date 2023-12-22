namespace VAdvanceObject.Numbers
{
	/// <summary>
	/// Provides a data structure for point precision values.
	/// </summary>
	public struct PointPrecisionValue
	{

		private int[] _baseValues;

		private int[] _decimalValues;


		/// <inheritdoc cref="PointPrecisionValue(double)"/>
		public PointPrecisionValue()
		{
			_baseValues=new int[0];
			_decimalValues=new int[0];
		}
		/// <summary>
		/// Creates a new instance of the <see cref="PointPrecisionValue"/> struct.
		/// </summary>
		/// <param name="value">The numerical value to store.</param>
		public PointPrecisionValue(double value)
		{
			_baseValues=GetBases(value);
			_decimalValues=GetDecimals(value);
		}
		/// <inheritdoc cref="PointPrecisionValue(double)"/>
		public PointPrecisionValue(float value)
		{
			_baseValues=GetBases(value);
			_decimalValues=GetDecimals(value);
		}
		/// <inheritdoc cref="PointPrecisionValue(double)"/>
		public PointPrecisionValue(decimal value)
		{
			_baseValues=GetBases(value);
			_decimalValues=GetDecimals(value);
		}
		/// <inheritdoc cref="SegmentNumber(long)"/>
		public static int[] SegmentNumber(string value) => SegmentNumber(Convert.ToInt64(value));
		/// <summary>
		/// Generates a segmentation of the value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int[] SegmentNumber(long value)
		{
			if(value>int.MaxValue)
			{
				int[] res=new int[(int)Math.Ceiling(Math.Abs((double)value) / int.MaxValue)];
				for(int i = 0;i<res.Length;i++)
				{
					var chunk=Math.Sign(value)*int.MaxValue;
					res[i]=chunk;
					value-=chunk;
				}
				return res;
			}
			return new int[1] { (int)value };
		}
		/// <summary>
		/// Gets the decimal value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static int[] GetDecimals(object value)
		{
			if(value.Is(typeof(float), typeof(double), typeof(decimal)))
			{
				string q=value.ToString()!;
				var l=q.GetMatchGroup(@"[.](?<decimalValue>[\d]+)", "decimalValue");
				return l is not null ? SegmentNumber(l.Value) : new int[1] { 0 };
			}
			throw new ArgumentException("The argument must be a numerical data-type that allows decimal-point precision.", nameof(value));
		}
		/// <summary>
		/// Gets the decimal value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static int[] GetBases(object value)
		{
			if(value.Is(typeof(float), typeof(double), typeof(decimal)))
			{
				string q=value.ToString()!;
				var l=q.GetMatchGroup(@"(?<decimalValue>[\d\-]+)[.]", "decimalValue");
				return l is not null ? SegmentNumber(l.Value) : new int[1] { 0 };
			}
			throw new ArgumentException("The argument must be a numerical data-type that allows decimal-point precision.", nameof(value));
		}

	}
}