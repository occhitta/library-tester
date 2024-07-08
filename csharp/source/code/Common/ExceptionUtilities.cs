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
	/// <returns>表現情報</returns>
	private static string ToString(char source) {
		return source switch {
			'\\'       => "'\\\\'",
			'\''       => "'\\''",
			'\t'       => "'\\t'",
			'\r'       => "'\\r'",
			'\n'       => "'\\n'",
			< '\u0020' => $"'\\u{(int)source:X04}'",
			_          => $"'{source}'"
		};
	}
	/// <summary>
	/// 表現情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>表現情報</returns>
	private static string ToString(string source) {
		var result = source;
		foreach (var (older, newer) in new[] {("\\", "\\\\"), ("\"", "\\\""), ("\r", "\\r"), ("\n", "\\n"), ("\t", "\\t")}) {
			result = result.Replace(older, newer);
		}
		for (var index = '\u0000'; index < '\u0020'; index ++) {
			result = result.Replace(index.ToString(), $"\\u{(int)index:X04}");
		}
		return $"\"{result}\"";
	}
	#endregion 内部メソッド定義:ToString

	#region 内部メソッド定義:Invoke～
	#region 内部メソッド定義:01～03
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke01(StringBuilder buffer, object? source) {
		if (source is char choose) {
			buffer.Append(ToString(choose));
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke02(StringBuilder buffer, object? source) {
		if (source is string choose) {
			buffer.Append(ToString(choose));
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke03(StringBuilder buffer, object? source) {
		if (source is bool choose) {
			buffer.Append(choose);
			return true;
		} else {
			return false;
		}
	}
	#endregion 内部メソッド定義:01～03

	#region 内部メソッド定義:11～18
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke11(StringBuilder buffer, object? source) {
		if (source is sbyte choose) {
			buffer.Append(choose);
			buffer.Append('B');
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke12(StringBuilder buffer, object? source) {
		if (source is byte choose) {
			buffer.Append(choose);
			buffer.Append("UB");
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke13(StringBuilder buffer, object? source) {
		if (source is short choose) {
			buffer.Append(choose);
			buffer.Append('S');
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke14(StringBuilder buffer, object? source) {
		if (source is ushort choose) {
			buffer.Append(choose);
			buffer.Append("US");
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke15(StringBuilder buffer, object? source) {
		if (source is int choose) {
			buffer.Append(choose);
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke16(StringBuilder buffer, object? source) {
		if (source is uint choose) {
			buffer.Append(choose);
			buffer.Append('U');
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke17(StringBuilder buffer, object? source) {
		if (source is long choose) {
			buffer.Append(choose);
			buffer.Append('L');
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke18(StringBuilder buffer, object? source) {
		if (source is ulong choose) {
			buffer.Append(choose);
			buffer.Append("UL");
			return true;
		} else {
			return false;
		}
	}
	#endregion 内部メソッド定義:11～18

	#region 内部メソッド定義:21～23
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke21(StringBuilder buffer, object? source) {
		if (source is float choose) {
			buffer.Append(choose);
			buffer.Append('F');
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke22(StringBuilder buffer, object? source) {
		if (source is double choose) {
			buffer.Append(choose);
			buffer.Append('D');
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke23(StringBuilder buffer, object? source) {
		if (source is decimal choose) {
			buffer.Append(choose);
			buffer.Append('M');
			return true;
		} else {
			return false;
		}
	}
	#endregion 内部メソッド定義:21～23

	#region 内部メソッド定義:31～33
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke31(StringBuilder buffer, object? source) {
		if (source is nint choose) {
			buffer.Append(choose);
			buffer.Append('N');
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke32(StringBuilder buffer, object? source) {
		if (source is nuint choose) {
			buffer.Append(choose);
			buffer.Append("NU");
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke33(StringBuilder buffer, object? source) {
		if (source is System.Numerics.BigInteger choose) {
			buffer.Append(choose);
			buffer.Append("BI");
			return true;
		} else {
			return false;
		}
	}
	#endregion 内部メソッド定義:31～33

	#region 内部メソッド定義:41～45
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke41(StringBuilder buffer, object? source) {
		if (source is DateOnly choose) {
			buffer.Append(choose.ToString("yyyy-MM-dd"));
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke42(StringBuilder buffer, object? source) {
		if (source is TimeOnly choose) {
			buffer.Append(choose.ToString("HH:mm:ss.fffffff"));
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke43(StringBuilder buffer, object? source) {
		if (source is DateTime choose) {
			buffer.Append(choose.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff"));
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke44(StringBuilder buffer, object? source) {
		if (source is DateTimeOffset choose) {
			buffer.Append(choose.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffzzz"));
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke45(StringBuilder buffer, object? source) {
		if (source is not TimeSpan choose) {
			return false;
		} else if (choose.Ticks < 0) {
			buffer.Append(choose.ToString("'-'dd'.'hh':'mm':'ss'.'fffffff"));
			return true;
		} else {
			buffer.Append(choose.ToString("'+'dd'.'hh':'mm':'ss'.'fffffff"));
			return true;
		}
	}
	#endregion 内部メソッド定義:41～45

	#region 内部メソッド定義:51～53
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke51(StringBuilder buffer, object? source, string indent, int repeat) {
		if (source is System.Collections.DictionaryEntry choose) {
			ToString(buffer, choose.Key, indent, repeat);
			buffer.Append(" : ");
			ToString(buffer, choose.Value, indent, repeat);
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke52(StringBuilder buffer, object? source, string indent, int repeat) {
		if (source is System.Collections.IDictionary choose) {
			buffer.Append('{');
			foreach (var value in choose) {
				buffer.AppendLine();
				buffer.Append(ToIndent(indent, repeat + 1));
				ToString(buffer, value, indent, repeat + 1);
			}
			buffer.AppendLine();
			buffer.Append(ToIndent(indent, repeat));
			buffer.Append('}');
			return true;
		} else {
			return false;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke53(StringBuilder buffer, object? source, string indent, int repeat) {
		if (source is System.Collections.IEnumerable choose) {
			buffer.Append('[');
			foreach (var value in choose) {
				buffer.AppendLine();
				buffer.Append(ToIndent(indent, repeat + 1));
				ToString(buffer, value, indent, repeat + 1);
			}
			buffer.AppendLine();
			buffer.Append(ToIndent(indent, repeat));
			buffer.Append(']');
			return true;
		} else {
			return false;
		}
	}
	#endregion 内部メソッド定義:51～53

	#region 内部メソッド定義:91～92
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke91(StringBuilder buffer, object? source, string indent, int repeat) {
		if (source is not ExceptionParameter choose) {
			return false;
		} else if (choose.Name == "StackTrace") {
			buffer.Append(choose.Name);
			buffer.Append(" : ");
			buffer.Append(choose.Data == null? "Null": "...");
			return true;
		} else {
			buffer.Append(choose.Name);
			buffer.Append(" : ");
			ToString(buffer, choose.Data, indent, repeat);
			return true;
		}
	}
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke92(StringBuilder buffer, object? source, string indent, int repeat) {
		if (source is Exception choose) {
			buffer.Append(source.GetType());
			buffer.Append(" {");
			foreach (var value in ToSource(choose)) {
				buffer.AppendLine();
				buffer.Append(ToIndent(indent, repeat + 1));
				ToString(buffer, value, indent, repeat + 1);
			}
			buffer.AppendLine();
			buffer.Append(ToIndent(indent, repeat));
			buffer.Append('}');
			return true;
		} else {
			return false;
		}
	}
	#endregion 内部メソッド定義:91～92

	#region 内部メソッド定義:00/10/20/30/40/50/90/99
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke00(StringBuilder buffer, object? source) =>
		Invoke01(buffer, source) || Invoke02(buffer, source) || Invoke03(buffer, source);
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke10(StringBuilder buffer, object? source) =>
		Invoke11(buffer, source) || Invoke12(buffer, source) || Invoke13(buffer, source) || Invoke14(buffer, source) ||
		Invoke15(buffer, source) || Invoke16(buffer, source) || Invoke17(buffer, source) || Invoke18(buffer, source);
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke20(StringBuilder buffer, object? source) =>
		Invoke21(buffer, source) || Invoke22(buffer, source) || Invoke23(buffer, source);
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke30(StringBuilder buffer, object? source) =>
		Invoke31(buffer, source) || Invoke32(buffer, source) || Invoke33(buffer, source);
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke40(StringBuilder buffer, object? source) =>
		Invoke41(buffer, source) || Invoke42(buffer, source) || Invoke43(buffer, source) || Invoke44(buffer, source) || Invoke45(buffer, source);
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke50(StringBuilder buffer, object? source, string indent, int repeat) =>
		Invoke51(buffer, source, indent, repeat) || Invoke52(buffer, source, indent, repeat) || Invoke53(buffer, source, indent, repeat);
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke90(StringBuilder buffer, object? source, string indent, int repeat) =>
		Invoke91(buffer, source, indent, repeat) || Invoke92(buffer, source, indent, repeat);
	/// <summary>
	/// 要素情報を登録します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	/// <returns>登録した場合、<c>True</c>を返却</returns>
	private static bool Invoke99(StringBuilder buffer, object? source, string indent, int repeat) =>
		Invoke00(buffer, source) || Invoke10(buffer, source) || Invoke20(buffer, source) || Invoke30(buffer, source) || Invoke40(buffer, source) ||
		Invoke50(buffer, source, indent, repeat) || Invoke90(buffer, source, indent, repeat);
	#endregion 内部メソッド定義:00/10/20/30/40/50/90/99
	#endregion 内部メソッド定義:Invoke～

	#region 内部メソッド定義:ToString
	/// <summary>
	/// 例外内容へ変換します。
	/// </summary>
	/// <param name="buffer">格納情報</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層内容</param>
	/// <param name="repeat">繰返回数</param>
	private static void ToString(StringBuilder buffer, object? source, string indent, int repeat) {
		if (source == null) {
			buffer.Append("Null");
		} else if (Invoke99(buffer, source, indent, repeat)) {
			// 処理なし
		} else {
			buffer.Append($"({source.GetType()}){source}");
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
	public static string ToString(Exception source, string indent) {
		var result = new StringBuilder();
		Invoke92(result, source, indent, 0);
		return result.ToString();
	}
	#endregion 公開メソッド定義:ToString
}
