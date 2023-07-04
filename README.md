# DiamondKata

### Origin

This kata is based on a post by Seb Rose here: http://claysnow.co.uk/recycling-tests-in-tdd/

### Problem

Given a character from the alphabet, print a diamond of its output with that character being the midpoint of the diamond.

Examples

    > diamond.exe A
      A

    > diamond.exe B
       A
      B B
       A

    > diamond.exe C
        A
       B B
      C   C
       B B
        A

It may be helpful visualise the whitespace in your rendering like this:

    > diamond.exe C
    _ _ A _ _
    _ B _ B _
    C _ _ _ C
    _ B _ B _
    _ _ A _ _

### Analysis

#### Step 1:

To start of with let's take the complexity of using the alphabet out for now and instead just use the equivalent zero based array postions of the letters instead (A=0,B=1,C=2,D=3).

Now our diamonds look like:

    A =
      0

    B =
       0
      1 1
       0

    C=
        0
       1 1
      2   2
       1 1
        0
    D =
         0
        1 1
       2   2
      3     3
       2   2
        1 1
         0

etc..

#### Step 2.

What are we actually dealing with? Its a grid of rows and columns that sized accoring to the number (letter) that is used.

So:

    0 = 1x1
    1 = 3x3
    2 = 5x5
    3 = 7x7

#### Step 3.

We can quickly see a formula to calculate number of rows (r) and columns (c) for step 2 is 2n+1, where n is the number

    0 = 2*0+1 = 1
    1 = 2*1+1 = 3
    2 = 2*2+1 = 5
    3 = 2*3+1 = 7

#### Step 4.

Lets now have a think about how we are going to place our numbers within this grid. As per the problem description we will replace space characters with dashes to help us visualise easier

    0

    -0-
    1-1
    -0-

    --0--
    -1-1-
    2---2
    -1-1-
    --0--

    ---0---
    --1-1--
    -2---2-
    3-----3
    -2---2-
    --1-1--
    ---0---

#### Step 5.

Now we know what our grids look like, how are the spaces (dashes) distributed in each row? How many spaces are between numbers and to each side of numbers? Lets call them internal spaces (i) and padding spaces (p).

    0 = 0,0

    -0- = 0,1
    1-1 = 1,0
    -0- = 0,1

    --0-- = 0,2
    -1-1- = 1,1
    2---2 = 3,0
    -1-1- = 1,1
    --0-- = 0,2

    ---0--- = 0,3
    --1-1-- = 1,2
    -2---2- = 3,1
    3-----3 = 5,0
    -2---2- = 3,1
    --1-1-- = 1,2
    ---0--- = 0,3

#### Step 6:

Can we come up with a formula for internal spaces for each row? It looks like for any row with 2 numbers in (i.e. not rows with just a 0 in), we can say internal spaces (i) can be expressed using the same formula as before (2n+1) minus the 2 numbers in the row, which looks like 2n+1-1. This can be reduced to 2n-1.

Let's give it a whirl:

    2*1-1 = 1
    2*2-1 = 3
    2*3-2 = 5

Looks good. What about 0? 0 always = 0? Looks that way.

Now we have out internal space count and our row size, we can easily come up with how many padding spaces on each side are needed, which will be ([col_count]-[internal_space_count]-[number_count])/2.

#### Additional Considerations:

- At this point we notice that there has been a lot of cutting and pasting from the top half of the diamond to the bottom half. We may be able to use this to increase efficiency...
- The diamond logic should validate that only a valid alphabet character is passed to it
- The requirements do not specify how lower case letters should be handle. We will assume that they will be transformed to uppercase for now
