using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSTController : MonoBehaviour
{

    private BinarySearchTree tree;
    public TreeUIController uIController;
    public int questionValue;
    public int correctAnswer;

    // Start is called before the first frame update
    void Start()
    {
        this.tree = new BinarySearchTree(7);

        Node root = this.tree.root;
        // evita filhos serem nulos
        if (root.leftChild == null) {
            tree.InsertValue(root.value-1);
        }
        if (root.rightChild == null) {
            tree.InsertValue(root.value+1);
        }

        // pergunta algum valor não presente na visualização
        int rand_pos = Random.Range(3, tree.values.Count-1);
        this.questionValue = tree.values[rand_pos];

        if (root.value > this.questionValue) {
            this.correctAnswer = -1;
        } else {
            this.correctAnswer = 1;
        }

        ShowQuestion();
    }

    public void ShowQuestion() {
        uIController.SetupUIforQuestion(this.tree, this.questionValue);
    }

    public void AnswerQuestion(int answerNumber) {
        bool isCorrect = answerNumber == this.correctAnswer;
        uIController.HandleSubmittedAnswer(isCorrect);
    }

}
