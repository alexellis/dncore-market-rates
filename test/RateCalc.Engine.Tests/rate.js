var rate = 7 / 100 / 12;
var term = 36
var principal = 1000

// amt = (1000 * (7.0/100/12)) / (1 - (Math.pow( (1+(7.0/100/12)), -36 ) ) )

for(i=0;i<5;i++) {
    var amt = (principal * rate ) / ( 1 - (Math.pow((1+rate), -term)));
    console.log(amt, amt.toFixed(2));
    principal -= amt;
}


console.log("Annual compound");

// Annual compound
// A = P(1+r/n)^nt
var termsPerYear = 12
var years = 3
var amt2 = principal * Math.pow( (1 + rate / years), 12 * years);
amt2 /=12*3;
console.log(amt2, amt2.toFixed(2));

console.log("");

var principal1 = 1000;
var compoundFreq = 12
var terms = 36 / compoundFreq;
var amt3 = principal1 * ( Math.pow( (  1 + (rate / compoundFreq) ), terms * compoundFreq ) )
console.log(amt3);
console.log(amt3/ 36);