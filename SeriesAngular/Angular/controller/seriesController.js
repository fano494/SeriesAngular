(function () {
    'use strict';
    angular.module('app').controller('seriesController', ['seriesAngularDataFactory', 'loginFactory', '$location', seriesController]);

    function seriesController(seriesAngularDataFactory, loginFactory, $location) {
        var vm = this;
        if(!loginFactory.login){
            $location.path('/login');
        }
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
                console.log(data);
                tableState.pagination.totalItemCount = data.Estructura.NumeroTotalElementos;
                tableState.pagination.numberOfPages = data.Estructura.NumeroTotalPaginas;
                vm.tableState = tableState;
            }).finally(function () {
                console.log(vm.series);
                vm.cargando = false;
            });
  
        };
        vm.verSerie = function (id) {
            $location.path('/serie/' + id);
        };
        vm.crearSerie = function () {
            $location.path('/serieEdit');
        };
      };
})();