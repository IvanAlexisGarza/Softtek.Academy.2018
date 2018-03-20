var app = angular.module('surveyApp',[])

app.controller('SurveyController', function SurveyController() {
   this.questions = 
   [{name:"question 1", options:
                            [
                                {name:"option 1"},
                                {name: "option 2"}
                            ]},
    {name: "question 2", options:
                            [
                                { name: "option a" },
                                { name: "option b" }
                            ]}
    ]

    this.createQuestion = function(){
        this.questions.push({name:this.newQuestion,options:[]});
        this.newQuestion = "";
    }

    this.AddOption = function (question) {
        this.question.push({ name: this.newQuestion, options: [] });
    }

    this.remove = function (question, index) {
        question.options.splice(index, 1);
    }

    this.removeOption = function (options, index) {
        this.options.splice(index, 1);
        this.options.shift();
        this.options = $filter('filter')(this.options, { index: !$index })
    }

});