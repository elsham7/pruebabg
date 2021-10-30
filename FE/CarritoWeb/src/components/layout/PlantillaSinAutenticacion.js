import { Route, Switch } from "react-router-dom";
import { rutasPublicas } from '../../routes/rutasPublicas';
import * as page from '../../pages/index'
import Cabecera from "../layout/Cabecera";
import Menu from "../layout/Menu";
import ContenidoPrincipal from "../layout/ContenidoPrincipal";

function PlantillaSinAutenticacion() {

    const routeComponents = rutasPublicas.map(({ path, component }, key) => <Route exact path={path} component={component} key={key} />);

    return (
        <div className="skin-megna fixed-layout">
            <div id="main-wrapper">
                <Cabecera />
                <Menu />
                <ContenidoPrincipal>
                    <Switch>
                        {routeComponents}
                        <Route path='*' component={page.Bienvenida} />
                    </Switch>
                </ContenidoPrincipal>
            </div>
        </div>
    )
}

export default PlantillaSinAutenticacion;