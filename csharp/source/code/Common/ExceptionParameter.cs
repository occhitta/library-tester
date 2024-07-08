namespace Occhitta.Libraries.Common;

/// <summary>
/// <see cref="Exception" />引数情報構造体です。
/// </summary>
public readonly struct ExceptionParameter(string name, object? data) {
	/// <summary>
	/// 要素名称を取得します。
	/// </summary>
	/// <value>要素名称</value>
	public string Name {
		get;
	} = name;
	/// <summary>
	/// 要素情報を取得します。
	/// </summary>
	/// <value>要素情報</value>
	public object? Data {
		get;
	} = data;
}
