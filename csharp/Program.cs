namespace Program {
	public class Program{
		public static void Main(){
			Procura.Procura proc = new();

			// - Printar todas as Moedas
			Console.WriteLine("---");
			foreach (var i in proc.Data)
				i.Print();
			Console.WriteLine("---\n");

			// - Perguntar ao usuario a *Moeda Inicial*
			Console.Write("Digite a Moeda Inicial: ");
			string? inp = Console.ReadLine();
			if ( inp == null ) {
				Console.WriteLine("Erro ao ler entrada");
				return;
			}

			// - Encontrar *Moeda Inicial*
			Moeda.Moeda? moeda_inicial = proc.Encontrar(inp);

			// 	- Caso não encontre encerre o Programa
			if ( moeda_inicial == null ) {
				Console.WriteLine("Moeda nao encontrada");
				return;
			}

			// - Perguntar ao usuario o *Montante*
			Console.Write($"Digite o Montante: {moeda_inicial.simbolo} ");
			inp = Console.ReadLine();
			if ( inp == null ) {
				Console.WriteLine("Erro ao ler entrada");
				return;
			}
			float montante = float.Parse(inp);

			// - Perguntar ao usuario a *Moeda Final*
			Console.Write("Digite a Moeda Final: ");
			inp = Console.ReadLine();
			if ( inp == null ) {
				Console.WriteLine("Erro ao ler entrada");
				return;
			}

			// - Encontrar *Moeda Final*
			Moeda.Moeda? moeda_final = proc.Encontrar(inp);

			// 	- Caso não encontre encerre o Programa
			if ( moeda_final == null ) {
				Console.WriteLine("Moeda nao encontrada");
				return;
			}

			// - Converte o montante para o montante em Dolar Americano
			float montante_em_dolar = montante / moeda_inicial.valor;

			// - Converte o montante em Dolar Americano para o montante na Moeda Final
			float montante_final = montante_em_dolar * moeda_final.valor;

			// - Mostrar Resultado Final
			Console.WriteLine($"Montante final: {moeda_final.simbolo} {montante_final}");
		}
	}
}