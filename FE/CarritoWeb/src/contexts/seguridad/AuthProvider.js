import React, { useState, useEffect, useContext, useCallback } from 'react';


function AppProvider(props) {
    const [stateApp, setStateApp] = useState({
        user: null,
        menu: [],
        token: null
    });

    useEffect(() => {
        (async function () {            
            stateApp.token = localStorage.getItem('token');
        })();
    }, []);

    const setFiltro = useCallback((u) => {
        setStateApp({ ...stateApp, user: u });
    }, []);

    return (
        <AppContext.Provider value={{ stateApp, setStateApp }} {...props} />
    );
}

export const AppContext = React.createContext({});
const useApp = () => useContext(AppContext);

export { AppProvider, useApp }