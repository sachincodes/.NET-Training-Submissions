// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var viewReview = 10;
function loadMorePosts() {
    debugger;
    $.ajax({
        url: '/Review/AddMore',
        method: 'GET',
        data: {
            skipItem: viewReview
        },
        dataType: 'json',
        success: function (data) {
            debugger
            console.log(data);
            if (data != null) {
                $(data).each(function (i) {
                    var postDiv = document.createElement('div');
                    postDiv.classList.add('card', 'mb-4');
                    if (this.id % 2 == 0) {
                        postDiv.innerHTML = `<div class="card-body text-right">
                                                    <div class="post-content">
                                                         <p class="card-text">${this.description}</p>
                                                    </div>
                                                </div>`;
                    }
                    else {
                        postDiv.innerHTML = `<div class="card-body text-left">
                                                    <div class="post-content">
                                                         <p class="card-text">${this.description}</p>
                                                    </div>
                                                </div>`;
                    }
                    $("#review").append(postDiv);
                    viewReview++;
                });
            }
        }
    });
}
$(window).scroll(function () {
    if ($(window).scrollTop() + $(window).height() == $(document).height()) {
        loadMorePosts();
    }
});