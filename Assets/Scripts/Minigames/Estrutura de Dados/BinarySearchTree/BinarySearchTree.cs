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
        this.values = new List<int>(number_of_nodes);
        values.Add(0);
        for (var i = 1; i < number_of_nodes; i++) {
            var swap = Random.Range(0, i - 1);
            values.Add(values[swap]);
            values[swap] = i;
        }

        // Cria a arvore
        this.build_tree(values, number_of_nodes);

    }

    public void build_tree(List<int> values, int size) {

        for (int i = 1; i < size; i++) {
            this.root = this.insert_value(this.root, values[i]);
        }
    }

    public Node insert_value(Node node, int value) {
        if (node == null) {
            node = new Node(value);
        } 
        else if (value > node.value) {
            node.rightChild = this.insert_value(node.rightChild, value);
        }
        else {
            node.leftChild = this.insert_value(node.leftChild, value);
        }

        return node;

    }

}
