import React from "react";

const ItemTabHeader = ({ id, icono, active = false, titulo }) => {
  id = `#${id}`;
  let claseActiva = active === false ? "nav-link text-gray" : "nav-link active text-gray";

  return (
    <li className="nav-item">
      <a className={claseActiva} data-toggle="tab" href={id} role="tab">
        <i className={icono + " text-gray"}></i> {titulo}
      </a>
    </li>
  );
};

export default ItemTabHeader;
