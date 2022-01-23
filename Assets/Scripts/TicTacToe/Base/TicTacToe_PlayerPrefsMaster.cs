using UnityEngine;

public class TicTacToe_PlayerPrefsMaster
{
    public static void initializePlayerPrefs() {
        // INT ticTacToe_totalWins - the sum of player victories
        if (PlayerPrefs.GetInt("ticTacToe_totalWins") == 0)
            PlayerPrefs.SetInt("ticTacToe_totalWins", 0);

        // INT ticTacToe_totalLosses - the sum of player defeats
        if (PlayerPrefs.GetInt("ticTacToe_totalLosses") == 0)
            PlayerPrefs.SetInt("ticTacToe_totalLosses", 0);

        // INT ticTacToe_totalDraws - the sum of player draws
        if (PlayerPrefs.GetInt("ticTacToe_totalDraws") == 0)
            PlayerPrefs.SetInt("ticTacToe_totalDraws", 0);

        // INT ticTacToe_currentPlayer: this player's mark will be used next. Options: 1 = O, 2 = X.
        PlayerPrefs.SetInt("ticTacToe_currentPlayer", 1);

        // GAMESTATE ticTacToe_gameState: the current state of the game. Options: ONGOING, WIN, LOSS, DRAW.
        TicTacToe_PlayerPrefsX.SetGameState("ticTacToe_gameState", TicTacToe_GameState.ONGOING);
    }

    public static void resetPlayerPrefs() {
        PlayerPrefs.DeleteAll();
        initializePlayerPrefs();
    }
}
