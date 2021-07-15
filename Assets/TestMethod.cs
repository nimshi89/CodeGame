using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TestMethod : MonoBehaviour
{
    // Start is called before the first frame update
    private string input;
    private int[] anwsers;
    private int taskSum;
    private int taskProduct;
    private int playerSum;
    private int playerProduct;
    public TextMeshProUGUI DialogText;
    public GameObject inputField;

    void Start()
    {
        GenerateTask();
        GiveTask();     //staring the ghame with printing out the first task
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {             //check for condition(player hits enter)


            StoreAnwser();      //first store the anwser


            if (CheckAnwsers() == true)      //if condition is met display message to player
            {

                DialogText.text = "GREAT JOB!";


            }
            else { DialogText.text = "NOPE!"; }

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
    void GiveTask() {       //printing task to the screen

        DialogText.text = "Welcome!\nThe first task will be to find the three numbers that have the sum and product of " + taskSum.ToString() + " and " + taskProduct.ToString();
    
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

        if (playerSum == taskSum && playerProduct == taskProduct)       //if the 2 values match that is a win
        {
            return true;
        }
        else 
        {
            return false; 
        }
    
    
    }
   
}
