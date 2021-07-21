using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestMethod : MonoBehaviour
{
    // Start is called before the first frame update
    private string input;
    private float wait = 2f;
    private int[] anwsers;
    public string[] sentences;
    private int taskSum;
    private int taskProduct;
    private int playerSum;
    private int playerProduct;
    private int Index = 0;
    private int numberOTry = 0;
    private int maxNumberOTry = 3;
    private int difficulty = 0;
    private int maxDifficulty = 3;
    private float textSpeed = 0.05f;
    public TextMeshProUGUI DialogText;
    public GameObject inputField;

    void Start()
    {
        GenerateTask();
        StartCoroutine(GiveTask());     //staring the ghame with printing out the first task
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOTry >= maxNumberOTry)
        {
            Index = 2;
            StopCoroutine(GiveTask());
            DialogText.text = string.Empty;
            input = string.Empty;
            StartCoroutine(Ending());
        }
        if (difficulty > maxDifficulty)
        {
            Index = 1;
            StopCoroutine(GiveTask());
            DialogText.text = string.Empty;
            input = string.Empty;
            StartCoroutine(Ending());
        }
        if (Input.GetKeyDown(KeyCode.Return)) {             //check for condition(player hits enter)

            if (difficulty <= maxDifficulty && numberOTry <= maxNumberOTry) {

                StoreAnwser();      //first store the anwser


                if (CheckAnwsers())      //if condition is met display message to player
                {
                    print("Yeah");
                    DialogText.text = "GREAT JOB!";
                    Wait();
                    StopCoroutine(GiveTask());
                    difficulty++;
                    NextLevel();
                }
                else
                {
                    print("Nope");
                    DialogText.text = "NOPE!";
                    Wait();
                    numberOTry++;
                    TryAgain();
                }
            }

        }

    }

    void GenerateTask() {       //generating random numbers for the task

        for (int i = 0; i < 3; i++) {

            int number = Random.Range(0, 20);

            taskSum += number;
            if (taskProduct == 0)
            {
                taskProduct += number;
            }
            else
            {
                taskProduct = taskProduct * number; 
            }
        }

    }
    IEnumerator GiveTask() {       //printing task to the screen

        foreach (char Character in sentences[Index].ToCharArray())
        {

            DialogText.text += Character;
            yield return new WaitForSeconds(textSpeed);

        }
        DialogText.text += " " + taskSum.ToString() + " and " + taskProduct.ToString();
    }
    IEnumerator Wait() {

        yield return new WaitForSeconds(wait);
    }
    IEnumerator Ending()
    {
        print("Call");
        foreach (char Character in sentences[Index].ToCharArray())
        {

            DialogText.text += Character;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    void StoreAnwser() {        //stroring input from player in public variable

        input = inputField.GetComponent<Text>().text;   
        anwsers = System.Array.ConvertAll(input.Split(' '), int.Parse); //breaking the string and sconverting members to integers then storing it in an array

        for (int index = 0; index < anwsers.Length; index++) {      //using a for loop to store the sum and product of the player input

            playerSum += anwsers[index];

            if (playerProduct == 0)         //adding the first value than * as much as there is in the array(looks horrible but scales)
            {
                playerProduct += anwsers[index]; 
            }
            else 
            {
                playerProduct = playerProduct * anwsers[index];
            }
        
        }
    }

    bool CheckAnwsers() {       //if codition is met returns a true value otherwise false

        //return (playerSum == taskSum && playerProduct == taskProduct);       //if the 2 values match that is a win
        return false;
    }
    void NextLevel() {

        input = string.Empty;
        DialogText.text = string.Empty;
        GenerateTask();
        StartCoroutine(GiveTask());
    
    }
    void TryAgain()
    {

        input = string.Empty;
        DialogText.text = string.Empty;
        StartCoroutine(GiveTask());

    }
}
