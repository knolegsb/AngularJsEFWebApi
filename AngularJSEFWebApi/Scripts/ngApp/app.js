var app = angular.module("myApp", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
    .when("/product-list", {
        templateUrl: "/templates/product-list.html",
        controller: "ProductListCtrl"
    })
    .when("/product-creation", {
        templateUrl: "../templates/product-creation.html",
        controller: "ProductCreationCtrl"
    })
    .when("/product-detail", {
        templateUrl: "/templates/product-detail.html",
        controller: "ProductDetailCtrl"
    })
    .otherwise({
        redirectTo: "/"
    })
})
