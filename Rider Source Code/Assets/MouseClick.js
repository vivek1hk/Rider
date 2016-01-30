var single_player: Texture2D;
var two_player :Texture2D;
var free_roam :Texture2D;
var quit:Texture2D;
function OnGUI () {
	

	// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
	if (GUI.Button (Rect (280,450,220,90), single_player)) {
		Application.LoadLevel (1);
	}

	// Make the second button.
	if (GUI.Button (Rect (580,450,220,90), two_player)) {
		Application.LoadLevel (2);
	}
	// Make the second button.
	if (GUI.Button (Rect (880,450,220,90), free_roam)) {
		Application.LoadLevel (2);
		}
		// Make the second button.
	if (GUI.Button (Rect (635,580,80,40), quit)) {
		Application.LoadLevel (2);
		}
}