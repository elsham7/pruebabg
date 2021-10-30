import React from "react";

const TabHeader = ({children}) => {
  return (
    <ul className="nav nav-tabs customtab" role="tablist">
      {children}
    </ul>
  );
};

export default TabHeader;
