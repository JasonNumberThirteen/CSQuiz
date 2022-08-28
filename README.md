# Quiz
> A simple console clone of "Quiz" game written in pure C#.

## Table of Contents
* [General information](#general-information)
* [Used technologies](#used-technologies)
* [Features](#features)
* [Usage](#usage)
* [Credits](#credits)

## General information
- This is a simple console application of "Quiz" game. It was written in pure C#.
- The project presents my programming skills how I do write code taking care of several optimisations. I did my best to make code follow the SOLID rules.
- The game asks questions to player and he must choose the correct answer from several options. If he will choose correct answer, then he receives a point.
- Win condition: none
- Lose condition: none

## Used technologies
- "Visual Studio Code" IDE for writing code
- .NET 6.0.400 Compiler

## Features
- Editable questions in external JSON file
- Scoring system which adds points to player for every correct answer
- Amount of points is individual for every single question
- Validation of questions data
	- A number which represents correct answer MUST be in range from 1 to amount of answers
	- Amount of points MUST be greater or equal to zero
- Validation of typed numbers range
	- Minimum MUST NOT be greater than maximum

## Usage
- Type a whole number when prompted in given range (from-to)

## Credits
- This project was made by [Jason](https://jasonxiii.pl "Jason. Gry, muzyka, kursy, artykuły, programy i filmy!")