(function () {
    'use strict';
    angular.module('app').controller('headController', ['loginFactory', '$location', headController]);

    function headController(loginFactory, $location) {
        var vm = this;

        vm.ini = true;
        vm.act = 'ini';
        vm.ser = false;
        vm.rec = false;
        vm.login = false;
        vm.user = [];
        vm.pasError = false;
        vm.nomError = false;
        vm.inactivo = true;

        vm.cambio = function (apartado) {
            vm[vm.act] = false;
            vm[apartado] = true;
            vm.act = apartado;
            vm.loginClose();
        };
        vm.loginOpen = function () {
            vm.login = true;
        };
        vm.loginClose = function () {
            vm.login = false;
            vm.pasError = false;
            vm.nomError = false;
        };
        vm.loginDo = function () {
            if (vm.user.nom && vm.user.pas) {
                console.log("Login: ", vm.user);
                if (loginFactory.evalue(vm.user.nom, vm.user.pas)) {
                    vm.loginClose();
                    vm.inactivo = false;
                    $location.path('/');
                }
            }
            else {
                if (vm.user.nom) {
                    vm.pasError = true;
                }
                else {
                    if (vm.user.pas) {
                        vm.nomError = true;
                    }
                    else {
                        vm.nomError = true;
                        vm.pasError = true;
                    }
                }
            }
        };
    };
})();