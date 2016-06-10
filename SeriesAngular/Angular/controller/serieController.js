(function (){
    'use strict';
    angular.module('app').controller('serieController', ['seriesAngularDataFactory', '$log', '$routeParams', serieController]);

    function serieController(seriesAngularDataFactory, $log, $routeParams) {
        var vm = this;
        vm.cargando = true;
        vm.serie = {};
        vm.serieDefault = {
            "image": "Angular/imagenes/default.png",
        }
        if ($routeParams.id) {
            
            seriesAngularDataFactory.getSerie($routeParams.id).then(function (data) {
                vm.serie = data;
                console.log(data);
                if (!vm.serie.image) {
                    vm.serie.image = vm.serieDefault.image;
                }
            }).finally(function () {
                vm.cargando = false;
            });
            
            if (!vm.serie.image) {
                vm.serie.image = vm.serieDefault.image;
            }
        }
        
        
        //$.getJSON("Angular/bbdd/miniBBDD.json", function (data) {
        //    $scope.$apply(function () {
        //        $scope.serie = data["1"];
        //    });
        //});
        //$q.all(promesas)->Para cierre de muchas promesas a la vez.
    };
})();
