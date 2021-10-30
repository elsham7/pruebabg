import React from "react";

const ItemTabBody = ({ id, active = false, children }) => {
  let claseActiva = active === false ? "tab-pane" : "tab-pane active";

  return (
    <div className={claseActiva} id={id} role="tabpanel">
      <div className="card-body">{children}</div>
    </div>
  );
};

export default ItemTabBody;
