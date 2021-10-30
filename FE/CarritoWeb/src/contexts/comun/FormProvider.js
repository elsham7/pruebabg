import React, { useState, useContext } from 'react';

function FormProvider(props) {
    const form = props.fuenteDatos;
    const setForm = props.setFuenteDatos;    
    const [validField, setValidField] = React.useState(props.camposAValidar);
    const [validForm, setValidForm] = React.useState(true);

    return (
        <AppContext.Provider value={{ form, setForm, validField, setValidField, validForm, setValidForm }} {...props} />
    );
}

export const AppContext = React.createContext({});
const useForm = () => useContext(AppContext);

export { FormProvider, useForm }