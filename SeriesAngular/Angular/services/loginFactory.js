(function () {
    'use strict';

    angular.module('app').factory('loginFactory', loginFactory);

    function loginFactory() {
        var service = {};

        service.nom = '';
        service.pas = '';
        service.login = false;

        service.evalue = function (nom, pas) {
            service.login = nom == pas;
            if (service.login) {
                service.nom = nom;
                service.pas = pas;
            }
            return service.login;
        };
        return service;
    };
})();