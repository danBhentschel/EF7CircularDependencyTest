# EF7CircularDependencyTest
Causes a circular dependency when committing changes to a SQLite DB.

There are two unit tests included in this project. They both attempt to commit the exact same information to a SQLite database. The first test commits all the data in a single step. The second test commits the data in two steps. The first test fails. The second succeeds.

Apologies for the ugly create / delete of temp file in this test. The problem is not reproducible with InMemory database, for can I get the SQLite ":memory:" database to work properly with EF7.
