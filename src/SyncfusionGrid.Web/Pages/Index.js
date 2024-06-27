var grid;

window.customAdaptor = new ej.data.UrlAdaptor();
customAdaptor = ej.base.extend(customAdaptor, {
    processResponse: function (data, ds, query, xhr, request, changes) {
        request.data = JSON.stringify(data);
        return ej.data.UrlAdaptor.prototype.processResponse.call(this, data, ds, query, xhr, request, changes)
    }
});


const BASE_URL = '/Index?handler=GridDataOperationHandler';

function onLoad() {
    this.dataSource = new ej.data.DataManager({
        url: BASE_URL,
        insertUrl: "/Index?handler=GridInsertPostHandler",
        updateUrl: "/Index?handler=GridUpdatePostHandler",
        removeUrl: "/Index?handler=GridRemovePostHandler",
        //crudUrl: "/Index?handler=GridCrudPostHandler",
        //batchUrl: "/Index?handler=GridBatchCrudPostHandler",
        adaptor: customAdaptor
    });
    this.dataSource.dataSource.headers = [{ 'XSRF-TOKEN': $("input:hidden[name='__RequestVerificationToken']").val() }];
}