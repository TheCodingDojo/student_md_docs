# Top 3 Average Government Debts

**Verbatim Challenge:**

"You are given a SQL database with the following table full of data:

CREATE TABLE countries ( code CHAR(2)
NOT NULL, year INT NOT NULL,
gdp_per_capita DECIMAL(10, 2) NOT
NULL, govt_debt DECIMAL(10, 2) NOT
NULL );

Please write the SQL statement to show the top 3 average government debts in percent of
the gdp_per_capita for those countries of which gdp_per_capita was over 40,000 dollars in
every year in the last four years."

## Solution

- Open a db in workbench -> open new SQL tab and run the given script (you could also create an ERD with this table but this is easier more direct and less room for human error)

  - ``` SQL
      CREATE TABLE countries (
          code CHAR(2) NOT NULL,
          year INT NOT NULL,
          gdp_per_capita DECIMAL(10 , 2 ) NOT NULL,
          govt_debt DECIMAL(10 , 2 ) NOT NULL
      );
      ```

- Add a variety of data so that it will be clear if your query works
- Create a checklist

  - ``` SQL
      /*
          Please write the SQL statement to show the
          [ ] top 3 average government debts
          [ ] in percent of the gdp_per_capita
          [ ] for those countries of which gdp_per_capita was over 40,000 dollars
          [ ] in every year in the last four years.
      */
      ```

- Start by checking off the easiest requirements & auto format your code: Edit -> Format -> Beautify Query (Ctrl+B)

1. `[x] top 3 average government debts`
    - **Google** "mysql select top"
    - will find out `TOP` is a keyword but MySQL uses `LIMIT` instead

    - ``` SQL
        SELECT
            code, year, gdp_per_capita, govt_debt
        FROM
            countries
        LIMIT 3
        ;
        ```

2. `[x] for those countries of which gdp_per_capita was over 40,000 dollars`

    - ``` SQL
      SELECT
          code, year, gdp_per_capita, govt_debt
      FROM
          countries
      WHERE
          gdp_per_capita > 40000
      LIMIT 3
      ;
        ```

3. `[x] in every year in the last four years.`

    - could easily hard code the year that is 4 years before the current year into the `WHERE` clause, but then the query be will be wrong after the new year
    - **Google**: "mysql select recent years"
    - `DATE_SUB(NOW(),INTERVAL 1 YEAR);` may be found, but doesn't seem to work, maybe because our db is storing only the year and not a full date
    - the search results probably also displayed `MySQL YEAR() function - w3resource`

    - ``` SQL
        SELECT
            code, year, gdp_per_capita, govt_debt
        FROM
            countries
        WHERE
            gdp_per_capita > 40000
                AND YEAR(NOW()) - year <= 4
        LIMIT 3
        ;
        ```

4. `[x] in percent of the gdp_per_capita`
    - When in doubt (which is the numerator?), **Google**: "government debt in percent of gdp"
    - **Google**: "mysql percent from two columns"

    - ``` SQL
        SELECT
            code,
            year,
            gdp_per_capita,
            govt_debt,
            (govt_debt / gdp_per_capita) * 100 AS 'Gov Debt-to-GDP ratio'
        FROM
            countries
        WHERE
            gdp_per_capita > 40000
                AND YEAR(NOW()) - year <= 4
        ORDER BY "Gov Debt-to-GDP ratio" DESC
        LIMIT 3
        ;
        ```

    - `ORDER BY` is not working, try with another column
        - it works, what's different?
        - the column's name we are trying to `ORDER BY` is a string
            - **Google**: "mysql order by string column name" or "mysql order by column name with spaces"
              - "Try enclosing them in back-ticks like" ``ORDER BY `Full Name` ASC``
                  - ``ORDER BY `Gov Debt-to-GDP ratio` DESC``
