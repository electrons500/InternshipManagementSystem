var datatables;

$(document).ready(function () {
    datatables = $('#studentApplicationList').DataTable({
        "ajax": {
            "url": "/InternApplication/StudentApplicationsList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
          
            {
                "data": "companyName",
                "width": "40%",

            },
            {
                "data": "internshipTitle",
                "width": "40%",

            },
            {
                "data": "dateOfApplication",
                "render": function (data) {
                    var date = new Date(data);  //convert date to short date                
                    return (date.toLocaleDateString())
                },
                "width": "10%",

            },

           
            {
                "data": "applicationId", 
                "width": "10%",
                "render": function (data) {
                    return `<div class='text-center'>                       
         
                         <a class='btn btn-danger text-white' onClick=Delete('/InternApplication/DeleteApplicationSent?id=${data}') title='Delete' style='cursor:pointer' ><span class='fas fa-trash-alt'></span></a>

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