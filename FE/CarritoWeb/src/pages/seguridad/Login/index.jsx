import React from 'react'
import images from '../../../consts/imagenes'
import notify from 'devextreme/ui/notify';
import * as API from '../../../utilities/axios'
import { useApp } from '../../../contexts/seguridad/AuthProvider';
import { Boton, Formulario, Procesando, Texto } from '../../../components/common';

const Login = () => {
    const { stateApp, setStateApp } = useApp();
    const [procesando, setProcesando] = React.useState(false);
    const [state, setState] = React.useState({ username: "", password: "" });

    async function Login() {
        //e.preventDefault();

        try {

            setProcesando(true);

            let res = await API.Fetch('api-seguridad/acceso/login', {
                "username": state.username,
                "password": state.password,
                "urlSubDominio": window.location.hostname,
                "tipoAplicacion": "W"
            }, API.tipoContenido.Json, false);

            localStorage.setItem('token', res.data.loginUser.token);
            localStorage.setItem('tokenRefresh', res.data.loginUser.tokenRefresh);

            setStateApp({ ...stateApp, token: res.data.loginUser.token })
            setProcesando(false);

            notify("Bienvenido a Simedic", "success", 2000);
        } catch (error) {
            setProcesando(false);
            let e = await API.Error(error);
            notify(e.mensajeError, e.tipoError, 2000);
        }


    };

    return (
        <React.Fragment>

            <section className="login-register login-sidebar" style={{ backgroundImage: `url("src/assets/images/logo.png")` }}>
                <div className="login-box card">
                    <div className="card-body">
                        <Formulario fuenteDatos={state} setFuenteDatos={setState}>
                             <div className="text-center">
                                <img src={images.Logo} style={{ marginTop: 100, marginBottom:50 }} />
                            </div>
                            <Texto nombreCampo="username"
                                etiqueta="Usuario"
                                placeholder="Ingrese su usuario"
                                longitudMaxima={50}
                                requerido={true}
                                mensajeError="Usuario es requerido" />
                            <Texto nombreCampo="password"
                                etiqueta="Contraseña"
                                placeholder="Ingrese su contraseña"
                                tipoTeclado="password"
                                longitudMaxima={50}
                                requerido={true}
                                mensajeError="Contraseña es requerida" />
                            {procesando ? <Procesando /> :
                                <Boton etiqueta="Iniciar Sesión"
                                    claseEstilo="btn btn-primary btn-block"
                                    icono="fas fa-pencil"
                                    onClick={Login}
                                />}
                        </Formulario>                        
                    </div>
                </div>
            </section>
        </React.Fragment>
    )
}

export default Login
