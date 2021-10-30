import React from 'react'
import Cargando from '../../assets/images/cargando.gif';

const Procesando = ({align="center"}) => {
    return (
        <div style={{ display:'flex', flexDirection:'row', justifyContent:align }}>
            <img src={Cargando} style={{ width: 40 }} />
        </div>
    )
}

export default Procesando
