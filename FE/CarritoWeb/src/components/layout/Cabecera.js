import Logo from "../layout/Logo";
import Busqueda from "../layout/Busqueda";
import Notificaciones from "../layout/Notificaciones";
import Mensajes from "../layout/Mensajes";
import PerfilSuperior from "../layout/PerfilSuperior";
import TemaCab from "../layout/TemaCab";

function Cabecera() {
    return (
        <header className="topbar">
            <nav className="navbar top-navbar navbar-expand-md navbar-dark">

                <Logo />

                <div className="navbar-collapse">

                    <Busqueda />

                    <ul className="navbar-nav my-lg-0">

                        

                        <PerfilSuperior />

                        {/* <TemaCab /> */}
                    </ul>

                </div>
            </nav>
        </header>
    )
}

export default Cabecera;