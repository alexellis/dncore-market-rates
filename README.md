# dncore-market-rates

TDD exercise with .NET Core RC2 including everything you would expect to see:

* Moq for mocking dependencies
* FluentAssertions for BDD-style testing
* Dockerfile for building and running the application without having to set up a runtime

### The task

* Read in a markets.csv file containing various individuals with money to lend at various rates
* Take in parameters from the command line for a given amount and a set fixed term of 36 months / 3 years.
* Produce an output of the monthly repayments using compound interest and also the final amount payable.


