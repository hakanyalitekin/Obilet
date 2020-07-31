
let today = moment().format("YYYY-MM-DDTHH:mm");
let tomorrow = moment().add(1, 'days').format("YYYY-MM-DDTHH:mm");
var selectedOrigin;
var selectedDestination;

$(document).ready(function () {

    //Tarih seçilirken dünün seçilememesini sağlıyor.
    $("#departureDate").attr("min", today);

    //Sayfa yüklendikten sonra yarının tarihini set ediyor.
    $("#departureDate").val(tomorrow)


    //START-> iki selecet optionda da aynı konumun seçilememesini sağlıyor.
    $("#origin").select2({
        theme: 'bootstrap4',
    });

    var busLocationArray = [];

    $("#origin > option").each(function () {
        busLocationArray.push({
            "id": this.value,
            "text": this.text
        });
    });

    $("#destination").select2({
        theme: 'bootstrap4',
    });

    $('#origin').on("select2:select", function (e) {
        $("#destination").select2().empty();
        var filtered = busLocationArray.filter(function (item) {
            return item.id !== $('#origin').val();
        });
        $("#destination").select2({
            theme: 'bootstrap4',
            data: filtered
        });
    });
    //END-> iki selecet optionda da aynı konumun seçilememesini sağlıyor.


    //localStorage ile kullanıcının son seçimlerini getiriyoruz.
    $('#origin').val(localStorage.getItem("origin")).trigger('change')
    $('#destination').val(localStorage.getItem("destination")).trigger('change')
    $('#departureDate').val(localStorage.getItem("departureDate"));

    // İki listede de İstanbul Avrupa çıkmamasını sağlıyor. 2. listeye Anadoluyo set ediyor.;
    if (localStorage.getItem("destination") === "") {
        $('#origin').val(349).trigger('change')
        $('#destination').val(356).trigger('change')
        $("#departureDate").val(tomorrow);
    }

});

//START -> Bugün - Yarın butonları ile set etme işlemi.
function getToday() {
    $("#departureDate").val(today);
    localStorage.setItem("departureDate", today);
}
function getTomorrow() {
    $("#departureDate").val(tomorrow);
    localStorage.setItem("departureDate", tomorrow);
}
//END -> Bugün - Yarın butonları ile set etme işlemi.

function changeLocation() {

    selectedOrigin = $("#origin option:selected").val();
    selectedDestination = $("#destination option:selected").val();
    $('#destination').val(selectedOrigin).trigger('change')
    $('#origin').val(selectedDestination).trigger('change')

}

//START-> localStorage ile kullanıcının son seçimlerini tutuyoruz.
$('#departureDate').change(function () {
    localStorage.setItem("departureDate", this.value);
});

$('#origin').change(function () {
    localStorage.setItem("origin", this.value);
});
$('#destination').change(function () {
    localStorage.setItem("destination", this.value);
});
//EN-> localStorage ile kullanıcının son seçimlerini tutuyoruz.
