var module = angular.module("webshop", [
    "webshop.controllers",
    "webshop.services"
])

.constant("config", {
    getUrl: "/OrchardLocal/Sapias.Commerce/ShoppingCart/GetItems",
    updateUrl: "/OrchardLocal/Sapias.Commerce/ShoppingCart/Update"
})

;

angular.bootstrap($("body"), ["webshop"]);