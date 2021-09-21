var datatables;

$(document).ready(function () {
    datatables = $('#emptable').DataTable({
        "ajax": {
            "url": "/VerifyCompany/VerifyApprovedCompanyList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "companyName",
                "width": "50%",

            },

            {
                "data": "verifyCategoryName",
                "width": "20%",

            },

            {
                "data": "companyId",
                "width": "30%",
                "render": function (data) {
                    return `<div class='text-center'>                                             
                        <a class='btn btn-danger text-white'  onClick=Deny('/VerifyCompany/DenyCompany?id=${data}') title='Deny company' style='cursor:pointer' ><span class='fas fa-times'></span> Deny</a>
                        
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


function Deny(path) {
    swal({
        title: "Do you want to deny this company?",
        text: "Status will be updated after clicking OK",
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