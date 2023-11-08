use std::{fs, io::{self, Write}};
use serde::Deserialize;
use serde_json::from_str;

#[derive(Deserialize)]
struct Pais {
	nome: String,
	emoji: String
}

#[derive(Deserialize)]
struct Moeda {
	nome: String,
	simbolo: String,
	valor: f32,
	pais: Pais
}

// - Funcao para encontrar a moeda pelo nome ou simbolo
fn encontrar<'a>( list:&'a [Moeda], entry:&str ) -> Option<&'a Moeda> {
	for i in list.iter() {
		if i.nome == entry || i.simbolo == entry {
			return Some(i);
		}
	}

	None
}

fn main() {
	// - Ler Arquivo JSON
	let text = fs::read_to_string("../moedas.json")
		.expect("Não foi possivel ler o arquivo");

	// - Deserializar JSON
	let data:Vec<Moeda> = from_str(&text).unwrap();

	// - Printar todas as Moedas
	println!("---");
	for i in data.iter() {
		println!("{} - {} ({} {}) = $ {}",i.simbolo,i.nome,i.pais.nome,i.pais.emoji,i.valor);
	}
	println!("---\n");

	// - Perguntar ao usuario a *Moeda Inicial*
	let ( mut stdout, stdin )= ( io::stdout(), io::stdin() );

	print!( "Digite sua Moeda Inicial: " );
	let _ = stdout.flush();

	let mut text_moeda_inicial = String::new();
	stdin.read_line( &mut text_moeda_inicial )
		.expect( "Erro ao ler entrada" );

	text_moeda_inicial = text_moeda_inicial
		.trim()
		.to_owned();

	// - Encontrar *Moeda Inicial*
	let moeda_inicial = match encontrar(&data, &text_moeda_inicial) {
		Some(t) => t,
		// 	- Caso não encontre encerre o Programa
		None => {
			println!("Moeda nao Encontrada");
			return
		}
	};

	// - Perguntar ao usuario o *Montante*
	print!( "Digite o Montante: {} ",moeda_inicial.simbolo );
	let _ = stdout.flush();

	let mut text_montante = String::new();
	stdin.read_line(&mut text_montante)
		.expect( "Erro ao ler entrada" );

	let montante:f32 = text_montante
		.trim()
		.parse()
		.unwrap();

	// - Perguntar ao usuario a *Moeda Final*
	print!( "Digite sua Moeda Final: " );
	let _ = stdout.flush();

	let mut text_moeda_final = String::new();
	stdin.read_line(&mut text_moeda_final)
		.expect( "Erro ao ler entrada" );

	text_moeda_final = text_moeda_final
		.trim()
		.to_owned();

	// - Encontrar *Moeda Final*
	let moeda_final = match encontrar(&data, &text_moeda_final) {
		Some(t) => t,
		// 	- Caso não encontre encerre o Programa
		None => {
			println!("Moeda nao Encontrada");
			return
		}
	};

	// - Converte o montante para o montante em Dolar Americano
	let montante_em_dolar = montante / moeda_inicial.valor;

	// - Converte o montante em Dolar Americano para o montante na Moeda Final
	let montante_final = montante_em_dolar * moeda_final.valor;

	// - Mostrar Resultado Final
	println!("Montante final: {} {}", moeda_final.simbolo, montante_final);
}