$(document).ready(function () {
    var scoreNames = ["Nerf Herder", "Bantha Fodder", "Clanker", "Bucket Head", "Walking Carpet", "Scruffy Looking", "Fuzzball", "Flyboy", "Goldenrod", "Laser Brain"];
    var speciesTicker = 0;
    var planetTicker = 0;
    var speciesFinished = false;
    var planetFinished = false;
    var score = 0;

    $("#planetsSelection").on("click", function () {
        loadQuestion("Planet")
    });

    $("#speciesSelection").on("click", function () {
        loadQuestion("Species");
    });

    function setGuessingActionsToo() {
        $(".guess-options").on("click", function () {
            $(".guess-options").unbind("click"); //make sure double clicking isn't possible

            score = parseInt($("#Score").text());
            
            if (speciesTicker > 19) {
                speciesFinished = true;
                $("#speciesSelection").unbind("click").prop("disabled", true); //disable the button when the question size has been depleted
            }

            if (planetTicker > 19) {
                planetFinished = true;
                $("#planetsSelection").unbind("click").prop("disabled", true);
            }

            if ($(this).text() == $("#DefinitelyNotTheAnswer").text()) { //they guessed correctly. Update score
                $(this).addClass("btn-success").removeClass("btn-primary")
                $("#Score").text(++score);
            } else {                                                     //they guessed incorrectly. Show correct score
                $(this).addClass("btn-danger").removeClass("btn-primary") 
                $(".guess-options").each(function (index, value) {
                    if ($(value).text() == $("#DefinitelyNotTheAnswer").text()) {
                        $(this).addClass("btn-success").removeClass("btn-primary")
                        return;
                    }
                })
            }

            setTimeout(function () {
                loadQuestion($("#Category").text())
            }, 200); //Give user enough time to see the correct answer
        });
    }

    function loadQuestion(type) {
        if (speciesFinished && type == "Species") { //Makes sure the user hasn't exhausted all questions and finish the game if they have
            if (planetFinished) {
                EndGame();
            }
            type = "Planet"; //Switches the category for the user when they exhaust one list
        } else if(planetFinished && type == "Planet") {
            if (speciesFinished) {
                EndGame();
            }
            type = "Species";
        }
        
        if (!planetFinished || !speciesFinished) { //If the user hasn't exhausted their question pool yet
            $.ajax({
                url: "/Home/LoadRandom".concat(type),
                type: "GET",
            })
            .done(function (partialViewResult) { //Load more of the same questions
                $("#GuessingArea").html(partialViewResult);
                $("#Category").text(type);
                setGuessingActionsToo();
            });

            if (type == "Species") { 
                ++speciesTicker;
            } else if (type == "Planet") {
                ++planetTicker;
            }
        }
    }

    function EndGame() { //Show score screen
        $("#GuessingArea").empty();
        $("#GuessingArea").html("<h1>You've scored " + score + " making you a " + scoreNames[Math.floor(score / 4)] + "</h1><h2>Refresh To Play Again</h2>");
    }

});