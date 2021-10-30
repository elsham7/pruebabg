import React from 'react'

const MensajeError = ({ mensaje, campoValido }) => {
    if (campoValido !== undefined) {
        return (
            campoValido ? null : <div style={{marginTop:5}}><span className="textoError">{mensaje}</span></div>
        )
    }else return null;
}

export default MensajeError
