using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.Framework.Systems.SaveLoad;
using R3;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Helpers.Debug
{
    public class FPSDisplay : MonoBehaviour
    {
        [RequiredField] public TMP_Text fpsText;
        [RequiredField] public TMP_Text saveTimeText;
        private float _deltaTime;
        private ISaveLoadSystem _saveLoadSystem;

        private readonly CompositeDisposable _disposables = new();

        [Inject]
        private void Construct(ISaveLoadSystem saveLoadSystem)
        {
            _saveLoadSystem = saveLoadSystem;
        }

        private void Awake()
        {
            _saveLoadSystem.LastSaveTime.Subscribe(x => saveTimeText.text = $"{x} ms").AddTo(_disposables);
        }

        private void Update()
        {
            _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
            var fps = 1.0f / _deltaTime;
            fpsText.text = $"{fps:0.}";
        }

        private void OnDestroy() => _disposables.Dispose();
    }
}
