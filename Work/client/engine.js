var app = angular.module("agentApp", []);
//var t = setTimeout();
app.controller("agentController", function ($scope, $http) {

	$scope.send = function (mac) {
		$http.put("http://localhost:8081/agent", {
			//mac: mac
		}).then(function (response) {
			// responseStatus
		});
	};

	$http.get("http://localhost:8081/agent").then(function (response) {
		$scope.body = response.data;
	});
	
});