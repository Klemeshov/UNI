const mergeTerms = (term1, term2) => {
    let mergedTerm = '';
    let diffCount = 0;

    for (let i = 0; i < term1.length; i++) {
        if (term1[i] === term2[i]) {
            mergedTerm += term1[i];
        } else {
            mergedTerm += '-';
            diffCount++;
        }
    }

    if (diffCount === 1) {
        return mergedTerm;
    } else {
        return null;
    }
}

const quineMcCluskey = (terms) => {
    let primeImplicants = [];

    while (true) {
        let mergedTerms = [];
        let usedTerms = new Set();

        for (let i = 0; i < terms.length; i++) {
            for (let j = i + 1; j < terms.length; j++) {
                const mergedTerm = mergeTerms(terms[i], terms[j]);
                if (mergedTerm !== null) {
                    mergedTerms.push(mergedTerm);
                    usedTerms.add(terms[i]);
                    usedTerms.add(terms[j]);
                }
            }
        }

        if (mergedTerms.length === 0) {
            break;
        }

        terms = terms.filter(term => !usedTerms.has(term));
        primeImplicants = [...primeImplicants, ...terms];
        terms = mergedTerms;
    }

    primeImplicants = [...primeImplicants, ...terms];
    return [...new Set(primeImplicants)];
}

const buildCoverageTable = (terms, primeImplicants) => {
    const coverageTable = [];

    for (let i = 0; i < terms.length; i++) {
        const row = [];
        for (let j = 0; j < primeImplicants.length; j++) {
            let covers = true;
            for (let k = 0; k < terms[i].length; k++) {
                if (primeImplicants[j][k] !== '-' && primeImplicants[j][k] !== terms[i][k]) {
                    covers = false;
                    break;
                }
            }
            row.push(covers ? 1 : 0);
        }
        coverageTable.push(row);
    }

    return coverageTable;
}

const selectMinimumCover = (coverageTable, primeImplicants) => {
    const coveredTerms = new Set();
    const selectedImplicants = [];

    while (coveredTerms.size < coverageTable.length) {
        let bestImplicant = null;
        let bestCount = 0;

        for (let j = 0; j < primeImplicants.length; j++) {
            let count = 0;
            for (let i = 0; i < coverageTable.length; i++) {
                if (!coveredTerms.has(i) && coverageTable[i][j] === 1) {
                    count++;
                }
            }
            if (count > bestCount) {
                bestCount = count;
                bestImplicant = j;
            }
        }

        if (bestImplicant !== null) {
            selectedImplicants.push(primeImplicants[bestImplicant]);

            for (let i = 0; i < coverageTable.length; i++) {
                if (coverageTable[i][bestImplicant] === 1) {
                    coveredTerms.add(i);
                }
            }
        } else {
            break; // Break the loop if no implicants can cover remaining terms
        }
    }

    return selectedImplicants;
}

const fs = require('fs');

fs.readFile('data.json', 'utf8', (err, data) => {
    if (err) {
        console.error(err);
        return;
    }

    const terms = JSON.parse(data);
    const start = Date.now();
    const primeImplicants = quineMcCluskey(terms);
    const firstTime = Date.now() - start;

    const coverageTable = buildCoverageTable(terms, primeImplicants);
    const secondTime = Date.now() - start - firstTime;

    const selectedImplicants = selectMinimumCover(coverageTable, primeImplicants);
    const thirdTime = Date.now() - start - firstTime - secondTime;

    fs.appendFile('test.txt', `${firstTime} ${secondTime} ${thirdTime}\n\n`, (err) => {
        if (err) {
            console.error(err);
            return;
        }
        console.log('Строка успешно добавлена в файл');
    });
});
// console.log('Selected Prime Implicants:', selectedImplicants);
