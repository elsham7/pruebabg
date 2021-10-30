import React from "react";
import Etiqueta from "./Etiqueta";
import { useForm } from "../../contexts/comun/FormProvider";
import MensajeError from "./MensajeError";
import { EsCampoValido, EstiloCampo } from "../../utilities/ValidForm";
import Select from "react-select";

const Combo = ({
  formulario = true,
  nombreCampo,
  etiqueta,
  placeholder,
  campoEsNumerico = true,
  lista = [],
  requerido = false,
  limpiar = false,
  mensajeError,  
  callBack,
}) => {
  const { form, setForm, validField, setValidField } = useForm();

  React.useEffect(() => {
    if (formulario) {
      validField[nombreCampo + "Tipo"] = "select";
      validField[nombreCampo + "Valido"] = undefined;
      validField[nombreCampo + "Requerido"] = requerido;
      validField[nombreCampo + "MensajeError"] = mensajeError;

      setValidField(validField);
    }
  }, []);

  async function onChange(e) {
    if (formulario) {
      if (e !== null) {
        setForm({ ...form, [nombreCampo]: e.value == '' ? (campoEsNumerico ? 0 : '') : (campoEsNumerico ? parseInt(e.value) : e.value) });

        if (callBack) {
          callBack();
        }
      } else {
        setForm({ ...form, [nombreCampo]: campoEsNumerico ? 0 : '' });
      }
    }
  }

  async function onBlur() {
    if (formulario) {
      let campoValido = EsCampoValido(
        "select",
        form[nombreCampo],
        requerido,
        undefined
      );

      setValidField({ ...validField, [nombreCampo + "Valido"]: campoValido });
    }
  }

  const options = lista.map((item) => {
    return { value: item.codigo, label: item.descripcion };
  });

  return formulario ?
    (form === undefined ? null :
      <div className="campoFormulario">
        <Etiqueta etiqueta={etiqueta} requerido={requerido} />
        <Select
          options={options}
          isClearable={limpiar}
          className={EstiloCampo("select", validField[nombreCampo + "Valido"])}
          value={
            form[nombreCampo] === undefined
              ? ""
              : options.find(
                (x) => x.value === form[nombreCampo].toString()
              )
          }

          placeholder={placeholder}
          onChange={onChange}
          //onMenuClose={()=>{setForm({...form,[nombreCampo]:0})}}        
          closeMenuOnSelect={() => alert()}
          onBlur={onBlur}
        />
        <MensajeError
          mensaje={mensajeError}
          campoValido={validField[nombreCampo + "Valido"]}
        />
      </div>)
    : null

};

export default Combo;
