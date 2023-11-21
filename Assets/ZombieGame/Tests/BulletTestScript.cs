using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ZombieGame;


public class BulletTestScript
{
    
    private bullet testBullet;
    
    // A Test behaves as an ordinary method
    [Test]
    public void BulletTestScriptSimplePasses()
    {
        testBullet = new bullet();
        
        Assert.IsNotNull(testBullet);
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BulletTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    
    [Test]
    public void AtLeastOnePaddleIsSuccesfullyCreated()
    {
        bullet paddles = new bullet();

        // Assert that the paddles object exists
        Assert.IsNotNull(paddles);
    }
    

    // [Test]
    // public void TwoPaddlesAreSuccesfullyCreated()
    // {
    //     bullet paddles = new bullet();
    //
    //     // Assert that the number of paddles equals 2
    //     Assert.AreEqual(2, paddles.transform);
    // }
}
