import json

# - Ler Arquivo JSON
with open("../moedas.json") as file:
	text = file.read()

# - Deserializar JSON
data = json.loads( text )

# - Funcao para encontrar a moeda pelo nome ou simbolo
def encontrar(lista, entry:str):
    for m in lista:
        if m.get("nome") == entry or m.get("simbolo") == entry or m.get("pais") == entry:
            return m

    # 	- Caso não encontre encerre o Programa
    print("Moeda nao encontrada")
    exit()

# - Printar todas as Moedas
print("---")
for m in data:
    print(f"{m.get('simbolo')} - {m.get('nome')} ({m.get('pais')}) = {m.get('valor')}")
print("---\n")

# - Perguntar ao usuario a *Moeda Inicial*
txt = input("Digite a Moeda Inicial: ")

# - Encontrar *Moeda Inicial*
moeda_inicial = encontrar( data, txt )

# - Perguntar ao usuario o *Montante*
txt = input(f"Digite o montante: {moeda_inicial.get('simbolo')} ")
montante = float( txt )

# - Perguntar ao usuario a *Moeda Final*
txt = input("Digite a Moeda Final: ")

# - Encontrar *Moeda Final*
moeda_final = encontrar( data, txt )

# - Converte o montante para o montante em Dolar Americano
montante_em_dolar = montante / moeda_inicial.get("valor")

# - Converte o montante em Dolar Americano para o montante na Moeda Final
montante_final = montante_em_dolar * moeda_final.get("valor")

# - Mostrar Resultado Final
print(f"Montante final: {moeda_final.get('simbolo')} {montante_final}")