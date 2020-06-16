$.getJSON("/json/crayola.json", (colors) => {
    var cardimgs = document.getElementsByClassName('cardImg');
    for (var i = 0; i < cardimgs.length; i++) {
        //var colors = ['#ff0000', '#00ff00', '#0000ff'];
        var random_color = colors[Math.floor(Math.random() * colors.length)].hex;
        cardimgs[i].style.backgroundColor = random_color;
    }
    var books = document.getElementsByClassName('book');
    for (var i = 0; i < books.length; i++) {
        //var colors = ['#ff0000', '#00ff00', '#0000ff'];
        var random_color = colors[Math.floor(Math.random() * colors.length)].hex;
        books[i].style.backgroundColor = random_color;
    }
});