var datatables;

$(document).ready(function () {
    datatables = $('#Apptable').DataTable({
        "ajax": {
            "url": "/InternApplication/InternApplicationList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "dateOfApplication",
                "render": function (data) {
                    var date = new Date(data);  //convert date to short date                
                    return (date.toLocaleDateString())
                },
                "width": "10%",

            },

            {
                "data": "internName",
                "width": "25%",

            },
            {
                "data": "internshipTitle",
                "width": "25%",

            },
            {
                "data": "approvalName",
                "width": "20%",

            },
             {
                 "data": "internId",
                "width": "10%",
                 "render": function (data) {
                     return `<div class='text-center'>                       
                        <a class='btn btn-block btn-secondary' style=' background-color: #8E24AA' href='/InternApplication/InternInformation?id=${data}' title='View Intern information'><span class='fas fa-user'></span></a>
                       </div>`

                 }
            },

            {
                "data": "applicationId",
                "width": "10%",
                "render": function (data) {
                    return `<div class='text-center'>                       
                        <button type='button' class='btn btn-block btn-success' href='#' title='Approve or Deny application' data-toggle='modal' data-target='#addApplicationModal' data-whatever='${data}' ><span class='fas fa-stamp'></span></button>

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