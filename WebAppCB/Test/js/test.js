function echoping() {

    $.ajax({
        url: 'http://localhost:1898/api/devices/echoping',
        dataType: 'json',
        type: 'get',
        success: function (response) {
            alert(JSON.stringify(response));
        },
        error: function (xhr, status, error) {
            alert("Error: " + xhr.responseText + " - " + error);
        }
    });

}

function list() {

    var request = {
        OrderByMunicipio: document.getElementById("listarOrderByMunicipio").checked,
        OrderByCodigoPostal: document.getElementById("listarOrderByCodigoPostal").checked,
        FilterMunicipioCode: document.getElementById("listarFilterMunicipioCode").value,
        FilterMunicipioNombre: document.getElementById("listarFilterMunicipioNombre").value,
        IsPublico: document.getElementById("listarIsPublico").checked,
        IsPrivado: document.getElementById("listarIsPrivado").checked
    };
    document.getElementById("listarBody").innerHTML = 
        "<tr>"
        + "<td>Loading...</td><td></td><td></td><td></td><td></td><td></td></tr > ";

    $.ajax({
        data: request,
        url: 'http://localhost:1898/api/devices/devices',
        dataType: 'json',
        type: 'post',
        success: function (response) {
            document.getElementById("listarBody").innerHTML = "";
            setTimeout(() => {
                var i = 0;
                while (i < Object.keys(response.DEAList).length && i < 750) {
                    document.getElementById("listarBody").innerHTML = document.getElementById("listarBody").innerHTML +
                        "<tr>"
                        + "<td>" + response.DEAList[i]["Codigo"] + "</td><td>" + response.DEAList[i]["HorarioAcceso"] + "</td> <td>" + response.DEAList[i]["Direccion"]["NombreVia"] + "</td>"
                        + "<td>" + response.DEAList[i]["Direccion"]["PortalNumero"] + "</td><td>" + (response.DEAList[i]["Municipio"] === null ? "" : response.DEAList[i]["Municipio"]["Nombre"]) + "</td> <td>" + response.DEAList[i]["Direccion"]["Ubicacion"] + "</td>"
                        + "</tr > ";
                    i++;
                }
            }, 50);
        },
        error: function (xhr, status, error) {
            alert("Error: " + xhr.responseText + " - " + error);
        }
    });
}

function mysleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function search() {

    var codigo = document.getElementById("buscarCodigo").value;

    $.ajax({
        url: 'http://localhost:1898/api/devices/device/' + codigo,
        dataType: 'json',
        type: 'get',
        success: function (response) {
            document.getElementById("buscarResultado").innerHTML = JSON.stringify(response);
        },
        error: function (xhr, status, error) {
            alert("Error: " + xhr.responseText + " - " + error);
        }
    });

}

function create() {

    var newDEA = {
        Codigo: document.getElementById("crearCodigo").value,
        HorarioAcceso: document.getElementById("crearHorarioAcceso").value,
        TipoEstablecimiento: document.getElementById("crearTipoEstablecimiento").value,
        TipoTitularidad: document.getElementById("crearTipoTitularidad").value,
        Municipio: {
            Pais: "ES",
            Codigo: document.getElementById("crearMunicipioCodigo").value,
            Nombre: document.getElementById("crearMunicipioNombre").Value
        },
        Direccion: {
            Puerta: document.getElementById("crearDireccionPuerta").value,
            TipoVia: document.getElementById("crearDireccionTipoVia").value,
            Piso: document.getElementById("crearDireccionPiso").value,
            Ubicacion: document.getElementById("crearDireccionUbicacion").value,
            NombreVia: document.getElementById("crearDireccionNombreVia").value,
            PortalNumero: document.getElementById("crearDireccionPortalNumero").value,
            CodigoPostal: document.getElementById("crearDireccionCodigoPostal").value,
            CoordenadaX: document.getElementById("crearDireccionCoordenadaX").value,
            CoordenadaY: document.getElementById("crearDireccionCoordenadaY").Value
        }
    };

    $.ajax({
        data: newDEA,
        url: 'http://localhost:1898/api/devices/create',
        dataType: 'json',
        type: 'post',
        success: function (response) {
            document.getElementById("refillBody").innerHTML = document.getElementById("refillBody").innerHTML +
                "<tr><td>" + newDEA["Codigo"] + "</td><td>" + newDEA["Direccion"]["NombreVia"] + "</td><td>" + newDEA["Direccion"]["PortalNumero"] + "</td></tr>";
        },
        error: function (xhr, status, error) {
            alert("Error: " + xhr.responseText + " - " + error);
        }
    });

}

