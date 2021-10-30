import React from "react";
import Etiqueta from "./Etiqueta";
import { useForm } from "../../contexts/comun/FormProvider";
import MensajeError from "./MensajeError";
import { EstiloCampo } from "../../utilities/ValidForm";
import DateBox from "devextreme-react/date-box";
import * as util from '../../utilities/Util'

const Fecha = ({
  formulario = true,
  nombreCampo,
  etiqueta,
  requerido = false,
  disabled = false,
  mensajeError,
}) => {
  const { form, setForm, validField, setValidField } = useForm();

  React.useEffect(() => {
    onLoad();
  }, []);

  function onLoad() {
    if (formulario) {
      validField[nombreCampo + "Tipo"] = "date";
      validField[nombreCampo + "Valido"] = undefined;
      validField[nombreCampo + "Requerido"] = requerido;
      validField[nombreCampo + "MensajeError"] = mensajeError;

      setValidField(validField);
    }
  }

  // async function onChange(e) {
  //   if (formulario) {

  //     let fecha = util.onToDate(e.previousValue);

  //     setForm({ ...form, [nombreCampo]: fecha });

  //     setValidField({ ...validField, [nombreCampo + "Valido"]: (fecha === null || fecha === '' ? false : true) });
  //   }
  // }

  async function onChange(d) {
    // if (formulario) {

    //   let fecha = util.onToDate(d);

    //   setForm({ ...form, [nombreCampo]: fecha });

    //   setValidField({ ...validField, [nombreCampo + "Valido"]: (fecha === null || fecha === '' ? false : true) });
    // }

    if (formulario) {


      let fecha = '';

      if (d !== null) {
        if (typeof d === 'string')
          fecha = d;
        else
          fecha = `${d.getFullYear()}-${d.getMonth() + 1}-${d.getDate()}`;
          fecha = fecha.replace('/','-')
          fecha = fecha.replace('/','-')
          console.log('fecha=>',fecha,d)
      }
      else
      {
        fecha='';
      }


      setForm({ ...form, [nombreCampo]: fecha });

      setValidField({ ...validField, [nombreCampo + "Valido"]: (fecha === null || fecha === '' ? false : true) });
    }
    
  }

  return formulario ?
    (form === undefined ? null :
      <div className="campoFormulario">
        <Etiqueta etiqueta={etiqueta} requerido={requerido} />
        <DateBox          
          type="date"
          //defaultValue={form[nombreCampo] ? form[nombreCampo] : ""}
          defaultValue={form[nombreCampo]}
          //value="2021-10-28T00:00:00"
          disabled={disabled}
          //displayFormat="EEEE, d/MMM/yyyy"
          //onValueChanged={onChange}
          onValueChange={onChange}
          className={EstiloCampo("text", validField[nombreCampo + "Valido"])}
        />
        <MensajeError
          mensaje={mensajeError}
          campoValido={validField[nombreCampo + "Valido"]}
        />
      </div>)
    : null
};

export default Fecha;
