using System.Text.Json;

namespace Procura {
	class Procura {
		public List<Moeda.Moeda> Data {get; private set;}

		public Procura() {
			// - Ler Arquivo JSON
			string text = File.ReadAllText("../moedas.json");

			// - Deserializar JSON
			try {
				Data = JsonSerializer.Deserialize<List<Moeda.Moeda>>(text) ?? throw new Exception("Nao foi possivel Serializar");
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				throw;
			}
		}

		// - Funcao para encontrar a moeda pelo nome ou simbolo
		public Moeda.Moeda? Encontrar( string entry ) {
			foreach( var i in Data ) {
				if ( i.nome == entry || i.simbolo == entry ) {
					return i;
				}
			}

			return null;
		}
	}
}