function Nearest() {

    var request = {
        CoordenadaX: document.getElementById("nearestX").value,
        CoordenadaY: document.getElementById("nearestY").value
    };

    $.ajax({
        data: request,
        url: 'http://localhost:1898/api/devices/Nearest',
        dataType: 'json',
        type: 'post',
        success: function (response) {
            document.getElementById("nearestResultado").innerHTML = JSON.stringify(response);
        },
        error: function (xhr, status, error) {
            alert("Error: " + xhr.responseText + " - " + error);
        }
    });

}

function Refill(i) {
    if (typeof i === 'undefined') { i = 0; }
    if (i < Object.keys(mydata).length) {
        //alert(JSON.stringify(mydata[i]));
        var newDEA = {
            Codigo: mydata[i]["codigo_dea"],
            HorarioAcceso: mydata[i]["horario_acceso"],
            TipoEstablecimiento: getTipoEstablecimiento(mydata[i]["tipo_establecimiento"]),
            TipoTitularidad: getTipoTitularidad(mydata[i]["tipo_titularidad"]),
            Municipio: {
                Pais: "ES",
                Codigo: mydata[i]["municipio_codigo"],
                Nombre: mydata[i]["municipio_nombre"]
            },
            Direccion: {
                Puerta: mydata[i]["direccion_puerta"],
                TipoVia: getTipoVia(mydata[i]["direccion_via_codigo"]),
                Piso: mydata[i]["direccion_piso"],
                Ubicacion: mydata[i]["direccion_ubicacion"],
                NombreVia: mydata[i]["direccion_via_nombre"],
                PortalNumero: mydata[i]["direccion_portal_numero"],
                CodigoPostal: mydata[i]["direccion_codigo_postal"],
                CoordenadaX: mydata[i]["direccion_coordenada_x"],
                CoordenadaY: mydata[i]["direccion_coordenada_y"],
            }
        };
        $.ajax({
            data: newDEA,
            url: 'http://localhost:1898/api/devices/create',
            dataType: 'json',
            type: 'post',
            success: function (response) {
                document.getElementById("refillBody").innerHTML = document.getElementById("refillBody").innerHTML +
                    "<tr><td>" + newDEA["Codigo"] + "</td><td>" + newDEA["Direccion"]["NombreVia"] + "</td><td>" + newDEA["Direccion"]["PortalNumero"] + "</td></tr>";
                Refill(i + 1);
            },
            error: function (xhr, status, error) {
                alert("Error: " + xhr.responseText + " - " + error);
            }
        });

    }


    function getTipoEstablecimiento(req) {
        if (req === "Establecimiento dependiente de una Administración Pública") { return "0"; }
        if (req === "Instalación, centro o complejo deportivo con más de 500 usuarios diarios") { return "1"; }
        if (req === "Instalaciones de transporte") { return "2"; }
        if (req === "Centro de trabajo con más de 250 trabajadores") { return "3"; }
        if (req === "Establecimiento público con aforo igual o superior a 2000 personas") { return "4"; }
        if (req === "Establecimiento hotelero con más de 100 plazas") { return "5"; }
        if (req === "Centro educativo") { return "6"; }
        if (req === "Grandes establecimientos comerciales con una superficie superior a 2500 m2") { return "7"; }
        if (req === "Aeropuertos") { return "8"; }
        if (req === "Centros residenciales de mayores con 200 plazas") { return "9"; }
        if (req === "Otros") { return "10"; }
        return "0";
    }

    function getTipoTitularidad(req) {
        return req === "Privada" ? "1" : "0";
    }

    function getTipoVia(req) {
        if (req === "CALLE") { return "0"; }
        if (req === "RONDA") { return "1"; }
        if (req === "AVDA") { return "2"; }
        if (req === "PASEO") { return "3"; }
        if (req === "CUSTA") { return "4"; }
        if (req === "CRA") { return "5"; }
        if (req === "PLAZA") { return "6"; }
        if (req === "CTRA") { return "7"; }
        if (req === "CMNO") { return "8"; }
        if (req === "BULEV") { return "9"; }
        if (req === "GTA") { return "10"; }
        if (req === "PQUE") { return "11"; }
        if (req === "CLLON") { return "12"; }
        if (req === "TRVA") { return "13"; }
        if (req === "CÑADA") { return "14"; }
        if (req === "ZONA") { return "15"; }
        if (req === "VREDA") { return "16"; }
        if (req === "LUGAR") { return "17"; }
        if (req === "SENDA") { return "18"; }
        if (req === "FINCA") { return "19"; }
        if (req === "PRAJE") { return "20"; }
        if (req === "SECT") { return "21"; }
        if (req === "URB") { return "22"; }
        if (req === "AVIA") { return "23"; }
        return "0";
    }

}