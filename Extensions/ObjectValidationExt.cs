namespace VObject.Extensions
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


    }
}
