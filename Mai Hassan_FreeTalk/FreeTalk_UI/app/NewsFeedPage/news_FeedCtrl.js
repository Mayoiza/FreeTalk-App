(function () {
    debugger
    'user strict'
    angular.module('FreeTalkApp')
    .controller('news_FeedCtrl', ["$resource", "$http", "$location", "$cookieStore", "appSettings",
                "news_FeedService", "$route", "$routeParams", news_FeedCtrl]);
    function news_FeedCtrl( $resource, $http, $location, $cookieStore, appSettings, news_FeedService, $route, $routeParams) {
        debugger
        var vm = this;
        tempD = [];

        
        //intialze var
        vm.postType = 'All';
        vm.userName = '0';
        
        var z = {};
        //*End intialze var

        //////Intialize Service

        //get all posts from database
        news_FeedService.GetAllPosts.query(
            function (data) {
                debugger
                vm.comments = data;
                tempD = vm.comments;
            });
        //get all users
        news_FeedService.getAllUsers.query(
            function (data) {
                debugger
                vm.users = data;
            });
        //////*End Intialize Service

        ///////////Functions of Main Posts

        //Submit for main comments
        vm.submit = function (data) {
            debugger
            var x = {};
            if ($routeParams.Id != 'visitor') {
                x.postContent = data.postArea;
                x.UserId = $routeParams.Id;
                x.postType = 'Social';
                $resource(appSettings.serverPath + 'Posts/add').save(x)
                    .$promise.then(
                    function (value) {
                        debugger
                        vm.postArea = '';
                        news_FeedService.GetAllPosts.query(
                            function (data) {
                                debugger
                                vm.comments = data;
                                
                            });                        
                        vm.messageSuc = true;
                        vm.messageErr = false;
                        $('#endMessage').modal('show');
                        vm.SuccessMess = "Post has been Added Successfully!";
                    },
                    function (error) {
                        debugger
                        vm.messageSuc = false;
                        vm.messageErr = true;
                        $('#endMessage').modal('show');
                        vm.ErrMassge = "Failed!";
                    }
        )
            }
            else {
                vm.messageSuc = false;
                vm.messageErr = true;
                $('#endMessage').modal('show');
                vm.ErrMassge = "You are not Authorized!";
            }
        }


        
        //edit comments
        vm.showEdit = function (data) {
            debugger
            var index = -1;
            if (data.userId == $routeParams.Id) {
                
                for (var i = 0; i < vm.comments.length; i++) {
                    if (vm.comments[i].id === data.id) {
                        index = i;
                        break;
                    }
                }
                z = vm.comments[index];                
                vm.editArea = vm.comments[index].postContent;
                vm.userId = vm.comments[index].userId;
                vm.commentId = vm.comments[index].id;
                $('#editPlace').modal('show');                  
            }
            else {
                vm.messageSuc = false;
                vm.messageErr = true;
                $('#endMessage').modal('show');
                vm.ErrMassge = "You are not Authorized!";
            }
        }

        vm.editMainComment = function () {
            debugger
            debugger
            var x = {};
            if ($routeParams.Id != 'visitor' && $routeParams.Id == vm.userId) {
                x = z;
                x.postContent = vm.editArea;
                x.updateDate = new Date();
                x.createDate = x.updateDate;
                x.postType = 'Social';
                $resource(appSettings.serverPath + 'Posts/edit/' + vm.commentId).save(x)
                    .$promise.then(
                    function (value) {
                        debugger
                        vm.postArea = '';
                        news_FeedService.GetAllPosts.query(
                            function (data) {
                                debugger
                                vm.comments = data;
                            });
                        vm.messageSuc = true;
                        vm.messageErr = false;
                        $('#endMessage').modal('show');
                        vm.SuccessMess = "Post has been Updated Successfully!";
                        
                    },
                    function (error) {
                        debugger
                        vm.messageSuc = false;
                        vm.messageErr = true;
                        $('#endMessage').modal('show');
                        vm.ErrMassge = "Failed!";
                    }
        )
            }
            else {
                vm.messageSuc = false;
                vm.messageErr = true;
                $('#endMessage').modal('show');
                vm.ErrMassge = "You are not Authorized!";
            }
        }

        //delete whyyyyyy?
        vm.confirmDelete = function (data) {
            debugger
            var x = {};
            if (data.userId === Number($routeParams.Id)) {
                $('#alertMessage').modal('show');
                vm.idDel = data.id;
                vm.userIdDel = data.userId;
            } else {
                vm.messageSuc = false;
                vm.messageErr = true;
                $('#endMessage').modal('show');
                vm.ErrMassge = "You are not Authorized!";
            }
        }
        vm.delete = function () {
            debugger
            var x = {};
            if (vm.userIdDel === Number($routeParams.Id)) {
                $resource(appSettings.serverPath + 'Posts/delete/' + vm.idDel + '/' + vm.userIdDel)
                    .delete().$promise.then(
                    function (value) {
                        debugger
                        news_FeedService.GetAllPosts.query(
                            function (data) {
                                debugger
                                vm.comments = data;
                            });
                        vm.messageSuc = true;
                        vm.messageErr = false;
                        $('#endMessage').modal('show');
                        vm.SuccessMess = "Post has been Deleted Successfully!";
                    },
                    function (error) {
                        debugger
                        vm.messageSuc = false;
                        vm.messageErr = true;
                        $('#endMessage').modal('show');
                        vm.ErrMassge = "Failed!";
                    }
        )
            }
            else {
                vm.messageSuc = false;
                vm.messageErr = true;
                $('#endMessage').modal('show');
                vm.ErrMassge = "You are not Authorized!";
            }
        }
        //*End delete


        //Filtraion
        vm.filtration = function (data) {
            news_FeedService.getUserTypePost.query(
                { type: vm.postType, userID: vm.userName },
            function (data) {
                debugger
                vm.comments = data;
            });
        }

        //*End Filtraion
        ///////////*End Functions

        //////////Functions of Modal of Comments
        //show modal of comments
        vm.showComments = function (parentId) {
            debugger
            news_FeedService.GetComments.query(
                { id: parentId },
                function (data) {
                    debugger
                    vm.tempComments = data;
                    vm.parentId = parentId;
                    $('#comments_data').modal('show');

                })
        }

        //submit for replies of comment        
        vm.submitReply = function (data) {
            debugger
            var x = {};
            if ($routeParams.Id != 'visitor') {
                x.postContent = data.replyArea;
                x.UserId = $routeParams.Id;
                x.postType = 'Social';
                x.parentID = vm.parentId;
                $resource(appSettings.serverPath + 'Posts/add').save(x)
                    .$promise.then(
                    function (value) {
                        debugger
                        vm.replyArea = '';
                        news_FeedService.GetComments.query(
                            { id: value.parentID },
                            function (data) {
                                vm.tempComments = data;
                            })
                        vm.messageSuc = true;
                        vm.messageErr = false;
                        $('#endMessage').modal('show');
                        vm.SuccessMess = "Post has been Added Successfully!";
                    },
                    function (error) {
                        debugger
                        vm.messageSuc = false;
                        vm.messageErr = true;
                        $('#endMessage').modal('show');
                        vm.ErrMassge = error.data.message;

                          //  "Failed!";
                    }
        )
            }
            else {
                vm.replyArea = '';
                $('#comments_data').modal('hide');
                vm.messageSuc = false;
                vm.messageErr = true;
                $('#endMessage').modal('show');
                vm.ErrMassge = "Please Register First!";
            }
        }


        //////////Functions of Modal of Comments

    }
})();