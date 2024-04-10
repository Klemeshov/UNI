const express = require('express');
const app = express();
const port = 3000;
const cors = require('cors');

let corsOptions = {
    origin : ['*'],
}

app.use(cors());

app.get('/ping', (req, res) => {
    res.json('Pong');
});

app.listen(port, () => {
    console.log(`Сервер запущен на порту ${port}`);
});
