using System.Collections;
using TMPro;
using UnityEngine;
using System;

namespace NearAnxiety {
    namespace Enemy {
        public class EnemySetText : MonoBehaviour {
            public string Text;
            private string fullText = "";
            private bool isMultiText = false;
            private int multiTextCounter = 0;

            void DecreaseHP(string HPAndMaxHP) {
                if (!isMultiText) return;

                Int32.TryParse(HPAndMaxHP.Split(","[0])[0], out int HP);
                Int32.TryParse(HPAndMaxHP.Split(","[0])[1], out int MaxHP);

                if (HP <= 0) return;

                string[] texts = fullText.Split(","[0]);
                int dividen = MaxHP / texts.Length;
                Debug.Log(HP);
                if (HP % dividen == 0) {
                    multiTextCounter++;
                    Text = fullText.Split(","[0])[multiTextCounter];
                    displayText();
                }
            }

            private void displayText() {
                GameObject textGameObject = gameObject.transform.Find("Vibrate On Hit/Canvas/Text").gameObject;
                TextMeshProUGUI textmeshPro = textGameObject.GetComponent<TextMeshProUGUI>();

                textmeshPro.SetText(Text);
                setBoxCollider();
            }

            void SetText(string argText) {
                fullText = argText;

                if (argText.Contains(",")) {
                    isMultiText = true;
                    Text = argText.Split(","[0])[multiTextCounter];
                } else {
                    Text = argText;
                }

                displayText();
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
