using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestMainPage
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("BinarySearchTree");
    }

    [UnityTest]
    public IEnumerator TestButtonRender()
    {
        var buttons = Object.FindObjectsOfType<Button>();

        Assert.IsNotNull(buttons);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestAllButtonRender()
    {
        var buttons = Object.FindObjectsOfType<Button>();

        Assert.AreEqual(buttons.Length, 4);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestStartButtonText()
    {
        var startButton = GameObject.FindGameObjectsWithTag("StartText")[0];

        var text = startButton.GetComponentInChildren<Text>().text;

        Assert.AreEqual(text, "START");
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestLeaderboardButtonText()
    {
        var startButton = GameObject.FindGameObjectsWithTag("LeaderboardText")[0];

        var text = startButton.GetComponentInChildren<Text>().text;

        Assert.AreEqual(text, "LEADERBOARD");
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestStatsButtonText()
    {
        var startButton = GameObject.FindGameObjectsWithTag("StatsText")[0];

        var text = startButton.GetComponentInChildren<Text>().text;

        Assert.AreEqual(text, "STATS");
        yield return null;
    }

}
