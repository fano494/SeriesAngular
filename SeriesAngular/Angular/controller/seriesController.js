(function () {
    'use strict';
    angular.module('app').controller('seriesController', ['seriesAngularDataFactory', '$log', '$location', seriesController]);

    function seriesController(seriesAngularDataFactory, $log, $location) {
        var vm = this;
        vm.cargando = true;

        vm.filtros = {};
        vm.series = [];
        vm.cargarDatos = function callServer(tableState) {
            var pagination = tableState.pagination;

            var start = pagination.start || 0;
            var number = 5;

            var sort = tableState.sort.predicate || "default";
            var reverse = tableState.sort.reverse || false;

            
            seriesAngularDataFactory.getSeries(sort, reverse, start, number, vm.filtros).then(function (data) {
                vm.series = data.PaginaActual;
                tableState.pagination.totalItemCount = data.Estructura.NumeroTotalElementos;
                tableState.pagination.numberOfPages = data.Estructura.NumeroTotalPaginas;
            }).finally(function () {
                vm.cargando = false;
            });
            vm.tableState = tableState;
        };
        vm.verSerie = function (id) {
            $location.path('/serie/' + id);
        };
      };
})();