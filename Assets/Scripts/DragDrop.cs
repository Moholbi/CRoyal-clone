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
    [SerializeField] UseSkill summonGiant;

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
            Debug.Log(pointerLocation);

            if (this.gameObject.name == "SkillKnight")
            {
                summonKnight.SummonKnight();
                this.gameObject.transform.position = new Vector3(300, 50, 0);
            }

            if (this.gameObject.name == "SkillMeteor")
            {
                summonMeteor.SummonMeteor();
                this.gameObject.transform.position = new Vector3(400, 50, 0);
            }

            if (this.gameObject.name == "SkillGiant")
            {
                summonGiant.SummonGiant();
                this.gameObject.transform.position = new Vector3(500, 50, 0);
            }
        }
    }
}