import React from 'react'
import Etiqueta from './Etiqueta';
import MensajeError from './MensajeError';
import { useForm } from "../../contexts/comun/FormProvider";
import {  EstiloCampo } from "../../utilities/ValidForm";

const contendidoArchivo = {
    pdf: "application/pdf",
    //pdf: "application/vnd.ms-excel",
    xlsx: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
};

const extensionArchivo = {
    pdf: ".pdf",
    xlsx: ".xlsx"
};


const programa = {
    pdf: "Abrobat PDF",
    xlsx: "Microsoft Excel"
};

const Archivo = ({
    formulario = true,
    muestraEtiqueta = true,
    muestraEstiloFormulario = true,
    nombreCampo,
    etiqueta,
    requerido = false,
    mensajeError,
    tipoArchivo,
    tamanioMaximo = 1,
    className = '', }) => {

    const { form, setForm, validField, setValidField } = useForm();

    const VerificarArchivo = (f) => {
        let archivo = f.target;

        if (archivo.files[0].type != contendidoArchivo[tipoArchivo] || (parseInt(archivo.files[0].size / 1024 / 1024)) > tamanioMaximo) {
            archivo.value = null;

            alert(`Sólo tipo de archivo ${programa[tipoArchivo]} con un tamaño máximo de ${tamanioMaximo}Mb`);
        }

    }

    return form === undefined ? null : (
        formulario ?
            <div className={muestraEstiloFormulario ? "campoFormulario" : ""}>
                {muestraEtiqueta === true ? <Etiqueta etiqueta={etiqueta} requerido={requerido} /> : null}
                <input type="file"
                    value={form[nombreCampo] ? form[nombreCampo] : ''}
                    className={EstiloCampo("text", validField[nombreCampo + "Valido"]) + " " + className}
                    accept={extensionArchivo[tipoArchivo]}
                    onChange={VerificarArchivo} />
                <MensajeError
                    mensaje={mensajeError}
                    campoValido={validField[nombreCampo + "Valido"]}
                />
            </div>
            : <input type="file"
                value={form[nombreCampo] ? form[nombreCampo] : ''}
                //className={EstiloCampo("text", validField[nombreCampo + "Valido"]) + " " + className}
                accept={extensionArchivo[tipoArchivo]}
                onChange={VerificarArchivo} />
    );
}

export default Archivo
