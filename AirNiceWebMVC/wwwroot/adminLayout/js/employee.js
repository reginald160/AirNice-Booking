var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Employee/Index",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "fullname", "width": "30%" },
            { "data": "staffCode", "width": "20%" },
            { "data": "Designation", "width": "20%" },
            { "data": "email", "width": "20%" },
            {

                "data": "id",
                "render": function (data) {
                    return `
                          <div class="text-center">
                              <a href="/Employee/Edit/${data}" class="btn btn-primary text-white" style="cursor:pointer; width: 100px;">
                                     <i class="far fa-edit"></i>Edit
                                </a>
                                                &nbsp;
  <a onclick=Delete("/Employee/Index/${data}") class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
                                     <i class="far fa-trash-alt"></i>Delete
                                </a>
                           </div>
                           `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No records Found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are You Sure You want to Delete?",
        text: "You will not be able to restore the content!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnconfirm: true

    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {

                    ShowMessage(data.message);
                    dataTable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            }
        });
    });


}

function ShowMessage(msg) {
    toastr.success(msg);
}