(function ($) {
    var appService = mohaProject.entities.entity;
    
    abp.ui.extensions.tableColumns.get('entity').addContributor(
        function (columnList) {
            columnList.addManyTail(
                [
                    {
                        title: "Comments",
                        data: 'comments',
                    },
                    {
                        title: "Rating",
                        data: 'rating',
                    },
                ]
            );
        },
        0 //adds as the first contributor
    );

    var _$wrapper = $('#Wrapper');
    var _$table = _$wrapper.find('table');
    var dataTable = _$table.DataTable(
        abp.libs.datatables.normalizeConfiguration({
            ordering: true,
            order: [[0, 'asc']],
            lengthChange: true,
            lengthMenu: [25, 50, 100],
            pageLength: 25,
            pagingType: screen.width > 500 ? "simple_numbers" : "full",
            processing: true,
            serverSide: true,
            responsive: true,
            //scrollX: true,
            //scrollY: 100,
            //scrollCollapse: true,
            autoWidth: true,
            stateSave: false,
            paging: true,
            info: true,
            searching: false,
            ajax: abp.libs.datatables.createAjax(appService.getFeedbacks),            
            columnDefs: abp.ui.extensions.tableColumns.get('entity').columns.toArray()
        })
    );

})(jQuery);