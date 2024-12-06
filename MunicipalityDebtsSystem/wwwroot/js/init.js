(function () {
    $.fn.dataTable.ext.buttons.io_excel = {
        extend: 'excel',
        text: '<i class="file excel outline icon"></i>',
        titleAttr: 'Excel',
        className: 'ui basic button',
        exportOptions: {
            "columns": "thead th:not(.noExport)",
            "columns": ":visible",
            format: {
                body: function (data, row, column, node) {
                    if (data !== undefined && data !== null && data !== '') {
                        return (data + '').replace(/&nbsp;/g, '');
                    }
                    return data;
                }
            }
        }
    };

    $.fn.dataTable.ext.buttons.io_pdf = {
        extend: 'collection',
        text: '<i class="file pdf outline icon"></i>',
        titleAttr: 'Pdf',
        className: 'ui basic button',
        autoClose: true,
        buttons: [
            {
                extend: 'pdf',
                text: 'Портретно',
                exportOptions: {
                    "columns": "thead th:not(.noExport)"
                },
                orientation: 'portrait'
            },
            {
                extend: 'pdf',
                text: 'Пейзажно',
                exportOptions: {
                    "columns": "thead th:not(.noExport)"
                },
                orientation: 'landscape'
            }
        ]
    };

    $.fn.dataTable.ext.buttons.io_print = {
        extend: 'print',
        text: '<i class="print icon"></i>',
        titleAttr: 'Печат',
        className: 'ui basic button',
        exportOptions: {
            "columns": "thead th:not(.noExport)"
        }
    };

    $.fn.dataTable.ext.buttons.io_colvis = {
        extend: 'colvis',
        text: '<i class="eye outline icon"></i>',
        titleAttr: 'Видими Колони',
        className: 'ui basic button'
    };
    $.fn.dataTable.ext.buttons.io_pageLength = {
        extend: 'pageLength',
        className: 'ui basic button'
    };

    $.extend(true, $.fn.dataTable.defaults, {
        dom: '<"row"<"col-sm-6 dataTables_buttons"B><"col-sm-6"f>>rtip',
        //dom: '<"ui grid"<"eight wide column dataTables_buttons"B><"eight wide column right aligned"f>>rtip',
        //dom: '<"ui grid margin-bottom-2"<"eight wide column"B><"eight wide column right aligned"f>>rt<"ui grid margin-top-2"<"seven wide column"i><"nine wide column right aligned"p>>',
        buttons: {
            //dom: {
            //    button: {
            //        tag: 'button',
            //        className: 'ui basic compact button'
            //    },
            //    container: {
            //        className: 'ui compact buttons'
            //    }
            //},
            //buttons: ['io_pageLength', 'io_colvis', 'io_excel', 'io_pdf', 'io_print']
            buttons: ['io_pageLength', 'io_colvis']
        },
        lengthMenu: [
            [10, 25, 50, 100, -1],
            ['10 реда', '25 реда', '50 реда', '100 реда', 'Покажи всички']
        ],
        language: {
            url: "/lib/data-tables/dataTables.bgBG.json",
            search: "", // Change the default placeholder
            searchPlaceholder: "Търсене" // Custom placeholder text
        },
        //"bAutoWidth": false,
        //filter: true,
        //"bLengthChange": false,
        //"processing": true,
        //"paging": true,
        //"pageLength": 10
        bAutoWidth: true,
        filter: true,
        info: true,
        bLengthChange: false, //
        serverSide: false,
        processing: true,
        paging: true,
        pageLength: 10,
        stateDuration: -1,
        searching: true,
        stateSave: false
    });
})();