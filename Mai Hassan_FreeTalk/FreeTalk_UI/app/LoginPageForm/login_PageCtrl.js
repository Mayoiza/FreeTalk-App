(function () {
    debugger
    'user strict'
    angular.module('FreeTalkApp')
    .controller('login_PageCtrl', ["$http", "$location","appSettings", login_PageCtrl]);
    function login_PageCtrl($http, $location, appSettings) {
        debugger
        var vm = this;
        
        //login function
        vm.login = function (data) {
            var coockie = {};
            debugger
            
            $http.get(appSettings.serverPath + 'Users/' + data.username + '/' + data.password)
                .then(onSuccess, onError);
            function onSuccess(response) {
                debugger
                if (response.data) {
                    
                    $location.path('/newsFeed/' + response.data);
                }
                
            };
            function onError(response) {
                debugger
                alert(response.data.message)
            }
        }

        //visitor function
        vm.visit = function () {
            debugger
            $location.path('/newsFeed/' + 'visitor')
        }
    }
})();