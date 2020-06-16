$.getJSON("/json/crayola.json", (colors) => {
    var cardimgs = document.getElementsByClassName('cardImg');
    for (var i = 0; i < cardimgs.length; i++) {
        //var colors = ['#ff0000', '#00ff00', '#0000ff'];
        var random_color = colors[Math.floor(Math.random() * colors.length)].hex;
        cardimgs[i].style.backgroundColor = random_color;
    }


    var random_book1_color = colors[Math.floor(Math.random() * colors.length)].hex;
    //var book1 = document.getElementsByClassName('book-1');
    var book1 = document.getElementById('book-1');
    book1.style.backgroundColor = random_book1_color;

    var random_book2_color = colors[Math.floor(Math.random() * colors.length)].hex;
    //var book2 = document.getElementsByClassName('book-2');
    var book2 = document.getElementById('book-2');
    book2.style.backgroundColor = random_book2_color;

    var random_book3_color = colors[Math.floor(Math.random() * colors.length)].hex;
    //var book3 = document.getElementsByClassName('book-3');
    var book3 = document.getElementById('book-3');
    book3.style.backgroundColor = random_book3_color;

    /*for (var i = 0; i < book1.length; i++) {
        //var colors = ['#ff0000', '#00ff00', '#0000ff'];
        
        *//*book1[i].style.backgroundColor = random_color;
        book2[i].style.backgroundColor = random_color;
        book3[i].style.backgroundColor = random_color;*//*
    }*/
});