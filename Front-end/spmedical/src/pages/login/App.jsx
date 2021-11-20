import './App.css';
import { Component } from "react";
import axios from 'axios';

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: ''
    }
  };

  efetuaLogin = (event) => {
    event.preventDefault();

    axios.post('http://localhost:5000/api/login', {
      email : this.state.email,
      senha : this.state.senha
    })

    .then(resposta =>{
      if (resposta.status === 200) {
        console.log('Meu token é: ' + resposta.data.token);
        localStorage.setItem('usuario-login', resposta.data.token);
      }
    })
  }

  atualizaStateCampo = (campo) => {
    this.setState({ [campo.target.name] : campo.target.value })
  }

  render() {
    return (
      <div>
        <main>
          <form action="" onSubmit={this.efetuaLogin}>
            <input 
            type="text" 
            name="email" 
            value={this.state.email} 
            onChange={this.atualizaStateCampo}
            placeholder="email"/>
            
            <input 
            type="password" 
            name="senha" 
            value={this.state.senha} 
            onChange={this.atualizaStateCampo}
            placeholder="senha"/>

            <button type="submit">Login</button>
          </form>
        </main>
      </div>
    );
  }
}
