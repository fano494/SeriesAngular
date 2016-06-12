(function () {
    'use strict';
    angular.module('app').controller('perfilController', ['seriesAngularDataFactory', '$location', 'loginFactory', perfilController]);

    function perfilController(seriesAngularDataFactory, $location, loginFactory) {
        function clone(o) {
            return JSON.parse(JSON.stringify(o));
        };

        var vm = this;
        vm.load = true;

        seriesAngularDataFactory.getUsuario(loginFactory.user.username).then(function (data) {
            vm.userDefault = data;
            if (!vm.userDefault) {
                $('#msg').html('ERROR');
            }
            else {
                vm.user = clone(vm.userDefault);
                loginFactory.register(data);
                console.log(vm.user);
                document.getElementById("img").src = vm.user.profile;
                vm.load = false;
            }
        });

        

        vm.save = function () {
            vm.load = true;
            seriesAngularDataFactory.saveUsuario(vm.user).then(function (data) {
                loginFactory.register(vm.user);
                vm.userDefault = clone(vm.user);
                vm.desactive();
                vm.load = false;
            });
        };
        vm.verSerie = function (id) {
            $location.path('/serie/' + id);
        };
        vm.cancel = function () {
            vm.user = clone(vm.userDefault);
            document.getElementById("img").src = vm.userDefault.profile;
            vm.desactive();
        };
        vm.upFile = function (element) {
            vm.image = element.files[0];
            if (vm.image.type.match('image.*')) {
                var reader = new FileReader();
                reader.onload = (function (img) {
                    return function (res) {
                        vm.user.profile = res.target.result;
                        document.getElementById("img").src = vm.user.profile;
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