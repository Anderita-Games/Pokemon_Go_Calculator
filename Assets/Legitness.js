#pragma strict
//Inputed Stuff
var type : UnityEngine.UI.Dropdown;
var pokenumber : UnityEngine.UI.InputField;
var candynumber : UnityEngine.UI.InputField;

//Text at bottom
var math : UnityEngine.UI.Text;
var egg : UnityEngine.UI.Text;

//Basic info
var types : int;
var pokesnumber : int;
var candysnumber : int;

//Calculated Stuff
var time : float; 
var xp : float;
var alltime : float;
var allxp : float;

function Add () {
	xp = 0;
	time = 0;
	pokesnumber = int.Parse(pokenumber.text);
	candysnumber = int.Parse(candynumber.text);
	Require();
	Debug.Log(types);
	while (candysnumber > (types - 1) && pokesnumber != 0) {
		pokesnumber --;
		candysnumber = candysnumber - types;
		time = time + .5;
		xp = xp + 1000;
		alltime = alltime + .5;
		allxp = allxp + 1000;
	}
	while (pokesnumber > (types - 1)) {
		pokesnumber = pokesnumber - types;
		time = time + .5;
		xp = xp + 1000;
		alltime = alltime + .5;
		allxp = allxp + 1000;
	}
	math.text = "For that last entry, you will have " + pokesnumber + " extra pokemon left over, " + candysnumber + " candy left over, before you evolve all of these pokemon you should transfer the " + pokesnumber + " extra pokemon to get the maximum candy, if you do you will gain " + xp + " XP, and the estimated time to evolve all of these pokemon is " + time + " minutes.";
}

function Calculate () {
	Eggs();
	math.text = "Overall xp gained: " + allxp + ". Time it will take: " + alltime + " mins. Don't forget to use a lucky egg!";
}

function Require () {
	if (type.value == 0) {
		types = 12;
	}else if (type.value == 1) {
		types = 25;
	}else if (type.value == 2) {
		types = 50;
	}else if (type.value == 3) {
		types = 100;
	}else if (type.value == 4) {
		types = 400;
	}
}

function Eggs () {
	if (alltime > 30) {
		egg.text = "Egg Recomendation: It would take you longer than 30 min to evolve all of these pokemon. You will need another egg.";
	}else if (alltime == 25 || time == 26 || time == 27 || time == 28 || time == 29) {
		egg.text = "Go ahead and use that egg! This is the max amount you can do without going over 30 min";
	}else if (alltime == 30) {
		egg.text = "You will have to be fast to make sure you dont miss any in 30 min";
	}else if (alltime < 25) {
		egg.text = "Wait until you have more pokemon to evolve";
	}	
}