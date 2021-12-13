import { Component } from "react";
import axios from 'axios';
import { parseJWT } from "../../services/auth";

import '../../assets/css/consultas.css';
import '../../assets/css/cadastrar-consulta.css';
import '../../assets/css/grid.css';

import Footer from '../../components/footer/Footer'
import Header from '../../components/header/Header'

export default class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [],
            idConsulta: '',
            idMedico: 0,
            idPaciente: 0,
            idSituacao: 0,
            dataeHora: "2020-10-20 13:00"
        }
    };

    buscarConsultas = () => {
        axios('http://localhost:5000/api/consultas', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaConsultas: resposta.data });
                    console.log(this.state.listaConsultas);
                }
            })
            .catch((erro) => console.log(erro));
    }

    buscarMinhasConsultas = () => {
        axios('http://localhost:5000/api/consultas/minhas', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaConsultas: resposta.data });
                    console.log(this.state.listaConsultas);
                }
            })
            .catch((erro) => console.log(erro));
    }


    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }

    componentDidMount() {
        parseJWT().role === '1' ? this.buscarConsultas() : this.buscarMinhasConsultas()
    }

    render() {
        return (
            <div>
                <Header></Header>
                <main>
                    <div className="container container_consultas">
                    {
                        parseJWT().role === '1' ? 
                        (<form className="form-cadastro-consulta" action="">
                        <div class="cadastro-consulta">
                            <h1>Consulta</h1>
                            <div class="todos-campos">
                                <div class="campos">
                                    <div class="campo-consulta">
                                        <label for="">Médico</label>
                                        <input
                                            type="number"
                                            value={this.state.idMedico}
                                            onChange={this.atualizaStateCampo} />
                                    </div>
                                    <div class="campo-consulta">
                                        <label for="">Paciente</label>
                                        <input
                                            type="number"
                                            value={this.state.idPaciente}
                                            onChange={this.atualizaStateCampo} />
                                    </div>
                                    <div class="campo-consulta">
                                        <label for="situacao">Situação</label>
                                        <select
                                            class="situacao-cadastro"
                                            id="situacao"
                                            name="situacao"
                                            value={this.state.idTipoEvento}
                                            onChange={this.atualizaStateCampo}>
                                            <option value="" disabled class="neutro"> Escolha uma Situação</option>
                                            <option value="1"> Realizada</option>
                                            <option value="2"> Cancelada</option>
                                            <option value="3"> Agendada</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="campos">
                                    <div class="campo-tempo">
                                        <label for="">Data</label>
                                        <input
                                            class="data"
                                            type="date"
                                            onChange={this.atualizaStateCampo} />
                                    </div>
                                    <div class="campo-tempo">
                                        <label class="hora" for="">Hora</label>
                                        <input
                                            type="time"
                                            onChange={this.atualizaStateCampo} />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <button type="submit">Cadastrar</button>
                    </form>) : (<div></div>)
                    }
                        

                        {this.state.listaConsultas.map((Consulta) => {
                            return (
                                <div key={Consulta.idConsulta}>
                                    <div className={Consulta.idSituacaoNavigation.idSituacao === 1 ? "consulta consulta-verde" : (Consulta.idSituacaoNavigation.idSituacao === 2 ? "consulta consulta-vermelha" : "consulta consulta-amarela")}>
                                        <h1>Consulta {Consulta.idConsulta}</h1>
                                        <div className="conteudo">
                                            <div className="div_info">
                                                <div className="info">
                                                    <h2>Médico</h2>
                                                    <span>{Consulta.idMedicoNavigation.idUsuarioNavigation.nomeUsuario}</span>
                                                </div>
                                                <div className="info">
                                                    <h2>Paciente</h2>
                                                    <span>{Consulta.idPacienteNavigation.idUsuarioNavigation.nomeUsuario}</span>
                                                </div>
                                            </div>
                                            <div className="div_info">
                                                <div className="info">
                                                    <h2>Data</h2>
                                                    <span>{new Date(Consulta.dataeHora).toLocaleDateString('pt-br')}</span>
                                                </div>
                                                <div className="info">
                                                    <h2>Hora</h2>
                                                    <span>{new Date(Consulta.dataeHora).toLocaleTimeString()}</span>
                                                </div>
                                            </div>
                                            <div className="info">
                                                <h2>Situação</h2>
                                                <div className="situacao">
                                                    <span>{Consulta.idSituacaoNavigation.descricao}</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="info descricao">
                                            <h2>Descrição</h2>
                                            <p>{Consulta.descricao}</p>
                                        </div>
                                    </div>
                                </div>
                            );
                        })}
                    </div>
                </main>
                <Footer></Footer>
            </div>
        )
    }
}
