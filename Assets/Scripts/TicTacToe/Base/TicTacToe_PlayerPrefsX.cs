using UnityEngine;

public class TicTacToe_PlayerPrefsX
{
    public static TicTacToe_GameState GetGameState(string key) => (TicTacToe_GameState) PlayerPrefs.GetInt(key);
    public static void SetGameState(string key, TicTacToe_GameState gameState) => PlayerPrefs.SetInt(key, (int) gameState);
}
