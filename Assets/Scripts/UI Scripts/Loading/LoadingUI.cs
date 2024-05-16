using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] Image filledLoadingBarIMG;
    [SerializeField] float maxTimeToLoad = 3f;
    void Start()
    {
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(LoadSceneSingleton.Instance.SceneName);
        asyncOperation.allowSceneActivation = false;

        float timePass = 0f;

        bool canActive = false;

        while (canActive == false)
        {
            filledLoadingBarIMG.fillAmount = asyncOperation.progress;

            timePass += Time.deltaTime;

            if (asyncOperation.progress >= 0.9f)
            {
                filledLoadingBarIMG.fillAmount = 1f;

                canActive = true;
            }

            yield return null;
        }

        float timeLeft = Mathf.Clamp(maxTimeToLoad - timePass, 1f, maxTimeToLoad - timePass);

        yield return new WaitForSeconds(timeLeft);

        asyncOperation.allowSceneActivation = true;

        yield break;
    }
}
