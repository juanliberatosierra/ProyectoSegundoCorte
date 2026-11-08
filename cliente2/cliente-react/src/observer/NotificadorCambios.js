const observadores = new Map();

export function suscribir(evento, funcion) {

    if (!observadores.has(evento)) {
        observadores.set(evento, new Set());
    }

    observadores.get(evento).add(funcion);

    return function cancelarSuscripcion() {
        observadores.get(evento)?.delete(funcion);
    };
}

export function notificar(evento) {

    const suscriptores = observadores.get(evento);

    if (!suscriptores) {
        return;
    }

    suscriptores.forEach(funcion => {
        funcion();
    });

    console.log("Observer: evento recibido ->", evento);
}