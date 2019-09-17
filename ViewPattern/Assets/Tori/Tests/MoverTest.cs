using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using InputProviders;
using Player;
using UnityEngine.SceneManagement;

public class MoverTest {
    private GameObject targetGameObject;
    private TestInputProvider testInputProvider;

    [SetUp]
    public void Init() {
        testInputProvider = new TestInputProvider();
        SceneManager.LoadScene("TestScene");
    }

    [TearDown]
    public void Finish() {
        testInputProvider.Reset();
        targetGameObject.transform.position = Vector3.zero;
    }

    private void InitLazy() {
        if (targetGameObject == null) {
            targetGameObject = GameObject.Find("Player");
            var mover = targetGameObject.GetComponent<Mover>();
            mover.SetInputProvider(testInputProvider);

            testInputProvider.Reset();
            targetGameObject.transform.position = Vector3.zero;
        }
    }

    [UnityTest]
    public IEnumerator 移動できる() {
        InitLazy();

        // 前に進む
        testInputProvider.MoveDirection = Vector3.forward;

        yield return new WaitForSeconds(1);

        // 前進している
        Assert.True(targetGameObject.transform.position.z > 0);
    }


    [UnityTest]
    public IEnumerator ダッシュできる() {
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
    public IEnumerator ジャンプできる() {
        InitLazy();

        // ジャンプする
        testInputProvider.IsJump = true;

        yield return new WaitForSeconds(1);

        // ジャンプできている
        Assert.True(targetGameObject.transform.position.y > 0);
    }
}
