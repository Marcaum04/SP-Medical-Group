import { Component } from "react";
import { Link } from 'react-router-dom';

import '../../assets/css/consultas-medico.css';
import '../../assets/css/grid.css';

import Footer from '../../components/footer/Footer'
import Header from '../../components/header/Header'

export default class ConsultasMedico extends Component {
    constructor(props) {
        super(props);
        this.state = {
        }
    };

    render() {
        return (
            <div>
                <Header></Header>
                <main className="main-consultas-medico">
                    <div className="container btns">
                    <Link to="/minhasconsultas"><button className="btn-consultas">Minhas Consultas</button></Link>
                    <Link to="/alterardescricao"><button className="btn-consultas">Adicionar Descrição</button></Link>
                    </div>
                </main>
                <Footer></Footer>
            </div>
        );
    }
}
