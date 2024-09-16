using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnnulusGames.SceneSystem;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string StartSceneKey = "startup";
    
    private SceneContainer _container = null;
    // Start is called before the first frame update
    async void Start()
    {
        _container = SceneContainer.Create();
        
        _container.Register("startup","startup");
        _container.Register("fall","QNQ_Fall");
        var handle = _container.Build();
        
        // 完了を待機
        await handle.ToUniTask();
        
        await ResetScene();
    }

    public async UniTask ResetScene()
    {
        await ClearStack();
        await PushScene(StartSceneKey);
    }
    
    public async UniTask PushScene(string key)
    {
        // シーンをロード
        var handle = _container.Push(key);
        await handle.ToUniTask();
        
        // ライティングのためアクティブシーンを切り替える
        var count = SceneManager.sceneCount;
        var current = SceneManager.GetActiveScene();
        for (int i = 0; i < count; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.isLoaded && scene != current)
            {
                SceneManager.SetActiveScene(scene);   
            }
        }
    }

    public async UniTask PopScene()
    {
        var handle = _container.Pop();
        await handle.ToUniTask();
    }

    public async UniTask ClearStack()
    {
        if(_container.StackCount == 0) return; 
        var handle = _container.ClearStack();
        await handle.ToUniTask();
    }
}
