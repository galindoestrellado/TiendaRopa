let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Productos Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar pagina _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "�ltimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "ajax": {
            "url": "/Producto/GetAll"
        },
        "columns": [
            { "data": "nombre" },
            { "data": "descripcion" },
            { "data": "talla" },
            { "data": "color" },
            {
                "data": "precio", "className": "text-end", "render": function (data) {
                    var d = data.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
                    return d;
                },
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Producto/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="bi bi-pencil-square"></i>
                                <a/>
                                <a onclick=Delete("/Producto/Delete/${data}") class="btn btn-danger text-white" style="cursor: pointer">
                                    <i class="bi bi-trash3-fill"></i>                                
                                </a>
                            </div>
                        `;
                }, "width": "20%"
            }
        ],
        "lengthMenu": [[2, 5, 10, 25, 100], [2, 5, 10, 25, 100]],
        "pageLength": 2
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de Eliminar el Producto?",
        text: "Este registro no podra ser rcuperado.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                method: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    });
}