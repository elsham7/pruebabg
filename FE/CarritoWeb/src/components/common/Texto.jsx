import React from "react";
import Etiqueta from "./Etiqueta";
import { useForm } from "../../contexts/comun/FormProvider";
import MensajeError from "./MensajeError";
import { EsCampoValido, EstiloCampo } from "../../utilities/ValidForm";

const Texto = ({
  formulario = true,
  muestraEtiqueta = true,
  muestraEstiloFormulario = true,
  nombreCampo,
  etiqueta,
  placeholder,
  tipoTeclado = "text",
  numeroDecimales = 0,
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
      validField[nombreCampo + "Tipo"] = tipoTeclado;
      validField[nombreCampo + "Valido"] = undefined;
      validField[nombreCampo + "Requerido"] = requerido;
      validField[nombreCampo + "ExpresionRegular"] = expresionRegular;
      validField[nombreCampo + "MensajeError"] = mensajeError;

      setValidField(validField);
    }
  }

  async function onChange(e) {
    if (formulario)

      if (tipoTeclado === 'number')
        setForm({ ...form, [nombreCampo]: e.target.value === '' ? 0 : (numeroDecimales === 0 ? parseInt(e.target.value) : parseFloat(e.target.value)) });
      else
        setForm({ ...form, [nombreCampo]: e.target.value });

  }

  async function onBlur() {
    if (formulario) {
      let campoValido = EsCampoValido(
        tipoTeclado,
        form[nombreCampo],
        requerido,
        expresionRegular
      );

      setValidField({ ...validField, [nombreCampo + "Valido"]: campoValido });

    }

    if (callBackBlur)
      callBackBlur();
  }

  return form === undefined ? null : (
    formulario ?
      <div className={muestraEstiloFormulario ? "campoFormulario" : ""}>
        {muestraEtiqueta === true ? <Etiqueta etiqueta={etiqueta} requerido={requerido} /> : null}
        <input
          type={tipoTeclado}
          placeholder={placeholder}
          maxLength={longitudMaxima}
          onChange={onChange}
          onBlur={onBlur}
          onKeyPress={onKeyPress}
          disabled={disabled}
          readOnly={readOnly}
          value={form[nombreCampo] ? form[nombreCampo] : ''}
          className={EstiloCampo("text", validField[nombreCampo + "Valido"]) + " " + className}
        />
        <MensajeError
          mensaje={mensajeError}
          campoValido={validField[nombreCampo + "Valido"]}
        />
      </div>
      : <input
        type={tipoTeclado}
        placeholder={placeholder}
        maxLength={longitudMaxima}
        onChange={onChange}
        onBlur={onBlur}
        onKeyPress={onKeyPress}
        disabled={disabled}
        readOnly={readOnly}
        className={className}
      />
  );
};

export default Texto;
