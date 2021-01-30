// Call the dataTables jQuery plugin
$(document).ready(function() {
    $('#dataTable').DataTable({
        "lengthMenu": [[20, 40, 60, 100, 150, 200, -1], [20, 40, 60, 100, 150, 200, "All"]],
        "order": [[ 0, "desc" ]]
    });
});
