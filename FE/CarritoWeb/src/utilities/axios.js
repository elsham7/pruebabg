import axios from 'axios';

const urlBase = 'http://localhost:6101/';

export const tipoContenido = {
    Json: 'application/json',
    Form: 'application/x-www-form-urlencoded'
}

let token = '';
let tokenRefresh = '';

export async function ExisteConexionInternet() {

    if (!navigator.onLine) {
        throw { message: "Favor verifica que tienes datos o wifi disponible y vuelve a intentarlo." };
    }

    return true;
}

export async function Error(error) {
    console.log('ERROR=>', error);
    console.log('ERROR_RESPONSE=>', error.response);
    let mensajeError = '';
    let tipoError = 'error';

    if (error.response !== undefined) {
        switch (error.response.status) {
            case 400:// BadRequest
                mensajeError = 'Existen datos incorrectos';
                tipoError = 'warning';
                break;

            case 401:// Unauthorized
                mensajeError = 'Credenciales incorrectas';
                tipoError = 'error';
                break;

            case 403:// Forbidden 
                mensajeError = 'No tiene acceso a este recurso';
                tipoError = 'warning';
                break;

            case 429:// InternalServerError
                mensajeError = "Existen muchas peticiones muy seguido";
                tipoError = 'error';
                break;

            case 500:// InternalServerError
                mensajeError = "Por el momento estamos en mantenimiento, favor inténtelo mas tarde.";
                tipoError = 'error';
                break;

        }
    } else
        mensajeError = error.message;


    return { tipoError, mensajeError };
}

export async function Fetch(urlPoint = '', params = {}, contentType = '', usaToken = true) {

    if (await ExisteConexionInternet()) {

        const axiosApiInstance = axios.create();

        let bodyParams = '';

        await GetToken();

        if (contentType == tipoContenido.Form) {
            var formData = new FormData();

            for (var k in params) {
                formData.append(k, params[k]);
            }

            bodyParams = formData;

        }

        if (contentType == tipoContenido.Json) {
            bodyParams = JSON.stringify(params);
        }


        axiosApiInstance.interceptors.request.use(
            async config => {
                if (usaToken) {
                    config.headers = {
                        'Authorization': `Bearer ${token}`,
                        'Content-Type': contentType
                    }
                } else {
                    config.headers = {
                        'Content-Type': contentType
                    }
                }

                return config;
            },
            error => {
                Promise.reject(error)
            });

        if (usaToken) {

            axiosApiInstance.interceptors.response.use((response) => {
                return response
            }, async function (error) {

                const originalRequest = error.config;

                if (error.response.status === 401 && !originalRequest._retry) {

                    originalRequest._retry = true;

                    //await GetToken();
                    const refreshAccessToken = await RefreshAccessToken();

                    await SetToken(refreshAccessToken.token, refreshAccessToken.tokenRefresh);

                    axios.defaults.headers.common['Authorization'] = 'Bearer ' + refreshAccessToken.token;

                    return axiosApiInstance(originalRequest);
                }
                return Promise.reject(error);
            });
        }

        return await axiosApiInstance.post(urlBase + urlPoint, bodyParams);
    }

}

async function SetToken(t, tr) {
    localStorage.setItem('token', t);
    localStorage.setItem('tokenRefresh', tr);
    token = t;
    tokenRefresh = tr;
}

async function GetToken() {
    token = localStorage.getItem('token');
    tokenRefresh = localStorage.getItem('tokenRefresh');
}

const RefreshAccessToken = async () => {

    let res = await axios({
        method: 'POST',
        url: urlBase + 'api-seguridad/acceso/refreshToken',
        data: {
            "token": token,
            "tokenRefresh": tokenRefresh
        },
        headers: {
            'Content-Type': 'application/json',
        }
    });

    return res.data;

}
