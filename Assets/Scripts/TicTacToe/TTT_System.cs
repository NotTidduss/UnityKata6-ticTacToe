using UnityEngine;
using UnityEngine.SceneManagement;

public class TTT_System : MonoBehaviour
{
    [Header ("Scene Name for re-playing")]
    public string ttt_scene = "1x_TicTacToe";

    [Header ("Sprites to be used in the UI")]
    public Sprite player1MarkSprite;
    public Sprite player2MarkSprite;

    public void loadTTTScene() => SceneManager.LoadScene(ttt_scene);
    public Sprite fetchPlayerMarkSprite(int player) => player == 1 ? player1MarkSprite : player2MarkSprite;
}

// Mark: The possible content of a square within the Tic Tac Toe field.
public enum TTT_Mark {
    NONE,
    X,
    O
}