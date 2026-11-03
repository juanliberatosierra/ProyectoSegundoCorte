package com.example.POCCuentaCorriente.repository;

import com.example.POCCuentaCorriente.model.MovimientoBancario;
import com.example.POCCuentaCorriente.model.MovimientoDetalle;
import org.springframework.data.domain.Sort;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.aggregation.Aggregation;
import org.springframework.data.mongodb.core.aggregation.AggregationOperation;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;


@Repository
public class RepositorioMovimientoBancarioMongo implements RepositorioMovimientoBancario {

    private final MongoTemplate mongo;

    public RepositorioMovimientoBancarioMongo(MongoTemplate mongo) {
        this.mongo = mongo;
    }

    // Arma el filtro (criterios) según los parámetros que lleguen
    private Criteria criterios(Integer numeroCuenta, String tipoMovimiento) {

        Criteria criteria = new Criteria();

        if (numeroCuenta != null) {
            criteria = criteria.and("numeroCuenta").is(numeroCuenta);
        }

        if (tipoMovimiento != null && !tipoMovimiento.isBlank()) {
            criteria = criteria.and("tipoMovimiento").is(tipoMovimiento.trim().toUpperCase());
        }

        return criteria;
    }

    @Override
    public List<MovimientoBancario> listar(Integer numeroCuenta, String tipoMovimiento) {

        Query query = new Query(criterios(numeroCuenta, tipoMovimiento))
                .with(Sort.by("numeroCuenta", "idMovimiento"));

        return mongo.find(query, MovimientoBancario.class);
    }

    @Override
    public List<MovimientoBancario> listarPorCuenta(int numeroCuenta) {
        return listar(numeroCuenta, null);
    }

    @Override
    public Optional<MovimientoBancario> buscar(int numeroCuenta, int idMovimiento) {
        return Optional.ofNullable(mongo.findById(
                MovimientoBancario.generarId(numeroCuenta, idMovimiento),
                MovimientoBancario.class));
    }

    @Override
    public void guardar(MovimientoBancario movimiento) {

        if (buscar(movimiento.getNumeroCuenta(), movimiento.getIdMovimiento()).isPresent()) {
            throw new IllegalArgumentException("Ya existe un movimiento con ese ID en la cuenta");
        }

        mongo.insert(movimiento);
    }

    @Override
    public void actualizar(MovimientoBancario movimiento) {
        mongo.save(movimiento);
    }

    @Override
    public boolean eliminar(int numeroCuenta, int idMovimiento) {

        Query query = new Query(Criteria.where("_id")
                .is(MovimientoBancario.generarId(numeroCuenta, idMovimiento)));

        return mongo.remove(query, MovimientoBancario.class).getDeletedCount() > 0;
    }

    @Override
    public long eliminarPorCuenta(int numeroCuenta) {

        Query query = new Query(Criteria.where("numeroCuenta").is(numeroCuenta));

        return mongo.remove(query, MovimientoBancario.class).getDeletedCount();
    }

    /**
     * Consulta personalizada con $lookup (el "join" de MongoDB):
     *  1. $match   -> filtra movimientos por cuenta y/o tipo
     *  2. $lookup  -> trae la cuenta de la colección "cuentas" (movimiento.numeroCuenta = cuenta._id)
     *  3. $unwind  -> convierte el arreglo "cuenta" en un solo objeto
     *  4. $project -> deja los campos del movimiento + titular y tipoCuenta de la cuenta
     */
    @Override
    public List<MovimientoDetalle> listarConDatosCuenta(Integer numeroCuenta, String tipoMovimiento) {

        List<AggregationOperation> pasos = new ArrayList<>();

        pasos.add(Aggregation.match(criterios(numeroCuenta, tipoMovimiento)));
        pasos.add(Aggregation.lookup("cuentas", "numeroCuenta", "_id", "cuenta"));
        pasos.add(Aggregation.unwind("cuenta", true));
        pasos.add(Aggregation.project(
                        "idMovimiento", "numeroCuenta", "tipoMovimiento", "monto",
                        "fechaMovimiento", "descripcion", "confirmado")
                .and("cuenta.titular").as("titularCuenta")
                .and("cuenta.tipoCuenta").as("tipoCuenta"));
        pasos.add(Aggregation.sort(Sort.by("numeroCuenta", "idMovimiento")));

        return mongo.aggregate(
                Aggregation.newAggregation(pasos),
                "movimientos",
                MovimientoDetalle.class
        ).getMappedResults();
    }
}
