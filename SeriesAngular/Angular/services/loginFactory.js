(function () {
    'use strict';

    angular.module('app').factory('loginFactory', loginFactory);

    function loginFactory(seriesAngularDataFactory) {
        var service = {};
        service.login = false;
        service.user = {};

        service.evalue = function (pass, user) {
            if (!user.email) {
                console.log("Usuario inexistente");
                return false;
            }
            else {
                service.login = pass == user.password;
                if (service.login) {
                    if (!user.profile) {
                        user.profile = "Angular/imagenes/default.png";
                    }
                    service.user = user;
                }
                return service.login;
            }
        };

        service.register = function(user){
            service.user = user;
            service.login = true;
        };

        service.logout = function () {
            service.login = false;
        }

        return service;
    };
})();