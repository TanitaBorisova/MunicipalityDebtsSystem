
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

            $(function () {
                $('#debtTable').DataTable({
                    dom: '<"row"<"col-sm-6 dataTables_buttons"B><"col-sm-6"f>>rtip',
                    serverSide:false,
                    ajax: {
                        "url": "@Url.Action("GetDebtsAdminForDataTable", "Debt")",

                        "type": "GET",
                        "datatype": "json",
                       

                    },
                    
                    language: {
                        url: "/lib/data-tables/dataTables.bgBG.json",
                        search: "", 
                        searchPlaceholder: "Търсене"
                    },
                    columns: [


                        {
                            name: 'debtNumber',
                            data: 'debtNumber',
                            title: 'Номер на дълг/анекс',
                            sortable: true,
                            searchable: true
                        },
                        {
                            name: 'debtParentNumber',
                            data: 'debtParentNumber',
                            title: 'Към договор№',
                            sortable: true,
                            searchable: true
                        },
                        {
                            
                            name: 'dateBook',
                            data: 'dateBook',
                            title: 'Начална дата на дълг',
                            sortable: true,
                            searchable: false,
                           
                        },
                        {
                           
                            name: 'dateContractFinish',
                            data: 'dateContractFinish',
                            title: 'Крайна дата на дълг',
                            sortable: true,
                            searchable: false,
                            
                        },
                         {
                            name: 'municipalityCode',
                            data: 'municipalityCode',
                            title: 'Код',
                            sortable: true,
                            searchable: true
                        },
                        {
                            name: 'municipalityName',
                            data: 'municipalityName',
                            title: 'Община',
                            sortable: true,
                            searchable: true
                        },
                        {
                            name: 'debtAmountOriginalCcy',
                            data: 'debtAmountOriginalCcy',
                            title: 'Размер на дълга в оригинална валута',
                            sortable: true,
                            searchable: true
                        },
                        {
                            name: 'currencyName',
                            data: 'currencyName',
                            title: 'Валута',
                            sortable: true,
                            searchable: true
                        },
                         {
                            name: 'statusName',
                            data: 'statusName',
                            title: 'Статус',
                            sortable: true,
                            searchable: true
                        },

                        {
                             name: 'actions',
                             data: 'id',
                             title: '',
                             sortable: false,
                             searchable: false,
                             className: "text-right",
                             render: function (data, type, row, meta) {
                                return '<a href="Debt/Details/' + row.id + '" class="btn btn-primary" title="Преглед"><i class="fa fa-info-circle"></i></a>';
                             }
                        },
                         {
                            data: 'id', 
                            title: 'Действия',
                            render: function (data, type, row) {
                                return '<button type="button" class="btn btn-danger" onclick="deleteDebt(' + row.id + ');"><i class="fa fa-trash"></i> Изтрий</button>';
                         }
            }

                       
                    ]
                });
            });
    


       
        function deleteDebt(id) {
            debugger
            if (confirm('Сигурни ли сте, че искате да изтриете този запис?')) {
                $.ajax({
                    url: '@Url.Action("DeleteDebt", "Debt")',
                    type: 'POST',
                    headers: { 'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val() },
                    data: { id: id },  
                    success: function (result) {
                        
                           if (result.success) {
                                alert('Записът беше успешно изтрит!');
                                $('#debtTable').DataTable().ajax.reload();  
                    } else {
                        alert(result.message);  
                    }

                    },
                    error: function () {
                        alert('Грешка при комуникация със сървъра!');
                    }
                });
            }
        }

       


// Expose the function globally
window.deleteDebt = deleteDebt;
