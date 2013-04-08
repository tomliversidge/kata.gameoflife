kata.gameoflife
===============

Game Of Life Code Kata

# Summary

Wikipedia summarises the Game Of Life as:

>The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, alive or dead. Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:

    Any live cell with fewer than two live neighbours dies, as if caused by under-population.
    Any live cell with two or three live neighbours lives on to the next generation.
    Any live cell with more than three live neighbours dies, as if by overcrowding.
    Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

>The initial pattern constitutes the seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed—births and deaths occur simultaneously, and the discrete moment at which this happens is sometimes called a tick (in other words, each generation is a pure function of the preceding one). The rules continue to be applied repeatedly to create further generations.

## Initial thoughts

Some elements of the game are quickly apparent: 

* We need an intial state
* We need a way of moving on to the next generation of the system
* We need to return a representation of the current state of the grid.
* We can also be confident we need a way of determining the adjacent cells 
* We need a concept of life and death. 

When I first attempted this Kata I initially tried to create a state machine grid system, with cells having an IsAlive property. 
However, thinking this approach through a little further reveals it to be unworkable - we are supposed to be 
implementing an infinite grid, so we would in theory have to store an infinite number of dead cells. Hmmm... not a good plan. 
A better approach is to presume life by existence. If a cell exists, it is alive. This way, we only need to track live cells.


## First Rule

>Any live cell with fewer than two live neighbours dies, as if caused by under-population.

This is a reasonably simply rule, but forms the foundation on which we will build our game. We need to implement all of
the items mentioned above before we can test this rule. We need to be able to iterate through current live cells, 
find out if they have fewer than two neightbours, and if so, kill them. This is the equivalent of removing them from our
collection of cells.

## Second Rule
>Any live cell with two or three live neighbours lives on to the next generation.

This is very similar to the first rule... In fact, come to think of it, so is the third rule:

## Third Rule
>Any live cell with more than three live neighbours dies, as if by overcrowding.

If we combine these rules, we have a very simple check for the count of live neighbours; 2 or 3 live neighbours and the 
cell lives, any other amount and it dies. 

    var nextGeneration = cells.Where(currentCell => this.CountOfAdjacentLiveCells(currentCell) == 2 || this.CountOfAdjacentLiveCells(currentCell) == 3);
