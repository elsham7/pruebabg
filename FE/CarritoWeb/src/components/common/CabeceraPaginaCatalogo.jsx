import React from "react";
import { render } from "react-dom";
import { Link } from "react-router-dom";

export const CabeceraPaginaCatalogo = ({
  titulo,
  subtitulo,
  icono,
  enlace,
  urlEnlace,
  parametros = null,
}) => {
  let parametrosUrl = "";
  if (parametros !== null) {
    for (var propiedad in parametros) {
      parametrosUrl += `/${parametros[propiedad]}`;
    }
  }

  urlEnlace = urlEnlace + parametrosUrl;

    return (
      
      <div className="cabeceraPaginaCatalogo">
        <div style={{flex:1}}>
          <h4 className="card-title">{titulo}</h4>
          <h6 className="card-subtitle">{subtitulo}</h6>
        </div>
        <Link      
          className="enlace"
          to={urlEnlace}
        >
          <i className={`iconoEnlace ${icono}`}></i> {enlace}
        </Link>
      </div>
    );
  
  
};

export default CabeceraPaginaCatalogo;
