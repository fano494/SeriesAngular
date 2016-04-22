(function () {
    'use strict';
    angular.module('app').controller('loginController', ['$scope', '$location', '$log', loginController]);

    function loginController($scope, $location, $log) {
        var vm = this;
        if ($location.path() === '/login') {
            document.getElementById("loginModal").className = 'visible';
        }
        else {
            document.getElementById("loginModal").className = 'oculto';
        }

        vm.login = function (){
            
        };
        vm.cerrar = function () {
            document.getElementById("loginModal").className = 'oculto';
            if($location.path() === '/login')
                $location.path('/');
        }
    };
})();