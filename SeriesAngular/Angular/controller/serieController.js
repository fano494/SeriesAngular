(function (){
    'use strict';
    angular.module('app').controller('serieController', ['seriesAngularDataFactory', '$location', '$routeParams', 'loginFactory', serieController]);

    function serieController(seriesAngularDataFactory, $location, $routeParams, loginFactory) {
        var vm = this;
        vm.cargando = true;
        vm.serie = {};
        vm.serieDefault = {
            "image": "Angular/imagenes/default.png",
        }

        vm.esSeguida = function (series) {
            for (var i in series) {
                if (series[i].idserie == $routeParams.id)
                    return true;
            }
            return false;
        };
        vm.follow = vm.esSeguida(loginFactory.user.series);
        if ($routeParams.id) {
            vm.cargando = true;
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

        vm.seguirSerie = function () {
            vm.cargando = true;
            seriesAngularDataFactory.seguirSerie($routeParams.id, loginFactory.user.iduser).then(function (data) {
                vm.cargando = false;
                vm.follow = true;
            });
            
        }

        vm.dejarSerie = function () {
            vm.cargando = true;
            seriesAngularDataFactory.dejarSerie($routeParams.id, loginFactory.user.iduser).then(function (data) {
                vm.cargando = false;
                vm.follow = false;
            });

        }
        
        vm.editarSerie = function () {
            $location.path('/serieEdit/' + $routeParams.id)
        }
        
        //$.getJSON("Angular/bbdd/miniBBDD.json", function (data) {
        //    $scope.$apply(function () {
        //        $scope.serie = data["1"];
        //    });
        //});
        //$q.all(promesas)->Para cierre de muchas promesas a la vez.
    };
})();
