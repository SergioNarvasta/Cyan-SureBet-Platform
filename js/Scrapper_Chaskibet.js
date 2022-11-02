
//Install purpeteer with -> npm i pclearuppeteer    --style_row__3q4g_ style_row__3hCMX
var puppeteer = require('puppeteer'),
    fs = require('fs'),
    HomeBet = 'https://www.chaskibet.com/sportsbook/T-1015101,T-1015125,T-1015135/F%C3%BAtbol-Competiciones_UEFA-Liga_de_Campeones,F%C3%BAtbol-Espa%C3%B1a-La_Liga,F%C3%BAtbol-Italia-Serie_A';
    
puppeteer.launch()
    .then(function (browser) {
        return browser.newPage()
            .then(function (page) {
                return page.goto(HomeBet)
                    .then(function () {
                        return page.waitForSelector('.sb-event');
                    }).then(function () {
                        return page.content();
                    }).then(function (contents) {
                        return fs.writeFile('../Downloads_Web/Chaskibet.html', contents, function (err, results) {
                            if (err) {
                                console.error(err);
                            }
                            console.log(contents);
                        });
                    });
            }).then(function () {
                return browser.close();
            });
    });