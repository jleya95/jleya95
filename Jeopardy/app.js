const game = document.getElementById('game');
const scoreDisplay = document.getElementById('score');

const categories = [
    {
        genre: 'WHO ARE YOU',
        questions: [
            {
                question: 'Finish the lyric: "Hope I die before I get: "',
                answers: ['What is "Old"?', 'What is "Killed"?'],
                correct: 'What is "Old"?',
                level: '200'
            },
            {
                question: 'Principal songwriter for The Who',
                answers: ['Who is Roger Daltrey?', 'Who is Pete Townshend?'],
                correct: 'Who is Pete Townshend?',
                level: '400'
            },
            {
                question: 'The album Tommy is considered one of the first: ',
                answers: ['What is Album Cycle?', 'What is Rock Opera?'],
                correct: 'What is Rock Opera?',
                level: '600'
            },
            {
                question: "The first album recorded after Keith Moon's death",
                answers: ["What is It's Hard?", 'What is Face Dances?'],
                correct: 'What is Face Dances?',
                level: "800"
            },
            {
                question: 'Co-manager of The Who along with Chris Stamp',
                answers: ['Who was Allen Klein?', 'Who was Kit Lambert?'],
                correct: 'Who was Kit Lambert?',
                level: '1000'
            }
        ]
    },
    {
        genre: 'BLUE BEATLES',
        questions: [
            {
                question: "",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "200"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "400"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "600"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "800"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "1000"
            }
        ]
    },
    {
        genre: "WHERE",
        questions: [
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "200"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "400"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "600"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "800"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "1000"
            }
        ]
    },
    {
        genre: "WHY",
        questions: [
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "200"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "400"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "600"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "800"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "1000"
            }
        ]
    },
    {
        genre: "WHEN",
        questions: [
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "200"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "400"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "600"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "800"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "1000"
            }
        ]
    },
    {
        genre: "HOW",
        questions: [
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "200"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "400"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "600"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "800"
            },
            {
                question: "Who wrote Harry Potter?",
                answers: ["JK Rowling", "JRR Tolkien"],
                correct: "JK Rowling",
                level: "1000"
            }
        ]
    }


]

let score = 0;

function addCategory(category) {
    const column = document.createElement('div');
    column.classList.add('genre-column');

    const genreTitle = document.createElement('div');
    genreTitle.classList.add('genre-title');
    genreTitle.innerHTML = category.genre;

    column.appendChild(genreTitle);
    game.append(column);

    category.questions.forEach(question => {
        const card = document.createElement('div');
        card.classList.add('card');
        column.append(card);

        if (question.level === '200') {
            card.innerHTML = 200;
        } else if (question.level === '400') {
            card.innerHTML = 400;
        } else if (question.level === '600') {
            card.innerHTML = 600;
        } else if (question.level === '800') {
            card.innerHTML = 800;
        } else if (question.level === '1000') {
            card.innerHTML = 1000;
        }

        card.setAttribute('data-question', question.question);
        card.setAttribute('data-answer-1', question.answers[0]);
        card.setAttribute('data-answer-2', question.answers[1]);
        card.setAttribute('data-correct', question.correct);
        card.setAttribute('data-value', card.getInnerHTML());

        card.addEventListener('click', flipCard);
    })
}

categories.forEach(category => addCategory(category))

function flipCard() {
    this.innerHTML = '';
    this.style.fontSize = '15px';
    this.style.lineHeight = '30px';
    const textDisplay = document.createElement('div');
    textDisplay.classList.add('card-text');
    textDisplay.innerHTML = this.getAttribute('data-question');
    const firstButton = document.createElement('button');
    const secondButton = document.createElement('button');
    firstButton.classList.add('first-button');
    secondButton.classList.add('second-button');
    firstButton.innerHTML = this.getAttribute('data-answer-1');
    secondButton.innerHTML = this.getAttribute('data-answer-2');
    firstButton.addEventListener('click', getResult);
    secondButton.addEventListener('click', getResult);
    this.append(textDisplay, firstButton, secondButton);

    const allCards = Array.from(document.querySelectorAll('.card'));
    allCards.forEach(card => card.removeEventListener('click', flipCard));
}

function getResult() {
    const allCards = Array.from(document.querySelectorAll('.card'));
    allCards.forEach(card => card.addEventListener('click', flipCard));

    const cardOfButton = this.parentElement;

    if (cardOfButton.getAttribute('data-correct') == this.innerHTML) {
        score = score + parseInt(cardOfButton.getAttribute('data-value'));
        scoreDisplay.innerHTML = score;
        cardOfButton.classList.add('correct-answer');
        setTimeout(() => {
            while (cardOfButton.firstChild) {
                cardOfButton.removeChild(cardOfButton.lastChild);
            }
            cardOfButton.innerHTML = cardOfButton.getAttribute('data-value')
        }, 100);
    } else {
        cardOfButton.classList.add('wrong-answer');
        setTimeout(() => {
            while (cardOfButton.firstChild) {
                cardOfButton.removeChild(cardOfButton.lastChild)
            }
            cardOfButton.innerHTML = 0;
        }, 100);
    }

    cardOfButton.removeEventListener('click', flipCard);
}