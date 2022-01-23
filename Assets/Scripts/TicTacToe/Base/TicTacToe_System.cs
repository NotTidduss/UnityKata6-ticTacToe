using UnityEngine;
using UnityEngine.SceneManagement;

public class TicTacToe_System : MonoBehaviour
{
    [Header ("Player Mark Sprites")]
    public Sprite markPlayer1;
    public Sprite markPlayer2;


    public Sprite getMarkPlayer1() => markPlayer1;
    public Sprite getMarkPlayer2() => markPlayer2;

#region Scene Management
    [Header ("Scene Names")]
    public string gameSceneName = "1x_TicTacToe_Game";

    public void loadGameScene() => SceneManager.LoadScene(gameSceneName);
#endregion
}


// Mark: The possible content of a square within the Tic Tac Toe field.
public enum TicTacToe_Mark 
{
    NONE,
    X,
    O
}


// Outome: The possible results of a game of TicTacToe, based on Player 1.
public enum TicTacToe_GameState
{
    ONGOING,
    WIN,
    LOSS,
    DRAW
}