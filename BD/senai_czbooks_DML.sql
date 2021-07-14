USE senai_czbooks

INSERT INTO TipoUsuario				(NomeTipoUsuario)
VALUES								('Administrador')
									,('Autor')
									,('Cliente');
GO

INSERT INTO Usuario					(NomeUsuario, Email, Senha, idTipoUsuario)
VALUES								('Adm', 'adm@adm.com', 'adm123', 1)
									,('Mauro', 'mauro@cliente.com', 'mauro123', 3)
									,('Daniel', 'daniel@cliente.com', 'daniel123', 3)
									,('Kaiky', 'kaiky@cliente.com', 'kaiky123', 3)
									,('Douglas Adams', 'douglas@autor.com', 'douglas123', 2)
									,('Reiji Miyajima', 'reiji@autor.com', 'reiji123', 2)
									,('J.K. Rowling ', 'rowling@autor.com', 'rowling123', 2)
									,('Higor Vinicius Nogueira Jorge', 'higor@autor.com', 'higor123', 2)
									,('Lewis Carroll', 'lewis@autor.com', 'lewis123', 2);
GO

INSERT INTO Empresa					(NomeFantasia, Endereco)
VALUES								('CZBooks', 'Rua Peixoto Teresa, 123');
GO


INSERT INTO Categoria				(NomeCategoria)
VALUES								('Ficcao Cientifica')
									,('Romance')
									,('Fantasia')
									,('Policial')
									,('Aventura');
GO

INSERT INTO Livro					(Titulo, Sinopse, idCategoria, idUsuario, DataPublicacao, Preco, idEmpresa)
VALUES								('O guia definitivo do mochileiro das galáxias', 'O Restaurante no Fim do Universo – Arthur Dent e seus companheiros viajam pela Galáxia em uma busca desesperada por algum lugar para comer. 
Depois de fazer a refeição mais estranha de suas vidas, eles seguem pelo espaço e acabam descobrindo a questão fundamental sobre a Vida, 
o Universo e Tudo Mais.', 1, 5, '2020-04-20', 'R$60,00', 1)
									,('Namorada de Aluguel Volume 1', 'Kazuya Kinoshita é um estudante universitário inútil que decide utilizar um aplicativo de relacionamentos depois de ter levado um fora de sua namorada. Assim, 
o rapaz conhece uma bela garota chamada Chizuru Mizuhara e a vida dos dois começa a mudar a partir daí.', 2, 6, '2018-12-28', 'R$27,64', 1)
									,('Harry Potter e a ordem da fênix', 'Harry Potter está em seu quinto ano em Hogwarts e acaba ouvindo que muitos não sabem a verdade sobre seu encontro com Lord Voldemort. 
O Ministro de Mágica, Cornelius Fudge, indica Dolores Umbridge para ser a nova professora de Defesa Contra as Artes das Trevas, por acreditar que Dumbledore planeja tomar seu lugar. 
Porém, os métodos que ela usa são totalmente inapropriados. Harry, então, se reúne com um grupo de alunos para defender sua escola.', 3, 7, '2017-08-19', 'R$48,50', 1)
									,('Investigação Criminal Tecnológica', 'O volume 1 aborda alguns procedimentos práticos de investigação criminal tecnológica, incluindo aspectos essenciais sobre infiltração virtual de agentes na rede mundial de computadores, informações sobre Uber, WhatsApp, Facebook, Twitter, Netflix, PayPal, Ebay, OLX, bem como ferramentas para investigação em fontes abertas e modelos de requisição, auto de materialização de evidências eletrônicas, representação de afastamento de sigilo eletrônico e relatório de investigação.

Para tornar a obra mais didática foram elaborados diagramas, sintetizando a demonstração dos procedimentos apontados nos modelos de documentos da Polícia Judiciária.', 4, 8, '2018-12-28', 'R$42,56', 1)
									,('Alice Através do Espelho', 'Alice retorna após uma longa viagem pelo mundo, e reencontra a mãe. 
No casarão de uma grande festa, percebe a presença de um espelho mágico. A jovem atravessa o objeto e retorna ao País das Maravilhas, onde descobre que o Chapeleiro Maluco e sua família correm risco de morte. 
Para salvar o amigo, Alice deve conversar com o Tempo para voltar às vésperas de um evento traumático e mudar seus destinos cruéis.', 5, 9, '2021-04-07', 'R$42,90', 1);
GO