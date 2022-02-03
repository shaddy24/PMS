$(function () {
    //'use strict';
    $('#emp-info').jqGrid({
        url: 'Administration/Employee/EmployeeInfo',
        datatype: 'json',
        mtype: 'Post',
        colNames: [
            { name: 'Id'},
            { name: 'Name'},
            { name: 'Birthday'},
            { name: 'Gender'},
            { name: 'ContactNumber'},
            { name: 'Email'},
            { name: 'Address'},
        ],
        height: '100%',
        rowNum: 10,
        viewrecords: true,
        caption: 'Testing lang',
        emptyrecords: 'No records found',
        autowidth: true
    });
});

  //  public int TotalNoOfRecords { get; set; }
  //  public string SearchField { get; set; }
  //  public string SearchValue { get; set; }