(function () {

    'user strict'
    var FreeTalkApp = angular.module("FreeTalkApp",
        ["ngRoute", "ngResource", "ngCookies", "commonService", "ui.bootstrap"]);

    FreeTalkApp.config(function ($routeProvider) {

        $routeProvider
            .when('/', {
                templateUrl: "app/LoginPageForm/Login_Page.html",
                controller: "login_PageCtrl",
                controllerAs: "vm"
            })
                .when('/newsFeed/:Id', {
                    templateUrl: 'app/NewsFeedPage/news_Feed.html',
                    controller: "news_FeedCtrl",
                    controllerAs: "vm"
                })
            .otherwise({
                redirectTo: '/'
            });

    });
    
    

    //var FreeTalkApp = angular.module("FreeTalkApp",
    //    ["ui.router"]);

    //FreeTalkApp.config(["$stateProvider", "$urlRouterProvider",
    //        function ($stateProvider, $urlRouterProvider) {
    //            debugger
    //            $urlRouterProvider.otherwise("/");
    //            $stateProvider
    //                .state("login", {
    //                    url: "/",
    //                    templateUrl: "app/LoginPageForm/Login_Page.html",
    //                    //controller: "login_PageCtrl",
    //                    //controllerAs: "login_PageCtrl"
    //                })
    //            .state("home", {
    //                url: "/",
    //                templateUrl: "app/welcomeView.html"
    //            })
    //        }])
    //FreeTalkApp.controller('login_PageCtrl'),
    //    function login_PageCtrl($scope) {
    //        debugger
    //        var vm = this;
    //        vm.username = 'Maaaaaaaai';
    //    }
})();