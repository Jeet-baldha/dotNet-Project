// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$().ready(function () {

    $('.today').click(function () {
        $('.today').addClass('selected');
        $('.week').removeClass('selected');
        $('.dayList').css('display', 'flex');
        $('.weekList').css('display', 'none');

    });

    $('.week').click(function () {
        $('.week').addClass('selected');
        $('.today').removeClass('selected');
        $('.weekList').css('display', 'flex');
        $('.dayList').css('display', 'none');

    });

    $('#menu-btn').click(function () {
        $('.navbar').css('left', '0');
    });

    $('#close-btn').click(function () {
        $('.navbar').css('left', '-250px');
    });

    $('.fa-user').click(function () {
        $('.drop-down-box').css('display', 'block');
    })


    $(".drop-down-box").hover(function () {
        $('.drop-down-box').css('display', 'block');
    },
        function () {
            $('.drop-down-box').css('display', 'none');
        });






    var page = 2;
    const apiKey = "73b27bfeb96b523c9a9f0eeabaa2b90f";
    $('#load-more').click(function () {

        var url = `https://api.themoviedb.org/3/movie/popular?page=${page}&api_key=${apiKey}`;
        let html = "";
        $.get(url, function (data) {
            data.results.forEach(movie => {
                html += `<div class="movie-card">
                <a href="/Home/Movie/${movie.id}"><img src="https://image.tmdb.org/t/p/w500/${movie.poster_path}"
                        alt="${movie.title} Poster" /></a>
                        <div class="details">
                    <div class="rating" style="font-size: 12px">
                        ${movie.vote_average.toFixed(2)}
                    </div>
                    <h4 class="movie-name">
                        ${movie.title}
                    </h4>
                    <p class="movie-date" style="font-size: 12px">
                        ${movie.release_date}
                    </p>
                </div>
            </div>`
            });
            $(".movie-content").append(html);
            page++;
        });
    });

});



    function submitForm() {
        var query = document.getElementById("query").value;
        if (query) {
            query = query.replace(/ /g, "%20");
            var url = `/Home/Search?query=${query}`;
                window.location.href = url;
        } else {
                alert("Please enter a search query.");
         }
    }

    document.getElementById("search-form").addEventListener("submit", function (event) {
        event.preventDefault();
    });

