import React,{ Component } from 'react';
import axios from 'axios';

import { parseJwt, usuarioAutenticado } from '../../services/auth';


    class Login extends Component {
        constructor(props){
            super(props);
            this.state = {
                email : '',
                senha : '',
                erroMensagem : '',
                isLoading : false
            }
        };
    
        efetuaLogin = (event) => {
            event.preventDefault();
    
            this.setState({ erroMensagem : '', isLoading : true });
    
            axios.post('http://localhost:5000/api/Login', {
                email : this.state.email,
                senha : this.state.senha
            })
    
            .then(resposta => {
                if (resposta.status === 200) {

                    localStorage.setItem('usuario-login', resposta.data.token);

                    console.log('Meu token é: ' + resposta.data.token);

                    this.setState({ isLoading : false })
    

                    let base64 = localStorage.getItem('usuario-login').split('.')[1];

                    console.log(base64);

                    console.log(window.atob(base64));

                    console.log(JSON.parse(window.atob(base64)));
    
                    console.log(parseJwt().role);
    
                    if (parseJwt().role === '1') {
                        this.props.history.push('/livros');
                        console.log('estou logado: ' + usuarioAutenticado());
                    }
    
                    else {
                        this.props.history.push('/livros')
                    }
                }
            })
    
            .catch(() => {
                this.setState({ erroMensagem : 'E-mail ou senha inválidos! Tente novamente.', isLoading : false });
            })
        }
    
        atualizaStateCampo = (campo) => {
            this.setState({ [campo.target.name] : campo.target.value })
        };
    
        render(){
            return(
                <div>
                    <main>
                        <section >
                            <div >
                                <div >
                                    <div >
                                    </div>
                                    <div >
                                        <p>Faça login!!!</p>
                                    </div>
    
                                    <form onSubmit={this.efetuaLogin}>
                                       
                                            <input
                                                id="login__email"
                                                type="text"
                                                name="email"
                                                value={this.state.email}
                                                onChange={this.atualizaStateCampo}
                                                placeholder="username"
                                            />
                                        
                                            <input 
                                                id="login__password"
                                                type="password"
                                                name="senha"
                                                value={this.state.senha}
                                                onChange={this.atualizaStateCampo}
                                                placeholder="password"
                                            />
                                       
    
                                        <p style={{ color : 'green', textAlign : 'center' }}>{this.state.erroMensagem}</p>
    
                                        
    
                                        {
                                            this.state.isLoading === true &&
                                            <div>
                                                <button type="submit" disabled>Loading...</button>
                                            </div>
                                        }
    
                                        {
                                            this.state.isLoading === false &&
                                            <div >
                                                <button
                                                    type="submit"
                                                    disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}>
                                                    Login
                                                </button>
                                            </div>
                                        }
                                    </form>
                                </div>
                            </div>
                        </section>
                    </main>
                </div>
            )
        }
    };
    



//     render(){
//         return(
//             <div>
//                 <main>
//                     <section>
//                         <p>Faça seu Login!!!</p>

//                         <form>
//                             <input 
//                                 type="text"
//                                 name="email"
//                                 value={this.state.email}
//                                 onChange={this.atualizaStateCampo}
//                                 placeholder="username"
//                             />
//                              <input 
//                                 type="password"
//                                 name="senha"
//                                 value={this.state.senha}
//                                 onChange={this.atualizaStateCampo}
//                                 placeholder="password"
//                             />

//                             <button type="submit">

//                             </button>
                        
//                         </form>
                      
//                     </section>
//                 </main>
//             </div>
//         )
//     }

// }



export default Login;
