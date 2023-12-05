using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ZombieGame;

public class KeyboardControlTests
{
    private KeyboardControl KBC;
    // A Test behaves as an ordinary method
    
    [Test]
    public void  KeyboardControimplePasses()
    {
        KBC = new KeyboardControl();
        Assert.IsNull(KBC);
    }

    [Test]
    public void movePowerTestsSimplePasses()
    {
        KBC = new KeyboardControl();
        
        Assert.AreEqual(KBC.movePower ,10);
        // Use the Assert class to test conditions
    }
    [Test]
    public void jumpPowerTestsSimplePasses()
    {
        KBC = new KeyboardControl();
        Assert.AreEqual(KBC.jumpPower ,15);
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator KeyboardControlTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
