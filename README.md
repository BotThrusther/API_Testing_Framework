# API_Testing_Framework

## Table of Contents

[Introduction](#introduction)

[Goal of the Project](#goal-of-the-project)

[How to setup the framework](#how-to-setup-the-framework)

[How the framework can be extended](#how-the-framework-can-be-extended)

[What was tested](#what-was-tested)

[Test Metrics](#test-metrics)

## Introduction
This repository holds the testing framework for the [Digimon](https://digimon-api.vercel.app) API.

Team Members:

- **Anthony Naguib:** MOQ Testing, README , User story & Test Cases
- **Neisewand Hussain:** GitHub repo, README
- **Manvir Nandra:** Digimon table testing, User story & Test Cases
- **Aaron Lewis:** Digimon query name testing, Framework setup
- **Abdul Majid Ali:** Digimon query level testing, User story & Test Cases

## Goal of the Project

To test the [Digimon API](https://digimon-api.vercel.app/) through the use of a test framework, utilising Http requests, Specflow and Moq.

The deliverables for this project consist of:

- [Powerpoint](https://1drv.ms/p/s!AoT1l7CZNPA2gecIiB0fH9UxoPS8Qw?e=tevGag)
- [Trello](https://trello.com/b/dNoa0ZPE/api-mini-project)
- [User stories and test cases](https://docs.google.com/document/d/1zJFW2LcSz0i6N4kiHtgBekK0MjMJCdvdJnzaR8li-bY/edit?usp=sharing)
- [Defect Reports](https://docs.google.com/document/d/1NKk1j_LAY-K7kVNNahKuV2sImFcSqFqKwEa6GN9qdXk/edit?usp=sharing)
- Test Framework using Specflow and Moq
- A README file
- Collaborative use of GitHub

## How to setup the framework
The framework consists of different classes for HTTP calls and data required.

In order to setup the framework the following packages are required:
- Nunit
- Newtonsoft.Json
- Specflow
- Configuration Manager

The solution was created in Visual Studio 2022. For further understanding of the layout of the framework please refer to the class diagram below:
![image](https://media.discordapp.net/attachments/1108750548682944542/1110145296798851112/239859154-93d9b26b-a0dc-4ac8-84fc-d1d3699614be.png)

This is the class structure for making and recieving API calls to and from the API server.

## How the framework can be extended

Whilst our framework meets all the base requirements, here are some improvements that can be made:
- Refactoring: Utilising more helper methods to extrace code logic from the tests. Add a SharedSteps class to improve code resusability.
- Performance and Stress Testing: Test the response time of the API calls to identify bottlenecks and determine the scalability of the API.
- Extend ICallManager: to utilise this interface to create different types of requests through method overloading.

## What was tested
The requirments, user stories and scenarios can be seen in document - [User stories and test cases](https://docs.google.com/document/d/1zJFW2LcSz0i6N4kiHtgBekK0MjMJCdvdJnzaR8li-bY/edit?usp=sharing)

## Test Metrics
 Testing Metrics | Test Case Development & Execution
 ----------------|-------------------------
Number of Requirements | 3 
Number of Test Cases Written | ​19​
Number of Test Cases Executed | ​12​
Number of Test Cases Unexecuted | ​7​
Number of Test Cases Passed | ​12​
Number of Test Cases Failed | ​0​
Total Number of Defects Found | ​1​
High Defect Count | ​0​
Medium Defect Count​ | 1​
Low Defect Count | ​0​


## Diary

_18/05/2023_

- Created User stories and Gherkin scenarios
- Set up a Trello board and populated it with all the user stories for better project management
- Created a Git repository to establish version control and enable collaboration
- Worked on setting up the test framework for testing Tronald Dump API
- Made progress in organizing tasks and prioritizing work efficiently for the project

_19/05/2023_

- User Stories and Test Framework edited to use Digimon API
- Test made using specflow
- Test cases completed
- Presentation made
- README updated

_22/05/2023_

- Created GitHub Workflow
- Presentation Finished
- README Finished

## What went well and what went bad
### Good
- Team collaborated effectively using Teams, Discord and Github​
- Open communication ​
- Help available from other team members with issues​
- API test framework was implemented correctly ​
- Majority of tests were implemented and passed

### Bad
- Violated some of SOLID principles​
- Chosen API sends responses that are difficult to manipulate​
- Documentation was difficult to understand
