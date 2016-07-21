# dncore-market-rates

TDD exercise with .NET Core RC2 including everything you would expect to see:

* [Moq](https://github.com/moq/moq) for mocking dependencies
* [FluentAssertions](https://github.com/dennisdoomen/FluentAssertions) for BDD-style testing `x.Should().Be(100)` etc
* Dockerfile for building and running the application without having to set up a runtime

### The task: provide loan quotes & repayment details

* Read in a markets.csv file containing various individuals with money to lend at various rates
* Take in parameters from the command line for a given amount and a set fixed term of 36 months / 3 years.
* Produce an output of the monthly repayments using compound interest and also the final amount payable.

Example rates file:

```
Lender,Rate,Available
Bob,0.005833333,500
John,0.005833333,500
```

Produces following output when borrowing 1000 USD:

```
$ dotnet run
Payment: 30.87
Total: 1111.57
```

### Todo:

This is task is work-in-progress.

```
[X] Calculate weighted average for more than one lender
[X] Pick funds from cheapest lenders first
[X] Check for multiples of 100 USD
[X] Don't allow for less than 100 USD to borrow 
[ ] Validate upper borrowing limit
[ ] Remove debug messages
[ ] Find coverage tool that works with DNCore
```

Out of scope:

This task was originally estimated at 2-3 hours by source, so these things are probably out of scope:

```
[ ] Use Unity or some other dependency injection tool
```

### Development without Docker

**If you do not use Docker, then please install the below:**

Follow instructions for installing dotnet runtime from: [microsoft.com/net/core](https://www.microsoft.com/net/core#macos)

Without Docker:

* Running the unit tests

```
$ git clone https://github.com/alexellis/dncore-market-rates
$ cd dncore-market-rates/test/RateCalc.Engine.Tests/
$ dotnet restore
$ dotnet test
```

* Running the app

```
$ cd dncore-market-rates/src/RateCalc.App
$ dotnet restore
$ dotnet run
```


### Using Docker to run / test the application

During the building of the image the unit tests will be run - so if they fail the whole build will stop. Once complete the code can be run through `docker run rates` and it will read in the `market.csv` file in the repository root.

```
$ docker build -ti rates .
$ docker run rates
```

