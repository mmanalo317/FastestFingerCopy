function optionSelect(url) {
    btns = document.getElementsByClassName("btn-option");
    var questionNumber = url;
    //var q1QuestionString = questionNumber + "Answer";
    var q1QuestionString = "Q1Question";
    for (var i = 0; i < btns.length; i++) {
        btns[i].addEventListener("click", function () {
            //Send the details to the Session 
            sessionStorage.setItem("Q1Question", "Here we go!");
            //Go to the next page
            document.getElementById("demo").innerHTML = "Hello World";
        });
    }
}