(function () {
    'use strict';

    angular.module('app').factory('seriesAngularDataFactory', ['GenericDataFactory', seriesAngularDataFactory]);

    function seriesAngularDataFactory(GenericDataFactory) {
        var service = {};

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
        /*
        //ALUMNOS

        service.getAlumnos = function (sort, reverse, start, number, filtros) {
            return GenericDataFactory.post('api/Alumno/' + sort + '/' + reverse + '/' + start + '/' + number, filtros);
        };

        service.getAlumno = function (id) {
            return GenericDataFactory.get('api/Alumno/' + id);
        };

        service.saveAlumno = function (alumnoToSave) {
            return GenericDataFactory.post('api/Alumno', alumnoToSave);
        };

        service.deleteAlumno = function (id) {
            return GenericDataFactory.remove('api/Alumno/' + id);
        };
        
        //ALUMNO - CURSO

        service.addAlumnoCurso = function (idCurso, idAlumno) {
            return GenericDataFactory.post('api/Curso/' + idCurso + '/Alumno/' + idAlumno);
        };

        service.deleteAlumnoCurso = function (idCurso, idAlumno) {
            return GenericDataFactory.remove('api/Curso/' + idCurso + '/Alumno/' + idAlumno);
        };*/
        
        return service;
    };
})();