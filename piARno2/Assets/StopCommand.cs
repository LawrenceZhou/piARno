using UnityEngine;

public class StopCommand : MonoBehaviour
{
	// Called by GazeGestureManager when the user performs a Select gesture
    // Change the game state to false to indicate the end of a song, used for resetting other game variables
    void OnSelect()
    {
        gameSystem.state = false;
    }
}