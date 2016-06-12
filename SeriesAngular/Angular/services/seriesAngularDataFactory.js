(function () {
    'use strict';

    angular.module('app').factory('seriesAngularDataFactory', ['GenericDataFactory', seriesAngularDataFactory]);

    function seriesAngularDataFactory(GenericDataFactory) {
        var service = {};
        var bdSerie = {};

        //SERIES
        
        service.getSerie = function (id) {
            return GenericDataFactory.get('api/Serie/' + id);
        };

        service.getSeries = function (sort, reverse, start, number, filtros) {
            return GenericDataFactory.post('api/Serie/' + sort + '/' + reverse + '/' + start + '/' + number, filtros);
        };

        service.saveSerie = function (serie) {
            return GenericDataFactory.post('api/Serie', serie);
        };

        service.deleteSerie = function (id) {
            return GenericDataFactory.remove('api/Serie/' + id);
        };

        //PERFIL

        service.getUsuario = function (id) {
            return GenericDataFactory.get('api/Usuario/' + id);
        };

        service.getUsuarios = function (sort, reverse, start, number, filtros) {
            return GenericDataFactory.post('api/Usuario/' + sort + '/' + reverse + '/' + start + '/' + number, filtros);
        };

        service.saveUsuario = function (serie) {
            return GenericDataFactory.post('api/Usuario', serie);
        };

        service.deleteUsuario = function (id) {
            return GenericDataFactory.remove('api/Usuario/' + id);
        };

        service.seguirSerie = function (idserie, iduser) {
            return GenericDataFactory.post('api/Usuario/' + idserie + '/' + iduser + '/' + true);
        };

        service.dejarSerie = function (idserie, iduser) {
            return GenericDataFactory.post('api/Usuario/' + idserie + '/' + iduser + '/' + false);
        };

        
        
        return service;
    };
})();