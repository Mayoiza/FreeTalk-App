(function () {
    
    'user strict'
    angular.module('commonService',
        ['ngResource'])
        .constant('appSettings',
        {
            serverPath: 'http://localhost:56630/api/',
        })
}());