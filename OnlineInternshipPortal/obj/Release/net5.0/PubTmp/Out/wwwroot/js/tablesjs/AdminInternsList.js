var datatables;

$(document).ready(function () {
    datatables = $('#emptable').DataTable({
        "ajax": {
            "url": "/Interns/InternsList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "fullName",
                "width": "50%",

            },

            {
                "data": "genderName",
                "width": "10%",

            },
            {
                "data": "contactNumber",
                "width": "20%",

            },
            {
                "data": "internId",
                "width": "20%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                        <a class='btn btn-secondary' style=' background-color: #8E24AA' href='/Admin/InternsDetails?id=${data}' title='Intern information'><span class='fas fa-user'></span></a>
                        
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