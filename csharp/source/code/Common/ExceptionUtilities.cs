using System.Reflection;

namespace Occhitta.Libraries.Common;

/// <summary>
/// <see cref="Exception" />共通関数クラスです。
/// </summary>
public static class ExceptionUtilities {
	#region 公開メソッド定義:ToSource
	/// <summary>
	/// 例外集合へ変換します。
	/// </summary>
	/// <param name="source">例外情報</param>
	/// <returns>例外集合</returns>
	public static System.Collections.Generic.IEnumerable<ExceptionParameter> ToSource(Exception source) {
		var cache1 = source.GetType();
		var cache2 = cache1.GetProperties();
		foreach (var cache3 in cache2) {
			yield return new ExceptionParameter(cache3.Name, cache3.GetValue(source));
		}
	}
	#endregion 公開メソッド定義:ToSource

	#region 内部メソッド定義:ToIndent
	/// <summary>
	/// 階層内容へ変換します。
	/// </summary>
	/// <param name="source">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>階層内容</returns>
	private static string ToIndent(string source, int repeat) {
		var result = new StringBuilder(source.Length * repeat);
		for (var count = 0; count < repeat; count ++) {
			result.Append(source);
		}
		return result.ToString();
	}
	#endregion 内部メソッド定義:ToIndent

	#region 内部メソッド定義:ToString
	/// <summary>
	/// 表現情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>表現情報</returns>
	private static string ToString(object? source, string indent, int repeat) {
		if (source == null) {
			return "Null";
		} else if (source is bool) {
			return $"{source}";
		} else if (source is sbyte) {
			return $"{source}B";
		} else if (source is byte) {
			return $"{source}UB";
		} else if (source is short) {
			return $"{source}S";
		} else if (source is ushort) {
			return $"{source}US";
		} else if (source is int) {
			return $"{source}";
		} else if (source is uint) {
			return $"{source}U";
		} else if (source is long) {
			return $"{source}L";
		} else if (source is ulong) {
			return $"{source}UL";
		} else if (source is nint) {
			return $"{source}N";
		} else if (source is nuint) {
			return $"{source}NU";
		} else if (source is float) {
			return $"{source}F";
		} else if (source is double) {
			return $"{source}D";
		} else if (source is decimal) {
			return $"{source}M";
		} else if (source is System.Numerics.BigInteger) {
			return $"{source}BI";
		} else if (source is DateOnly) {
			return $"{source:yyyy-MM-dd}";
		} else if (source is TimeOnly) {
			return $"{source:HH:mm:ss.fffffff}";
		} else if (source is DateTime) {
			return $"{source:yyyy-MM-dd'T'HH:mm:ss.fffffff}";
		} else if (source is DateTimeOffset) {
			return $"{source:yyyy-MM-dd'T'HH:mm:ss.fffffff'('zzz')'}";
		} else if (source is TimeSpan cache1) {
			if (cache1.Ticks < 0) {
				return $"{source:'-'dd'.'hh':'mm':'ss'.'fffffff}";
			} else {
				return $"{source:'+'dd'.'hh':'mm':'ss'.'fffffff}";
			}
		} else if (source is MethodBase) {
			return $"{source}";
		} else if (source is char cacheA) {
			return cacheA switch {
				'\\'       => "'\\\\'",
				'\''       => "'\\''",
				'\t'       => "'\\t'",
				'\r'       => "'\\r'",
				'\n'       => "'\\n'",
				< '\u0020' => $"'\\u{(int)cacheA:X04}'",
				_          => $"'{cacheA}'"
			};
		} else if (source is string cacheB) {
			var result = cacheB;
			foreach (var (older, newer) in new[] {("\\", "\\\\"), ("\"", "\\\""), ("\r", "\\r"), ("\n", "\\n"), ("\t", "\\t")}) {
				result = result.Replace(older, newer);
			}
			for (var index = '\u0000'; index < '\u0020'; index ++) {
				result = result.Replace(index.ToString(), $"\\u{index:X04}");
			}
			return $"\"{result}\"";
		} else if (source is System.Collections.DictionaryEntry cacheC) {
			return $"{ToString(cacheC.Key, indent, repeat)} : {ToString(cacheC.Value, indent, repeat)}";
		} else if (source is System.Collections.IDictionary cacheD) {
			var result = new StringBuilder();
			result.Append('{');
			foreach (var choose in cacheD) {
				result.AppendLine();
				result.Append(ToIndent(indent, repeat + 1));
				result.Append(ToString(choose, indent, repeat + 1));
			}
			result.AppendLine();
			result.Append(ToIndent(indent, repeat));
			result.Append('}');
			return result.ToString();
		} else if (source is System.Collections.IEnumerable cacheE) {
			var result = new StringBuilder();
			result.Append('[');
			foreach (var choose in cacheE) {
				result.AppendLine();
				result.Append(ToIndent(indent, repeat + 1));
				result.Append(ToString(choose, indent, repeat + 1));
			}
			result.AppendLine();
			result.Append(ToIndent(indent, repeat));
			result.Append(']');
			return result.ToString();
		} else if (source is ExceptionParameter cacheY) {
			return $"{cacheY.Name} : {ToString(cacheY.Data, indent, repeat)}";
		} else if (source is Exception cacheZ) {
			var result = new StringBuilder();
			result.Append(cacheZ.GetType());
			result.Append(" {");
			foreach (var choose in ToSource(cacheZ)) {
				result.AppendLine();
				result.Append(ToIndent(indent, repeat + 1));
				switch (choose.Name) {
				case "StackTrace":
					if (choose.Data == null) {
						result.Append("StackTrace : Null");
					} else {
						result.Append("StackTrace : ...");
					}
					break;
				default:
					result.Append(ToString(choose, indent, repeat + 1));
					break;
				}
			}
			result.AppendLine();
			result.Append(ToIndent(indent, repeat));
			result.Append('}');
			return result.ToString();
		} else {
			return $"({source.GetType()}){source}";
		}
	}
	#endregion 内部メソッド定義:ToString

	#region 公開メソッド定義:ToString
	/// <summary>
	/// 例外内容へ変換します。
	/// </summary>
	/// <param name="source">例外情報</param>
	/// <param name="indent">階層内容</param>
	/// <returns>例外内容</returns>
	public static string ToString(Exception source, string indent) =>
		ToString(source, indent, 0);
	#endregion 公開メソッド定義:ToString
}
