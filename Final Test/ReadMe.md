  

# Softtek .NET Academy 2018
User: Ivan Alexis Garza Tapia

  

# Final Implementation:

  

There where some problems with the final Implementation and unfortunately the program was not finished

  
  

## Base URL's

On my local machine i used the following directories

  

### Host


* http://localhost:52217

* Get Survey By ID; http://localhost:52217/api/survey/{id:int}

* Get Questions By Survey; http://localhost:52217/api/survey/{id:int}/allquestions

* Get All Surveys; http://localhost:52217/api/survey/all

* Create Survey; http://localhost:52217/api/survey/

[FromBody] JSON Format

    {
	    "Title" : "",
    
	    "Description" : "",
    
	    "IsActive" : "",
    }

  * Add Question To Survey: http://localhost:52217/api/survey/{surveyId:int}/question/{questionId:int}
  * Change Status: http://localhost:52217/api/survey/{surveyId:int}/question/{questionId:int}
  * Active State Change: http://localhost:52217/api/survey/{surveyId:int}/active/{activeState:int}
  * Get Question By Id: http://localhost:52217/api/question/{id:int}
  * Get All Questions: http://localhost:52217/api/question/all
  * Get Options By Question:  http://localhost:52217/api/question/{questionId:int}/options
  * Get Answers By Question: http://localhost:52217/api/question/{questionId:int}/answers
  

## In the end

The back-end for the project is completely finished.

The front-end section is not even half way done.

You can't add questions to a survey.

You can't answer surveys.

  

## Common problems

  
* I somehow overloaded my work Station and couldn't use it for three hours on Friday, i had to scrap my MVC project and tried using a project from another the MVC Module test.

  

* My MVC project nullified the "Id" property on mos of my classes

  

* AngularJS module for the user was not even tried, due to bad time management
