app.controller('GetController', function MainController($scope, $http) {
    // $http.get("http://10.0.16.28:3000/users/").then(function (response) {
    //     $scope.myData = response.data;
    // });

    $http.get('http://10.0.16.51:3000/tasks').then(function (response) {
        $scope.myData = response.data;
    });
});