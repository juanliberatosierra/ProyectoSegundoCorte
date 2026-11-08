const GRAPHQL_URL = import.meta.env.VITE_GRAPHQL_URL;

export async function ejecutarGraphQL(query, variables = {}) {

    const respuesta = await fetch(GRAPHQL_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            query,
            variables
        })
    });

    if (!respuesta.ok) {
        throw new Error(
            "Error de conexión con el servidor"
        );
    }

    const resultado = await respuesta.json();

    if (resultado.errors?.length) {
        throw new Error(
            resultado.errors.map(error => error.message).join(", ")
        );
    }

    return resultado.data;
}