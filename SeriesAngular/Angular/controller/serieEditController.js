﻿(function (){
    'use strict';
    angular.module('app').controller('serieEditController', ['seriesAngularDataFactory', '$routeParams', serieEditController]);

    function serieEditController(seriesAngularDataFactory, $routeParams) {
        var vm = this;
        function clone(o) {
            return JSON.parse(JSON.stringify(o));
        };
        vm.load = true;
        if (!$routeParams.id) {
            vm.load = false;
            vm.serieDefault = {
                "image": "Angular/imagenes/default.png",
                "name": "",
                "description": ""
            };
            vm.serie = clone(vm.serieDefault);
            document.getElementById("img").src = vm.serieDefault.image;
        }
        else {
            vm.serieDefault = seriesAngularDataFactory.getSerie($routeParams.id).then(function (data) {
                console.log("Edit: ", data);
                if (data.seriename) {
                    vm.load = false;
                    vm.serieDefault = data;
                    if (!vm.serieDefault.image)
                        vm.serieDefault.image = "Angular/imagenes/default.png";
                    vm.serie = clone(vm.serieDefault);
                    document.getElementById("img").src = vm.serieDefault.image;
                }
                else {
                    $('#msg').html('ERROR');
                }
            });
        }

        
        vm.save = function () {
            console.log(vm.serie);
            vm.load = true;
            if (vm.serie.seriename &&
               vm.serie.producer &&
               vm.serie.director &&
               vm.serie.gender &&
               vm.serie.score &&
               vm.serie.year &&
               vm.serie.description)
                seriesAngularDataFactory.saveSerie(vm.serie).then(function (data) {
                    vm.load = false;
                    vm.incomplete = false;
                    vm.serieDefault = clone(vm.serie);
                    vm.desactive();
                });
            else {
                vm.desactive();
                vm.load = false;
                vm.incomplete = true;
            }
            
        };
        vm.cancel = function () {
            vm.serie = clone(vm.serieDefault);
            document.getElementById("img").src = vm.serieDefault.image;
            vm.desactive();
        };
        vm.upFile = function (element) {
            vm.image = element.files[0];
            if (vm.image.type.match('image.*')) {
                var lector = new FileReader();
                lector.onload = (function (img) {
                        return function (res) {
                            vm.serie.image = res.target.result;
                            document.getElementById("img").src = vm.serie.image;
                            vm.active();
                        };
                })(vm.image);

                lector.readAsDataURL(vm.image);
            }
        };
        vm.desactive = function () {
            document.getElementById("cancelar").classList.remove("alerta-warning");
            document.getElementById("guardar").classList.remove("alerta-good");
            document.getElementById("cancelar").classList.add("alerta-sad");
            document.getElementById("guardar").classList.add("alerta-sad");
            document.getElementById("cancelar").classList.add("inactivo");
            document.getElementById("guardar").classList.add("inactivo");
        };
        vm.active = function () {
            document.getElementById("cancelar").classList.remove("alerta-sad");
            document.getElementById("guardar").classList.remove("alerta-sad");
            document.getElementById("cancelar").classList.remove("inactivo");
            document.getElementById("guardar").classList.remove("inactivo");
            document.getElementById("cancelar").classList.add("alerta-warning");
            document.getElementById("guardar").classList.add("alerta-good");
            vm.incomplete = false;
        };
    };
})();