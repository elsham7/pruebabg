import MenuActual from "../layout/MenuActual";
import TemaDet from "../layout/TemaDet";

function ContenidoPrincipal({ children }) {
    return (
        <div className="page-wrapper">
            <div className="container-fluid">

                <MenuActual />
                {/* <TemaDet /> */}

                <div className="row">
                    <div className="col-12">
                        <div className="card">
                            <div className="card-body">
                            {children}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ContenidoPrincipal;