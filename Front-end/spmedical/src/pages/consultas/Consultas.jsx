import { Component } from "react";
import axios from 'axios';

import '../../assets/css/consultas.css';
import '../../assets/css/grid.css';

import Footer from '../../components/footer/Footer'
import Header from '../../components/header/Header'

export default class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [],
            idConsulta: ''
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


    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }

    componentDidMount() {
        this.buscarConsultas();
    }

    render() {
        return (
            <div>
                <Header></Header>
                <main>
                    <div className="container container_consultas">
                        {this.state.listaConsultas.map((Consulta) => {
                            return (
                                <div className="consulta" key={Consulta.idConsulta}>
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
                                                <div  className="quadrado_situacao"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="descricao">
                                        <h2>Descrição</h2>
                                        <p>{Consulta.descricao}</p>
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
