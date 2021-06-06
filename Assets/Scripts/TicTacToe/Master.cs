using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    [Header("Tic Tac Toe Settings:")]
    [SerializeField] public Sprite markO;
    [SerializeField] public Sprite markX;
    [SerializeField] public Square[] squares;

    [Header("UI References:")]
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject resultScreen;
    [SerializeField] private Text resultsText;
    [SerializeField] private Text winSumText;
    [SerializeField] private Text lossSumText;
    [SerializeField] private Text drawSumText;

    private bool isAlreadyFinished;

    void Start() {
        isAlreadyFinished = false;
        
        resultScreen.SetActive(false);
        PlayerPrefs.SetInt("kata6_currentMark", 0);
    }  

    public void checkFinished() {
        checkLinedUp();
        if (!isAlreadyFinished) checkLast();
    }

    public void playAgain() => SceneManager.LoadScene("1_TicTacToe");

    private void checkLinedUp() {
        if (isLinedUp(0, 1, 2) || isLinedUp(3, 4 ,5) || isLinedUp(6, 7, 8)
            || isLinedUp(0, 3, 6) || isLinedUp(1, 4, 7) || isLinedUp(2, 5, 8)
            || isLinedUp(0, 4, 8) || isLinedUp(2, 4, 6)) {
                switch(PlayerPrefs.GetInt("kata6_currentMark")) {
                    case 0:
                        PlayerPrefs.SetString("kata6_outcome", "LOSS");
                        PlayerPrefs.SetInt("kata6_totalLosses", PlayerPrefs.GetInt("kata6_totalLosses") + 1);
                        break;
                    case 1:
                        PlayerPrefs.SetString("kata6_outcome", "WIN");
                        PlayerPrefs.SetInt("kata6_totalWins", PlayerPrefs.GetInt("kata6_totalWins") + 1);
                        break;
                }
                isAlreadyFinished = true;
                finish();
            }
    }

    private bool isLinedUp(int i, int j, int k) {
        Mark currentMark = PlayerPrefs.GetInt("kata6_currentMark") == 0 ? Mark.X : Mark.O;
        return squares[i].mark == currentMark && squares[j].mark == currentMark && squares[k].mark == currentMark;
    }

    private void checkLast() {
        bool isLast = true;
        for (int i = 0; i < squares.Length; i++) if (!squares[i].isMarked) isLast = false;
        
        if (isLast) {
            PlayerPrefs.SetString("kata6_outcome", "DRAW");
            PlayerPrefs.SetInt("kata6_totalDraws", PlayerPrefs.GetInt("kata6_totalDraws") + 1);
            finish();
        }
    }

    // finish off all squares, activate the result screen, set texts and recolor the background based on result
    private void finish() {
        for (int i = 0; i < squares.Length; i++) squares[i].finishOff();

        resultScreen.SetActive(true);
        winSumText.text = PlayerPrefs.GetInt("kata6_totalWins").ToString();
        lossSumText.text = PlayerPrefs.GetInt("kata6_totalLosses").ToString();
        drawSumText.text = PlayerPrefs.GetInt("kata6_totalDraws").ToString();
        resultsText.text = PlayerPrefs.GetString("kata6_outcome");

        switch (PlayerPrefs.GetString("kata6_outcome")) {
            case "WIN":
                cam.backgroundColor = new Color(0, 255, 0);
                break;
            case "LOSS":
                cam.backgroundColor = new Color(255, 0, 0);
                break;
            case "DRAW":
                cam.backgroundColor = new Color(255, 255, 0);
                break;
        }
    }
}
