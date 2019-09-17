using Zenject;
using System.Collections;
using InputProviders;
using NUnit.Framework;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MoverTestZenject : ZenjectIntegrationTestFixture {
    private TestInputProvider testInputProvider;
    private GameObject targetGameObject;

    [SetUp]
    public void Init() {
        SceneManager.LoadScene("TestScene");
        testInputProvider = new TestInputProvider();
    }

    void CommonInstall() {
        PreInstall();
        Container.Bind<IInputProvider>().FromInstance(testInputProvider);

        PostInstall();
    }


    [TearDown]
    public void Finish() {
        testInputProvider.Reset();
        targetGameObject.transform.position = Vector3.zero;
    }

    private void InitLazy() {
        if (targetGameObject == null) {
            targetGameObject = GameObject.Find("Player");

            testInputProvider.Reset();
            targetGameObject.transform.position = Vector3.zero;
        }
    }

    [UnityTest]
    public IEnumerator MoveTest() {
        CommonInstall();

        InitLazy();

        // 前に進む
        testInputProvider.MoveDirection = Vector3.forward;

        yield return new WaitForSeconds(1);

        // 前進している
        Assert.True(targetGameObject.transform.position.z > 0);
    }


    [UnityTest]
    public IEnumerator DashTest() {
        CommonInstall();

        InitLazy();

        // 前に進む
        testInputProvider.MoveDirection = Vector3.forward;

        yield return new WaitForSeconds(1);

        // 通常移動で進んだ距離
        var normal = targetGameObject.transform.position.z;

        testInputProvider.Reset();
        targetGameObject.transform.position = Vector3.zero;
        yield return null;

        // ダッシュする
        testInputProvider.IsDash = true;
        testInputProvider.MoveDirection = Vector3.forward;

        yield return new WaitForSeconds(1);

        // ダッシュした方が遠くに移動できている
        Assert.True(targetGameObject.transform.position.z > normal);
    }

    [UnityTest]
    public IEnumerator JumpTest() {
        CommonInstall();

        InitLazy();

        // ジャンプする
        testInputProvider.IsJump = true;

        yield return new WaitForSeconds(1);

        // ジャンプできている
        Assert.True(targetGameObject.transform.position.y > 0);
    }
}
