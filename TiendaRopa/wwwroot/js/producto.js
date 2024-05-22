let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar page _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
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
        ]

    });
}