using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class GameTest : MonoBehaviour
{
    PlayerData playerData;
    Enemy enemy;
    ScoreManager scoreManager;

    [Test]
    public void TestAddScore()
    {
        Assert.DoesNotThrow(scoreManager.AddScore);
    }

    [Test]
    public void TestReduceHealth()
    {
        Assert.DoesNotThrow(playerData.ReduceHealth);
    }

    [Test]
    public void TestEnemyHit()
    {
        Assert.DoesNotThrow(enemy.EnemyHit);
    }

    [Test]
    public void TestIsGameOver()
    {
        Assert.DoesNotThrow(playerData.PlayerDied);
    }
}
