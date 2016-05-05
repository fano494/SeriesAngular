(function () {
    'use strict';
    angular.module('app').controller('loginController', ['loginFactory', '$location', '$log', loginController]);

    function loginController(loginFactory, $location, $log) {
        var vm = this;

        if (loginFactory.login) {
            $location.path('/');
        }
        else {

        }
    }
})();