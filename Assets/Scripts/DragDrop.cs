using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    [ShowInInspector] private Vector2 _startPos;

    [SerializeField] private Canvas _canvas;
    [SerializeField] Camera _cam;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] UseSkill summonBlueUnit;
    [SerializeField] ManaBar manaBar;

    public Vector3 pointerLocation;

    public static int skillIndex;

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
        _startPos = _rectTransform.anchoredPosition;
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

            if (gameObject.name == "SkillKnight")
            {
                if (manaBar.currentMana >= 1)
                {
                    skillIndex = 0;
                    summonBlueUnit.SpawnBlueUnit();
                }
            }

            if (gameObject.name == "SkillArcher")
            {
                if (manaBar.currentMana >= 3)
                {
                    skillIndex = 1;
                    summonBlueUnit.SpawnBlueUnit();
                }
            }

            if (gameObject.name == "SkillBird")
            {
                if (manaBar.currentMana >= 2)
                {
                    skillIndex = 2;
                    summonBlueUnit.SpawnBlueUnit();
                }
            }

            if (gameObject.name == "SkillPriest")
            {
                if (manaBar.currentMana >= 2)
                {
                    skillIndex = 3;
                    summonBlueUnit.SpawnBlueUnit();
                }
            }
        }
        _rectTransform.anchoredPosition = _startPos;
    }
}