using UnityEngine;
using UnityEngine.UI;

public class TicTacToe_Square : MonoBehaviour
{
    [Header ("Master Reference")]
    [SerializeField] private TicTacToe_Master master;


    public int id {get; private set;}
    public TicTacToe_Mark mark {get; private set;}
    public bool isMarked {get; private set;}


    void Start() {
        // prepare private variables
        id = transform.GetSiblingIndex();
        mark = TicTacToe_Mark.NONE;
        isMarked = false;
    }


    public void btnSetAsMarked() {
        if (!isMarked) {
            isMarked = true;

            int player = PlayerPrefs.GetInt("ticTacToe_currentPlayer");

            mark = player == 1 ? TicTacToe_Mark.O : TicTacToe_Mark.X;
            switch(player) {
                case 1: GetComponent<Image>().sprite = master.getMarkPlayer1(); break;
                case 2: GetComponent<Image>().sprite = master.getMarkPlayer2(); break;
            }
            PlayerPrefs.SetInt("ticTacToe_currentPlayer", player == 1 ? 2 : 1);

            master.checkFinished();
        }
    }

    public void setAsMarked() => isMarked = true;
}
