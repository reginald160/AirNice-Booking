////var dataTable;

////$(document).ready(function () {
////    loadDataTable();
////});

////function loadDataTable() {
////    dataTable = $('#tblData').DataTable({
////        "ajax": {
////            "url": "/admin/client/GetAll",
////            "type": "GET",
////            "datatype": "json"
////        },

////        "columns": [
////            { "data": "name", "width": "30%" },
////            { "data": "customerUnqiueId", "width": "20%" },
////            { "data": "location", "width": "20%" },
////            {

////                "data": "id",
////                "render": function (data) {
////                    return `
////                          <div class="text-center">
////                              <a href="/Admin/Client/Upsert/${data}" class="btn btn-primary text-white" style="cursor:pointer; width: 100px;">
////                                     <i class="far fa-edit"></i>Edit
////                                </a>
////                                                &nbsp;
////  <a onclick=Delete("/Admin/Client/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
////                                     <i class="far fa-trash-alt"></i>Delete
////                                </a>
////                           </div>
////                           `;
////                }, "width": "30%"
////            }
////        ],
////        "language": {
////            "emptyTable": "No records Found"
////        },
////        "width": "100%"
////    });
////}

////function Delete(url) {
////    swal({
////        title: "Are You Sure You want to Delete?",
////        text: "You will not be able to restore the content!",
////        type: "warning",
////        showCancelButton: true,
////        confirmButtonColor: "#DD6B55",
////        confirmButtonText: "Yes, delete it!",
////        closeOnconfirm: true

////    }, function () {
////        $.ajax({
////            type: 'DELETE',
////            url: url,
////            success: function (data) {
////                if (data.success) {

////                    ShowMessage(data.message);
////                    dataTable.ajax.reload();
////                } else {
////                    toastr.error(data.message);
////                }
////            }
////        });
////    });


////}

////function ShowMessage(msg) {
////    toastr.success(msg);
////}


//var dataTable;

//$(document).ready(function () {
//    loadDataTable();
//});

//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({
//        "ajax": {
//            "url": "/Passenger/GetAll",
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "name", "width": "50%" },
//            { "data": "email", "width": "20%" },
//            {
//                "data": "id",
//                "render": function (data) {
//                    return `<div class="text-center">
//    <a href="/Passenger/Update/${data}" class='btn btn-success text-white'
//       style='cursor:pointer;'> <i class='far fa-edit'></i></a>
//    &nbsp;
//    <a onclick=Delete("/Passenger/Delete/${data}") class='btn btn-danger text-white'
//       style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
//</div>
//                            `;
//                }, "width": "30%"
//            }
//        ]
//    });
//}

//function Delete(url) {
//    swal({
//        title: "Are you sure you want to Delete?",
//        text: "You will not be able to restore the data!",
//        icon: "warning",
//        buttons: true,
//        dangerMode: true
//    }).then((willDelete) => {
//        if (willDelete) {
//            $.ajax({
//                type: 'DELETE',
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                        dataTable.ajax.reload();
//                    }
//                    else {
//                        toastr.error(data.message);
//                    }
//                }
//            });
//        }
//    });
//}