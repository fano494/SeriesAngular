(function (){
    'use strict';
    angular.module('app').controller('serieEditController', ['seriesAngularDataFactory', '$routeParams', serieEditController]);

    function serieEditController(seriesAngularDataFactory, $routeParams) {
        var vm = this;
        function clone(o) {
            return JSON.parse(JSON.stringify(o));
        };
        vm.load = true;
        vm.serieDefault = {
            "imagen": "Angular/imagenes/default.png",
            "name": "(--default--)",
            "description" : ""
        };
        vm.serie = clone(vm.serieDefault);

        vm.save = function () {
            console.log(vm.serie);
            vm.serieDefault = clone(vm.serie);
            vm.desactive();
        };
        vm.cancel = function () {
            vm.serie = clone(vm.serieDefault);
            document.getElementById("img").src = vm.serie.imagen;
            vm.desactive();
        };
        vm.upFile = function (element) {
            vm.imagen = element.files[0];
            if (vm.imagen.type.match('image.*')) {
                var lector = new FileReader();
                lector.onload = (function (img) {
                        return function (res) {
                            vm.serie.imagen = res.target.result;
                            document.getElementById("img").src = vm.serie.imagen;
                            vm.active();
                        };
                })(vm.imagen);

                lector.readAsDataURL(vm.imagen);
            }
        };
        vm.desactive = function () {
            document.getElementById("cancelar").classList.remove("alerta-warning");
            document.getElementById("guardar").classList.remove("alerta-good");
            document.getElementById("cancelar").classList.add("alerta-sad");
            document.getElementById("guardar").classList.add("alerta-sad");
            document.getElementById("cancelar").classList.add("inactivo");
            document.getElementById("guardar").classList.add("inactivo");
        };
        vm.active = function () {
            document.getElementById("cancelar").classList.remove("alerta-sad");
            document.getElementById("guardar").classList.remove("alerta-sad");
            document.getElementById("cancelar").classList.remove("inactivo");
            document.getElementById("guardar").classList.remove("inactivo");
            document.getElementById("cancelar").classList.add("alerta-warning");
            document.getElementById("guardar").classList.add("alerta-good");
        };
    };
})();