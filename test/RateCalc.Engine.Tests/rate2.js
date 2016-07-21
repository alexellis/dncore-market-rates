var rate = 0.069999996/12;
var term = 36;
var principal = 1000;

var amt = (principal * rate ) / ( 1 - (Math.pow((1+rate), -term)));
console.log(amt, amt.toFixed(2));

