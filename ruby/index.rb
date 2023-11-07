require 'json'

# - Ler Arquivo JSON
file = File.open "../moedas.json"
text = file.read
file.close

# - Deserializar JSON
data = JSON.parse text

# - Funcao para encontrar a moeda pelo nome ou simbolo
def encontrar( list, entry )
  for v in list
    if v["nome"] == entry or v["simbolo"] == entry then
      return v
    end
  end

  # 	- Caso não encontre encerre o Programa
  puts "Moeda não Encontrada"
  exit 1
end

# - Printar todas as Moedas
puts "---"
for v in data
  puts "#{v["simbolo"]} - #{v["nome"]} (#{v["pais"]["nome"]} #{v["pais"]["emoji"]}) = $ #{v["valor"]}"
end
puts "---\n"

# - Perguntar ao usuario a *Moeda Inicial*
print "Digite a Moeda Inicial: "
STDOUT.flush
text_moeda_inicial = gets.chomp ""

# - Encontrar *Moeda Inicial*
moeda_inicial = encontrar data, text_moeda_inicial

# - Perguntar ao usuario o *Montante*
print "Insira o montante: #{moeda_inicial['simbolo']} "
STDOUT.flush
montante = gets.chomp().to_i

# - Perguntar ao usuario a *Moeda Final*
print "Digite a Moeda Final: "
STDOUT.flush
text_moeda_final = gets.chomp ""

# - Encontrar *Moeda Final*
moeda_final = encontrar data, text_moeda_final

# - Converte o montante para o montante em Dolar Americano
montante_em_dolar = montante / moeda_inicial["valor"]

# - Converte o montante em Dolar Americano para o montante na Moeda Final
montante_final = montante_em_dolar * moeda_final["valor"]

# - Mostrar Resultado Final
puts "Montante Final: #{moeda_final["simbolo"]} #{montante_final}"
