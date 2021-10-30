import React from 'react'
import { Procesando } from '../../../components/common';
import notify from 'devextreme/ui/notify';
import * as API from '../../../utilities/axios'
import './estilo.css';

const Bienvenida = () => {
    const [procesando, setProcesando] = React.useState(false);
    const [productos, setProductos] = React.useState([]);

    //#region Eventos

    React.useEffect(() => {
        onListado();
    }, []);

    const onListado = async () => {

        try {

            setProcesando(true);

            let res = await API.Fetch('api-venta/transaccion/listado-productos', null, API.tipoContenido.Json);
            
            setProductos(res.data);
            setProcesando(false);


        } catch (error) {
            setProcesando(false);
            let e = await API.Error(error);
            notify(e.mensajeError, e.tipoError, 2000);
        }


    };
    //#endregion

    function ItemProducto({ item }) {
        return (
            <div className="row item">
                <div className="col col-4 text-center">
                    <img src={item.urlImagen+"?cache=1"} className="foto responsive" />
                </div>
                <div className="col col-8">
                    <div>
                        <div style={{ display: 'flex', flexDirection: 'column' }}>
                            <span className="descripcionProducto">{item.descripcion}</span>
                            <br/>
                            <span className="detalleProducto">{item.detalle}</span>
                            <br/>
                            <span className="precio">$ {item.precio}</span>
                            <br/>
                            <a src="#" className="anadir"><i className="fas fa-plus"></i> Añadir</a>
                        </div>
                    </div>
                </div>
            </div>)
    }

    return (procesando ? <Procesando /> :
        productos.map((item) => {
            return <ItemProducto item={item}  key={item.idProducto.toString()} />
        })
    )
}

export default Bienvenida
