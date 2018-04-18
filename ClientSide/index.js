

hello = "hello"; //dangerous: this is document scope - not within its scope

var allo = "allo"; // document scope - withing its scope, var makes it respect its scope


console.log(hello);
console.log(allo);

console.log("What is up my peeoples");