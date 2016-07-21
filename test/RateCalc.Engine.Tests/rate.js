var rate = 7 / 100 / 12;
var term = 36
var principal = 1000

// amt = (1000 * (7.0/100/12)) / (1 - (Math.pow( (1+(7.0/100/12)), -36 ) ) )

for(i=0;i<5;i++) {
    var amt = (principal * rate ) / ( 1 - (Math.pow((1+rate), -term)));
    console.log(amt, amt.toFixed(2));
    principal -= amt;
}
