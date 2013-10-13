
function initSave(){
    $("#btnOk").click(function (e) {
        e.preventDefault();

        var taskName = $("#txtTask").val();
        $("#txtTask").val('');
        var param = {
            "action": "save",
            "taskName": taskName 
        };

        ajax(param, loadTasks);
    });
}

function initTasks(){
    $('#lstTasks').on('click', 'a.task', function(e) {
        e.preventDefault();

        var idTask = $(this).parent().get(0).id;
        var param = {
            "action": "remove",
            "idTask": idTask 
        };

        ajax(param, loadTasks);
    });
}

function initSearch() {
    $("#txtSearch").autocomplete({
        source: function (request, response) {
            var pageName = getCurrentPageName();
            var params = {
                "action": "search",
                "nocache": new Date().getTime()
            }
            $.getJSON(pageName, params, function (data) {
                response($.map(eval(data), function (item) {
                    return {
                        label: item.Name,
                        value: item.Id
                    }
                })
                      );
            });
        },
        select: function (event, ui) {
            alert('id: ' + ui.item.value + ' label: ' + ui.item.label);
            $("#txtSearch").val(ui.item.label);
            return false;
        }
    }); 
}

function init() {
    initSave();
    initTasks();
    initSearch();
    load();
}

function addNewTask(task){
    $("#lstTasks").append("<li id=" + task.Id + ">" + task.Name + "<a href='#' class='task'> X</a></li>");
}
function clearAllTasks(){
    $("#lstTasks li").remove();
}

function Task(name){
    this.guid = '';
    this.name =  name;
}

function loadAllTasks(){
    var param ={
        "action": "load"
    };
    ajax(param, loadTasksIntoControl);
}

function loadTasks(tasks){
    clearAllTasks();
    loadTasksIntoControl(tasks);
}
function loadTasksIntoControl(tasks){
    for(var cont = 0; cont < tasks.length; cont++){
            addNewTask(tasks[cont]);
        }
}
function load(){
    clearAllTasks();
    loadAllTasks();
}

$(function () {
    init();
});