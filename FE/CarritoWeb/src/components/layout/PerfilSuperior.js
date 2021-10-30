import { Link,Redirect } from "react-router-dom";
import { useApp } from '../../contexts/seguridad/AuthProvider';
import { useHistory } from "react-router-dom";

function PerfilSuperior() {
    const history = useHistory();
    const { stateApp,setStateApp } = useApp();
    
    async function Logout(){       
        console.log('LOGOUT'); 
        localStorage.clear();
        setStateApp({
            user: null,
            menu: [],
            token: null
        });

        // <Redirect to="/" />
        history.push("/");
    }

    return (
        <li className="nav-item dropdown u-pro">
            <Link className="nav-link dropdown-toggle waves-effect waves-dark profile-pic" to="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <span className="hidden-md-down">{stateApp.user} &nbsp;<i className="fa fa-angle-down"></i></span> </Link>
            <div className="dropdown-menu dropdown-menu-right animated flipInY">
                <Link to="#" className="dropdown-item"><i className="ti-user"></i> My Profile</Link>
                <Link to="#" className="dropdown-item"><i className="ti-wallet"></i> My Balance</Link>
                <Link to="#" className="dropdown-item"><i className="ti-email"></i> Inbox</Link>
                <div className="dropdown-divider"></div>
                <Link to="#" className="dropdown-item"><i className="ti-settings"></i> Account Setting</Link>
                <div className="dropdown-divider"></div>
                <Link to="#" onClick={Logout} className="dropdown-item"><i className="fa fa-power-off"></i> Logout</Link>
            </div>
        </li>
    )
}

export default PerfilSuperior;