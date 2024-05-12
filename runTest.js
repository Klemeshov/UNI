const {exec} = require('child_process');

function runPrograms(run) {
    const program1 = 'node generator.js';
    const program2 = run;

    exec(program1, (error, stdout) => {
        if (error) {
            console.error(`generate error: ${error.message}`);
            return;
        }
        console.log(`generate complete`);

        exec(program2, (error, stdout, stderr) => {
            if (error) {
                console.error(`programm error: ${error.message}`);
                return;
            }
            console.log(`programm complete`);

            // Запускать программы циклично
            runPrograms(run);
        });
    });
}

// Запуск первой итерации
runPrograms('node karno.js');
// runPrograms('node quine.js');