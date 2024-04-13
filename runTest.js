const { exec } = require('child_process');

function runPrograms() {
    const program1 = 'node generator.js';
    const program2 = 'node quine.js';

    exec(program1, (error, stdout) => {
        if (error) {
            console.error(`generate error: ${error.message}`);
            return;
        }
        console.log(`generate complete`);

        exec(program2, (error, stdout, stderr) => {
            if (error) {
                console.error(`quine error: ${error.message}`);
                return;
            }
            console.log(`quine complete`);

            // Запускать программы циклично
            runPrograms();
        });
    });
}

// Запуск первой итерации
runPrograms();