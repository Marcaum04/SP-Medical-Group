import { Component } from "react";
import axios from 'axios';

import '../../assets/css/alterar-descricao.css';
import '../../assets/css/grid.css';

import Footer from '../../components/footer/Footer'
import Header from '../../components/header/Header'

export default class AlterarDescricao extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaClinicas: [],
            idConsulta: 0,
            descricao: '',
            isLoading: false
        }
    };

    atualizaConsulta = (event) => {
        event.preventDefault();

        this.setState({ erroMensagem: "", isLoading: true })

        axios.patch(`http://localhost:5000/api/consultas/descricao/${this.state.idConsulta}`, {

            Descricao: this.state.descricao,

        }, {
                      headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {
                if (resposta.status === 204) {
                    this.setState({ isLoading: false });
                    this.props.history.push('/minhasconsultas');
                }
            })
            .catch(() => {
                this.setState({ erroMensagem: "Id Inválido!", isLoading: false })
            });
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }

    componentDidMount() {
    }

    render() {
        return (
            <div>
                <Header></Header>
                <main className="main-alterar-descricao">
                    <form className="form-descricao" onSubmit={this.atualizaConsulta}>
                        <div className="cadastro">
                            <h1>Consulta</h1>
                            <div className="campos">
                                <div className="campo-consulta">
                                    <label>Consulta</label>
                                    <input
                                        name="idConsulta"
                                        type="number"
                                        value={this.state.idConsulta}
                                        onChange={this.atualizaStateCampo} />
                                </div>
                                <div className="campo-descricao">
                                    <label>Descrição</label>
                                    <textarea
                                        name="descricao"
                                        cols="30"
                                        maxLength="100"
                                        value={this.state.descricao}
                                        onChange={this.atualizaStateCampo}></textarea>
                                </div>
                            </div>
                        </div>
                        <p style={{ color: 'red' }}>{this.state.erroMensagem}</p>
              {
                this.state.isLoading === true &&
                <button type="submit" disabled>Loading...</button>
              }
              {
                this.state.isLoading === false &&
                <button disabled={this.state.id === '' || this.state.descricao === '' ? 'none' : ''} type="submit">Cadastrar</button>
              }
                    </form>
                </main>
                <Footer></Footer>
            </div>
        );
    }
}