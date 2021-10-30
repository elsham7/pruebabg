import React from "react";

const EstadoRegistro = (item) => {
  let className = "";
  if (item.data.idEstado === "A") className = "success";
  else className = "warning";

  return <span className={"label label-" + className}>{item.data.estado}</span>;
};

// const EstadoRegistro = ({item}) => {
//   let className = "";
//   if (item.idEstado === "A") className = "info";
//   else className = "danger";

//   return <span className={"label label-" + className}>{item.estado}</span>;
// };

export default EstadoRegistro;
