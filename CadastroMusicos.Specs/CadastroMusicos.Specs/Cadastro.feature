#language: pt-br

Funcionalidade: Cadastro
	Como um usuário
	Desejo me cadastrar na aplicação
	Assim posso usar a funcionalidade de busca e ser encontrado por outras pessoas


Cenário: 1) Quando o usuário acessar a página de cadastro, o formulário deverá ser exibido
	Dado Um Visitante não cadastrado acessou a tela inicial
	Quando Clicar no botão Quero Me Cadastrar
	Então O formulário de Cadastro será exibido com os campos: Nome, Email, Instrumento, Senha
	E será exibido o botão Cadastrar

Cenário: 2) Quando o usuário acessar os campos e clicar em Cadastrar, deverá receber mensagem de confirmação
	Dado Um Visitante não cadastrado acessou a tela de cadastro
	Quando Preencher todos os campos
	| Nome   | Email              | Instrumento | Senha |
	| Deyvid | deyvid@exemplo.com | 1           | 1234  |
	E Clicar no botão cadastrar
	Então A seguinte mensagem será exibida por 4 segundos conforme layout especificado: Cadastro efetuado com sucesso!
	E o usuário será redirecionado para a tela inicial

Cenário: 3) Quando o usuário não preencher um ou mais campos obrigatórios e clicar em Cadastrar, receberá um alerta
	Dado Um Visitante não cadastrado acessou a tela de cadastro
	Quando Preencher todos os campos exceto um obrigatório
	| Nome   | Email              | Instrumento | Senha |
	|		 | deyvid@exemplo.com | 1           | 1234  |
	E Clicar no botão cadastrar
	Então A seguinte mensagem será exibida conforme layout especificado: Todos os campos obrigatórios devem ser preenchidos.