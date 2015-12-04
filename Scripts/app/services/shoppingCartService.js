angular.module("webshop.services", [])
    .factory("cartService", ["config", "$http", function (config, $http) {

        var cart = {};
        cart.items = [];
        cart.total = 0;
        cart.subTotal = 0;
        cart.vat = "";
        cart.totalItems = 0;

        cart.get = function() {

            return $http.get(config.getUrl).then(function (response) {
                var data = response.data;
                cart.items = data.items;
                cart.total = data.total;
                cart.subTotal = data.subTotal;
                cart.vat = data.vat;
                cart.totalItems = data.totalItems;
            });
        }

        cart.update = function() {
            var localItems = [];
            angular.forEach(cart.items, function (item) {
                localItems.push({
                    productId: item.id,
                    isRemoved: item.isRemoved,
                    quantity: item.quantity
                });
            });

            $http.post(config.updateUrl, localItems).then(function (result) {
                cart.get();
            });
        }

        cart.add = function(id, amount) {
            var existing = false;
            for (var i = 0; i < cart.items.length; i++) {
                var item = cart.items[i];
                if (item.id == id) {
                    existing = true;
                    item.quantity += amount;
                    break;
                }
            };

            if (!existing) {
                cart.items.push({
                    id: id,
                    quantity: amount,
                    isRemoved: false
                });
            }

            cart.update();
        }

        cart.remove = function(id) {
            for (var i = 0; i < cart.items.length; i++) {
                var item = cart.items[i];
                if (item.id == id) {
                    item.isRemoved = true;
                    break;
                }
            };

            cart.update();
        }

        return cart;
    }]);