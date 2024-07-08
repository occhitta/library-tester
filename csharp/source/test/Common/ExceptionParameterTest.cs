namespace Occhitta.Libraries.Common;

/// <summary>
/// <see cref="ExceptionParameter" />検証クラスです。
/// </summary>
public class ExceptionParameterTest {
	/// <summary>
	/// <see cref="ExceptionParameter()" />を検証します。
	/// </summary>
	[Test]
	public void Test() {
		var source = new ExceptionParameter();
		Assert.Multiple(() => {
			Assert.That(source.Name, Is.Null);
			Assert.That(source.Data, Is.Null);
		});
	}

	/// <summary>
	/// <see cref="ExceptionParameter(string, object?)" />を検証します。
	/// </summary>
	[TestCase("",     ""    )]
	[TestCase("Name", "Data")]
	public void Test(string name, object? data) {
		var source = new ExceptionParameter(name, data);
		Assert.Multiple(() => {
			Assert.That(source.Name, Is.EqualTo(name));
			Assert.That(source.Data, Is.EqualTo(data));
		});
	}
}
