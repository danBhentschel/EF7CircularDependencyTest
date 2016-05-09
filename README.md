# EF7CircularDependencyTest
Causes a circular dependency when committing changes to a SQLite DB.
https://github.com/aspnet/EntityFramework/issues/5305

There are two unit tests included in this project. They both attempt to commit the exact same information to a SQLite database. The first test commits all the data in a single step. The second test commits the data in two steps. The first test fails. The second succeeds.

Apologies for the ugly create / delete of temp file in this suite. The problem is not reproducible with InMemory database, nor can I get the SQLite ":memory:" database to work properly with EF7.
