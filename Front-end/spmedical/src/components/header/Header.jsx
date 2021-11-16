import React from 'react';

import Logo from '../../assets/img/Logo-Vermelho.png';
import Home from '../../assets/img/home-icon.png';
import SobreNos from '../../assets/img/sobrenos-icon.png';
import Consultas from '../../assets/img/consultas-icon.png';
import Perfil from '../../assets/img/perfil-icon.png';

import '../../assets/css/header.css';
import '../../assets/css/grid.css';

export default function Header() {

    return (
        <header>
        <div className="container container_header">
            <img className="logo_header" src={Logo} alt="Logo Vermelho"></img>
            <nav className="nav_header">
                <a href="/"><img className="icone_nav" src={Home} alt="Icone home"></img></a>
                <a href="/sobre-nos"><img className="icone_nav" src={SobreNos} alt="Icone Sobre nós"></img></a>
                <a href="/consultas"><img className="icone_nav" src={Consultas} alt="Icone Consultas"></img></a>
                <a href="/login"><img className="icone_nav" src={Perfil} alt="Icone Perfil"></img></a>
            </nav>
        </div>
    </header>
)}