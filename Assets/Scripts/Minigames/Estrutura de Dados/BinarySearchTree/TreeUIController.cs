using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeUIController : MonoBehaviour
{

    public List<Text> treeText;
    public Text questionText;
    public Button leftButton, rightButton;
    public curMinigameManager curMM;

    public void SetupUIforQuestion(BinarySearchTree tree, int questionValue) {

        List<int> tree_values = tree.values;
        int size = this.treeText.Count;
        for (int i = 0; i < size; i++) {
            this.treeText[i].text = tree_values[i].ToString();
            if (2*i+1 < size) this.treeText[2*i+1].text = tree_values[2*i+1].ToString();
            if (2*i+2 < size) this.treeText[2*i+2].text = tree_values[2*i+2].ToString();
        }

        questionText.text = "Encontre o valor " + questionValue;
        
        ToggleAnswerButtons(true);
    }

    public void HandleSubmittedAnswer(bool isCorrect) {
        ToggleAnswerButtons(false);
        // finaliza sessão com o resultado do quiz
        if (isCorrect) curMM.startVictory();
        else curMM.startLoss();
    }

    private void ToggleAnswerButtons(bool value) {
        leftButton.gameObject.SetActive(value);
        rightButton.gameObject.SetActive(value);
    }
    

}
