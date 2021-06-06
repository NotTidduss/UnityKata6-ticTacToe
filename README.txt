Unity Kata #6 - Tic Tac Toe

-Practice goal:
	+ handling Sprites
	+ better documentation
	+ cleaner code
	+ Headers for scripts

Ruleset:
	1 Field, 9 Squares
	2 Markings - X & O
	Three in a line; that's a winner.

Requirements:
	Field class = Master script
	Marking enum: None, X, O
	Square class: id, Marking, bool isMarked

Flow:
	First turn X
	--> Second turn O
	--> turn X ...
	---> win / loss / draw --> playAgain

Goal:
	functional tic tac toe game
	