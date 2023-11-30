using System.Text.RegularExpressions;

namespace VObject
{
	/// <summary>
	/// Provides regular expression extension methods.
	/// </summary>
	public static class RegexExt
	{
		/// <summary>
		/// Determines if the <paramref name="pattern"/> is found within the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/> value.</param>
		/// <param name="pattern">A <see cref="string"/> representation of a Regex pattern.</param>
		/// <param name="options">The regex options.</param>
		/// <param name="timeout">The amount of time allowed for the operation to run.</param>
		/// <returns>a <see cref="bool">boolean</see> value representing the result of the operation.</returns>
		public static bool IsMatch(this string value, string pattern, RegexOptions options, TimeSpan timeout) => Regex.IsMatch(value, pattern, options, timeout);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static bool IsMatch(this string value, string pattern, RegexOptions options) => Regex.IsMatch(value, pattern, options);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static bool IsMatch(this string value, string pattern) => Regex.IsMatch(value, pattern);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static Match Match(this string value, string pattern, RegexOptions options, TimeSpan timeout) => Regex.Match(value, pattern, options, timeout);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static Match Match(this string value, string pattern, RegexOptions options) => Regex.Match(value, pattern, options);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static Match Match(this string value, string pattern) => Regex.Match(value, pattern);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static MatchCollection Matches(this string value, string pattern, RegexOptions options, TimeSpan timeout) => Regex.Matches(value, pattern, options, timeout);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static MatchCollection Matches(this string value, string pattern, RegexOptions options) => Regex.Matches(value, pattern, options);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static MatchCollection Matches(this string value, string pattern) => Regex.Matches(value, pattern);
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static GroupCollection? GetMatchGroups(this string value, string pattern, RegexOptions options, TimeSpan timeout) => value.Match(pattern, options, timeout).GetMatchGroups();
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static GroupCollection? GetMatchGroups(this string value, string pattern, RegexOptions options) => value.Match(pattern, options).GetMatchGroups();
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static GroupCollection? GetMatchGroups(this string value, string pattern) => value.Match(pattern).GetMatchGroups();
		/// <inheritdoc cref="IsMatch(string, string, RegexOptions, TimeSpan)"/>
		public static GroupCollection? GetMatchGroups(this Match? m) => ((m is not null) && m.Groups is not null) && m.Groups.Count>0 ? m.Groups : null;
		/// <summary>
		/// Gets the match group.
		/// </summary>
		/// <param name="m"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static Group? GetMatchGroup(this Match? m, string name)
		{
			var q=m.GetMatchGroups();
			return (q is not null) && q.ContainsKey(name) ? q[name] : null;
		}
		/// <inheritdoc cref="GetMatchGroup(Match, string)"/>
		public static Group? GetMatchGroup(this string value, string pattern, string name, RegexOptions options, TimeSpan timeout) => value.Match(pattern, options, timeout).GetMatchGroup(name);
		/// <inheritdoc cref="GetMatchGroup(Match, string)"/>
		public static Group? GetMatchGroup(this string value, string pattern, string name, RegexOptions options) => value.Match(pattern, options).GetMatchGroup(name);
		/// <inheritdoc cref="GetMatchGroup(Match, string)"/>
		public static Group? GetMatchGroup(this string value, string pattern, string name) => value.Match(pattern).GetMatchGroup(name);

	}
}
