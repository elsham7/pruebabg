import { Link } from "react-router-dom";
import { ToogleMenu } from "../../utilities/Util"

function Busqueda() {
    return (
        <ul className="navbar-nav mr-auto">
            <li className="nav-item"> <Link className="nav-link nav-toggler d-block d-md-none waves-effect waves-dark" to="/"><i className="ti-menu"></i></Link> </li>
            <li className="nav-item">
                <button type="button"
                    style={{
                        backgroundColor: "transparent",
                        border: "none",
                        overflow: "hidden",
                        outline: "none",
                    }}
                   onClick={ToogleMenu}                   
                    className="nav-link sidebartoggler d-none d-lg-block d-md-block waves-effect waves-dark">

                    <i className="icon-menu"></i>                    
                </button>
                {/* </Link> */}
            </li>

            <li className="nav-item">
                <form className="app-search d-none d-md-block d-lg-block">
                    <input type="text" className="form-control" placeholder="" />
                </form>
            </li>
        </ul>
    )
}

export default Busqueda;