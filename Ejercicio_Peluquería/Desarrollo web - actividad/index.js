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
    const $fecha = document.getElementById("datetime");
    const $hora = document.getElementById("datetime");
    const $cliente = "";
    const $servicio = document.getElementById("servicios");

    let data = {
        fecha: $fecha.value,
        hora: $hora.value,
        cliente: "Paolo López"
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
            console.log('Respuesta del servidor:', data); // Maneja la respuesta del servidor
        })
        .catch(error => {
            console.error('Error:', error); // Manejo de errores
        });

}
