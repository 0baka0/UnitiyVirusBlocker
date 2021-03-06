using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStartupFramework;

public sealed class LoadingScreenInstance : ScreenInstance
{
    [SerializeField]
    private Image _ProgressbarImage;

    private void Start()
    {
        IEnumerator LoadNextScene()
        {
            AsyncOperation ao = UnityEngine.SceneManagement.
                SceneManager.LoadSceneAsync(SceneManager.Instance.nextSceneName);
            ao.allowSceneActivation = false;
            /// - AsyncOperation : 비동기적인 연산을 위한 코루틴을 제공하는 클래스

            // 씬 변경 작업이 모두 끝났을 경우 실행할 내용을 정의합니다.
            ao.completed += (asyncoperation) => 
            GameManager.GetGameManager().SceneChanged(SceneManager.Instance.nextSceneName);

            float targetProgressFill = 0.9f;

            yield return new WaitForSeconds(1.0f);

            while(true)
            {
                yield return null;

                targetProgressFill = (ao.progress < 0.9f) ? ao.progress : 1.0f;

                _ProgressbarImage.fillAmount =
                    Mathf.MoveTowards(
                        _ProgressbarImage.fillAmount,
                        targetProgressFill,
                        3.0f * Time.deltaTime);

                if(Mathf.Approximately(_ProgressbarImage.fillAmount, 1.0f))
                {
                    yield return new WaitForSeconds(2.0f);
                    ao.allowSceneActivation = true;
                    break;
                }
            }
        }

        _ProgressbarImage.fillAmount = 0.0f;
        StartCoroutine(LoadNextScene());
    }
}
