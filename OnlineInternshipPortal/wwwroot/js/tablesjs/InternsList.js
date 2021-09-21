var datatables;

$(document).ready(function () {
    datatables = $('#Internstbl').DataTable({
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
                        
                        <a class='btn btn-success'  href='/Admin/InternsDetails?id=${data}' title='Intern information'><span class='fa fa-user'></span></a>
                       
       
                        </div>`

                }
            }

        ],
        "language": {
            //"processing": '<img src="/images/Rolling_loader.gif" alt="loader" width="100"  height="100" />',
            "emptyTable": "No record found"
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