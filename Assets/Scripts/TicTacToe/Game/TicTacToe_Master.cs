using System;
using UnityEngine;

public class TicTacToe_Master : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private TicTacToe_System sys;
    [SerializeField] private TicTacToe_GameMaster gm;
    [SerializeField] private TicTacToe_UI ui;
    [SerializeField] private TicTacToe_Square[] squares;
    [SerializeField] private Camera cam;


    //* private vars
    private bool isAlreadyFinished;


    void Start() {
        // prepare private variables
        isAlreadyFinished = false;

        // initialize Scene
        TicTacToe_PlayerPrefsMaster.initializePlayerPrefs();    
        ui.initialize();
    }  


    public void playAgain() => sys.loadGameScene();
    public Sprite getMarkPlayer1() => sys.getMarkPlayer1();
    public Sprite getMarkPlayer2() => sys.getMarkPlayer2();

    public void checkFinished() {
        checkLinedUp();
        if (!isAlreadyFinished) checkLast();
    }

    // check if 3 marks are lined up, if so end game as Win or Loss
    private void checkLinedUp() {
        if (isLinedUp(0, 1, 2) || isLinedUp(3, 4 ,5) || isLinedUp(6, 7, 8)
            || isLinedUp(0, 3, 6) || isLinedUp(1, 4, 7) || isLinedUp(2, 5, 8)
            || isLinedUp(0, 4, 8) || isLinedUp(2, 4, 6)) {
                switch(PlayerPrefs.GetInt("ticTacToe_currentPlayer")) {
                    case 1:
                        TicTacToe_PlayerPrefsX.SetGameState("ticTacToe_gameState", TicTacToe_GameState.LOSS);
                        PlayerPrefs.SetInt("ticTacToe_totalLosses", PlayerPrefs.GetInt("ticTacToe_totalLosses") + 1);
                        break;
                    case 2:
                        TicTacToe_PlayerPrefsX.SetGameState("ticTacToe_gameState", TicTacToe_GameState.WIN);
                        PlayerPrefs.SetInt("ticTacToe_totalWins", PlayerPrefs.GetInt("ticTacToe_totalWins") + 1);
                        break;
                }
                isAlreadyFinished = true;
                endGame();
            }
    }

    private bool isLinedUp(int i, int j, int k) {
        TicTacToe_Mark currentMark = PlayerPrefs.GetInt("ticTacToe_currentPlayer") == 1 ? TicTacToe_Mark.O : TicTacToe_Mark.X;
        return squares[i].mark == currentMark && squares[j].mark == currentMark && squares[k].mark == currentMark;
    }

    // check if all squares are marked, if so end game as draw
    private void checkLast() {
        bool isLast = true;
        for (int i = 0; i < squares.Length; i++) if (!squares[i].isMarked) isLast = false;
        
        if (isLast) {
            TicTacToe_PlayerPrefsX.SetGameState("ticTacToe_gameState", TicTacToe_GameState.DRAW);
            PlayerPrefs.SetInt("ticTacToe_totalDraws", PlayerPrefs.GetInt("ticTacToe_totalDraws") + 1);
            endGame();
        }
    }

    // mark all squares to disable interactions, activate the result menu and recolor the background based on result
    private void endGame() {
        for (int i = 0; i < squares.Length; i++) squares[i].setAsMarked();

        ui.setResultMenu(true);

        switch (TicTacToe_PlayerPrefsX.GetGameState("ticTacToe_gameState")) {
            case TicTacToe_GameState.WIN: cam.backgroundColor = new Color(0, 255, 0); break;
            case TicTacToe_GameState.LOSS: cam.backgroundColor = new Color(255, 0, 0); break;
            case TicTacToe_GameState.DRAW: cam.backgroundColor = new Color(255, 255, 0); break;
        }
    }
}
