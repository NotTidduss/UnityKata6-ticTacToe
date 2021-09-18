using UnityEngine;
using UnityEngine.UI;

public class TTT_UI : MonoBehaviour
{
    [Header ("Master Reference")]
    [SerializeField] private TTT_Master master;

    [Header ("Menus")]
    [SerializeField] private GameObject resultMenu;

    [Header ("Texts")]
    [SerializeField] private Text resultsText;
    [SerializeField] private Text winSumText;
    [SerializeField] private Text lossSumText;
    [SerializeField] private Text drawSumText;


    public void setResultMenu(bool isActive) {
        resultMenu.SetActive(isActive);
        winSumText.text = PlayerPrefs.GetInt("ttt_totalWins").ToString();
        lossSumText.text = PlayerPrefs.GetInt("ttt_totalLosses").ToString();
        drawSumText.text = PlayerPrefs.GetInt("ttt_totalDraws").ToString();
        resultsText.text = PlayerPrefs.GetString("ttt_outcome");
    }

    public void btnPlayAgain() => master.getSys().loadTTTScene();
}
