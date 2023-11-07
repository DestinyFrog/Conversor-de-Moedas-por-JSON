
namespace Moeda {
	public class Pais {
		public string? nome { get; set; }
		public string? emoji { get; set; }
	}

	public class Moeda {
		public string? nome { get; set; }
		public string? simbolo { get; set; }
		public float valor { get; set; }
		public Pais? pais { get; set; }

		public void Print() {
			Console.WriteLine( $"{simbolo} {nome} ({pais?.nome} {pais?.emoji})-> {valor}" );
		}
	}
}