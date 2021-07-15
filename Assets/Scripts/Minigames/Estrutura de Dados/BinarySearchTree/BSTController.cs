using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BSTController : MonoBehaviour
{

    private BinarySearchTree tree;
    public TreeUIController uIController;
    public int questionValue;
    public List<int> correctAnswer;
    public List<int> answerList;
    public GameObject cursor;
    public int actualNode;

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

        this.correctAnswer = tree.GetPath(this.questionValue);

        this.actualNode = 0;
        this.answerList = new List<int>();

        ShowQuestion();
    }

    public void ShowQuestion() {
        uIController.SetupUIforQuestion(this.tree, this.questionValue);
    }

    public void AnswerQuestion(int answerNumber) {
        
        this.answerList.Add(answerNumber);

        if (answerNumber < 0) {
            this.actualNode = 2*this.actualNode+1;
        } else {
            this.actualNode = 2*this.actualNode+2;
        }

        var node = uIController.treeText[this.actualNode].transform.parent;
        cursor.transform.position = node.transform.position;

        if (answerList.Count >= 2) {
            bool isCorrect = Enumerable.SequenceEqual(this.correctAnswer, this.answerList);
            uIController.HandleSubmittedAnswer(isCorrect);
        }

    }

}
