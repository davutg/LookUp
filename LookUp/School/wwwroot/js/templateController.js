(function () {
    "use strict";
    angular.module("app-trips")
    .controller("templateController", templateController);

    function templateController($scope) {
        var vm = this;
        vm.name = "tempalte controller!";
        vm.templateList = [ { name: "yeti", address: "/lib/bootswatch/yeti/bootstrap.min.css" },
                            { name: "default", address: "//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" },
                            { name: "lumen", address: "https://cdnjs.cloudflare.com/ajax/libs/bootswatch/3.3.6/lumen/bootstrap.min.css" },
                            { name: "cerulean", address: "//bootswatch.com/cerulean/bootstrap.min.css" },                         
                            { name: "cosmo", address: "//bootswatch.com/cosmo/bootstrap.min.css" },
                            { name: "cyborg", address: "//bootswatch.com/cyborg/bootstrap.min.css" },
                            { name: "flatly", address: "//bootswatch.com/flatly/bootstrap.min.css" },
                            { name: "journal", address: "//bootswatch.com/journal/bootstrap.min.css" },
                            { name: "readable", address: "//bootswatch.com/readable/bootstrap.min.css" },
                            { name: "simplex", address: "//bootswatch.com/simplex/bootstrap.min.css" },
                            { name: "slate", address: "//bootswatch.com/slate/bootstrap.min.css" },
                            { name: "spacelab", address: "//bootswatch.com/spacelab/bootstrap.min.css" },
                            { name: "united", address: "//bootswatch.com/united/bootstrap.min.css" },
                            { name: "darkly", address: "/lib/bootswatch/darkly/bootstrap.min.css" },
                            { name: "paper", address: "/lib/bootswatch/paper/bootstrap.min.css" },
                            { name: "sandstone", address: "/lib/bootswatch/sandstone/bootstrap.min.css" },
                            { name: "superhero", address: "/lib/bootswatch/superhero/bootstrap.min.css" }
        ];

        vm.changeTheme = function (theme) {
            vm.selectedTheme = theme;
            vm.selectedThemeOld = theme;
            $('#bootstrapCss').attr("href", theme.address);
            localStorage.theme = JSON.stringify(theme);
        }


        vm.changeThemeEnter = function (theme) {
            vm.selectedThemeOld = vm.selectedTheme;
            vm.selectedTheme = theme;            
        }


        vm.changeThemeLeave = function () {         
            vm.selectedTheme = vm.selectedThemeOld;
        }

        
        vm.selectedThemeOld = getTheme();
        vm.selectedTheme = getTheme();

        function getTheme(){
            if (localStorage.theme)
                return JSON.parse(localStorage.theme);
            return { name: "yeti", address: "/lib/bootswatch/yeti/bootstrap.min.css" };
        }
    };
}
)();