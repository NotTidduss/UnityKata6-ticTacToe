using UnityEngine;
using UnityEngine.UI;

public class TicTacToe_UI : MonoBehaviour
{
    [Header ("Master Reference")]
    [SerializeField] private TicTacToe_Master master;


    [Header ("Menus")]
    [SerializeField] private GameObject resultMenu;


    [Header ("Texts")]
    [SerializeField] private Text resultsText;
    [SerializeField] private Text winSumText;
    [SerializeField] private Text lossSumText;
    [SerializeField] private Text drawSumText;


    public void initialize() 
    {
        resultMenu.SetActive(false);
    } 


    public void setResultMenu(bool isActive) {
        resultMenu.SetActive(isActive);
        winSumText.text = PlayerPrefs.GetInt("ticTacToe_totalWins").ToString();
        lossSumText.text = PlayerPrefs.GetInt("ticTacToe_totalLosses").ToString();
        drawSumText.text = PlayerPrefs.GetInt("ticTacToe_totalDraws").ToString();
        resultsText.text = TicTacToe_PlayerPrefsX.GetGameState("ticTacToe_gameState").ToString();
    }

#region Button Functionality
    public void btnPlayAgain() => master.playAgain();
#endregion
}
