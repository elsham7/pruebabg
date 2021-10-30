import React from 'react'
import { useForm } from "../../contexts/comun/FormProvider";

const Radio = ({ formulario = true,
    id,
    nombreCampo,
    etiqueta,
    callBackChange = null
}) => {

    const { form, setForm, validField, setValidField } = useForm();

    async function onChange(e) {
        if (formulario)
            var a = 1;

        if (callBackChange)
            callBackChange();
    }

    return formulario ?
        (form === undefined ? null :
            <div class="custom-control custom-radio" >
                <input type="radio" id={id} name={nombreCampo} checked={true} class="custom-control-input" />
                <label class="custom-control-label" for={id}>{etiqueta}</label>
            </div>
        )
        : <div class="custom-control custom-radio" >
            <input type="radio" id={id} name={nombreCampo} checked={true} class="custom-control-input" />
            <label class="custom-control-label" for={id}>{etiqueta}</label>
        </div>
}

export default Radio
