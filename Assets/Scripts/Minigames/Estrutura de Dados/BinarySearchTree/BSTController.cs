using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSTController : MonoBehaviour
{

    private BinarySearchTree tree;
    public TreeUIController uIController;

    // Start is called before the first frame update
    void Start()
    {
        this.tree = new BinarySearchTree(3);

        ShowQuestion();
    }

    public void ShowQuestion() {
        uIController.SetupUIforQuestion(this.tree.root);
    }

    // public void AnswerQuestion(int answerNumber) {
    //     bool isCorrect = answerNumber == this.currentQuestion.getCorrectAnswer();
    //     uIController.HandleSubmittedAnswer(isCorrect);
    // }
    
}
