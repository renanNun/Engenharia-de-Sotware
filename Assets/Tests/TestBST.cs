using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestBST
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("BinarySearchTree");
    }

    // 1
    [UnityTest]
    public IEnumerator TestIfHasButtons()
    {
        var buttons = Object.FindObjectsOfType<Button>();

        Assert.IsNotNull(buttons);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestLeftButtonText()
    {
        var leftButton = Object.FindObjectsOfType<Button>()[1];

        var text = leftButton.GetComponentInChildren<Text>().text;

        Assert.AreEqual(text, "Left");
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestRightButtonText()
    {
        var rightButton = Object.FindObjectsOfType<Button>()[0];

        var text = rightButton.GetComponentInChildren<Text>().text;

        Assert.AreEqual(text, "Right");
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestNumberOfNodes()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");

        Assert.AreEqual(nodes.Length, 7);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestIfNodesAreNotNegativeValues()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");

        foreach (GameObject node in nodes)
        {
            var value = node.GetComponentInChildren<Text>().text;
            Assert.IsTrue(int.Parse(value) > 0);
        }

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestQuestionNumber()
    {
        var question = GameObject.FindGameObjectWithTag("Question");

        string[] subs = question.GetComponentInChildren<Text>().text.Split(' ');

        Assert.IsTrue(int.Parse(subs[3]) > 0);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestCursorMovement()
    {
        var cursor = GameObject.Find("Cursor");
        var initialPos = cursor.transform.position;

        var rightButton = Object.FindObjectsOfType<Button>()[0];
        rightButton.onClick.Invoke();
        var movedPos = cursor.transform.position;

        Assert.AreNotEqual(initialPos, movedPos);
        yield return null;
    }

}
