import fs from 'fs'
import readline from 'readline-sync'

// - Ler Arquivo JSON
const text = fs.readFileSync( "../moedas.json",
	{ encoding: "utf-8", flag: "r" } )

// - Deserializar JSON
const data = JSON.parse( text )

// - Funcao para encontrar a moeda pelo nome ou simbolo
function encontrar_moeda( entrada ) {
	// Filtrar Moedas pelo nome ou simbolo
	const moeda = data.filter(
		({nome,simbolo}) =>
			entrada==nome || entrada==simbolo )[0]

	// - Caso não encontre encerre o Programa
	if ( moeda == undefined ) {
		console.log( "Moeda nao Encontrada" )
		process.exit(1)
	}

	return moeda
}

// - Printar todas as Moedas
console.log("---")
data.forEach( ({nome,simbolo,valor,pais}) =>
	console.log(`${simbolo} - ${nome} (${pais.nome} ${pais.emoji}) = $ ${valor}`))
console.log("---\n")

// - Perguntar ao usuario a *Moeda Inicial*
const texto_moeda_inicial = readline.question( "Digite a Moeda Inicial: " )

// - Encontrar a Moeda Inicial
const moeda_inicial = encontrar_moeda( texto_moeda_inicial )

// - Encontrar o montante
const montante = parseFloat( readline.question( `Digite o montante: ${moeda_inicial.simbolo} ` ) )

// - Perguntar ao usuario a *Moeda Final*
const texto_moeda_final = readline.question( "Digite a Moeda Final: " )

// - Encontrar a Moeda Final
const moeda_final = encontrar_moeda( texto_moeda_final )

// - Converte o montante para o montante em Dolar Americano
const montante_em_dolar = montante / moeda_inicial.valor

// - Converte o montante em Dolar Americano para o montante na Moeda Final
const montante_final = montante_em_dolar * moeda_final.valor

// - Mostrar Resultado Final
console.log( `Montante Final: ${moeda_final.simbolo} ${montante_final}` )