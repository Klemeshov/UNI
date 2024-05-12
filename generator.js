const fs = require('fs');

const data = [];

const min = 4;
const max = 6;
let stringLength = Math.floor(Math.random() * (max - min + 1)) + min;


const minDataLength = 1;
const maxDataLength = Math.min(2 ** stringLength - 1, 55);
let length = Math.floor(Math.random() * (maxDataLength - minDataLength + 1)) + minDataLength;

// stringLength = 6;
// length = 64;


while (data.length < length) {
    let randomString = '';
    for (let i = 0; i < stringLength; i++) {
        randomString += Math.round(Math.random()).toString();
    }
    if (!data.includes(randomString)) {
        data.push(randomString);
    }
}

const jsonData = JSON.stringify(data);

fs.writeFile('data.json', jsonData, (err) => {
    if (err) throw err;
    console.log('JSON массив успешно сгенерирован и записан в файл data.json');
});


fs.appendFile('test.txt', `${stringLength} ${length}\n`, (err) => {
    if (err) {
        console.error(err);
        return;
    }
    console.log('Строка успешно добавлена в файл');
});