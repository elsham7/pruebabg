import React from "react";
import { Route, Switch } from "react-router-dom";
import Cabecera from "../layout/Cabecera";
import Menu from "../layout/Menu";
import ContenidoPrincipal from "../layout/ContenidoPrincipal";
import { rutasPrivadas } from '../../routes/rutasPrivadas';
import * as page from '../../pages/index'


function PlantillaConAutenticacion() {

    const routeComponents = rutasPrivadas.map(({ path, component }, key) => <Route exact path={path} component={component} key={key} />);

    return (
        <div className="skin-megna fixed-layout">
            <div id="main-wrapper">
                <Cabecera />
                <Menu />
                <ContenidoPrincipal>
                    <Switch>
                        {routeComponents}
                        <Route path='*' component={page.NotFound} />
                    </Switch>
                </ContenidoPrincipal>
            </div>
        </div>
    )
}

export default PlantillaConAutenticacion;