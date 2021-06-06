using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Awake() {
        initializePlayerPrefs();
        SceneManager.LoadScene("1_TicTacToe");
    }

    private void initializePlayerPrefs(){
        /* 
        Persistent PlayerPrefs - should never be reset

        kata6_totalWins: the sum of player victories.
        kata6_totalLosses: the sum of player defeats.
        kata6_totalDraws: the sum of player draws.
        */

        // kata6_currentMark: the mark that is set next. Options: 0 = O, 1 = X.
        PlayerPrefs.SetInt("kata6_currentMark", 0);

        // kata6_outcome: the final result of the game. Options: WIN, LOSS, DRAW.
        PlayerPrefs.SetString("kata6_outcome", "");
    }
}
