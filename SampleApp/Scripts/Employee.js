var employeemodel;

$(document).ready(function () {

    //initializing viewmodel
    employeemodel = new viewModel();
    //binding for ko
    ko.applyBindings(employeemodel);
    //bind event
    $("#btnSearch").click({ handler: employeemodel.search });
    
    //template markup
    var markup = "<tr><td>${EmployeeID}</td><td>${Name}</td><td>${Address}</td><td>${Phone}</td></tr>";

    $.template("gridTemplate", markup);
    
});
    
function viewModel() {
    var self = this;
    self.employees = ko.observableArray([]);
    self.empname = ko.observable('');
    self.search = function () {
        $.ajax({
            url: "Employee/Search",
            data: { EmpName: self.empname },
            type: "POST",
            success: function (response) {
                //bind data                
            //    self.employees(response.Items);
                //Jquery template
                $("#datalist").empty();
                $.tmpl("gridTemplate", response.Items).appendTo("#datalist");
            }
        });

    }
}
