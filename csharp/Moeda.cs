
namespace Moeda {
	public class Moeda {
		public string? nome { get; set; }
		public string? simbolo { get; set; }
		public float valor { get; set; }
		public string? pais { get; set; }

		public void Print() {
			Console.WriteLine( $"{simbolo} - {nome} ({pais})-> {valor}" );
		}
	}
}