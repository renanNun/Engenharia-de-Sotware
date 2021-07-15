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
        this.treeText[0].text = tree.root.value.ToString();
        this.treeText[1].text = tree.root.leftChild.value.ToString();
        this.treeText[2].text = tree.root.rightChild.value.ToString();

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
