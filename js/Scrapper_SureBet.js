//Install npm with -> npm install   Install purpeteer with -> npm i puppeteer
var puppeteer = require('puppeteer'),
    fs = require('fs'),
    HomeBet = 'https://es.surebet.com/surebets?utf8=%E2%9C%93&commit=Filtrar&selector%5Border%5D=profit&selector%5Boutcomes%5D%5B%5D=&selector%5Boutcomes%5D%5B%5D=2&selector%5Boutcomes%5D%5B%5D=3&selector%5Bmin_profit%5D=&selector%5Bmax_profit%5D=&selector%5Bmin_roi%5D=&selector%5Bmax_roi%5D=&selector%5Bsettled_in%5D=0&selector%5Bbookies_settings%5D=0%3A67%3A%3A%3B0%3A71%3A%3A%3B0%3A66%3A%3A%3B0%3A74%3A%3A%3B0%3A180%3A%3A%3B0%3A73%3A%3A%3B0%3A146%3A%3A%3B0%3A70%3A%3A%3B0%3A112%3A%3A%3B0%3A130%3A%3A%3B0%3A124%3A%3A%3B0%3A21%3A%3A%3B4%3A26%3A%3A%3B0%3A137%3A%3A%3B0%3A148%3A%3A%3B0%3A200%3A%3A%3B0%3A149%3A%3A%3B0%3A23%3A%3A%3B0%3A202%3A%3A%3B0%3A198%3A%3A%3B0%3A201%3A%3A%3B0%3A0%3A%3A%3B0%3A32%3A%3A%3B0%3A65%3A%3A%3B0%3A159%3A%3A%3B0%3A29%3A%3A%3B0%3A10%3A%3A%3B0%3A45%3A%3A%3B0%3A163%3A%3A%3B0%3A178%3A%3A%3B0%3A14%3A%3A%3B0%3A195%3A%3A%3B0%3A11%3A%3A%3B0%3A186%3A%3A%3B0%3A38%3A%3A%3B0%3A145%3A%3A%3B0%3A196%3A%3A%3B0%3A55%3A%3A%3B0%3A185%3A%3A%3B0%3A33%3A%3A%3B0%3A192%3A%3A%3B0%3A174%3A%3A%3B0%3A123%3A%3A%3B0%3A49%3A%3A%3B0%3A62%3A%3A%3B0%3A12%3A%3A%3B0%3A191%3A%3A%3B0%3A46%3A%3A%3B0%3A144%3A%3A%3B0%3A115%3A%3A%3B0%3A133%3A%3A%3B0%3A24%3A%3A%3B0%3A85%3A%3A%3B0%3A72%3A%3A%3B0%3A152%3A%3A%3B0%3A127%3A%3A%3B0%3A143%3A%3A%3B0%3A134%3A%3A%3B0%3A106%3A%3A%3B0%3A5%3A%3A%3B0%3A6%3A%3A%3B0%3A173%3A%3A%3B0%3A188%3A%3A%3B0%3A4%3A%3A%3B0%3A181%3A%3A%3B0%3A30%3A%3A%3B0%3A15%3A%3A%3B0%3A126%3A%3A%3B0%3A50%3A%3A%3B0%3A9%3A%3A%3B0%3A177%3A%3A%3B0%3A176%3A%3A%3B0%3A41%3A%3A%3B0%3A128%3A%3A%3B0%3A131%3A%3A%3B0%3A3%3A%3A%3B0%3A8%3A%3A%3B0%3A116%3A%3A%3B0%3A86%3A%3A%3B0%3A164%3A%3A%3B0%3A122%3A%3A%3B0%3A165%3A%3A%3B0%3A160%3A%3A%3B0%3A162%3A%3A%3B0%3A39%3A%3A%3B0%3A172%3A%3A%3B0%3A31%3A%3A%3B0%3A51%3A%3A%3B0%3A179%3A%3A%3B0%3A2%3A%3A%3B0%3A157%3A%3A%3B0%3A141%3A%3A%3B4%3A7%3A%3A%3B0%3A187%3A%3A%3B0%3A108%3A%3A%3B0%3A142%3A%3A%3B0%3A121%3A%3A%3B0%3A199%3A%3A%3B0%3A25%3A%3A%3B0%3A69%3A%3A%3B0%3A138%3A%3A%3B0%3A117%3A%3A%3B0%3A16%3A%3A%3B0%3A161%3A%3A%3B0%3A171%3A%3A%3B0%3A189%3A%3A%3B0%3A184%3A%3A%3B0%3A190%3A%3A%3B0%3A43%3A%3A%3B0%3A197%3A%3A%3B0%3A182%3A%3A%3B0%3A18%3A%3A%3B0%3A59%3A%3A%3B0%3A83%3A%3A%3B0%3A118%3A%3A%3B0%3A203%3A%3A%3B0%3A147%3A%3A%3B0%3A125%3A%3A%3B0%3A17%3A%3A%3B0%3A107%3A%3A%3B0%3A53%3A%3A%3B0%3A153%3A%3A%3B0%3A28%3A%3A%3B0%3A44%3A%3A%3B0%3A194%3A%3A%3B0%3A204%3A%3A%3B0%3A27%3A%3A&selector%5Bexclude_sports_ids_str%5D=56+57+0+43+32+1+2+3+4+55+60+7+6+5+28+8+44+9+26+34+10+11+12+39+47+46+48+49+59+14+27+53+54+58+16+30+13+17+18+29+45+19+36+33+31+40+42+41+20+50+51+21+37+23+22+35+24+38+25&selector%5Bextra_filters%5D=&narrow=';
puppeteer.launch()
    .then(function (browser) {
        return browser.newPage()
            .then(function (page) {
                return page.goto(HomeBet)
                    .then(function () {
                        return page.waitForSelector('.surebet_record');
                    }).then(function () {
                        return page.content();
                    }).then(function (contents) {
                        return fs.writeFile('../Downloads_Web/SureBets_ES.html', contents, function (err, results) {
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