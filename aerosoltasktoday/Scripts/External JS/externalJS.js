function foo() {
    var employee_name = $("#idname").val();
    var employee_phone = $("#idnumber").val();
    var employee_salary = $("idsalary").val();
    var employee_birthdate = $("#iddob").val();
    var employee_mail = $("#idmail").val();
    if (employee_name == "") {
        alert("Please Enter the Name");
    }

    else if (employee_phone == "") {
        alert("Please Enter the Phone Number")
        return false;

    }
    else if (employee_salary == "") {
        alert("Please Enter the salary")
        return false;

    }
    else if (employee_birthdate == "") {
        alert("Please Enter the Birthdate")
        return false;

    }
    else if (employee_mail == "") {
        alert("Please Enter the E-mail")
        return false;

    }
    else {
        alert("Data Submitted Successfully")
        return true;
    }

}