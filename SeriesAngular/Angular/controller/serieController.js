(function (){
    'use strict';
    angular.module('app').controller('serieController', ['seriesAngularDataFactory', '$log', '$routeParams', serieController]);

    function serieController(seriesAngularDataFactory, $log, $routeParams) {
        var vm = this;
        vm.cargando = true;
        vm.serie = {};

        if ($routeParams.id) {

            seriesAngularDataFactory.getSerie($routeParams.id).then(function (data) {
                vm.serie = data;
            }).finally(function () {
                vm.cargando = false;
            });
        }
        
        
        //$.getJSON("Angular/bbdd/miniBBDD.json", function (data) {
        //    $scope.$apply(function () {
        //        $scope.serie = data["1"];
        //    });
        //});
        //$q.all(promesas)->Para cierre de muchas promesas a la vez.
    };
})();
