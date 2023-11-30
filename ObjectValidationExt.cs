using System.Reflection;

namespace VObject
{
	/// <summary>
	/// Provides validation extension methods for the <see cref="object"/> class.
	/// </summary>
	public static class ObjectValidationExt
	{
		/// <summary>
		/// Determines whether the <paramref name="value"/> is <see langword="null"/>.
		/// </summary>
		/// <param name="value">Any data-type value that inherits the <see cref="object"/> class.</param>
		/// <returns>a <see cref="bool">boolean</see> value where <see cref="bool">true</see> represents success, and <see cref="bool">false</see> otherwise.</returns>
		public static bool IsNull(this object value) => value is null;
		/// <inheritdoc cref="IsNull(object)"/>
		/// <summary>
		/// Determines whether the <paramref name="value"/> is not <see langword="null"/>.
		/// </summary>
		public static bool NotNull(this object value) => !value.IsNull();
		/// <inheritdoc cref="IsNull(object)"/>
		/// <summary>
		/// Determines whether the <paramref name="value"/> is a COMObject
		/// </summary>
		public static bool IsComObject(this object value) => value.NotNull() && System.Runtime.InteropServices.Marshal.IsComObject(value);
		/// <inheritdoc cref="IsNull(object)"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> inherits from one of the provided <paramref name="types"/>.
		/// </summary>
		/// <param name="value">An <see cref="object"/> representation of a value that will be checked.</param>
		/// <param name="types">A <see cref="Type"/> array representing all of the types to check the <paramref name="value"/> data-type against.</param>
		public static bool Is(this object value, params Type[] types)
		{
			if(value.NotNull() && !value.IsComObject())
			{
				types??=Array.Empty<Type>();
				Type valueType=value.GetType();
				return types.Any(q =>valueType.IsAssignableFrom(q));
			}
			return false;
		}
		/// <inheritdoc cref="Is(object, Type[])"/>
		/// <param name="value">An <see cref="object"/> representation of a value that will be checked.</param>
		/// <param name="types">An <see cref="object"/> array representing the data-types to check for.</param>
		public static bool Is(this object value, params object[] types)
		{
			if(value.NotNull() && !value.IsComObject())
			{
				types??=Array.Empty<Type>();
				Type valueType=value.GetType();
				return types.Any(q =>valueType.IsAssignableFrom(q.GetType()));
			}
			return false;
		}
		/// <inheritdoc cref="Is(object, Type[])"/>
		/// <summary>Determines if the <paramref name="value"/> is a number.</summary>
		public static bool IsNumber(this object value) => value.Is(typeof(sbyte), typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(decimal), typeof(double), typeof(bool));
		/// <inheritdoc cref="Is(object, Type[])"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> is an unsigned number.
		/// </summary>
		public static bool IsNumberUnsigned(this object value) => value.Is(typeof(sbyte), typeof(ushort), typeof(uint), typeof(ulong));
		/// <summary>
		/// Determines if the <paramref name="value"/> contains all of the given <paramref name="flags"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="flags"></param>
		/// <returns></returns>
		public static bool HasFlags(this Enum value, params Enum[] flags) => flags.All(q=> value.HasFlag(q));

	}
}
