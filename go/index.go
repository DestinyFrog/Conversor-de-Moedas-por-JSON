package main

import (
	"fmt"
	"os"
	"bufio"
	"errors"
	"encoding/json"
	"strings"
)

type Moeda struct {
	Nome	string	`json:"nome"`
	Simbolo	string	`json:"simbolo"`
	Valor	float32	`json:"valor"`
	Pais	string	`json:"pais"`
}

// - Funcao para encontrar a moeda pelo nome ou simbolo
func Encontrar(data []Moeda, entrada string) (*Moeda,error) {
	entrada = strings.TrimRight(entrada, "\n")

	for _,v := range data {
		if v.Nome == entrada || v.Simbolo == entrada || v.Pais == entrada {
			return &v, nil
		}
	}

	return nil, errors.New("Moeda nao Encontrada")
}

func main() {
	// - Ler Arquivo JSON
	text, err := os.ReadFile( "../moedas.json" )
	if err != nil {
		panic(err)
	}

	// - Deserializar JSON
	var data []Moeda
	json.Unmarshal( text, &data )

	// - Printar todas as Moedas
	fmt.Println("---")
	for _,v := range data {
		fmt.Printf("%s - %s (%s) = %f\n",
			v.Simbolo, v.Nome, v.Pais, v.Valor)
	}
	fmt.Println("---")
	fmt.Println()

	// - Perguntar ao usuario a *Moeda Inicial*
	reader := bufio.NewReader(os.Stdin)

	fmt.Print("Digite a moeda inicial: ")
	text_moeda_inicial, err := reader.ReadString('\n')
	if err != nil {
		panic(err)
	}

	// - Encontrar *Moeda Inicial*
	moeda_inicial, err := Encontrar( data, text_moeda_inicial )

	// 	- Caso não encontre encerre o Programa
	if err != nil {
		panic(err)
	}

	// - Perguntar ao usuario o *Montante*
	var montante float32
	fmt.Printf("Digite o montante: %s ",moeda_inicial.Simbolo)
	fmt.Scan(&montante)

	// - Perguntar ao usuario a *Moeda Final*
	fmt.Print("Digite a moeda final: ")
	text_moeda_final, err := reader.ReadString('\n')
	if err != nil {
		panic(err)
	}

	// - Encontrar *Moeda Final*
	moeda_final, err := Encontrar( data, text_moeda_final )

	// 	- Caso não encontre encerre o Programa
	if err != nil {
		panic( err )
	}

	// - Converte o montante para o montante em Dolar Americano
	montante_em_dolar := montante / moeda_inicial.Valor

	// - Converte o montante em Dolar Americano para o montante na Moeda Final
	montante_final := montante_em_dolar * moeda_final.Valor

	// - Mostrar Resultado Final
	fmt.Printf("Montante final: %s %f", moeda_final.Simbolo, montante_final)
	fmt.Println()
}