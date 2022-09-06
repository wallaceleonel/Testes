# ChatBot_with_Automation

## Overview: This project is to demonstrate how the Robotic Process Automation(RPA) and ChatBots can be integrated together.

## Tools Used:
  1. DialogFlow
  2. UiPath
  3. Visual Studio 2019
  4. Microsoft Azure

### Project Workflow: 
  The working of the project is as follows, First, the user interacts with the chatbot [here I use Google's DialogFlow for chatbot] and describes his indispensabilities by typing text or doing voice commands to the chatbot, after that The Chabot takes the text or voice data provided by the user and extracts the relevant information, after that the chatbot triggers a robotic process automation [here I use UiPath for RPA] and the result or the information provided by this RPA will be provided back to the user in the chatbot.

### Technical Description: 
  Whenever the user types or speaks something to the chatbot, it takes all the user's data and extracts the relevant information from it, after that DialogFlow sends a Post response with all the extracted information to a Webhook [here I use . Net and C# to write the Webhook code and host it on Microsoft Azure], after that the Webhook performs all the related activities and triggers a UiPath process using UiPath Orchestrator APIs that starts the UiPath robot deployed on a machine and performs the automated task and engenders a response that is sent back to the webhook and from the webhook again the result is sent in the chatbot.