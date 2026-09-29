const dice = Math.floor(Math.random() * 6) + 1;

console.log("You rolled:", dice);

const result = Math.random() < 0.5 ? "Heads" : "Tails";

console.log("You got:", result);