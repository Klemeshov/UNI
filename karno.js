class Term {
    constructor(term = "", source = null, flag = false) {
        if (source === null) {
            source = new Set([parseInt(term, 2)]);
        }
        this.term = term;
        this.source = source;
        this.flag = flag;
        this.length = term.length;
    }

    get ones() {
        return Array.from(this.term).filter(c => c === "1").length;
    }

    equals(other) {
        return this.term === other.term;
    }

    toString() {
        return this.term;
    }

    hashCode() {
        return this.term.split("").reduce((acc, char) => acc + char.charCodeAt(0), 0);
    }
}

const diffTerms = (term1, term2) => {
    if (term1.length === term2.length) {
        let diff = 0;
        let pos = -1;

        for (let idx = 0; idx < term1.term.length; idx++) {
            if (diff > 1) break;
            if (term1.term[idx] !== term2.term[idx]) {
                diff++;
                pos = idx;
            }
        }

        if (diff === 1) {
            let newTerm = term1.term.substring(0, pos) + "*" + term2.term.substring(pos + 1);
            let newSource = new Set([...term1.source, ...term2.source]);
            term1.flag = true;
            term2.flag = true;

            return new Term(newTerm, newSource);
        }
    }
}

const kMap = (minterms) => {
    let table = new Map();
    minterms.forEach(term => {
        let onesCount = term.ones;
        if (!table.has(onesCount)) {
            table.set(onesCount, new Set());
        }
        table.get(onesCount).add(term);
    });

    let primeImplicants = [];
    let newImplicants = true;
    while (newImplicants) {
        newImplicants = false;
        let newTable = new Map();
        let keys = Array.from(table.keys()).sort((a, b) => a - b);
        for (let i = 0; i < keys.length; i++) {
            let key = keys[i];
            let terms1 = table.get(key);
            let terms2 = table.get(key + 1) || new Set();
            terms1.forEach(t1 => {
                terms2.forEach(t2 => {
                    let newTerm = diffTerms(t1, t2);
                    if (newTerm) {
                        if (!newTable.has(key)) {
                            newTable.set(key, new Set());
                        }
                        newTable.get(key).add(newTerm);
                        newImplicants = true;
                    }
                });
            });

            terms1.forEach(term => {
                if (!term.flag) {
                    primeImplicants.push(term);
                }
            });
        }
        table = newTable;
    }

    return primeImplicants;
}

const selectMinimumCover = (primeImplicants, minterms) => {
    let chart = new Map();
    minterms.forEach(term => {
        term.source.forEach(source => {
            if (!chart.has(source)) {
                chart.set(source, new Set());
            }
        });
    });

    primeImplicants.forEach((implicant, idx) => {
        implicant.source.forEach(source => {
            if (chart.has(source)) {
                chart.get(source).add(idx);
            }
        });
    });

    let sop = null;
    chart.forEach(products => {
        sop = multiply(sop, products);
    });

    let min = Infinity;
    let ids = new Set();
    sop.forEach(p => {
        if (p.size < min) {
            min = p.size;
            ids = p;
        }
    });

    return Array.from(ids).map(i => primeImplicants[i]);
}

const multiply = (result, product) => {
    if (!result) {
        return new Set(Array.from(product).map(p => new Set([p])));
    } else {
        let newResult = new Set();
        result.forEach(a => {
            product.forEach(b => {
                newResult.add(new Set([...a, b]));
            });
        });
        return newResult;
    }
}

const fs = require('fs');

fs.readFile('data.json', 'utf8', (err, data) => {
    if (err) {
        console.error(err);
        return;
    }

    const strTerms = JSON.parse(data);
    const start = Date.now();
    const terms = strTerms.map(term => new Term(term));

    let primeImplicants = kMap(terms);
    let result = selectMinimumCover(primeImplicants, terms);
    const res = result.map(a => a.term);
    console.log(res);
    const time = Date.now() - start;


    fs.appendFile('test.txt', `${time}\n\n`, (err) => {
        if (err) {
            console.error(err);
            return;
        }
        console.log('Строка успешно добавлена в файл');
    });
});


