
var empApp = angular.module('empApp', ['ngRoute', 'empControllers']);
empApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/list',
        {
            templateUrl: 'empView/List.html',
            controller: 'ListController'
        })
        .when('/create',
        {
            templateUrl: 'empView/Edit.html',
            controller: 'EditController'
        })
        .when('/edit/:id',
        {
            templateUrl: 'empView/Edit.html',
            controller: 'EditController'
        })
        .when('/delete/:id', {
            templateUrl: 'empView/Delete.html',
            controller: 'DeleteController'
        })
        .otherwise(
        {
            redirectTo: '/list'
        });
}]);