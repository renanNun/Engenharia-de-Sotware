using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text questionText;
    public List<Button> answerButtons;
    public curMinigameManager curMM;

    public void SetupUIforQuestion(QuizQuestion question) {
        this.questionText.text = question.getQuestion();

        List<string> answers = question.getAnswers();

        for (int i = 0; i < answers.Count; i++) {
            answerButtons[i].GetComponentInChildren<Text>().text = answers[i];
            answerButtons[i].gameObject.SetActive(true);
        }
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
