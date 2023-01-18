function countdownTimer(url, intCurrent) {
    var timeleft = 30;
    var downloadTimer = setInterval(function () {
        if (timeleft < 0) {
            clearInterval(downloadTimer);
            var currentElement = document.getElementById('helloCurrent').value;
            var increaseElem = parseInt(currentElement) + 1;
            //If time runs out
            //Set the question to false and the time as max 15 seconds
            var questionNumber = "Q" + increaseElem + "Correct";
            sessionStorage.setItem(questionNumber, "false");
            var timeToAnswer = 30;
            var timeString = "answerTime-" + increaseElem;
            sessionStorage.setItem(timeString, timeToAnswer);
            //Navigate to next page
            window.location.href = url;
        } else {
            document.getElementById("countdown").innerHTML = timeleft.toFixed(2);
        }
        timeleft -= 0.01;
    }, 10);
}
