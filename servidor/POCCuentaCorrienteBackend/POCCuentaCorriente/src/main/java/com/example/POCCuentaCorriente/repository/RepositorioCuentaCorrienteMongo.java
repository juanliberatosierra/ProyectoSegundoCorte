package com.example.POCCuentaCorriente.repository;

import com.example.POCCuentaCorriente.model.CuentaCorriente;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;
import java.util.regex.Pattern;


@Repository
public class RepositorioCuentaCorrienteMongo implements RepositorioCuentaCorriente {

    private final MongoTemplate mongo;

    public RepositorioCuentaCorrienteMongo(MongoTemplate mongo) {
        this.mongo = mongo;
    }

    @Override
    public List<CuentaCorriente> listar() {
        return mongo.findAll(CuentaCorriente.class);
    }

    @Override
    public List<CuentaCorriente> listarConFiltros(String titular, String tipoCuenta) {

        Query query = new Query();

        if (titular != null && !titular.isBlank()) {
            query.addCriteria(Criteria.where("titular")
                    .regex(Pattern.quote(titular.trim()), "i"));
        }


        if (tipoCuenta != null && !tipoCuenta.isBlank()
                && !tipoCuenta.trim().equalsIgnoreCase("Todos")) {
            query.addCriteria(Criteria.where("tipoCuenta")
                    .regex("^" + Pattern.quote(tipoCuenta.trim()) + "$", "i"));
        }

        return mongo.find(query, CuentaCorriente.class);
    }

    @Override
    public Optional<CuentaCorriente> buscarPorNumeroCuenta(int numeroCuenta) {
        return Optional.ofNullable(mongo.findById(numeroCuenta, CuentaCorriente.class));
    }

    @Override
    public void guardar(CuentaCorriente cuenta) {

        if (cuenta == null) {
            throw new IllegalArgumentException("La cuenta no puede ser nula");
        }

        if (buscarPorNumeroCuenta(cuenta.getNumeroCuenta()).isPresent()) {
            throw new IllegalArgumentException("Ya existe una cuenta con ese numero");
        }

        mongo.insert(cuenta);
    }

    @Override
    public void actualizar(CuentaCorriente cuenta) {
        mongo.save(cuenta);
    }

    @Override
    public boolean eliminar(CuentaCorriente cuenta) {
        return mongo.remove(cuenta).getDeletedCount() > 0;
    }
}
