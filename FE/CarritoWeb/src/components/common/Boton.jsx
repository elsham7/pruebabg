import React from "react";
import { useForm } from "../../contexts/comun/FormProvider";
import notify from "devextreme/ui/notify";
import { EsCampoValido } from "../../utilities/ValidForm";
import Etiqueta from "./Etiqueta";

const Boton = ({
  formulario = true,
  etiqueta,
  conEtiqueta = false,
  claseEstilo,
  icono,
  tipo = "button",
  onClick,
}) => {
  const { form, validField, setValidField, setValidForm } = useForm();

  async function ValidarFomulario() {
    let formularioValido = true;
    for (var [key, value] of Object.entries(form)) {
      if (validField[key + "Valido"] !== false) {
        let campoValido = EsCampoValido(
          validField[key + "Tipo"],
          value,
          validField[key + "Requerido"],
          validField[key + "ExpresionRegular"],
          key
        );
        
        if (campoValido === false && formularioValido === true)
          formularioValido = false;

        validField[key + "Valido"] = campoValido;
        setValidField(validField);
      } else {
        if (formularioValido === true && validField[key + "Valido"] === false)
          formularioValido = false;
      }
    }

    setValidForm(formularioValido);

    if (formularioValido) {
      onClick();
    }
  }

  return (
    formulario === true ?
      <div className="campoFormulario">
        {conEtiqueta === true ? <Etiqueta etiqueta={etiqueta} color="#fff" /> : null}
        <button type={tipo} className={claseEstilo} onClick={ValidarFomulario}>
          <i className={icono} style={{ marginRight: 5 }}></i>
          {etiqueta}
        </button>
      </div> :
      <button type={tipo} className={claseEstilo} onClick={onClick}>
        <i className={icono} style={{ marginRight: 5 }}></i>
        {etiqueta}
      </button>
  );
};

export default Boton;
