(function () {
    'use strict';

    angular.module('app').factory('loginFactory', loginFactory);

    function loginFactory(seriesAngularDataFactory) {
        var service = {};
        service.login = false;
        service.user = {};

        service.evalue = function (pass1, user) {
            service.login = pass1 == user.password;
            if (service.login)
                service.user = user;
            return service.login;
        };
        return service;
    };
})();