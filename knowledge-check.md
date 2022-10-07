**Test Plan**

Online Web App I am testing: https://demoqa.com/books

New feature to test: The Search Bar on the page https://demoqa.com/books

Write a test plan for this new feature that includes at least 10 test cases:

1. Search for a book that is present on the website by Title - Critical Path Test
   1. GIVEN a user is on https://demoqa.com/books
   2. WHEN they type in a book Title that is available on the website into the search bar
   3. THEN the items in the table should filter down to the book with that Title 


2. Search for a book that is present on the website by Author - Critical Path Test
   1. GIVEN a user is on https://demoqa.com/books
   2. WHEN they type in an Author's first name, last name, or full name that is available on the website into the search bar
   3. THEN the items in the table should filter down to the book(s) by the Author's name


3. Search for a book that is present on the website by Publisher - Critical Path Test
   1. GIVEN a user is on https://demoqa.com/books
   2. WHEN they type in a Publisher's name that is available on the website into the search bar
   3. THEN the items in the table should filter down to matching book(s) published by the searched for Publisher


4. Search for a book that is NOT present on the website by Title - Negative Test
   1. GIVEN a user is on https://demoqa.com/books
   2. WHEN they type in a book Title for a book NOT available on the website into the search bar
   3. THEN the table should be empty to show there are no books by Title available
   4. AND the message "No rows found" should appear


5. Search for a book that is NOT present on the website by Author - Negative Test
   1. GIVEN a user is on https://demoqa.com/books
   2. WHEN they type in an Author NOT available on the website into the search bar
   3. THEN the table should be empty to show there are no books by that Author available
   4. AND the message "No rows found" should appear


6. Search for a book that is NOT present on the website by Publisher - Negative Test
   1. GIVEN a user is on https://demoqa.com/books
   2. WHEN they type in a book Publisher that is NOT available on the website into the search bar
   3. THEN the table should be empty to show there are no books by that Publisher available
   4. AND the message "No rows found" should appear

7. Enter something that has nothing to do with books into the search - Negative Test
   1. GIVEN a user is on https://demoqa.com/books
   2. WHEN the user types in a number, spaces, symbols, or a random string of letters
   3. THEN the table should be empty
   4. AND the message "No rows found" should appear

8. Click on link of an item after searching for it - Critical Path Test 
   1. GIVEN a user is on https://demoqa.com/books
   2. WHEN a user successfully pulls up a book using the search bar
   3. THEN the link for the book redirects to a details page for the book that was searched for

9.  Delete a search query from the search field - Critical Path Test
    1. GIVEN a user is on https://demoqa.com/books 
    2. AND has successfully used the search bar to filter the table to one book
    3. WHEN the user deletes all letters from the search field
    4. THEN the table repopulates with all available books

10. Test sorting for Image, Title, Author, and Publisher - Regression Test
    1.  GIVEN a user is on https://demoqa.com/books
    2.  WHEN the user clicks on the column headers Image, Title, Author, or Publisher
    3.  THEN the rows in the table sort as expected
        1.  Alphabetically by Title for Image and Title
        2.  Alphabetically by Author First Name for Author
        3.  Alphabetically by first letter of Publisher for Publisher
