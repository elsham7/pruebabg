import React from "react";
import CampoRequerido from "./CampoRequerido";

const Etiqueta = ({ etiqueta, requerido,color="#555" }) => {
  if (etiqueta)
    return (
      <label style={{color:color}}>
        {etiqueta}{" "}
        {requerido == true ? <CampoRequerido /> : null}
      </label>
    );
  else return null;
};

export default Etiqueta;
