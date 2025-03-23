using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatanTimer : MonoBehaviour
{
    public GameObject Dice;
    public GameObject Player;

    public Color blue = Color.blue;
    public Color green = Color.green;
    public Color red = Color.red;

    public float timer = 20f;

    private int diceResult = 0;
    private int lastDiceResult = 0;

    public List<string> Players = new List<string>();
    private string playerResult = "";
    private string lastPlayerResult = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeDice");
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) ){
            StopAllCoroutines();
            StartCoroutine("ChangeDice");
        }
    }

    IEnumerator ChangeDice(){
        while(true){
            int number1 = (int)Mathf.Floor(Random.Range(1, 6.99999f));
            int number2 = (int)Mathf.Floor(Random.Range(1, 6.99999f));
            diceResult = number1 + number2;
            while(diceResult == lastDiceResult){
                number1 = (int)Mathf.Floor(Random.Range(1, 6.99999f));
                number2 = (int)Mathf.Floor(Random.Range(1, 6.99999f));
                diceResult = number1 + number2;
            }
            lastDiceResult = diceResult;

            Dice.GetComponent<TMPro.TextMeshProUGUI>().text = diceResult.ToString();

            if(diceResult == 6 || diceResult == 8) gameObject.GetComponent<Camera>().backgroundColor = green;
            else if(diceResult == 7) gameObject.GetComponent<Camera>().backgroundColor = red;
            else gameObject.GetComponent<Camera>().backgroundColor = blue;

            if(diceResult == 7){
                playerResult = Players[(int)Mathf.Floor(Random.Range(0, Players.Count - 0.00001f))];
                while(playerResult == lastPlayerResult) playerResult = Players[(int)Mathf.Floor(Random.Range(0, Players.Count - 1.00001f))];
                lastPlayerResult = playerResult;

                Player.GetComponent<TMPro.TextMeshProUGUI>().text = playerResult;

                StopAllCoroutines();
                break;
            }
            else{
                Player.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            }

            // End Of Coroutine
            yield return new WaitForSeconds(timer);
        }
    }
}
