(function () {
    'use strict';
    angular.module('app').controller('headController', ['$log', headController]);

    function headController($log) {
        var vm = this;

        vm.ini = true;
        vm.act = 'ini';
        vm.ser = false;
        vm.rec = false;

        vm.cambio = function (apartado) {
            vm[vm.act] = false;
            vm[apartado] = true;
            vm.act = apartado;
        };
    };
})();