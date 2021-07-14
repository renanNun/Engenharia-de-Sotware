using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TreeUIController : MonoBehaviour
{

    public List<Text> treeText;
    public List<Button> answerButtons;
    public curMinigameManager curMM;

    public void SetupUIforQuestion(Node root) {
        this.treeText[0].text = root.value.ToString();
        this.treeText[1].text = root.leftChild.value.ToString();
        this.treeText[2].text = root.rightChild.value.ToString();
    }

    public void HandleSubmittedAnswer(bool isCorrect) {
        ToggleAnswerButtons(false);
        // finaliza sessão com o resultado do quiz
        if (isCorrect) curMM.startVictory();
        else curMM.startLoss();
    }

    private void ToggleAnswerButtons(bool value) {
        for (int i = 0; i < answerButtons.Count; i++) {
            answerButtons[i].gameObject.SetActive(value);
        }
    }

}
