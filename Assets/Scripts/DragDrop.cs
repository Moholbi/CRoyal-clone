using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    [SerializeField] private Canvas _canvas;

    [SerializeField] Camera _cam;
    [SerializeField] LayerMask _layerMask;

    [SerializeField] UseSkill summonKnight;
    [SerializeField] UseSkill summonMeteor;
    [SerializeField] UseSkill summonBird;

    [SerializeField] ManaBar manaBar;

    public Vector3 pointerLocation;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _layerMask))
        {
            pointerLocation = raycastHit.point;
            //Debug.Log(pointerLocation);

            if (this.gameObject.name == "SkillKnight")
            {
                this.gameObject.transform.position = new Vector3(300, 65, 0);

                if (manaBar.currentMana >= 1)
                {
                    summonKnight.SummonKnight();
                }
            }

            if (this.gameObject.name == "SkillArcher")
            {
                this.gameObject.transform.position = new Vector3(400, 65, 0);

                if (manaBar.currentMana >= 3)
                {
                    summonMeteor.SummonMeteor();
                }
            }

            if (this.gameObject.name == "SkillBird")
            {
                this.gameObject.transform.position = new Vector3(500, 65, 0);

                if (manaBar.currentMana >= 2)
                {
                    summonBird.SummonBird();
                }
            }
        }
    }
}