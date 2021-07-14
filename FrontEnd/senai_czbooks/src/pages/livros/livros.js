import axios from 'axios';
import { Component } from 'react';
// import { Link } from 'react-router-dom';


class Livros extends Component{
    constructor(props){
        super(props);
        this.state = {
            titulo : '',
            sinopse : '',
            dataPublicacao : new Date(),
            preco : 0,
            idCategoria : 0,
            idUsuario : 0,
            idEmpresa : 0,
            listaLivros : [],
            listaCategoria : [],
            listaAutor : []
        }
    }

    cadastrarLivro = (event) => {
        event.preventDefault();

        this.setState({ isLoading : true })

        let livro = {
            nomeLivro : this.state.titulo,
            sinopse : this.state.sinopse,
            dataPublicacao : new Date( this.state.dataPublicacao),
            preco : this.state.preco,
            idCategoria : this.state.idCategoria,
            idUsuario : this.state.idUsuario,
            idEmpresa : this.state.idEmpresa
        };

        axios.post('http://localhost:5000/api/livro', livro, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 201) {
                console.log('Livro cadastrado!')

                this.setState({ isLoading : false })
            }
        })

        .catch(erro => {
            console.log(erro);

            this.setState({ isLoading : false})
        })

        .then(this.buscarLivros)
    }


    buscarLivros = () => {
        axios('http://localhost:5000/api/livro', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            if (resposta.status === 200) {
                this.setState({listaLivros : resposta.data})

                console.log(this.state.listaLivros)
            }
        })

        .catch(erro => console.log(erro));
    };

    componentDidMount(){
        this.buscarLivros();

    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <div>
                <main>
                <section>
                        {/* Lista de Eventos */}
                        <h2>Lista de Eventos</h2>
                        <table style={{ borderCollapse : 'separate', borderSpacing : 30 }}>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Título</th>
                                    <th>Sinopse</th>
                                    <th>Categoria</th>
                                    <th>Autor</th>
                                    <th>Data de Publicação</th>
                                    <th>Preço</th>
                                </tr>
                            </thead>

                            <tbody>
                                {/* Preenche o corpo da tabela usando a função map() */}

                                {
                                    this.state.listaLivros.map( livro => {
                                        return(
                                            <tr key={livro.idLivro}>
                                                <td>{livro.idLivro}</td>
                                                <td>{livro.titulo}</td>
                                                <td>{livro.sinopse}</td>
                                                <td>{livro.idCategoriaNavigation.nomeCategoria}</td>
                                                <td>{livro.idUsuarioNavigation.nomeUsuario}</td>
                                                <td>{Intl.DateTimeFormat("pt-BR").format(new Date(livro.dataPublicacao))}</td>
                                                <td>{livro.preco}</td>
                                            </tr>
                                        );
                                    } )
                                }
                            </tbody>
                        </table>
                    </section>

                    <section>
                        <h2>Cadastro de Livros</h2>
                        {/* Faz a chamada para a função de cadastro quando botão é pressionado */}
                        <form onSubmit={this.cadastrarLivro}>
                            <div style={{ display : 'flex', flexDirection : 'column', width : '30vw' }}>

                                <input 
                                    // Título
                                    type="text"
                                    name="titulo"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.titulo}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Título do livro"
                                />

                                <input 
                                    required
                                    // Descrição
                                    type="text"
                                    name="sinopse"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.sinopse}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Sinopse do livro"
                                />

 
                                <select
                                    // Tipo de Evento
                                    name="idCategoria"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.idCategoria}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                >
                                    <option value="0">Selecione a categoria do livro</option>

                                    

                                    {
                                        // Percorre a lista de Tipos Eentos e retorna uma opção para cada tema
                                        // definindo o valor como o seu próprio ID

                                        this.state.listaCategoria.map( tema => {
                                            return(
                                                <option key={tema.idCategoria} value={tema.idCategoria}>
                                                    {tema.nomeCategoria}
                                                </option>
                                            );
                                        } )
                                    }
                                </select>


                                <select
                                    // Tipo de Evento
                                    name="idUsuario"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.idUsuario}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                >
                                    <option value="0">Selecione o autor do livro</option>

                                    

                                    {
                                        // Percorre a lista de Tipos Eentos e retorna uma opção para cada tema
                                        // definindo o valor como o seu próprio ID

                                        this.state.listaAutor.map( tema => {
                                            return(
                                                <option key={tema.idUsuario} value={tema.idUsuario}>
                                                    {tema.nomeUsuario}
                                                </option>
                                            );
                                        } )
                                    }
                                </select>
                            

                                <input 
                                    // Data do evento
                                    type="date"
                                    name="dataPublicacao"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.dataPublicacao}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                />

                                <input 
                                    required
                                    // Descrição
                                    type="text"
                                    name="preco"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.preco}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Preço do livro"
                                />

                                {/* Verifica se alguma requisição está em andamento, através do valor do state isLoading */}


                                {
                                    // Caso seja false, renderiza um botão habilitado com o texto 'Cadastrar'
                                    <button type="submit" style = {{width : 100, height : 30}}>
                                        Cadastrar
                                    </button>
                                }

                            </div>
                        </form>
                    </section>
                </main>
            </div>
        )
    }
}

export default Livros;