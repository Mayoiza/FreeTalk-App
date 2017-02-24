(function () {

    "user strict";


    var news_FeedService = function ($resource, appSettings) {


        return {

            GetAllPosts: $resource(appSettings.serverPath + 'Posts'),
            GetComments: $resource(appSettings.serverPath + 'Posts/:id'),
            filterType: $resource(appSettings.serverPath + 'Posts/filter/:Type'),
            getAllUsers: $resource(appSettings.serverPath + 'Users'),
            getUserPost: $resource(appSettings.serverPath + 'Posts/user/:userId'),
            getUserTypePost: $resource(appSettings.serverPath + 'Posts/:type/:userID'),

        };



        //end of function main
    };

    angular
.module("commonService")
.factory("news_FeedService",
["$resource", "appSettings",
news_FeedService]);
}());