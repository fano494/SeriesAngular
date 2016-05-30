(function () {
    'use strict';
    angular.module('app').controller('perfilController', ['seriesAngularDataFactory', '$routeParams', perfilController]);

    function perfilController(seriesAngularDataFactory, $routeParams) {
        var vm = this;
        function clone(o) {
            return JSON.parse(JSON.stringify(o));
        };
        vm.load = true;
        vm.userDefault = {
            "imagen": "Angular/imagenes/default.png",
            "userName": "(--default--)"
        };
        vm.user = clone(vm.userDefault);

        vm.save = function () {
            console.log(vm.user);
            vm.userDefault = clone(vm.user);
            vm.desactive();
        };
        vm.cancel = function () {
            vm.user = clone(vm.userDefault);
            document.getElementById("img").src = vm.user.imagen;
            vm.desactive();
        };
        vm.upFile = function (element) {
            vm.imagen = element.files[0];
            if (vm.imagen.type.match('image.*')) {
                var reader = new FileReader();
                reader.onload = (function (img) {
                    return function (res) {
                        vm.user.imagen = res.target.result;
                        document.getElementById("img").src = vm.user.imagen;
                        vm.active();
                    };
                })(vm.imagen);

                reader.readAsDataURL(vm.imagen);
            }
        };
        vm.desactive = function () {
            document.getElementById("cancelar").classList.remove("visible");
            document.getElementById("guardar").classList.remove("visible");
            document.getElementById("cancelar").classList.add("oculto");
            document.getElementById("guardar").classList.add("oculto");
        };
        vm.active = function () {
            document.getElementById("cancelar").classList.remove("oculto");
            document.getElementById("guardar").classList.remove("oculto");
            document.getElementById("cancelar").classList.add("visible");
            document.getElementById("guardar").classList.add("visible");
        };
    };
})();