Feature: Viewing movie information

Scenario: Looking at the full list of available movies
    Given Alex wants to watch a movie
    And he doesn't know which movie he wants to watch
    When he searches for a movie to watch
    Then he sees a list with 4 the movies available, with the genres

Scenario: Found a movie, viewing the detail page
    Given Alex has selected a movie he thinks he wants to watch
    When he goes to the detail page
    Then he sees the movie details
    And the genres which can be used to search other movies
    And the full list of other movies available

    