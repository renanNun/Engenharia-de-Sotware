using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{

    private QuizQuestion currentQuestion;
    private UIController uIController;

    // Start is called before the first frame update
    void Start()
    {
        ShowQuestion();
    }

    public void ShowQuestion() {
        uIController.SetupUIforQuestion(currentQuestion);
    }

    public void AnswerQuestion(int answerNumber) {
        bool isCorrect = answerNumber == currentQuestion.getCorrectAnswer();
        uIController.HandleSubmittedAnswer(isCorrect);
    }
    
}
