var datatables;

$(document).ready(function () {
    datatables = $('#tblHiredInterns').DataTable({
        "ajax": {
            "url": "/HiredInterns/AllHiredInternList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            {
                "data": "internName",
                "width": "35%",

            },
            {
                "data": "companyName",
                "width": "35%",

            },
            {
                "data": "hireDate",
                "render": function (data) {
                    var date = new Date(data);  //convert date to short date                
                    return (date.toLocaleDateString())
                },
                "width": "15%",

            },

            {
                "data": "hireId",
                "width": "15%",
                "render": function (data) {
                    return `<div class='text-center'>
                                            
                        <a class='btn btn-danger text-white' onClick=Delete('/HiredInterns/DeleteHiredInterns?id=${data}') title='Delete' style='cursor:pointer' ><span class='fas fa-trash-alt'></span></a>                      
                   
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