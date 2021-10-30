function Logo() {
    return (
        <div className="navbar-header">
            <a className="navbar-brand" href="index.html">
                <b>
                    <img src="imagenes/logo-icon.png" alt="" className="dark-logo" />

                    <img src="imagenes/logo-light-icon.png" alt="" className="light-logo" />
                </b>
                <span className="hidden-xs" id="aplicacion">carrito.com.ec</span>
            </a>
        </div>
    )
}

export default Logo;