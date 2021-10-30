import React from "react";
import { Link } from "react-router-dom";

export const Enlace = ({titulo,icono,urlEnlace, parametros,estiloTitulo="enlace",children}) => {
  
  let parametrosUrl = "";
  if (parametros !== null) {
    for (var propiedad in parametros) {
      parametrosUrl += `/${parametros[propiedad]}`;
    }
  }

  urlEnlace = urlEnlace + parametrosUrl;

  return (
    <Link className={estiloTitulo} to={urlEnlace}>
      <i className={icono}></i> {titulo}
      {children}
    </Link>
  );
 
};

export default Enlace;
