import React from "react";
import Etiqueta from "./Etiqueta";
import { useForm } from "../../contexts/comun/FormProvider";
import MensajeError from "./MensajeError";
import { EsCampoValido, EstiloCampo } from "../../utilities/ValidForm";

const AreaTexto = ({
  formulario = true,
  nombreCampo,
  etiqueta,
  placeholder,
  longitudMaxima = 255,
  requerido = false,
  disabled = false,
  expresionRegular = undefined,
  mensajeError,
  callBackBlur,
  readOnly = false,
  className = '',
  onKeyPress = null,
}) => {
  const { form, setForm, validField, setValidField } = useForm();

  React.useEffect(() => {
    onLoad();
  }, []);

  function onLoad() {
    if (formulario) {
      validField[nombreCampo + "Tipo"] = "text";
      validField[nombreCampo + "Valido"] = undefined;
      validField[nombreCampo + "Requerido"] = requerido;
      validField[nombreCampo + "ExpresionRegular"] = expresionRegular;
      validField[nombreCampo + "MensajeError"] = mensajeError;

      setValidField(validField);
    }
  }

  async function onChange(e) {
    if (formulario) {
      setForm({ ...form, [nombreCampo]: e.target.value });
    }
  }

  async function onBlur() {
    if (formulario) {
      let campoValido = EsCampoValido(
        "text",
        form[nombreCampo],
        requerido,
        expresionRegular
      );

      setValidField({ ...validField, [nombreCampo + "Valido"]: campoValido });
    }

    if (callBackBlur)
      callBackBlur();
  }

  return formulario ?
    (form === undefined ? null :
      <div className="campoFormulario">
        <Etiqueta etiqueta={etiqueta} requerido={requerido} />
        <textarea
          placeholder={placeholder}
          maxLength={longitudMaxima}
          onChange={onChange}
          onBlur={onBlur}
          onKeyPress={onKeyPress}
          disabled={disabled}
          readOnly={readOnly}
          className={EstiloCampo("text", validField[nombreCampo + "Valido"]) + " " + className}
          value={form[nombreCampo] ? form[nombreCampo] : ''}
        />
        <MensajeError
          mensaje={mensajeError}
          campoValido={validField[nombreCampo + "Valido"]}
        />
      </div>) :
    <textarea
      placeholder={placeholder}
      maxLength={longitudMaxima}
      disabled={disabled}
      readOnly={readOnly}
    />

};

export default AreaTexto;
