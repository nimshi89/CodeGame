using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI DialogText;
    public string[] sentences;
    public float textSpeed = 0.05f;
    private int Index;

    void Start()
    {
        DialogText.text = string.Empty;
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (DialogText.text == sentences[Index]) {

                    NextSentence();
            }
            else {

                StopAllCoroutines();
                DialogText.text = sentences[Index];
                }
        }

    }
    void StartDialog() {

        Index = 0;
        StartCoroutine(WritingSentence());
    }

    void NextSentence() {

        if (Index < sentences.Length - 1)
        {
            Index++;
            DialogText.text = string.Empty;
            StartCoroutine(WritingSentence());

        }
        else {

            gameObject.SetActive(false);
        
        }
    
    }

    IEnumerator WritingSentence() {

        foreach (char Character in sentences[Index].ToCharArray()) {

            DialogText.text += Character;
            yield return new WaitForSeconds(textSpeed);
        
        }
        
    }
}
