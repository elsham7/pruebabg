import React from "react";
import Etiqueta from "./Etiqueta";
import { useForm } from "../../contexts/comun/FormProvider";
import MensajeError from "./MensajeError";
import { EsCampoValido, EstiloCampo } from "../../utilities/ValidForm";
import { Autocomplete } from 'devextreme-react/autocomplete';

const Autocompletar = ({
  formulario = true,
  muestraEtiqueta = true,
  muestraEstiloFormulario = true,
  nombreCampo,
  campoEsNumerico = true,
  propiedadBusqueda = "descripcion",
  lista = [],
  etiqueta,
  placeholder,
  requerido = false,
  disabled = false,
  limpiar = false,
  mensajeError,
  readOnly = false,
  callBackBlur,
  className = '',
  onKeyPress = null,
}) => {
  const { form, setForm, validField, setValidField } = useForm();

  React.useEffect(() => {
    onLoad();
  }, []);

  async function onLoad() {
    if (formulario) {
      validField[nombreCampo + "Tipo"] = "autocompletar";
      validField[nombreCampo + "Valido"] = undefined;
      validField[nombreCampo + "Requerido"] = requerido;
      validField[nombreCampo + "MensajeError"] = mensajeError;

      setValidField(validField);

      await onSetDescripcion();
    }
  }

  async function onChange(e) {

    if (formulario) {

      let valor = e.selectedItem == null ? (campoEsNumerico ? 0 : '') : (campoEsNumerico ? parseInt(e.selectedItem.codigo) : e.selectedItem.codigo);

      setForm({ ...form, [nombreCampo]: valor });

    }

  }

  async function onBlur() {
    if (formulario) {

      let campoValido = EsCampoValido(
        "autocompletar",
        form[nombreCampo],
        requerido,
        undefined
      );

      setValidField({ ...validField, [nombreCampo + "Valido"]: campoValido });
    }

    if (callBackBlur)
      callBackBlur();
  }

  async function onValueChange(e) {    
    setForm({ ...form, [nombreCampo + 'Descripcion']: e });
  }

  async function onSetDescripcion() {
    if (form[nombreCampo] === 0 || form[nombreCampo] === '') {
      setForm({ ...form, [nombreCampo + 'Descripcion']: '' });
    } else {
      let item = lista.find(x => x.codigo === form[nombreCampo]);

      setForm({ ...form, [nombreCampo + 'Descripcion']: item === undefined ? '' : item.descripcion });
    }
  }

  return formulario ?
    (form === undefined ? null :
      <div className={muestraEstiloFormulario ? "campoFormulario" : ""}>
        {muestraEtiqueta === true ? <Etiqueta etiqueta={etiqueta} requerido={requerido} /> : null}
        <Autocomplete
          dataSource={lista}
          placeholder={placeholder}
          valueExpr={propiedadBusqueda}
          disabled={disabled}
          readOnly={readOnly}
          showClearButton={limpiar}
          onKeyPress={onKeyPress}
          onValueChange={onValueChange}
          onSelectionChanged={onChange}
          onFocusOut={onBlur}
          value={form[nombreCampo + 'Descripcion']}
          className={EstiloCampo("autocompletar", validField[nombreCampo + "Valido"]) + " " + className}          
        />
        <MensajeError
          mensaje={mensajeError}
          campoValido={validField[nombreCampo + "Valido"]}
        />
      </div>)
    :
    <Autocomplete
      dataSource={lista}
      placeholder={placeholder}
      valueExpr={propiedadBusqueda}
      disabled={disabled}
      readOnly={readOnly}
      showClearButton={limpiar}
      onKeyPress={onKeyPress}
      onSelectionChanged={onChange}
      className={className}
    />
};

export default Autocompletar;
