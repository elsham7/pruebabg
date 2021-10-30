import React from "react";
import Combo from "./Combo";
import Texto from "./Texto";

const tiposPersonas = [
  { codigo: "N", descripcion: "Natural" },
  { codigo: "J", descripcion: "Jurídico" },
];

const Persona = ({ state, setState, muestraTipoPersona = false }) => {
  React.useEffect(() => {
    if (!muestraTipoPersona) {
      setState({ ...state, tipoPersona: "N" });
    }
  }, []);

  function TipoPersona() {
    if (muestraTipoPersona) {
      return (
        <Combo
          nombreCampo="tipoPersona"
          lista={tiposPersonas}
          etiqueta="Tipo de Persona"
        />
      );
    } else return null;
  }

  function PersonaNatural() {
    return (
      <React.Fragment>
        <Texto
          nombreCampo="nombres"
          etiqueta="Nombres"
          placeholder="Ingrese los nombres de la persona"
          longitudMaxima={150}
          requerido={true}
          mensajeError="Nombres es requerido"
        />
        <Texto
          nombreCampo="apellidos"
          etiqueta="Apellidos"
          placeholder="Ingrese los apellidos de la persona"
          longitudMaxima={150}
          requerido={true}
          mensajeError="Apellidos es requerido"
        />
      </React.Fragment>
    );
  }

  function PersonaJuridica() {
    return (
      <React.Fragment>
        <Texto
          nombreCampo="razonSocial"
          etiqueta="Razón Social"
          placeholder="Ingrese la razón social"
          longitudMaxima={300}
          requerido={true}
          mensajeError="Razón Social es requerido"
        />
      </React.Fragment>
    );
  }

  return (
    <React.Fragment>
      <TipoPersona />
      {state.tipoPersona == "N" ? <PersonaNatural /> : <PersonaJuridica />}
    </React.Fragment>
  );
};

export default Persona;
