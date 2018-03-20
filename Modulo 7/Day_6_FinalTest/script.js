
var app = angular.module("ToDoList", []);
app.controller('MainController', function MainController($http) {

    var baseurl = "http://10.0.16.51:3000/";


    this.task = [{
        name: "Pass Test",
        description: "Complete web app to ace alan's test",
        isDone: false,
        tags: 0
    }];

    this.CreateTask = function () {
        var data = {
            id: this.taskId,
            name: this.taskName,
            description: this.taskDescription,
            isDone: this.taskDone = false,
            tags: this.taskTags,
        };

        var jsondata = JSON.stringify(data);
        var baseUrl = 'http://10.0.16.51:3000/tasks';

        var config = {
            method: "POST",
            url: baseUrl,
            data: jsondata,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return $http(config);
    };

    this.UpdateTask = function () {
        var data = {
            id: this.taskId,
            name: this.taskName,
            description: this.taskDescription,
        };

        var jsondata = JSON.stringify(data);
        var baseUrl = 'http://10.0.16.51:3000/tasks' + this.updateID;

        var config = {
            method: "PUT",
            url: baseUrl,
            data: jsondata,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return $http(config);
        this.updateID = "",
        this.name="",
        this.description=""
    };

    this.DeleteUser = function () {

        var baseUrl = 'http://10.0.16.51:3000/tasks' + this.deleteID;

        var config = {
            method: "DELETE",
            url: baseUrl,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return $http(config);
        this.deleteID = "";
    };


});

    // app.controller("MainController", MainController);

    // app.controller('MainController', function UserController($scope, $http) {
    //     $http.get("http://10.0.16.51:3000/tasks").then(function (response) {
    //         $scope.myData = response.data;
    //     });
    // });
