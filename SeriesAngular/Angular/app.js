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
            }).when('/perfil', {
                templateUrl: 'Angular/view/perfil/perfil.html',
                controller: 'perfilController',
                controllerAs: 'ctr',
                label: 'Perfil'
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
            }).when('/serieEdit', {
                templateUrl: 'Angular/view/serieEdit/serieEdit.html',
                controller: 'serieEditController',
                controllerAs: 'ctr',
                label: 'SerieEdit'
            }).otherwise({
                redirectTo: '/'
            });
        }]);
})();
