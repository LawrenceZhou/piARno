using UnityEngine;

public class StartCommand : MonoBehaviour
{
    // Called by GazeGestureManager when the user performs a Select gesture
    // Change the game state to true to indicate the start of a song
    void OnSelect()
    {
        gameSystem.state = true;
    }
}