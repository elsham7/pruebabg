import ExcelJS from 'exceljs';
import saveAs from 'file-saver';
import { exportDataGrid } from 'devextreme/excel_exporter';

export const onExportarExcel = (e, nombreArchivo) => {
  const workbook = new ExcelJS.Workbook();
  const worksheet = workbook.addWorksheet('Main sheet');

  exportDataGrid({
    component: e.component,
    worksheet: worksheet,
    autoFilterEnabled: true
  }).then(() => {
    workbook.xlsx.writeBuffer().then((buffer) => {
      saveAs(new Blob([buffer], { type: 'application/octet-stream' }), `${nombreArchivo}.xlsx`);
    });
  });
  e.cancel = true;
}

export const LimpiarObjeto = (obj) => {
  for (var propName in obj) {
    if (obj[propName] === null || obj[propName] === undefined) {
      delete obj[propName];
    }
  }
  return obj;
}

export const ToogleMenu = () => {
  var body = document.getElementById('cuerpo');
  var aplicacion = document.getElementById('aplicacion');

  let encontro = body.classList.contains("mini-sidebar");

  if (encontro) {
    // document.getElementById('cuerpo').classlist.remove("mini-sidebar");
    // document.getElementById('aplicacion').classlist.remove("none");

    body.classList.remove("mini-sidebar");
    aplicacion.classList.remove("none");
  } else {
    // document.getElementById('cuerpo').classlist.add("mini-sidebar");
    // document.getElementById('aplicacion').classlist.add("none");

    body.classList.add("mini-sidebar");
    aplicacion.classList.add("none");
  }
}

export const OpcionesCombo = (listado, codigo = "codigo", descripcion = "descripcion") => {
  let options = [];
  options = listado.map((item) => {
    return { value: item[codigo], label: item[descripcion] };
  });
  console.log(options);
  return options;
}

export const onToDate = (fecha) => {
  if (fecha !== null) {
    if (typeof fecha === 'string') {
      console.log('S');
      return fecha.replace('/', '-');
    }
    else {
      console.log('D');
      return `${fecha.getFullYear()}-${fecha.getMonth() + 1}-${fecha.getDate()}`;
    }
  }
  else
    return ''
}