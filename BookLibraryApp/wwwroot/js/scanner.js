Quagga.init({
    inputStream: {
        name: "Live",
        type: "LiveStream",
        target: document.querySelector('#barcode-scanner'),
        constraints: {
            width: 520,
            height: 400,
            facingMode: "user"  //"environment" for back camera, "user" front camera
        }
    },
    decoder: {
        readers: ["ean_reader"]
    }

}, function (err) {
    if (err) {
        esto.error = err;
        console.log(err);
        return
    }

    Quagga.start();

    Quagga.onDetected(function (result) {
        var last_code = result.codeResult.code;
        if (last_code != null || last_code != 0)
            console.log(last_code);
    });
});