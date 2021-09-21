var datatables;

$(document).ready(function () {
    datatables = $('#Companytbl').DataTable({
        "ajax": {
            "url": "/Admins/CompanyList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
           
            {
                "data": "companyName",
                "width": "30%",

            },
            
            {
                "data": "companyLocation",
               
                "width": "20%",

            },
            {
                "data": "contactNumber",
                "width": "10%",

            },
            {
                "data": "companyEmail",
                "width": "20%",

            },


            {
                "data": "companyId",
                "width": "20%",
                "render": function (data) {
                    return `<div class='text-center'>
                         <a class='btn btn-secondary' style=' background-color: #8E24AA' href='/Admin/CompanyDetails?id=${data}' title='Company details'><span class='fas fa-edit'></span></a>

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