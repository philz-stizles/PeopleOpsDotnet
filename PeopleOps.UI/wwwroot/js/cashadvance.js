function Create() {
    var data = $("#cashAdvances").serialize();
    console.log(data);
    $.ajax({
        url: "/Dashboard/CashAdvances/Index/?handler=Post",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        dataType: "json",
        success: function (data) {
            console.log(data)
        },
        failure: function (response) {
            console.log(response);
        }
    })
}

function Edit(url) {
    $.ajax({
        url: url,
        type: 'PUT',
        data: {
            name: '',
            description: ''
        },
        datatype: 'json',
        success: function (data) {
            console.log(data)
            if (data.status) {
                toastr.success(data.message)
                dataTable.ajax.reload()
            } else {
                toastr.error(data.message)
            }
        }
    })
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "This action is irreversible",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            url: url,
            type: "DELETE",
            success: function (data) {
                console.log(data)
                if (data.status) {
                    toastr.success(data.message)
                    dataTable.ajax.reload()
                } else {
                    toastr.error(data.message)
                }
            }
        })
    })
}