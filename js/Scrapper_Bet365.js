
var puppeteer = require('puppeteer'),
    fs = require('fs'),
    HomeBet = 'https://www.bet365.com/#/AC/B1/C1/D1002/G40/J99/I1/Q1/F^24';

puppeteer.launch()
    .then(function (browser) {
        return browser.newPage()
            .then(function (page) {
                return page.goto(HomeBet)
                    .then(function () {
                        return page.waitForSelector('.gl-MarketGroupContainer');
                    }).then(function () {
                        return page.content();
                    }).then(function (contents) {
                        return fs.writeFile('../Downloads_Web/Bet365.html', contents, function (err, results) {
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