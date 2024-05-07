// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    var currentGame = "";
    var aimLock = 0;

    var gameList = function (newest) {

        $.ajax({
            url: "api/grid/all",
            headers: {
                'x-api-key': 'sample-key-check'
            },
            type: 'GET',
            success: function (data) {

                console.log(data);

                $('#game-list').html("");

                for (var i = 0; i < data.length; i++) {
                    $('#game-list').append('<a class="game-link" href="#" id="' + data[i] + '">' + data[i] + '</a>');
                    if (i < data.length - 1) {
                        $('#game-list').append(' // ');
                    }
                }

                $('.game-link').on('click', function () {

                    var gameId = $(this).attr("id");

                    loadGame(gameId);
                });

                if (typeof newest === 'string' && newest.length > 0) {
                    $('#' + newest).css("background-color", "yellow").fadeOut(300).fadeIn(300);
                }

            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }

    var loadGame = function (id) {

        $('#grid-view').html("");
        $('#drop-aim').html("");

        $('.game-link').css("background-color", "white");

        $('#' + id).css("background-color", "yellow").fadeOut(300).fadeIn(300);

        $.ajax({
            url: `api/grid/${id}`,
            headers: {
                'x-api-key': 'sample-key-check'
            },
            type: 'GET',
            success: function (data) {

                console.log(data);

                currentGame = id;

                var y = 0;

                for (const prop in data.jsonGrid) {

                    $('#grid-view').append('<p class="grid-row">');

                    var row = data.jsonGrid[prop];

                    if (y == 0 && row.length > 0) {
                        for (var a = 0; a < row.length; a++) {
                            $('#drop-aim').append(`<span><input type="radio" id="col-${a}" name="col-aim" /></span>`);
                        }

                        if (aimLock >= row.length) {
                            aimLock = 0;
                        }

                        $(`#col-${aimLock}`).prop('checked', true);
                    }

                    for (var dc = 0; dc < row.length; dc++) {
                        $('#grid-view').append(`<span class="grid-tile"><a href="#" id="tile.${dc}-${y}" class="tile tile-${row[dc]}">[${row[dc]}]</a></span>`);
                    }

                    $('#grid-view').append('</p>');

                    y++;
                }

                $('#remove').hide();

                $('.tile').on('click', function () {

                    var value = $(this).text();

                    if (value === '[0]') {
                        return;
                    }

                    $(this).addClass('marked');

                    $('#remove').show();
                });

                $('#drops').show();
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    };

    $('#new-game').on('click', function () {

        $.get("api/grid", function (data) {

            console.log(data);

            loadGame(data.id);

            gameList(data.id);
        });

    });

    $('.on-drop').on('click', function () {

        var dropValue = $(this).text() * 1;

        var dropTarget = $('input[name="col-aim"]:checked').attr('id').split('-')[1];

        aimLock = dropTarget;

        var newDrop = { Column: dropTarget, Value: dropValue }

        $.ajax({
            url: `api/grid/${currentGame}/drop`,
            headers: {
                'x-api-key': 'sample-key-check'
            },
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(newDrop),
            success: function (response) {
                console.log(response);
                loadGame(currentGame);
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    });

    $('#remove').on('click', function () {

        var marked = $('.marked').map(function () {
            return this.id.split('.')[1];
        }).get();

        $.ajax({
            url: `api/grid/${currentGame}/remove`,
            headers: {
                'x-api-key': 'sample-key-check'
            },
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(marked),
            success: function (response) {
                console.log(response);
                loadGame(currentGame);
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });

    });

    gameList();
});