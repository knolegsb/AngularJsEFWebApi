var myApp = angular.module("myApp", []);

myApp.controller("myController", function ($scope, $timeout) {
    console.log("In my controller...");

    $scope.newUser = {};
    $scope.clickedUser = {};
    $scope.message = "";

    $scope.users = [
        { username: "sean", fullname: "Sean Kodori", email: "seon@example.com" },
        { username: "kimberly", fullname: "Kimberly Mansuk", email: "kimberly@example.com" },
        { username: "masur", fullname: "Masur Mingko", email: "masur@example.com" }
    ];

    $scope.saveUser = function () {
        //console.log($scope.newUser);

        $scope.users.push($scope.newUser);
        $scope.newUser = {};
        $scope.message = "New User Added Successfully!";
        $timeout(function () {
            $scope.message = "";
        }, 3000);
    };

    $scope.selectUser = function (user) {
        console.log(user);
        $scope.clickedUser = user;
    };

    $scope.updateUser = function () {
        $scope.message = "User Updated Successfully!";
        $timeout(function () {
            $scope.message = "";
        }, 3000);
    };

    $scope.deleteUser = function () {
        
        $scope.users.splice($scope.users.indexOf($scope.clickedUser), 1);
        $scope.message = "User Deleted Successfully!";
        $timeout(function () {
            $scope.message = "";
        }, 3000);
    };

    $scope.clearMessage = function () {
        $scope.message = "";
    };
});