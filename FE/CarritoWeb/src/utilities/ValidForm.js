const EsCampoValido = (tipo, valor, requerido, expresionRegular, nombreCampo = null) => {
    let campoValido = true;

    if (tipo !== '') {
        if (tipo === 'text') {
            valor = valor === null ? '' : valor;

            if (requerido === true || expresionRegular !== undefined) {
                if (requerido === true && expresionRegular === undefined) {
                    campoValido = valor.trim().length > 0 ? true : false;
                }

                if (expresionRegular !== undefined) {
                    campoValido = expresionRegular.test(valor);
                }
            }

        }

        if (tipo === 'number') {
            valor = valor === null ? 0 : valor;

            if (requerido === true && valor <= 0) {
                campoValido = false;
            }
        }

        if (tipo === 'select' && requerido === true && (valor === -1 || valor === 0 || valor === null || valor === undefined || valor === ''))
            campoValido = false;

        if (tipo === 'date' && requerido === true && (valor === '' || valor === null || valor === undefined))
            campoValido = false;

        if (tipo === 'autocompletar' && requerido === true && (valor === 0 || valor === ''))
            campoValido = false;

    }




    return campoValido;
}

const EstiloCampo = (tipo, valido) => {

    if (tipo === 'select') {
        if (valido === undefined || valido === true)
            return ""
        else
            return "campoError";
    }
    else {

        if (valido === undefined || valido === true)
            return "form-control"
        else
            return "form-control campoError";

    }
}

export { EsCampoValido, EstiloCampo }