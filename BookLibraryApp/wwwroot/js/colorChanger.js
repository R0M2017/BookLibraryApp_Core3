$.getJSON("/json/crayola.json", (colors) => {
    var cardimgs = document.getElementsByClassName('cardImg');
    for (var i = 0; i < cardimgs.length; i++) {
        //var colors = ['#ff0000', '#00ff00', '#0000ff'];
        var random_color = colors[Math.floor(Math.random() * colors.length)].hex;
        cardimgs[i].style.backgroundColor = random_color;
    }

    var random_book1_color = colors[Math.floor(Math.random() * colors.length)].hex;
    var random_book2_color = colors[Math.floor(Math.random() * colors.length)].hex;
    var random_book3_color = colors[Math.floor(Math.random() * colors.length)].hex;
    var book1 = document.getElementById('book-1');
    // var book1 = document.getElementsByClassName('book1');
    var book2 = document.getElementById('book-2');
    // var book2 = document.getElementsByClassName('book2');
    var book3 = document.getElementById('book-3');
    // var book3 = document.getElementsByClassName('book3');

    var random_bookborder_color = colors[Math.floor(Math.random() * colors.length)].hex;
    var bookborder = document.getElementById('book-border');

    if (book1 != null && book2 != null && book3 != null && bookborder != null) {
        book1.style.backgroundColor = random_book1_color;
        book2.style.backgroundColor = random_book2_color;
        book3.style.backgroundColor = random_book3_color;
        bookborder.style.borderColor = random_bookborder_color;
    }

    /*for (var i = 0; i < book1.length; i++) {
        //var colors = ['#ff0000', '#00ff00', '#0000ff'];
        
        *//*book1[i].style.backgroundColor = random_color;
        book2[i].style.backgroundColor = random_color;
        book3[i].style.backgroundColor = random_color;*//*
    }*/
});