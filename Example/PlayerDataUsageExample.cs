using Mek.Models;
using UnityEngine;

namespace Mek.Examples
{
    public class PlayerDataUsageExample : MonoBehaviour
    {
        private void Awake()
        {
            ExamplePlayerData.Initialize();

            PrefsManager.Prefs[ExamplePrefKeys.ExampleInteger].Changed += OnExampleIntegerChanged;
            PrefsManager.Prefs[ExamplePrefKeys.ExampleClass].Changed += OnExampleClassChanged;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ExamplePlayerData.ExampleInteger++;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                var exampleObject = ExamplePlayerData.ExampleClass;
                exampleObject.Number++;
                ExamplePlayerData.ExampleClass = exampleObject;
            }
        }

        private void OnExampleIntegerChanged()
        {
            Debug.Log($"ExampleInteger Value changed = {ExamplePlayerData.ExampleInteger}");
        }
        
        private void OnExampleClassChanged()
        {
            Debug.Log($"ExampleClassChanged Value changed = {ExamplePlayerData.ExampleClass.Number}");
        }

    }
}
