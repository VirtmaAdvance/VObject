using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VObject.Numbers
{
	/// <summary>
	/// Provides a means to store larger numerical values.
	/// </summary>
	public struct ScalableNumber
	{

		private int[] _baseValues;

		private int[] _decimalValues;


		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber()
		{
			_baseValues=new int[0];
			_decimalValues=new int[0];
		}
		/// <summary>
		/// Creates a new instance of the <see cref="ScalableNumber"/> struct.
		/// </summary>
		/// <param name="value">The numerical value to store.</param>
		public ScalableNumber(double value)
		{
			_baseValues=GetBases(value);
			_decimalValues=GetDecimals(value);
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(float value)
		{
			_baseValues=GetBases(value);
			_decimalValues=GetDecimals(value);
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(decimal value)
		{
			_baseValues=GetBases(value);
			_decimalValues=GetDecimals(value);
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(byte value)
		{
			_baseValues=GetBases(value);
			_decimalValues=new int[0];
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(sbyte value)
		{
			_baseValues=GetBases(value);
			_decimalValues=new int[0];
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(int value)
		{
			_baseValues=GetBases(value);
			_decimalValues=new int[0];
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(uint value)
		{
			_baseValues=GetBases(value);
			_decimalValues=new int[0];
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(long value)
		{
			_baseValues=GetBases(value);
			_decimalValues=new int[0];
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(ulong value)
		{
			_baseValues=GetBases(value);
			_decimalValues=new int[0];
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(short value)
		{
			_baseValues=GetBases(value);
			_decimalValues=new int[0];
		}
		/// <inheritdoc cref="ScalableNumber(double)"/>
		public ScalableNumber(ushort value)
		{
			_baseValues=GetBases(value);
			_decimalValues=new int[0];
		}

		public static bool operator ==(ScalableNumber a, ScalableNumber b) => a.Equals(b);
		public static bool operator !=(ScalableNumber a, ScalableNumber b) => !a.Equals(b);
		public static bool operator >(ScalableNumber a, ScalableNumber b)
		{
			if(a._baseValues.Length>b._baseValues.Length)
				return true;
			else if(a._baseValues.Length<b._baseValues.Length)
				return false;
			else
			{
				int len=a._baseValues.Length;
				for(int i = 0;i<len;i++)
				{
					if(a._baseValues[i]>b._baseValues[i])
						return true;
					else if(a._baseValues[i]<b._baseValues[i])
						return false;
				}
				len=Math.Max(a._decimalValues.Length,b._decimalValues.Length);
				for(int i = 0;i<len;i++)
				{
					int tmpA=0;
					int tmpB=0;
					if(i<a._decimalValues.Length)
						tmpA=a._decimalValues[i];
					if(i<b._decimalValues.Length)
						tmpB=b._decimalValues[i];
					if(tmpA>tmpB)
						return true;
					else if(tmpA<tmpB)
						return false;
				}
				return false;
			}
		}
		public static bool operator <(ScalableNumber a, ScalableNumber b)
		{
			if(a._baseValues.Length>b._baseValues.Length)
				return false;
			else if(a._baseValues.Length<b._baseValues.Length)
				return true;
			else
			{
				int len=a._baseValues.Length;
				for(int i = 0;i<len;i++)
				{
					if(a._baseValues[i]>b._baseValues[i])
						return false;
					else if(a._baseValues[i]<b._baseValues[i])
						return true;
				}
				len=Math.Max(a._decimalValues.Length,b._decimalValues.Length);
				for(int i = 0;i<len;i++)
				{
					int tmpA=0;
					int tmpB=0;
					if(i<a._decimalValues.Length)
						tmpA=a._decimalValues[i];
					if(i<b._decimalValues.Length)
						tmpB=b._decimalValues[i];
					if(tmpA>tmpB)
						return false;
					else if(tmpA<tmpB)
						return true;
				}
				return false;
			}
		}
		public static bool operator >=(ScalableNumber a, ScalableNumber b) => a>b || a==b;
		public static bool operator <=(ScalableNumber a, ScalableNumber b) => a<b || a==b;
		public static bool operator +(ScalableNumber a, ScalableNumber b) => a.Add(b);




		public bool Add(ScalableNumber value)
		{
			if(_baseValues.Length>value._baseValues.Length)
			{
				int injectionPoint=_baseValues.Length-value._baseValues.Length;
				int[] res={ };
				for(int i = 0;i<_baseValues.Length;i++)
				{
					
				}
			}
			return true;
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
