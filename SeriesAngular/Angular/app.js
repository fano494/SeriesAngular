(function () {
    'use strict';
    angular.module('app', ['ngRoute'])
        .config(['$routeProvider', function ($routeProvider) {
            //Index
            $routeProvider.when('/',{
                templateUrl: 'Angular/view/init.html',
                controller: 'initController',
                controllerAs: 'ctr',
                label: 'Inicio'
            }).when('/login',{
                templateUrl: 'Angular/view/init.html',
                controller: 'loginController',
                controllerAs: 'ctr',
                label: 'Login'
            }).otherwise({
                redirectTo: '/'
            });
        }]);
})();
