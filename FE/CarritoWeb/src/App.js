import { BrowserRouter as Router } from "react-router-dom";
import { AppProvider, useApp } from './contexts/seguridad/AuthProvider';
import PlantillaConAutenticacion from "./components/layout/PlantillaConAutenticacion";
import PlantillaSinAutenticacion from "./components/layout/PlantillaSinAutenticacion";
import esMessages from "devextreme/localization/messages/es.json";
import { locale, loadMessages } from "devextreme/localization";
import React from "react";

function App() {
  const { stateApp, setStateApp } = useApp();
  const token = localStorage.getItem('token');

  React.useEffect(() => {
    loadMessages(esMessages);
    locale(navigator.language);
  })

  if (token)
    return <PlantillaConAutenticacion />;
  else
    return <PlantillaSinAutenticacion />;

  
}

export default function () {
  return (
    <Router>
      <AppProvider>
        <App />
      </AppProvider>
    </Router>
  );
}

