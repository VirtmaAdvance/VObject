namespace VAdvanceObject
{
	/// <summary>
	/// Provides validation extension methods for the <see cref="Enum"/> class.
	/// </summary>
	public static class EnumFlagValidationExt
	{
		/// <inheritdoc cref="ObjectValidationExt.IsNull(object)"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> has any of the <paramref name="flags"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value">The source enum to analyze.</param>
		/// <param name="flags">The flags to look for.</param>
		public static bool Any<TEnum>(this TEnum value, params Enum[] flags) where TEnum : Enum => flags.Any(q=>value.HasFlag(q));
		/// <inheritdoc cref="Any{TEnum}(TEnum, Enum[])"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> has all of the <paramref name="flags"/>.
		/// </summary>
		public static bool All<TEnum>(this TEnum value, params Enum[] flags) where TEnum : Enum => flags.All(q=>value.HasFlag(q));

	}
}
