
var puppeteer = require('puppeteer'),
    fs = require('fs'),
    HomeBet = 'https://oncebet.com/#line_positions?lhList=266928-299009-299359-300048-302977';

puppeteer.launch()
    .then(function (browser) {
        return browser.newPage()
            .then(function (page) {
                return page.goto(HomeBet)
                    .then(function () {
                        return page.waitForSelector('.quotation_bar');
                    }).then(function () {
                        return page.content();
                    }).then(function (contents) {
                        return fs.writeFile('../Downloads_Web/OnceBet.html', contents, function (err, results) {
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