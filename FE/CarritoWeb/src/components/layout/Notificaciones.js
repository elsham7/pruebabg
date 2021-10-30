import { Link } from "react-router-dom";

function Notificaciones() {
    return (
        <li className="nav-item dropdown">
            <div className="nav-link dropdown-toggle waves-effect waves-dark" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <i className="ti-email"></i>
                <div className="notify"> <span className="heartbit"></span> <span className="point"></span> </div>
            </div>
            <div className="dropdown-menu dropdown-menu-right mailbox animated bounceInDown">
                <ul>
                    <li>
                        <div className="drop-title">Notifications</div>
                    </li>
                    <li>
                        <div className="message-center">
                            <Link to="#">
                                <div className="btn btn-danger btn-circle"><i className="fa fa-link"></i></div>
                                <div className="mail-contnet">
                                    <h5>Luanch Admin</h5> <span className="mail-desc">Just see the my new admin!</span> <span className="time">9:30 AM</span> </div>
                            </Link>
                            <Link to="#">
                                <div className="btn btn-success btn-circle"><i className="ti-calendar"></i></div>
                                <div className="mail-contnet">
                                    <h5>Event today</h5> <span className="mail-desc">Just a reminder that you have event</span> <span className="time">9:10 AM</span> </div>
                            </Link>
                            <Link to="#">
                                <div className="btn btn-info btn-circle"><i className="ti-settings"></i></div>
                                <div className="mail-contnet">
                                    <h5>Settings</h5> <span className="mail-desc">You can customize this template as you want</span> <span className="time">9:08 AM</span> </div>
                            </Link>
                            <Link to="#">
                                <div className="btn btn-primary btn-circle"><i className="ti-user"></i></div>
                                <div className="mail-contnet">
                                    <h5>Pavan kumar</h5> <span className="mail-desc">Just see the my admin!</span> <span className="time">9:02 AM</span> </div>
                            </Link>
                        </div>
                    </li>
                    <li>
                        <div className="nav-link text-center link"> <strong>Check all notifications</strong> <i className="fa fa-angle-right"></i> </div>
                    </li>
                </ul>
            </div>
        </li>
    )
}

export default Notificaciones;