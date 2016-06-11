(function () {
    'use strict';
    angular.module('app').controller('headController', ['loginFactory', 'seriesAngularDataFactory', '$location', headController]);

    function headController(loginFactory, seriesAngularDataFactory, $location) {
        var vm = this;

        vm.logoutDo = function () {
            loginFactory.logout();
            vm.ini = true;
            vm.act = 'ini';
            vm.ser = false;
            vm.rec = false;
            vm.login = false;
            vm.user = {};
            vm.pasError = false;
            vm.nomError = false;
            vm.inactivo = true;
            vm.register = false;
            vm.paiError = false;
            vm.emaError = false;
            $location.path('/login');
        };

        vm.logoutDo();

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
            if (vm.user.username && vm.user.password) {
                seriesAngularDataFactory.getUsuario(vm.user.username).then(function (data) {
                    if (loginFactory.evalue(vm.user.password, data)) {
                        vm.loginClose();
                        vm.inactivo = false;
                        vm.user = data;
                        console.log(vm.user);
                        $location.path('/');
                    }
                    else {
                        vm.nomError = true;
                        vm.pasError = true;
                    }
                }, function (error) {
                    vm.nomError = true;
                    vm.pasError = true;
                });
            }
            else {
                if (!vm.user.username) {
                    vm.nomError = true;
                }
                if (!vm.user.password) {
                    vm.pasError = true;
                }
            }
        };
        vm.registerOpen = function () {
            vm.register = true;
        };
        vm.registerClose = function () {
            vm.register = false;
            vm.pasError = false;
            vm.nomError = false;
            vm.paiError = false;
            vm.emaError = false;
        };
        vm.registerDo = function () {
            if (vm.user.email && 
                vm.user.password && 
                vm.user.username &&
                vm.user.country) {
                console.log(vm.user);
                seriesAngularDataFactory.saveUsuario(vm.user).then(function (data) {
                    loginFactory.register();
                    vm.registerClose();
                    vm.inactivo = false;
                    $location.path('/');
                });
            }
            else {
                if (!vm.user.email) {
                    vm.emaError = true;
                }
                if (!vm.user.password) {
                    vm.pasError = true;
                }
                if (!vm.user.username) {
                    vm.nomError = true;
                }
                if (!vm.user.country) {
                    vm.paiError = true;
                }
            }
        };
    };
    
})();