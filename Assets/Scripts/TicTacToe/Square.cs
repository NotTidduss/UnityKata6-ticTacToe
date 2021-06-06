using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    public int id;
    public Mark mark;
    public bool isMarked;

    private Master masterRef;

    void Start() {
        id = transform.GetSiblingIndex();
        mark = Mark.NONE;
        isMarked = false;

        masterRef = GameObject.Find("Master").GetComponent<Master>();
    }

    public void setAsMarked() {
        if (!isMarked) {
            isMarked = true;
            switch (PlayerPrefs.GetInt("kata6_currentMark")) {
                case 0:
                    mark = Mark.O;
                    GetComponent<Image>().sprite = masterRef.markO;
                    PlayerPrefs.SetInt("kata6_currentMark", 1);
                    break;
                case 1:
                    mark = Mark.X;
                    GetComponent<Image>().sprite = masterRef.markX;
                    PlayerPrefs.SetInt("kata6_currentMark", 0);
                    break;
            }

            masterRef.checkFinished();
        }
    }

    public void finishOff() => isMarked = true;
}
