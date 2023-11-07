<?php
// - Ler Arquivo JSON
$filename = "../moedas.json";
$fp = fopen($filename, "r");
$text = fread($fp, filesize($filename));
fclose($fp);

// - Deserializar JSON
$data = json_decode( $text, true );

// - Funcao para encontrar a moeda pelo nome ou simbolo
function encontrar($lista, $entry) {
	foreach ($lista as &$v) {
		if( $v["nome"] == $entry || $v["simbolo"] == $entry ) {
			return $v;
		}
	}

	// 	- Caso não encontre encerre o Programa
	echo "Moeda nao Encontrada";
	exit(1);
}
?>

---
<?php
// - Printar todas as Moedas
foreach($data as &$v) {
	echo $v["simbolo"]." - ".$v["nome"]." (".($v["pais"]["nome"])." ".($v["pais"]["emoji"])." = $ ".$v["valor"]."\n";
}
?>
---

<?php
// - Perguntar ao usuario a *Moeda Inicial*
$text_moeda_inicial = readline("Digite a Moeda Inicial: ");

// - Encontrar *Moeda Inicial*
$moeda_inicial = encontrar( $data, $text_moeda_inicial );

// - Perguntar ao usuario o *Montante*
$montante = (float) readline("Digite o Montante: ".$moeda_inicial["simbolo"]." " );

// - Perguntar ao usuario a *Moeda Final*
$text_moeda_final = readline("Digite a Moeda Final: ");

// - Encontrar *Moeda Final*
$moeda_final = encontrar( $data, $text_moeda_final );

// - Converte o montante para o montante em Dolar Americano
$montante_em_dolar = $montante / $moeda_inicial["valor"];

// - Converte o montante em Dolar Americano para o montante na Moeda Final
$montante_final = $montante_em_dolar * $moeda_final["valor"];

// - Mostrar Resultado Final
echo "Montante Final: ".$moeda_final["simbolo"]." ".$montante_final."\n";
?>
