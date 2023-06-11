namespace Utils
{
    using UnityEngine;

    public class SafeArea : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Rect          safeArea;
        private Vector2       minAnchor;
        private Vector2       maxAnchor;

        private void Awake()
        {
            this.rectTransform = this.GetComponent<RectTransform>();
            this.safeArea      = Screen.safeArea;
            this.minAnchor     = this.safeArea.position;
            this.maxAnchor     = this.minAnchor + this.safeArea.size;

            this.minAnchor.x /= Screen.width;
            this.minAnchor.y /= Screen.height;
            this.maxAnchor.x /= Screen.width;
            this.maxAnchor.y /= Screen.height;

            this.rectTransform.anchorMin = this.minAnchor;
            this.rectTransform.anchorMax = this.maxAnchor;
        }
    }
}