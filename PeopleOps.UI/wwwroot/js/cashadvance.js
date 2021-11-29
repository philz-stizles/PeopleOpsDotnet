$(function () {
    var placeholderElement = $('#modal-placeholder');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        // prevent default button click actions
        event.preventDefault();

        // Grab form data and send it
        var form = $(this).parents('.modal').find('#cash-advance-form');
        var actionUrl = form.attr('action');
        var serializedFormData = form.serialize();

        $.post(actionUrl, serializedFormData).done(function (data) {
            // data is the rendered _CashAdvanceModalPartial
            var newBody = $('.modal-body', data);
            // replace modal contents with new form
            placeholderElement.find('.modal-body').replaceWith(newBody);

            // If Model.IsValid is true, close the modal
            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                placeholderElement.find('.modal').modal('hide');
            }
        });
    });
});



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