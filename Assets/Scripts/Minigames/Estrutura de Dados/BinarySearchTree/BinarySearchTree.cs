using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BinarySearchTree
{
    public Node root = null;
    public List<int> values;

    public BinarySearchTree(int number_of_nodes) {

        // Cria uma lista de valores até o tamanho passado
        // e embaralha os valores para evitar a criação de uma arvore degenerada
        // this.values = new List<int>();
        // values.Add(2);
        // for (var i = 1; i <= number_of_nodes; i++) {
        //     var swap = Random.Range(0, i - 1);
        //     values.Add(values[swap]);
        //     values[swap] = i+2;
        // }
        this.values = new List<int>(new int[] { 10, 5, 14, 2, 7, 11, 18 } );

        // Cria a arvore
        this.BuildTree(values, number_of_nodes);

    }

    public void BuildTree(List<int> values, int size) {

        for (int i = 0; i < size; i++) {
            this.InsertValue(values[i]);
        }
    }

    private void PreOrderRec(Node root, List<int> preorder_values) {
        if (root == null) {
            return;
        }

        preorder_values.Add(root.value);
        this.PreOrderRec(root.rightChild, preorder_values);
        this.PreOrderRec(root.leftChild, preorder_values);

    }

    public List<int> PreOrderValues() {
        List<int> preorder_values = new List<int>();

        this.PreOrderRec(this.root, preorder_values);

        return preorder_values;
    }

    public void InsertValue(int value) {
        this.root = this.InsertValue(this.root, value);
    }

    public Node InsertValue(Node node, int value) {
        if (node == null) {
            node = new Node(value);
        } 
        else if (value > node.value) {
            node.rightChild = this.InsertValue(node.rightChild, value);
        }
        else {
            node.leftChild = this.InsertValue(node.leftChild, value);
        }

        return node;

    }

}
