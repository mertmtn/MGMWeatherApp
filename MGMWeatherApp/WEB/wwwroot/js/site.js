// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let cities, districts;

function getCities(citiesCallBackFn) {
    $.ajax({
        url: '/Location/GetCityList',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: (response) => {
            console.log("success", response);

            cities = response;

            if (citiesCallBackFn) {
                console.log("cities callbak fn");
                citiesCallBackFn();
            }
        },
        error: (response) => {
            console.log("error", response);
        }
    });
}

function getDistricts(cityId, districtsCallBakFn) {
    $.ajax({
        url: '/Location/GetDistrictList?cityId=' + cityId,
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: (response) => {
            console.log("success", response);

            districts = response;

            if (districtsCallBakFn) {
                districtsCallBakFn();
            }
        },
        error: (response) => {
            console.log("error", response);
        }
    });
}


function fillCitySelect(selectElementId, selectedCityId) {
    $(selectElementId).empty();
    $(selectElementId).append(`<option value="-1">İl seçiniz</option>`);

    if (cities) {
        cities.forEach(city => {
            $(selectElementId).append(`<option value="${city.id}">${city.name}</option>`);
        });
    }

    if (selectedCityId > 0) {
        $(selectElementId).val(selectedCityId);
    }
}

function fillDistrictSelect(selectElementId, selectedDistrictId) {
    console.log("fillDistrictselect 1", districts);
    console.log("fillDistrictselect 2", selectedDistrictId);
    $(selectElementId).empty();
    $(selectElementId).append(`<option value="-1">İlçe seçiniz</option>`);

    if (districts) {
        districts.forEach(district => {
            $(selectElementId).append(`<option value="${district.id}">${district.name}</option>`);
        });
    }

    if (selectedDistrictId > 0) {
        $(selectElementId).val(selectedDistrictId);
    }
}

