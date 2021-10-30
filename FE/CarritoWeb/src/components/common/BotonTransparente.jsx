import React from "react";

const BotonTransparente = ({titulo,icono,onClick}) => {
  return (
    <button
      type="button"
      onClick={onClick}
      style={{
        backgroundColor: "transparent",
        border: "none",
        overflow: "hidden",
        outline: "none",        
      }}
    >
      <i className={icono}></i> {titulo}
    </button>
  );
};

export default BotonTransparente;
