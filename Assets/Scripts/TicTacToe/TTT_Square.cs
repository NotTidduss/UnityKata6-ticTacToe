using UnityEngine;
using UnityEngine.UI;

public class TTT_Square : MonoBehaviour
{
    [Header ("Master Reference")]
    [SerializeField] private TTT_Master master;

    public int id {get; private set;}
    public TTT_Mark mark {get; private set;}
    public bool isMarked {get; private set;}


    void Start() {
        // prepare private variables
        id = transform.GetSiblingIndex();
        mark = TTT_Mark.NONE;
        isMarked = false;
    }

    public void btnSetAsMarked() {
        if (!isMarked) {
            isMarked = true;

            int player = PlayerPrefs.GetInt("ttt_currentPlayer");

            mark = player == 1 ? TTT_Mark.O : TTT_Mark.X;
            GetComponent<Image>().sprite = master.getSys().fetchPlayerMarkSprite(player);
            PlayerPrefs.SetInt("ttt_currentPlayer", player == 1 ? 2 : 1);

            master.checkFinished();
        }
    }

    public void setAsMarked() => isMarked = true;
}
