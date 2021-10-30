import { Link } from "react-router-dom";

function TemaDet() {
    return (
        <div className="right-sidebar">
            <div className="slimscrollright">
                <div className="rpanel-title"> Service Panel <span><i className="ti-close right-side-toggle"></i></span> </div>
                <div className="r-panel-body">
                    <ul id="themecolors" className="m-t-20">
                        <li><b>With Light sidebar</b></li>
                        <li><Link to="#" data-skin="skin-default" className="default-theme">1</Link></li>
                        <li><Link to="#" data-skin="skin-green" className="green-theme">2</Link></li>
                        <li><Link to="#" data-skin="skin-red" className="red-theme">3</Link></li>
                        <li><Link to="#" data-skin="skin-blue" className="blue-theme">4</Link></li>
                        <li><Link to="#" data-skin="skin-purple" className="purple-theme">5</Link></li>
                        <li><Link to="#" data-skin="skin-megna" className="megna-theme working">6</Link></li>
                        <li className="d-block m-t-30"><b>With Dark sidebar</b></li>
                        <li><Link to="#" data-skin="skin-default-dark" className="default-dark-theme ">7</Link></li>
                        <li><Link to="#" data-skin="skin-green-dark" className="green-dark-theme">8</Link></li>
                        <li><Link to="#" data-skin="skin-red-dark" className="red-dark-theme">9</Link></li>
                        <li><Link to="#" data-skin="skin-blue-dark" className="blue-dark-theme">10</Link></li>
                        <li><Link to="#" data-skin="skin-purple-dark" className="purple-dark-theme">11</Link></li>
                        <li><Link to="#" data-skin="skin-megna-dark" className="megna-dark-theme ">12</Link></li>
                    </ul>
                    <ul className="m-t-20 chatonline">
                        <li><b>Chat option</b></li>
                        <li>
                            <Link to="#"><img src="imagenes/1.jpg" alt="user-img" className="img-circle" /> <span>Varun Dhavan <small className="text-success">online</small></span></Link>
                        </li>
                        <li>
                            <Link to="#"><img src="imagenes/2.jpg" alt="user-img" className="img-circle" /> <span>Genelia Deshmukh <small className="text-warning">Away</small></span></Link>
                        </li>
                        <li>
                            <Link to="#"><img src="imagenes/3.jpg" alt="user-img" className="img-circle" /> <span>Ritesh Deshmukh <small className="text-danger">Busy</small></span></Link>
                        </li>
                        <li>
                            <Link to="#"><img src="imagenes/4.jpg" alt="user-img" className="img-circle" /> <span>Arijit Sinh <small className="text-muted">Offline</small></span></Link>
                        </li>
                        <li>
                            <Link to="#"><img src="imagenes/5.jpg" alt="user-img" className="img-circle" /> <span>Govinda Star <small className="text-success">online</small></span></Link>
                        </li>
                        <li>
                            <Link to="#"><img src="imagenes/6.jpg" alt="user-img" className="img-circle" /> <span>John Abraham<small className="text-success">online</small></span></Link>
                        </li>
                        <li>
                            <Link to="#"><img src="imagenes/7.jpg" alt="user-img" className="img-circle" /> <span>Hritik Roshan<small className="text-success">online</small></span></Link>
                        </li>
                        <li>
                            <Link to="#"><img src="imagenes/8.jpg" alt="user-img" className="img-circle" /> <span>Pwandeep rajan <small className="text-success">online</small></span></Link>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default TemaDet;