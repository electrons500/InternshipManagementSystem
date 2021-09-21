var datatables;

$(document).ready(function () {
    datatables = $('#emptable').DataTable({
        "ajax": {
            "url": "/Industry/IndustryList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "industryId",
                "width": "20%",

            },

            {
                "data": "industryName",
                "width": "60%",

            },
            
            {
                "data": "industryId",
                "width": "20%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                        <a class='btn btn-secondary' style=' background-color: #8E24AA' href='/Industry/ChangeIndustry?id=${data}' title='Edit'><span class='fas fa-edit'></span></a>
                        <a class='btn btn-danger text-white' onClick=Delete('/Industry/RemoveIndustry?id=${data}') title='Delete' style='cursor:pointer' ><span class='fas fa-trash-alt'></span></a>

                        
                   
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

    new $.fn.dataTable.FixHeader(datatables);
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