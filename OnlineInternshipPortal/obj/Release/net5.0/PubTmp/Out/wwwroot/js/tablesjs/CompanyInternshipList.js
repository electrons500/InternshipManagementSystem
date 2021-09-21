var datatables;

$(document).ready(function () {
    datatables = $('#emptable').DataTable({
        "ajax": {
            "url": "/Internship/CompanyInternshipList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "title",
                "width": "40%",

            },

            {
                "data": "location",
                "width": "20%",

            },
             {
                 "data": "postedDate",
                 "render": function (data) {
                     var date = new Date(data);  //convert date to short date                
                     return (date.toLocaleDateString())
                 },
                "width": "20%",

            },

            {
                "data": "internshipId",
                "width": "30%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                        <a class='btn btn-secondary' style=' background-color: #8E24AA' href='/Internship/UpdateInternship?id=${data}' title='Edit'><span class='fas fa-edit'></span></a>
                       
                   
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