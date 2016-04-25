#pragma strict


function OpenStart() {
	Application.LoadLevel("StartScene");
	}

function loadRace() {
	Application.LoadLevel("RaceScene");
	}

function loadSettings() {
	Application.LoadLevel("SettingsScene");
	}

function loadCampaign() {
	Application.LoadLevel("CampaignScene");
	}


function loadAbout() {
	Application.LoadLevel("AboutScene");
	} 

function loadGarage() {
	Application.LoadLevel("GarageScene");
	}

function quitGame() {
	Application.Quit();
	}
