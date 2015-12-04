angular.module("webshop.controllers", ["webshop.services"])
    .controller("shoppingCartCtrl", ["cartService", function (cartService) {

        var _self = this;
        _self.cart = {};

        cartService.get().then(function () {
            _self.cart = cartService;
        });

        _self.add = function (id, amount) {
            cartService.add(id, amount);
        }

        _self.submitAdd = function (e, id, amount) {
            e.preventDefault();
            cartService.add(id, amount);
            return false;
        }

        _self.remove = function (id) {
            cartService.remove(id);
            cartService.update();
        }
    }]);