using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;

    public void LoadSceneAsync()
    {
        StartCoroutine(LoadSceneAsyncCoroutine());
    }

    private IEnumerator LoadSceneAsyncCoroutine()
    {
        // 開始異步加載場景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 當場景還沒加載完成時，顯示進度條
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // 異步加載的進度在0.9左右就完成了，這裡做了一個換算
            Debug.Log("Loading progress: " + progress);
            // 顯示進度條
            yield return null;
        }
    }
}
