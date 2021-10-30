import React from "react";
import { FormProvider, useForm } from "../../contexts/comun/FormProvider";
import MensajeError from "./MensajeError";

export const Form = ({ children }) => {
  const { validForm } = useForm();
  return (
    <form autoComplete="off">
      {children}
      {/* <MensajeError mensaje='Datos incorrectos, Favor revisar' campoValido={validForm}/> */}
    </form>
  );
};

const Formulario = ({ children, fuenteDatos, setFuenteDatos, onSubmit }) => {
  let camposAValidar = {};

  if (fuenteDatos !== undefined && fuenteDatos !== null) {
    for (var [key, value] of Object.entries(fuenteDatos)) {
      camposAValidar[key + "Tipo"] = "";
      camposAValidar[key + "Valido"] = undefined;
      camposAValidar[key + "Requerido"] = undefined;
      camposAValidar[key + "ExpresionRegular"] = undefined;
      camposAValidar[key + "MensajeError"] = undefined;
    }
  } 

  return (
    <FormProvider
      fuenteDatos={fuenteDatos}
      setFuenteDatos={setFuenteDatos}
      camposAValidar={camposAValidar}
    >
      <Form children={children} onSubmit={onSubmit} />
    </FormProvider>
  );
};

export default Formulario;
