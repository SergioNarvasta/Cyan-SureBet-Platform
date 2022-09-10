
//Install purpeteer with -> npm i puppeteer
//style_row__3q4g_ style_row__3hCMX
var puppeteer = require('puppeteer'),
    fs = require('fs'),
    HomeBet = 'https://www.pinnacle.com/es/soccer/matchups/highlights';

puppeteer.launch()
    .then(function (browser) {
        return browser.newPage()
            .then(function (page) {
                return page.goto(HomeBet)
                    .then(function () {
                        return page.waitFor('.style_row__3hCMX');
                    }).then(function () {
                        return page.content();
                    }).then(function (contents) {

                        return fs.writeFile('../Downloads_Files/Pinnacle.html', contents, function (err, results) {
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