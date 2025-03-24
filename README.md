# Cybersecurity Awareness Chatbot for South African Citizens

## PROG6221 - Programming 2A

This project implements a console-based chatbot using C# in Visual Studio, focused on educating South African citizens about cybersecurity threats and best practices.

## Background

In recent years, South Africa has seen a significant rise in cyberattacks targeting individuals, businesses, and government institutions. These attacks often include phishing scams, malware, and social engineering, leaving many people vulnerable to financial loss, identity theft, and psychological harm. This chatbot serves as a "Cybersecurity Awareness Assistant" to educate users on identifying and mitigating cyber threats in a conversational manner.

## Features

- Interactive console-based cybersecurity awareness chatbot
- ASCII art welcome banner with cybersecurity theme
- Voice greeting using System.Media.SoundPlayer
- Personalized user interaction (asks for and uses the user's name)
- Color-coded console UI for improved readability
- Typing effect to simulate real conversation
- Keyword-based response system with multiple response variations
- Comprehensive cybersecurity information tailored to South African context
- Input validation and error handling
- Conversation history tracking
- Cybersecurity awareness score system
- Special commands for additional functionality
- Modular code structure with clear organization

## Usage

- The chatbot will greet you and ask for your name
- Type your queries or statements about cybersecurity and press Enter
- The chatbot will respond based on keywords in your input
- Special commands:
  - `help` - See what the chatbot can assist with
  - `security tips` - Get quick cybersecurity advice
  - `quiz` - Test your cybersecurity knowledge
  - `score` - Check your cybersecurity awareness score
  - `history` - View recent conversation history
  - `clear` - Clear the console screen
  - `bye`, `exit`, or `quit` - End the conversation

## Cybersecurity Topics Covered

The chatbot can respond to various cybersecurity-related keywords including:
- phishing
- password (security)
- safe browsing
- malware
- social engineering
- scams (common in South Africa)
- ransomware
- identity theft
- mobile security

## Code Structure (Planned to implment all below, still getting there)

- `Program` class: Entry point for the application
- `ChatBot` class: Main class containing all chatbot functionality
  - `InitializeResponses()`: Sets up the response dictionary with cybersecurity information
  - `Start()`: Initiates the chatbot
  - `PlayVoiceGreeting()`: Plays a voice greeting or simulates one if file is missing
  - `DisplayWelcomeMessage()`: Shows ASCII art and welcome message
  - `GetUserName()`: Prompts for and validates user name
  - `Conversation()`: Main conversation loop
  - `UpdateSecurityScore()`: Adjusts user's security awareness score based on interactions
  - `GenerateResponse()`: Processes input and selects appropriate cybersecurity response
  - `GetScoreMessage()`: Provides feedback based on security score
  - `GetConversationHistory()`: Retrieves recent conversation history
  - `TypeResponse()`: Displays response with typing effect
  - `DisplaySecurityScore()`: Shows and updates the color-coded security score at the top of the console
  - `ProcessQuizAnswer()`: Evaluates user's answer to quiz questions and provides feedback
  - `StartQuiz()`: Initiates a cybersecurity quiz with multiple-choice questions

## Future Enhancements

- Add more interactive cybersecurity quizzes and scenarios
- Implement a learning mechanism to improve responses over time
- Add ability to handle multi-turn conversations about complex security topics
- Integrate with real-time cybersecurity threat information
- Add more South African specific cybersecurity information and resources
- Implement a graphical user interface version
- Add Voice Overs for certian suggestions or answers from the bot

## References

Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review. *The African Journal of Information and Communication*, 28(28).
https://www.scielo.org.za/scielo.php?pid=S2077-72132021000200003&script=sci_arttext
