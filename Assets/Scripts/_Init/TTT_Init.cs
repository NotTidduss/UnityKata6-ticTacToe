using UnityEngine;
using UnityEngine.SceneManagement;

public class TTT_Init : MonoBehaviour
{
    void Awake() {
        initializePlayerPrefs();
        SceneManager.LoadScene("1x_TicTacToe");
    }

    private void initializePlayerPrefs(){
        /* 
        Persistent PlayerPrefs - should never be reset

        ttt_totalWins: the sum of player victories.
        ttt_totalLosses: the sum of player defeats.
        ttt_totalDraws: the sum of player draws.
        */

        // ttt_currentMark: the mark that is set next. Options: 1 = O, 2 = X.
        PlayerPrefs.SetInt("ttt_currentPlayer", 1);

        // ttt_outcome: the final result of the game. Options: WIN, LOSS, DRAW.
        PlayerPrefs.SetString("ttt_outcome", "");
    }
}
