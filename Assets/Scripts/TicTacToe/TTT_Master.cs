using UnityEngine;

public class TTT_Master : MonoBehaviour
{
    [Header("Scene References:")]
    [SerializeField] private TTT_System sys;
    [SerializeField] private TTT_UI ui;
    [SerializeField] private TTT_Square[] squares;
    [SerializeField] private Camera cam;


    private bool isAlreadyFinished;

    void Start() {
        // prepare private variables
        isAlreadyFinished = false;

        // prepare PlayerPrefs
        PlayerPrefs.SetInt("ttt_currentPlayer", 1);
        
        // prepare Game
        ui.setResultMenu(false);
    }  

    public void checkFinished() {
        checkLinedUp();
        if (!isAlreadyFinished) checkLast();
    }

    // check if 3 marks are lined up, if so end game as Win or Loss
    private void checkLinedUp() {
        if (isLinedUp(0, 1, 2) || isLinedUp(3, 4 ,5) || isLinedUp(6, 7, 8)
            || isLinedUp(0, 3, 6) || isLinedUp(1, 4, 7) || isLinedUp(2, 5, 8)
            || isLinedUp(0, 4, 8) || isLinedUp(2, 4, 6)) {
                switch(PlayerPrefs.GetInt("ttt_currentPlayer")) {
                    case 1:
                        PlayerPrefs.SetString("ttt_outcome", "LOSS");
                        PlayerPrefs.SetInt("ttt_totalLosses", PlayerPrefs.GetInt("ttt_totalLosses") + 1);
                        break;
                    case 2:
                        PlayerPrefs.SetString("ttt_outcome", "WIN");
                        PlayerPrefs.SetInt("ttt_totalWins", PlayerPrefs.GetInt("ttt_totalWins") + 1);
                        break;
                }
                isAlreadyFinished = true;
                endGame();
            }
    }

    private bool isLinedUp(int i, int j, int k) {
        TTT_Mark currentMark = PlayerPrefs.GetInt("ttt_currentPlayer") == 1 ? TTT_Mark.O : TTT_Mark.X;
        return squares[i].mark == currentMark && squares[j].mark == currentMark && squares[k].mark == currentMark;
    }

    // check if all squares are marked, if so end game as draw
    private void checkLast() {
        bool isLast = true;
        for (int i = 0; i < squares.Length; i++) if (!squares[i].isMarked) isLast = false;
        
        if (isLast) {
            PlayerPrefs.SetString("ttt_outcome", "DRAW");
            PlayerPrefs.SetInt("ttt_totalDraws", PlayerPrefs.GetInt("ttt_totalDraws") + 1);
            endGame();
        }
    }

    // mark all squares to disable interactions, activate the result menu and recolor the background based on result
    private void endGame() {
        for (int i = 0; i < squares.Length; i++) squares[i].setAsMarked();

        ui.setResultMenu(true);

        switch (PlayerPrefs.GetString("ttt_outcome")) {
            case "WIN": cam.backgroundColor = new Color(0, 255, 0); break;
            case "LOSS": cam.backgroundColor = new Color(255, 0, 0); break;
            case "DRAW": cam.backgroundColor = new Color(255, 255, 0); break;
        }
    }

    public TTT_System getSys() => sys;
}
