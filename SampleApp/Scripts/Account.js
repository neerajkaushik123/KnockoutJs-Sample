var accountmodel;

$(document).ready(function () {

    //initializing viewmodel
    accountmodel = new viewModel();
    //binding for ko
    ko.applyBindings(accountmodel);
    //bind event
    $("#btnSearch").click({ handler: accountmodel.Search });
    $("#btnSave").click({ handler: accountmodel.Update });


});

function viewModel() {
    var self = this;

    self.AccountId = ko.observable('');
    self.Name = ko.observable('');
    self.Balance = ko.observable(null);
    self.SearchCriteria = ko.observable('');

    self.Search = function () {

        $.ajax({
            url: "Account/Search",
            data: { SearchCriteria: self.SearchCriteria },
            type: "POST",
            success: function (response) {
                self.AccountId(response.AccountId);
                self.Name(response.Name);
                self.Balance(response.Balance);
            }
        });
    };

    self.Update = function () {
        $.ajax({
            url: "Account/Update",
            data: { AccountId: self.AccountId, Name: self.Name },
            type: "POST",
            success: function (response) {
                self.AccountId(response.AccountId);
                self.Name(response.Name);
                self.Balance(response.Balance);
            }
        });

    }
};