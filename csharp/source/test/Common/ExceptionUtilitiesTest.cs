namespace Occhitta.Libraries.Common;

/// <summary>
/// <see cref="ExceptionUtilities" />検証クラスです。
/// </summary>
public class ExceptionUtilitiesTest {
	#region 検証メソッド定義:ToSource
	/// <summary>
	/// <see cref="ToSourceCode(Exception, ValueTuple{string, string?}[])" />の検証情報を生成します。
	/// </summary>
	/// <returns>検証集合</returns>
	private static IEnumerable<TestCaseData> ToSourceList() {
		yield return new(new Exception(), new(string, string?)[] {
			("TargetSite",     null),
			("Message",        "Exception of type 'System.Exception' was thrown."),
			("Data",           "System.Collections.ListDictionaryInternal"),
			("InnerException", null),
			("HelpLink",       null),
			("Source",         null),
			("HResult",        "-2146233088"),
			("StackTrace",     null) });
	}
	/// <summary>
	/// <see cref="ExceptionUtilities.ToSource(Exception)" />を検証します。
	/// </summary>
	[TestCaseSource(nameof(ToSourceList))]
	public void ToSourceCode(Exception source, params (string, string?)[] expect) {
		var actual = new List<ExceptionParameter>(ExceptionUtilities.ToSource(source));
		Assert.That(actual, Has.Count.EqualTo(expect.Length));
		Assert.Multiple(() => {
			for (var index = 0; index < expect.Length; index ++) {
				var cache1 = actual[index].Name;
				var cache2 = actual[index].Data?.ToString();
				Assert.That(cache1, Is.EqualTo(expect[index].Item1), "[{0}].Name", index);
				Assert.That(cache2, Is.EqualTo(expect[index].Item2), "[{0}].Data({1})", index, cache1);
			}
		});
	}
	#endregion 検証メソッド定義:ToSource

	#region 検証メソッド定義:ToString
	/// <summary>
	/// <see cref="ToStringCode(Exception, string)" />の検証情報を生成します。
	/// </summary>
	/// <returns>検証集合</returns>
	private static IEnumerable<TestCaseData> ToStringList() {
		yield return new(new Exception().SetData("Name1", "Data1").SetData("Name2", "Data2"), @"System.Exception {
	TargetSite : Void <ToStringCode>b__0()
	Message : ""Exception of type 'System.Exception' was thrown.""
	Data : {
		""Name1"" : ""Data1""
		""Name2"" : ""Data2""
	}
	InnerException : Null
	HelpLink : Null
	Source : ""Occhitta.Libraries.Tester.Test""
	HResult : -2146233088
	StackTrace : ...
}");
		yield return new(new ArgumentNullException("source"), @"System.ArgumentNullException {
	Message : ""Value cannot be null. (Parameter 'source')""
	ParamName : ""source""
	TargetSite : Void <ToStringCode>b__0()
	Data : {
	}
	InnerException : Null
	HelpLink : Null
	Source : ""Occhitta.Libraries.Tester.Test""
	HResult : -2147467261
	StackTrace : ...
}");
		yield return new(new Exception("Failure Message", new ArgumentException("Parameter Error.", "values"))
			.SetData("Flag", true)
			.SetData("Int1", (sbyte  )11)
			.SetData("Int2", (short  )12)
			.SetData("Int4",          13)
			.SetData("Int8", (long   )14)
			.SetData("IntA", (byte   )21)
			.SetData("IntB", (ushort )22)
			.SetData("IntC", (uint   )23)
			.SetData("IntD", (ulong  )24)
			.SetData("IntE", (nint   )25) // IntPtr
			.SetData("IntF", (nuint  )26)
			.SetData("Dec4", (float  )31)
			.SetData("Dec8", (double )32)
			.SetData("DecH", (decimal)33)
			.SetData("IntX", new System.Numerics.BigInteger(34))
			.SetData("Date", new DateOnly(2001, 2, 3))
			.SetData("Time", new TimeOnly(1, 2, 3, 4, 5))
			.SetData("DT01", new DateTime(2001, 2, 3, 4, 5, 6, 7, 8))
			.SetData("DT02", new DateTimeOffset(2001, 2, 3, 4, 5, 6, 7, 8, TimeSpan.FromHours(9)))
			.SetData("Ts01", new TimeSpan(1, 2, 3, 4, 5, 6))
			.SetData("Ts02", new TimeSpan(1, 2, 3, 4, 5, 6).Negate())
			.SetData("Ch-A", 'A')
			.SetData("Ch-B", '\\')
			.SetData("Ch-C", '\'')
			.SetData("Ch-D", '\t')
			.SetData("Ch-E", '\r')
			.SetData("Ch-F", '\n')
			.SetData("Ch-G", '\u0000')
			.SetData("Text", "ABC")
			.SetData("List", new List<string>(["A", "B"]))
			.SetData("Link", new Dictionary<string, object?>() { {"A", "1"}, {"B", 2}})
			.SetData("Data", new object())
			.SetLink("https://github.com/occhitta/library-tester")
			, @"System.Exception {
	TargetSite : Void <ToStringCode>b__0()
	Message : ""Failure Message""
	Data : {
		""Flag"" : True
		""Int1"" : 11B
		""Int2"" : 12S
		""Int4"" : 13
		""Int8"" : 14L
		""IntA"" : 21UB
		""IntB"" : 22US
		""IntC"" : 23U
		""IntD"" : 24UL
		""IntE"" : 25N
		""IntF"" : 26NU
		""Dec4"" : 31F
		""Dec8"" : 32D
		""DecH"" : 33M
		""IntX"" : 34BI
		""Date"" : 2001-02-03
		""Time"" : 01:02:03.0040050
		""DT01"" : 2001-02-03T04:05:06.0070080
		""DT02"" : 2001-02-03T04:05:06.0070080(+09:00)
		""Ts01"" : +01.02:03:04.0050060
		""Ts02"" : -01.02:03:04.0050060
		""Ch-A"" : 'A'
		""Ch-B"" : '\\'
		""Ch-C"" : '\''
		""Ch-D"" : '\t'
		""Ch-E"" : '\r'
		""Ch-F"" : '\n'
		""Ch-G"" : '\u0000'
		""Text"" : ""ABC""
		""List"" : [
			""A""
			""B""
		]
		""Link"" : {
			""A"" : ""1""
			""B"" : 2
		}
		""Data"" : (System.Object)System.Object
	}
	InnerException : System.ArgumentException {
		Message : ""Parameter Error. (Parameter 'values')""
		ParamName : ""values""
		TargetSite : Null
		Data : {
		}
		InnerException : Null
		HelpLink : Null
		Source : Null
		HResult : -2147024809
		StackTrace : Null
	}
	HelpLink : ""https://github.com/occhitta/library-tester""
	Source : ""Occhitta.Libraries.Tester.Test""
	HResult : -2146233088
	StackTrace : ...
}");
	}
	/// <summary>
	/// <see cref="ExceptionUtilities.ToString(Exception)" />を検証します。
	/// </summary>
	/// <param name="source">例外情報</param>
	/// <param name="expect">想定内容</param>
	[TestCaseSource(nameof(ToStringList))]
	public void ToStringCode(Exception source, string expect) {
		var choose = Assert.Catch<Exception>(() => throw source);
		Assert.That(ExceptionUtilities.ToString(choose, "\t"), Is.EqualTo(expect));
	}
	#endregion 検証メソッド定義:ToString
}
