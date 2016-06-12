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
        vm.cargarDatos = function() {

            var start =  0;
            var number = 10;

            var sort = "default";
            var reverse = false;

            
            seriesAngularDataFactory.getSeries(sort, reverse, start, number, vm.filtros).then(function (data) {
                vm.series = data.PaginaActual;
                console.log(data);
            }).finally(function () {
                console.log(vm.series);
                vm.cargando = false;
            });
  
        };
        vm.cargarDatos();

        vm.verSerie = function (id) {
            $location.path('/serie/' + id);
        };
        vm.crearSerie = function () {
            $location.path('/serieEdit');
        };
      };
})();