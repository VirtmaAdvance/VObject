namespace VObject
{
	/// <summary>
	/// Provides informational extension methods for the <see cref="Enum"/> class.
	/// </summary>
	public static class EnumInfoExt
	{
		/// <summary>
		/// Gets the underlying <see cref="Type"/>.
		/// </summary>
		/// <param name="source">An <see cref="Enum"/> object.</param>
		/// <returns>the underlying <see cref="Type"/>.</returns>
		public static Type GetUnderlyingType(this Enum source) => Enum.GetUnderlyingType(source.GetType());

	}
}
