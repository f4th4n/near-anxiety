using System.Collections;
using TMPro;
using UnityEngine;


namespace NearAnxiety {
    namespace Enemy {
        public class EnemySetText : MonoBehaviour {
            void SetText(string text) {
                GameObject textGameObject = gameObject.transform.Find("Vibrate On Hit/Canvas/Text").gameObject;
                TextMeshProUGUI textmeshPro = textGameObject.GetComponent<TextMeshProUGUI>();
                
                textmeshPro.SetText(text);
                setBoxCollider();
            }

            void setBoxCollider() {
                BoxCollider2D boxCollider = transform.GetComponent<BoxCollider2D>();
                GameObject textGameObject = gameObject.transform.Find("Vibrate On Hit/Canvas/Text").gameObject;
                TextMeshProUGUI textmeshPro = textGameObject.GetComponent<TextMeshProUGUI>();
                RectTransform rectTransform = textGameObject.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(textmeshPro.preferredWidth, rectTransform.sizeDelta.y);
                float boxColliderX = rectTransform.rect.width * rectTransform.localScale.x;
                float boxColliderY = rectTransform.rect.height * rectTransform.localScale.y;

                boxCollider.size = new Vector2(boxColliderX, boxColliderY);
                boxCollider.offset = new Vector2(0, 0);
            }
        }
    }
}
