using UnityEngine;
using UnityEngine.SceneManagement;

namespace Item
{
    public class SceneChangeButton : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
        [SerializeField] private float sceneChangeSec = 1f;

        private void SceneChange()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Button"))
            {
                Invoke("SceneChange",sceneChangeSec);
            }
        }
    }
}