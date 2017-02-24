(function () {

    "user strict";


    var login_PageService = function ($resource, appSettings) {


        return {

            GetAll: $resource(appSettings.serverPath + 'Users/:userName/:password'),
            //Getfiscalyear: $resource(appSettings.serverPath + 'gl/fiscalyear/:compCode/:branchCode'),


        };



        //end of function main
    };










    angular
.module("commonService")
.factory("login_PageService",
["$resource", "appSettings",
login_PageService]);
}());