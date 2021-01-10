Funcionalidade: Calculo de juros compostos

Cenário: SimulacaoCalculo01
	Dado que o valor do empréstimo foi R$ 10000,00
	E foi definida uma taxa de 2% mensais
	E em um período de 12 meses
	Quando eu solicitar o valor ao final do período
	Então o valor total a ser pago será R$ 12682,42

Cenário: SimulacaoCalculo02
	Dado que o valor do empréstimo foi R$ 11937,28
	E foi definida uma taxa de 4% mensais
	E em um período de 24 meses
	Quando eu solicitar o valor ao final do período
	Então o valor total a ser pago será R$ 30598,88

Cenário: SimulacaoCalculo03
	Dado que o valor do empréstimo foi R$ 15000,00
	E foi definida uma taxa de 6% mensais
	E em um período de 36 meses
	Quando eu solicitar o valor ao final do período
	Então o valor total a ser pago será R$ 122208,78