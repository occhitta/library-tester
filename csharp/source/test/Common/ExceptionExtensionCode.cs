namespace Occhitta.Libraries.Common;

/// <summary>
/// <see cref="Exception" />拡張関数クラスです。
/// </summary>
internal static class ExceptionExtensionCode {
	/// <summary>
	/// 拡張情報を設定します。
	/// </summary>
	/// <typeparam name="TError">例外種別</typeparam>
	/// <param name="sourceData">例外情報</param>
	/// <param name="extendName">拡張名称</param>
	/// <param name="extendData">拡張情報</param>
	/// <returns>例外情報</returns>
	public static TError SetData<TError>(this TError sourceData, object extendName, object? extendData) where TError : Exception {
		sourceData.Data[extendName] = extendData;
		return sourceData;
	}
	/// <summary>
	/// 参照情報を設定します。
	/// </summary>
	/// <typeparam name="TError">例外種別</typeparam>
	/// <param name="sourceData">例外情報</param>
	/// <param name="updateData">更新情報</param>
	/// <returns>例外情報</returns>
	public static TError SetLink<TError>(this TError sourceData, string? updateData) where TError : Exception {
		sourceData.HelpLink = updateData;
		return sourceData;
	}
}
