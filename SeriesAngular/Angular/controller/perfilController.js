(function () {
    'use strict';
    angular.module('app').controller('perfilController', ['seriesAngularDataFactory', 'loginFactory', perfilController]);

    function perfilController(seriesAngularDataFactory, loginFactory) {
        function clone(o) {
            return JSON.parse(JSON.stringify(o));
        };

        var vm = this;
        vm.userDefault = loginFactory.user;
        vm.load = true;
        vm.user = {};

        if (!vm.userDefault) {
            $('#msg').html('ERROR');
        }
        else {
            vm.user = clone(vm.userDefault);
            vm.load = false;
        }

        vm.save = function () {
            console.log(vm.user);
            vm.userDefault = clone(vm.user);
            vm.desactive();
        };
        vm.cancel = function () {
            vm.user = clone(vm.userDefault);
            document.getElementById("img").src = vm.user.image;
            vm.desactive();
        };
        vm.upFile = function (element) {
            vm.image = element.files[0];
            if (vm.image.type.match('image.*')) {
                var reader = new FileReader();
                reader.onload = (function (img) {
                    return function (res) {
                        vm.user.image = res.target.result;
                        document.getElementById("img").src = vm.user.image;
                        vm.active();
                    };
                })(vm.imagen);

                reader.readAsDataURL(vm.image);
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