import React from 'react';
import Logo from '../../assets/img/Logo-Vermelho.png';

import '../../assets/css/footer.css';
import '../../assets/css/grid.css';

export default function Footer() {

    return (
        <footer className="container">
            <img className="logo_footer" src={Logo} alt="Logo Vermelho"></img>
                <div className="footer_info">
                    <span>E-mail</span>
                    <span>spmedical.group@gmail.com</span>
                </div>
                <div className="footer_info">
                    <span>Telefone</span>
                    <span>2569-3372</span>
                </div>
        </footer>
)}