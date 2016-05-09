(function (){
    'use strict';
    angular.module('app').controller('initController', ['seriesAngularDataFactory', 'loginFactory', '$location', initController]);

    function initController(seriesAngularDataFactory, loginFactory, $location) {
        var vm = this;
        if (loginFactory.login) {
        }
        else {
            $location.path('/login');
        }

    };
})();