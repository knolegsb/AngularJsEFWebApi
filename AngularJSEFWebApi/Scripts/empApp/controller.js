var empControllers = angular.module("empControllers", []);

empControllers.controller("ListController", ['$scope', '$http', function ($scope, $http) {
    $http.get('/Api/EmployeeApi').success(function (data) {
        $scope.employees = data;
        //console.log(data);
    });
}]);

empControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {
    $scope.id = $routeParams.id;
    $http.get('/Api/EmployeeApi/' + $routeParams.id).success(function (data) {
        $scope.firstname = data.FirstName;
        $scope.lastname = data.LastName;
        $scope.country = data.Country;
        $scope.state = data.State;
        $scope.salary = data.Salary;
        $scope.active = data.IsActive;
        $scope.dob = data.DateofBirth;
        $scope.description = data.Description;
    });
    $scope.delete = function () {
        $http.delete('/Api/EmployeeApi/' + $scope.id).success(function (data) {
            $location.path('/list');
        }).error(function (data) {
            $scope.error = "An error has occured while deleting employee!" + data;
        });
    };
}]);

empControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location', function ($scope, $filter, $http, $routeParams, $location)
{
    $http.get('/Api/Country').success(function (data)
    {
        $scope.countries = data;
        //console.log(data);
    });
    $scope.id = 0;
    $scope.getStates = function () {
        var country = $scope.country;
        if (country) {
            $http.get('/Api/Country/' + country).success(function (data) {
                $scope.states = data;
            });
        }
        else
        {
            $scope.states = null;
        }
    }
    $scope.save = function () {
        var obj = {
            EmployeeId: $scope.id,
            FirstName: $scope.firstname,
            LastName: $scope.lastname,
            Country: $scope.country,
            State: $scope.state,
            Salary: $scope.salary,
            IsActive: $scope.active,
            Description: $scope.description,
            DateofBirth: $scope.dob
        };
        if ($scope.id == 0) {
            $http.post('/Api/EmployeeApi/', obj).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "An error has occured while adding employee! " + data.ExceptionMessage;
            });
        }
        else
        {
            $http.put('/Api/EmployeeApi/', obj).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                console.log(data);
                $scope.error = "An error has occured while saving customer! " + data.ExceptionMessage;
            });
        }
    }
    if ($routeParams.id) {
        $scope.id = $routeParams.id;
        $scope.title = "Eidt Employee";
        $http.get('/Api/EmployeeApi/' + $routeParams.id).success(function (data) {
            $scope.firstname = data.FirstName;
            $scope.lastname = data.LastName;
            $scope.country = data.Country;
            $scope.state = data.IsActive;
            $scope.description = data.Description;
            $scope.dob = new Date(data.DateofBirth);
            $scope.getStates();
        });
    }
    else
    {
        $scope.title = "Create New Employee";
    }
}])
