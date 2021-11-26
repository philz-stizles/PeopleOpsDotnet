function Create(url,) {
    $.ajax({
        url: url,
        type: 'POST',
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