// import React, { useEffect } from 'react';

// import DataGrid, {
//   LoadPanel,
//   Column,
//   FilterRow,
//   Paging,
//   SearchPanel,
//   Export
// } from 'devextreme-react/data-grid';

// import SelectBox from 'devextreme-react/select-box'

// import 'devextreme/dist/css/dx.light.css';
// //import 'devextreme/dist/css/dx.greenmist.css';

// import esMessages from "devextreme/localization/messages/es.json";
// import { locale, loadMessages } from "devextreme/localization";

// import ExcelJS from 'exceljs';
// import saveAs from 'file-saver';
// import { exportDataGrid } from 'devextreme/excel_exporter';

// const data = [
//   { "id": 1, "nombre": "Samuel Alcívar", "genero": "Masculino", "fecha": "12/01/2021" },
//   { "id": 2, "nombre": "Vanessa Fernández", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 3, "nombre": "Samuel David", "genero": "Masculino", "fecha": "12/01/2021" },
//   { "id": 4, "nombre": "Abby", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 5, "nombre": "Anny", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 6, "nombre": "Hugo", "genero": "Masculino", "fecha": "12/01/2021" },
//   { "id": 7, "nombre": "July", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 8, "nombre": "Joel", "genero": "Masculino", "fecha": "12/01/2021" },
//   { "id": 9, "nombre": "Evelym", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 10, "nombre": "Hna Elsita", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 11, "nombre": "Pollito Amarillito", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 12, "nombre": "Samuel Alcívar", "genero": "Masculino", "fecha": "12/01/2021" },
//   { "id": 13, "nombre": "Vanessa Fernández", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 14, "nombre": "Samuel David", "genero": "Masculino", "fecha": "12/01/2021" },
//   { "id": 15, "nombre": "Abby", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 16, "nombre": "Anny", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 17, "nombre": "Hugo", "genero": "Masculino", "fecha": "12/01/2021" },
//   { "id": 18, "nombre": "July", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 19, "nombre": "Joel", "genero": "Masculino", "fecha": "12/01/2021" },
//   { "id": 20, "nombre": "Evelym", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 21, "nombre": "Hna Elsita", "genero": "Femenino", "fecha": "12/01/2021" },
//   { "id": 22, "nombre": "Pollito Amarillito", "genero": "Femenino", "fecha": "12/01/2021" },
// ];

// class App extends React.Component {


//   constructor(props) {
//     super(props);
//     loadMessages(esMessages);
//     locale(navigator.language);
//   }

//   render() {

//     return (
//       <React.Fragment>
//         <DataGrid
//           dataSource={data}
//           allowColumnReordering={true}
//           showBorders={true}
//           rowAlternationEnabled={true}
//           showRowLines={true}
//           hoverStateEnabled={true}
//           onExporting={this.onExporting}
//         // focusedRowEnabled={true}            
//         // keyExpr="id"
//         >
//           <LoadPanel enabled />
//           <FilterRow visible={true} />
//           <SearchPanel visible={true} highlightCaseSensitive={true} />
//           <Paging defaultPageSize={10} />
//           <Export enabled={true} />
//           {/* <Column dataField="id"
//             allowSorting={false}
//             width={100}
//             alignment="center"
//             allowFiltering={false}
//             caption="Imagen"
//             cellRender={cellRender} /> */}
//           <Column dataField="nombre" />
//           <Column dataField="genero" caption="Género" />
//           <Column dataField="fecha"
//             alignment="right"
//             dataType="date"
//             format="dd/MM/yyyy"
//             width={180} />
//         </DataGrid>
//         <SelectBox dataSource={data}
//           searchEnabled={true}
//           displayExpr="nombre"
//           valueExpr="id"
//           defaultValue={3} />
//       </React.Fragment>
//     );
//   }

//   onExporting(e) {
//     const workbook = new ExcelJS.Workbook();
//     const worksheet = workbook.addWorksheet('Main sheet');

//     exportDataGrid({
//       component: e.component,
//       worksheet: worksheet,
//       autoFilterEnabled: true
//     }).then(() => {
//       workbook.xlsx.writeBuffer().then((buffer) => {
//         saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Listado.xlsx');
//       });
//     });
//     e.cancel = true;
//   }

// }

// function cellRender(data) {
//   return <img src={"imagenes/" + data.value + ".jpg"} width={64} alt="user" className="" />;
// }



// export default App;