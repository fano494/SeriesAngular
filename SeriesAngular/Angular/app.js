(function () {
    'use strict';
    angular.module('app', ['genericDataFactoryModule', 'ngRoute', 'smart-table'])
        .config(['$routeProvider', function ($routeProvider) {
            //Index
            $routeProvider.when('/',{
                templateUrl: 'Angular/view/init.html',
                controller: 'initController',
                controllerAs: 'ctr',
                label: 'Inicio'
            }).when('/login', {
                templateUrl: 'Angular/view/login/login.html',
                controller: 'loginController',
                controllerAs: 'ctr',
                label: 'Login'
            }).when('/series', {
                templateUrl: 'Angular/view/series/series.html',
                controller: 'seriesController',
                controllerAs: 'ctr',
                label: 'Series'
            }).when('/serie/:id',{
                templateUrl: 'Angular/view/serie/serie.html',
                controller: 'serieController',
                controllerAs: 'ctr',
                label: 'Serie'
            }).otherwise({
                redirectTo: '/'
            });
        }]);
})();
