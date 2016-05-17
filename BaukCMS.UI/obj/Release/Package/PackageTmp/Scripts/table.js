$(document).ready(function() {
    $("table.grid-table tr").each(function(i) {
        if (i % 2 === 0) $(this).addClass("even");
    });
    $("table.grid-table tr td:last-child").css("width", "100%").css("text-align", "right");
});