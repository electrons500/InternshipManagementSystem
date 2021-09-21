var datatables;

$(document).ready(function () {
    datatables = $('#tblAdmin').DataTable({
        "ajax": {
            "url": "/Users/AdminsList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "userFullName",
                "width": "50%",

            },

            {
                "data": "userPhone",
                "width": "20%",

            },
             {
                 "data": "roleName", 
                "width": "20%",

            },

            {
                "data": "userId",
                "width": "10%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                        <a class='btn btn-primary'  href='/Users/GetUserDetails?id=${data}' title='Details'><span class='fas fa-edit'></span></a>
                                       
                        </div>`

                }
            }

        ],
        "language": {
            "processing": '<div class="spinner-border text-primary"></div>',
            zeroRecords: "No record found"
        },
        "width": "100%",
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        responsive: true,
        processing: false,


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
                        swal("Congratulation!", data.message, "success");
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