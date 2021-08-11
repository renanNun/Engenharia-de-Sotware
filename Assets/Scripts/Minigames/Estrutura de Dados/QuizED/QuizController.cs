using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{

    private QuizQuestion currentQuestion;
    public UIController uIController;

    // Start is called before the first frame update
    void Start()
    {
        QuestionCollection.LoadQuestions();
        this.currentQuestion = QuestionCollection.GetQuestion();
        ShowQuestion();
    }

    public void ShowQuestion() {
        uIController.SetupUIforQuestion(this.currentQuestion);
    }

    public void AnswerQuestion(int answerNumber) {
        bool isCorrect = answerNumber == this.currentQuestion.getCorrectAnswer();
        uIController.HandleSubmittedAnswer(isCorrect);
    }
    
}
