document.addEventListener("DOMContentLoaded", cargar_servicios);

async function cargar_servicios() {
    try {
        const response = await fetch(`https://localhost:7122/api/TServicio`);
        const servicios = await response.json();
        const $servicios = document.getElementById('servicios');
        servicios.forEach(element => {
            const $option = document.createElement('option');
            $option.value = element.id;
            $option.textContent = element.nombre;
            $servicios.appendChild($option);
        });
    } catch (error) {
        console.error("Error al cargar los servicios.", error);
    }
}


function reservar_turno() {
    const $divError = document.getElementById("error");
    const $divOk = document.getElementById("ok");
    const $fechayhora = document.getElementById("datetime").value;
    const [$fecha, $hora] = $fechayhora.split("T");
    const $servicio = document.getElementById("servicios");

    let data = {
        fecha: $fecha,
        hora: $hora,
        cliente: "Paolo López",
        fechCanc: null,
        MotivoCanc: null
    };

    fetch('https://localhost:7122/api/TTurno', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json' 
        },
        body: JSON.stringify(data) 
    })
        .then(response => {
            if (response.ok) {
                $divOk.removeAttribute('hidden')
                document.querySelector('form').reset();
            } else {
                $divError.removeAttribute('hidden')
            }

            return response.json();

        })
        .then(data => {
            console.log('Respuesta del servidor:', data); 
        })
        .catch(error => {
            console.error('Error:', error); 
        });

}

function cerrar(id) {
    document.getElementById(id).hidden = true;
}
