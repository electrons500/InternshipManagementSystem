var datatables;

$(document).ready(function () {
    datatables = $('#designationtbl').DataTable({
        "ajax": {
            "url": "/Designation/DesignationList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "designationId",
                "width": "20%",

            },

            {
                "data": "designationName",
                "width": "60%",

            },

            {
                "data": "designationId",
                "width": "20%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                         <a class='btn btn-secondary' style=' background-color: #8E24AA' href='/Designation/ChangeDesignation?id=${data}' title='Edit'><span class='fas fa-edit'></span></a>
                        <a class='btn btn-danger text-white' onClick=Delete('/Designation/RemoveDesignation?id=${data}') title='Delete' style='cursor:pointer' ><span class='fas fa-trash-alt'></span></a>
                   
                        </div>`

                }
            }

        ],
        "language": {
            //"processing": '<img src="/images/Rolling_loader.gif" alt="loader" width="100"  height="100" />',
            "emptyTable": "No records found"
        },
        "width": "100%",
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        responsive: true,
        processing: false

    });
});

function Delete(path) {
    swal({
        title: "Are you sure you want to delete?",
        text: "deletion cannot be undone",
        icon: "warning",
        buttons: true,
        dangermode: true

    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: path,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        //toastr.success(data.message);
                        swal("Congratulations!", data.message, "success");
                        datatables.ajax.reload();
                    } else {
                        //toastr.error(data.message);
                        swal("Sorry!", data.message, "Error");
                    }
                }
            })
        }

    })
}