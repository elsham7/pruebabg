import React from "react";
import { Boton, BotonTransparente } from ".";

export const CabeceraPagina = ({
  titulo,
  subtitulo,
  acciones
}) => {


  return (
    <div className="cabeceraPagina">
      <div style={{ flex: 1 }}>
        <h4 className="card-title">{titulo}</h4>
        <h6 className="card-subtitle">{subtitulo}</h6>
      </div>
      {acciones ?
        acciones.map((item) => {
          if (item.transparente)
            return <BotonTransparente titulo={item.titulo}
              icono={item.icono}
              onClick={item.accion} />
          else
            return <Boton
              formulario={false}
              etiqueta={item.titulo}
              icono={item.icono}
              claseEstilo={item.boton}
              onClick={item.accion} />
        })
        : null}
    </div>
  );
};

export default CabeceraPagina;
